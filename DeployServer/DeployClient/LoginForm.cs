using DeployClient.Common;
using Entity;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Masuit.Tools.Security;
using Microsoft.Win32;
using System.Diagnostics;
namespace DeployClient
{
    public partial class LoginForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly IAuthTokenStore authTokenStore;
        private readonly RegisterForm _registerForm;
        private Entity.Version newVersion;
        private IFlurlClient flurlClient;
        private IFlurlClientCache clients;
        private Options _options;
        public LoginForm(RegisterForm registerForm, MainForm mainForm, IAuthTokenStore authTokenStore, Options options,IFlurlClientCache clients)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.authTokenStore = authTokenStore;
            _registerForm = registerForm;
            _options = options;
            flurlClient = clients.Get("Cli");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            _registerForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginResult = flurlClient.Request("User", "Login")
                .AppendQueryParam("username",textBox1.Text)
                .AppendQueryParam("password",textBox2.Text)
                .PostAsync()
                .ReceiveJson<Resp<LoginToken>>()
                .Result;
            if (loginResult.code != 200)
            {
                MessageBox.Show(loginResult.message);
                return;
            }
            if (loginResult.data.Username == textBox1.Text)
            {
                Save(loginResult.data);
                this.Hide();
                var result = _mainForm.ShowDialog();
                if (result == DialogResult.TryAgain)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void Save(LoginToken token)
        {
            if (checkBox1.Checked)
            {
                _options.From().AutoLogin = true;
                _options.From().User = textBox1.Text;
                _options.From().Password = textBox2.Text.DesEncrypt("linxtest");
                _options.Save();
            }
            else
            {
                _options.From().AutoLogin = false ;
                _options.From().User = "";
                _options.From().Password = "";
                _options.Save();
            }
            authTokenStore.SetAuthToken(token);
            flurlClient.WithHeader("x-token", token.Token);
        }
        private void RegisteUrlProtocol(bool useParam)
        {
            var protocolName = "deploy";
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(protocolName, true);
            RegistryKey shell, open, command;
            string cmd;
            var path =Application.ExecutablePath;

            key = Registry.ClassesRoot.CreateSubKey(protocolName);
            key.SetValue("", "Url:" + protocolName + " Protocol", RegistryValueKind.String);
            key.SetValue("URL Protocol", path, RegistryValueKind.String);

            key.CreateSubKey("DefaultIcon").SetValue("", path + ",1");

            shell = key.CreateSubKey("shell");
            open = shell.CreateSubKey("open");
            command = open.CreateSubKey("command");
            cmd = "\"" + path + "\"";
            if (useParam)
                cmd += " \"%1\"";
            command.SetValue("", cmd);
        }
        private async void LoginForm_Shown(object sender, EventArgs e)
        {
            RegisteUrlProtocol(true);
            //检查是否可以连接到服务器
            try
            {
                var ok = flurlClient.Request("Server", "Health")
                .GetStringAsync()
                .Result;
                if (ok == "ok")
                {
                    this.Text += "  服务器连接正常";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接到服务器失败, 请配置服务器API地址:{ex.Message}");
                return;
            }

            //检查更新
            var hasNewVersion = false;
            var versionReqult = await flurlClient.Request("Version", "CheckUpdate")
                .AppendQueryParam("version", VersionConst.VersionInt)
                .GetJsonAsync<Resp<Entity.Version>>();
            if (versionReqult.code!=200)
            {
                linkLabel1.Text = "已是最新版本";
                linkLabel1.Enabled = false;
                
            }
            else
            {
                var newVersion = versionReqult.data;
                linkLabel1.Text = $"发现新版本v{newVersion.VersionInt}, 点击更新";
                this.newVersion = newVersion;
                linkLabel1.Enabled = true;
                hasNewVersion = true;
                linkLabel1.MouseClick += LinkLabel1_MouseClick;
                return;
            }

            //自动登录
            if (_options.From().AutoLogin)
            {
                textBox1.Text = _options.From().User;
                textBox2.Text = _options.From().Password.DesDecrypt("linxtest");
                checkBox1.Checked = _options.From().AutoLogin;
                if (!hasNewVersion)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        button1.PerformClick();
                    }
                }
               
            }
        }

        private void LinkLabel1_MouseClick(object? sender, MouseEventArgs e)
        {
            var dr = MessageBox.Show($"新版本 {newVersion.Name} {newVersion.VersionInt}\n\n{newVersion.ReleaseLog}\n\n是否更新?", "版本更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.OK)
            {
                var url = _options.currentUrl + $"/Version/DownloadUpdate?id={newVersion.DownloadID}";
                doUpgradeVersion(url);
            }
        }

        private void doUpgradeVersion(string url)
        {
            var pid = Process.GetCurrentProcess().Id;
            var exe = "DeployClient.exe";
            var p = new Process();
            p.StartInfo.FileName = "update.exe";
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Arguments = $"{pid} {exe} {url}";
            p.Start();

        }

        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            InputBoxItem[] items = new InputBoxItem[] {
                new InputBoxItem("服务器地址",  _options.currentUrl)
            };
            InputBox input = InputBox.Show("配置服务器", items, InputBoxButtons.OKCancel);
            if (input.Result == InputBoxResult.OK)
            {
                var url = input.Items["服务器地址"].Trim();
                try
                {
                    var u = new Uri(url);
                    _options.FromFirst().BaseApi = u.AbsoluteUri ;
                    _options.Save();
                    MessageBox.Show("配置成功, 请重新打开部署工具");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("无效的服务器地址");
                    _options.FromFirst().BaseApi = "http://124.223.93.57:5000/api";
                    return;
                }



            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
