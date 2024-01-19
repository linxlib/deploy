using DeployServer.Middleware;
using DeployServer.Queues;
using Entity;

using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace DeployServer.Controllers
{
    /// <summary>
    /// 版本
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Auth]
    [ApiController]
    public class VersionController : ControllerBase
    {

        private LiteDatabase database;
        private ILiteCollection<Entity.Version> _versions;

        public VersionController(LiteDatabase lite)
        {
            database = lite;
            _versions = lite.GetCollection<Entity.Version>();
        }
        /// <summary>
        /// 添加版本
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> AddVersion(Entity.Version version)
        {
           version.InDate = DateTime.Now;
            version.IsDelete = false;
            version.IsPublish = false;
            _versions.Insert(version);
            return Resp.OK(true);
        }
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="version">当前版本</param>
        /// <returns></returns>
        [HttpGet]
        [NonAuth]
        public Task<Resp<Entity.Version>> CheckUpdate(int version)
        {
            var newest = _versions.Find(e=>e.IsPublish==true).OrderByDescending(e => e.VersionInt).FirstOrDefault();
            if (newest != null)
            {
                if (newest.VersionInt > version)
                {
                    return Resp.OK(newest);
                } else
                {
                    return Resp.Fail<Entity.Version>("");
                }
                
            } else
            {
                return Resp.Fail<Entity.Version>("");
            }
        }
        /// <summary>
        /// 下载更新包
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [NonAuth]
        public Task<FileContentResult> DownloadUpdate(string id)
        {
            var info = database.FileStorage.FindById(id);
            if (info == null)
            {
                throw new Exception("file not found");
            }

            using (var reader = new MemoryStream())
            {
                info.CopyTo(reader);
                reader.Position = 0;
                var bs = reader.ToArray();
                return Task.FromResult( File(bs, "application/zip","update.zip"));
            }
        }
        [HttpGet]
        public Task<Resp<Entity.Version>> GetVersion(string id)
        {
            return Resp.OK( _versions.FindOne(e=>e.Id==id.ToObjectId()));
        }

        /// <summary>
        /// 版本列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<Resp<List<Entity.Version>>> GetVersions()
        {
            return Resp.OK(_versions.FindAll().OrderByDescending(e=>e.VersionInt).ToList());
        }
        /// <summary>
        /// 发布版本
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public Task<Resp<bool>> Publish(Entity.Version version, [FromServices] IMessageQueue<string, MsgType, object> queue)
        {
            version.IsPublish = true;
            version.PublishTime = DateTime.Now;
            
            _versions.Update(version);
            //queue.EnQueue("", MsgType.VERSION, new UpgradeMessage
            //{
            //    time = version.PublishTime,
            //    updateLog = version.ReleaseLog,
            //    version = version.VersionInt.ToString(),
            //    downloadId = version.DownloadID
            //});
            //service.SendNewVersionAsync(new UpgradeMessage
            //{
            //    time = version.PublishTime,
            //    updateLog = version.ReleaseLog,
            //    version = version.VersionInt.ToString(),
            //    downloadId = version.DownloadID
            //});
            return Resp.OK(true);

        }
        /// <summary>
        /// 删除版本
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> RemoveVersion(string id)
        {
            var thisversion = _versions.FindOne(e=>e.Id == id.ToObjectId());
            var fileId = thisversion.DownloadID;
            if (fileId != null) {
                database.FileStorage.Delete(fileId);
            }
            _versions.DeleteMany(e=>e.Id == thisversion.Id);
            return Resp.OK(true);
        }
        /// <summary>
        /// 删除更新包
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> RemoveVersionFile(string id)
        {
            database.FileStorage.Delete(id);
            return Resp.OK(true);
        }

        /// <summary>
        /// 更新版本
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<bool>> UpdateVersion(Entity.Version version)
        {
            return Resp.OK(_versions.Update(version));
        }
        /// <summary>
        /// 上传更新包
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<string>> UploadUpdateFile([FromForm] IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var id = Guid.NewGuid().ToString();
                var info = database.FileStorage.Upload(id, id, ms);
                return Resp.OK(info.Id);
            }
        }
        /// <summary>
        /// 上传最新版本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Resp<string>> UploadLastestFile([FromForm] IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var id = "latestversion";
                var info = database.FileStorage.Upload(id, "latest.zip", ms);
                return Resp.OK(info.Id);
            }
        }
        /// <summary>
        /// 下载最新版本
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [NonAuth]
        public Task<FileContentResult> DownloadLatest()
        {
            var info = database.FileStorage.FindById("latestversion");
            if (info == null)
            {
                throw new Exception("file not found");
            }

            using (var reader = new MemoryStream())
            {
                info.CopyTo(reader);
                reader.Position = 0;
                var bs = reader.ToArray();
                return Task.FromResult(File(bs, "application/zip", "latestversion.zip"));
            }
        }

    }
}
