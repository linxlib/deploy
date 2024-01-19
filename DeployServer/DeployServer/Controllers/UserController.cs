using Entity;
using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using LiteDB;
using Masuit.Tools;
using Masuit.Tools.Security;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DeployServer.Middleware;

namespace DeployServer.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Auth]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILiteCollection<User> collection;
        private LiteDatabase database;
        private const string secretKey = "fghjkloiuytrefghj";

        public UserController(LiteDatabase lite)
        {
            collection = lite.GetCollection<User>();
            database = lite;
        }
        /// <summary>
        /// 添加用户-由管理员添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<User>> Add(User user)
        {
            if (!user.Email.MatchEmail().isMatch)
            {
                return Resp.Fail<User>("邮箱不正确");
            }
            var exist = collection.Exists(e => e.Name == user.Name || e.Email == user.Email);
            if (exist)
            {
                return Resp.Fail<User>("用户或邮箱已存在");

            }
            user.Enable = true;
            collection.Insert(user);
            return Resp.OK(collection.FindOne(e=>e.Id==user.Id));
        }
        /// <summary>
        /// 审核通过用户注册
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> Approve(string userId)
        {
            var user = collection.FindOne(e => e.Id == userId.ToObjectId());
            if (user.Enable)
            {
                return Resp.Fail<bool>("用户已经审核");
            }
            user.Enable = true;
            user.EditDate = DateTime.Now;
            return Resp.OK(collection.Update(user));

        }
        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="userId"></param>
        [HttpPost]
        public Task<Resp<bool>> DelUser(string userId)
        {
            return Resp.OK(collection.DeleteMany(e => e.Id == userId.ToObjectId()) > 0);
        }
        /// <summary>
        /// 获取头像(Base64)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<string> GetAvatar(string id)
        {
           var info = database.FileStorage.FindById(id).OpenRead();
            
           using (var reader = new MemoryStream())
            {
                info.CopyTo(reader);
               // reader.SaveFile("3.png");
                reader.Seek(0, SeekOrigin.Begin);
                return Task.FromResult(Convert.ToBase64String(reader.GetBuffer()));
            }
         
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<User>> GetUser(string userId)
        {
            return Resp.OK(collection.FindOne(e=>e.Id==userId.ToObjectId()));
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="isEnable">启用</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<Resp<List<User>>> GetUsers(bool isEnable)
        {
            if (!isEnable)
            {
                return Resp.OK(collection.Find(e => e.Enable == isEnable).ToList());
            } else
            {
                return Resp.OK(collection.FindAll().ToList());
            }
            
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">可以为用户名或者邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        [NonAuth]
        public Task<Resp<LoginToken>> Login(string username, string password)
        {
            var user = collection.FindOne(e => e.Name == username || e.Email == username);
            if (user==null)
            {
                return Resp.Fail<LoginToken>("用户不存在");
            }
            if (!user.Enable)
            {
                return Resp.Fail<LoginToken>("用户已停用, 请联系管理员操作");
            }
            if (user.Password==password.MDString("deploy"))
            {
                user.LastLoginTime = DateTime.Now;
                collection.Update(user);
                byte[] key = Encoding.UTF8.GetBytes(secretKey);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();//序列化
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加解密
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var sessionId = Guid.NewGuid().ToString();
                var token = encoder.Encode(new LoginToken
                {
                    Username = user.Name,
                    Avatar = user.Avatar,
                    UserId = user.Id.ToString(),
                    IsAdmin = user.IsAdmin,
                    Expire = DateTime.Now.AddHours(8),
                    sessionId = sessionId
                },key);
                return Resp.OK(new LoginToken
                {
                    Token = token,
                    Username = user.Name,
                    Avatar = user.Avatar,
                    UserId = user.Id.ToString(),
                    IsAdmin =user.IsAdmin,
                    sessionId = sessionId,
                    Expire = DateTime.Now.AddHours(8),
                });
            }
            else
            {
                return Resp.Fail<LoginToken>("登录失败, 用户名或密码不正确");
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        [NonAuth]
        public Task<Resp<bool>> Register([Required]string name, [Required]string email, [Required]string password)
        {
            if (!email.MatchEmail().isMatch)
            {
                return Resp.Fail<bool>("邮箱不正确");
            }
            var exist = collection.Exists(e => e.Name == name || e.Email == email);
            if (exist)
            {
                return Resp.Fail<bool>("用户或邮箱已存在");

            }
            var isadmin = false;
            if (collection.Count()==0)
            {
                isadmin = true;
            }
            collection.Insert(new User
            {
                Name = name,
                Email = email,
                Password = password.MDString("deploy"),
                Avatar = "",
                IsAdmin = isadmin,
                Enable = isadmin,
                InDate = DateTime.Now,

            });
            return Resp.OK(true);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<User>> Update(User user)
        {
            //TODO: 管理员的信息只能自己修改
            var myuser = collection.FindOne(e => e.Id == user.Id);

            if (myuser.IsAdmin && !this.IsAdmin())
            {
                return Resp.Fail<User>("修改失败: 你不能修改管理员信息");
            }
            if (collection.Update(user))
            {
                return Resp.OK(collection.FindOne(e => e.Id == user.Id));
            }
            else
            {
                return Resp.Fail<User>("修改失败");
            }
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="file">文件流</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<string>> UploadAvatar([FromForm] IFormFile file, [FromForm] string fileName)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var id = Guid.NewGuid().ToString();
                var info = database.FileStorage.Upload(id, fileName, ms);
                return Resp.OK(info.Id);
            }
        }
    }
}
