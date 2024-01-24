using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployClient.Common
{
    public class Options : List<Option> 
    {
        private string filename = "app.json";
        private Options? options;
        public string currentUrl { get; set; }
        public Options()
        {
            
        }
        public Options(string filename) {
            if (!string.IsNullOrEmpty(filename))
            {
                this.filename = filename;
            }
          
            var jsonfile = AppDomain.CurrentDomain.BaseDirectory + "/" + this.filename;
            if (!File.Exists(jsonfile))
            {
                var o = new Option
                {
                    BaseApi = "http://124.223.93.57:5000/api",
                    AutoLogin = false,
                    User = "",
                    Password = "",
                    LastDeployPath = "",
                    LastDeployType = "",
                    LoginToken = "",
                    MainSelectedService = "",
                    SettingSelectedService = ""
                };
                var list = new Options { o };
                var aa =JsonConvert.SerializeObject(list);
                File.WriteAllText(jsonfile, aa );
            }
            var data = File.ReadAllText(jsonfile);
            options = JsonConvert.DeserializeObject<Options>(data);
            currentUrl = FirstUrl();
        }
        public string FirstUrl()
        {
            return this.options?.FirstOrDefault().BaseApi;
        }
        public Option? FromFirst()
        {
            var o = this.options?.FirstOrDefault();
            if (o == null)
            {
                o = new Option
                {
                    BaseApi = "http://124.223.93.57:5000/api",
                    AutoLogin = false,
                    User = "",
                    Password = "",
                    LastDeployPath = "",
                    LastDeployType = "",
                    LoginToken = "",
                    MainSelectedService = "",
                    SettingSelectedService = ""
                };
                if (this.options == null || this.options.Count <= 0)
                {
                    this.options = new Options("app.json");
                }
                this.options.Add(o);
                this.options.Save();
                return o;
            }
            else
            {
                return o;
            }

        }
  
        public Option? From()
        {
            var o = this.options?.Where(e => e.BaseApi == currentUrl).FirstOrDefault();
            if (o==null)
            {
                o = new Option
                {
                    BaseApi = currentUrl,
                    AutoLogin = false,
                    User = "",
                    Password = "",
                    LastDeployPath = "",
                    LastDeployType = "",
                    LoginToken = "",
                    MainSelectedService = "",
                    SettingSelectedService = ""
                };
                if (this.options==null || this.options.Count<=0)
                {
                    this.options = new Options("app.json");
                }
                this.options.Add(o);
                this.options.Save();
                return o;
            } else
            {
                return o;
            }
            
        }
        
        public void Save() 
        {
            var text = JsonConvert.SerializeObject(this.options,Formatting.Indented);
            var jsonfile = AppDomain.CurrentDomain.BaseDirectory + "/" + this.filename;
            File.WriteAllText(jsonfile, text);
        }
    
    }

    public class Option
    {
        /// <summary>
        /// api地址
        /// </summary>
        public string BaseApi { get; set; }
        /// <summary>
        /// 上次部署路径
        /// </summary>
        public string LastDeployPath { get; set; }
        /// <summary>
        /// 上次部署类型
        /// </summary>
        public string LastDeployType { get; set; }
        /// <summary>
        /// 登录token
        /// </summary>
        public string LoginToken { get; set; }
        /// <summary>
        /// 上次选择的服务
        /// </summary>
        public string MainSelectedService { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 设置页面选择的服务
        /// </summary>
        public string SettingSelectedService { get; set; }
        /// <summary>
        /// 是否自动登录
        /// </summary>
        public bool AutoLogin { get; set; }
    }
}
