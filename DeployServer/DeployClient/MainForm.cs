using DeployClient.Common;
using DeployClient.Modals;
using Entity;
using Ext;
using Flurl.Http;
using Flurl.Http.Configuration;
using Linx.Helper;
using Linx.Http;
using Masuit.Tools;
using Masuit.Tools.DateTimeExt;
using Masuit.Tools.Files;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.WebSockets;
using WSRPC.WebSocketRPC;

namespace DeployClient
{
    public partial class MainForm : Form
    {
        private LoginToken token;
        private readonly UserForm userForm;
        private readonly DeployTaskForm deployTaskForm;
        private readonly ServerForm serverForm;
        private readonly UpdateForm updateForm;
        private IAuthTokenStore authTokenStore;
        private readonly RemoteDirectorySelectModalForm remoteDirectorySelectModalForm;
        private Options _options;
        private IFlurlClient flurlClient;
        private Dictionary<string, string> lastDeployPathMap = new Dictionary<string, string>();

        public MainForm(UserForm userForm, DeployTaskForm deployTaskForm, ServerForm serverForm, UpdateForm updateForm, IAuthTokenStore authTokenStore, RemoteDirectorySelectModalForm remoteDirectorySelectModalForm, Options options, IFlurlClientCache clients)
        {
            InitializeComponent();

            this.userForm = userForm;
            this.deployTaskForm = deployTaskForm;
            this.serverForm = serverForm;
            this.updateForm = updateForm;
            this.authTokenStore = authTokenStore;
            this.remoteDirectorySelectModalForm = remoteDirectorySelectModalForm;
            _options = options;
            flurlClient = clients.Get("Cli");
        }




        private void 部署日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deployTaskForm.ShowDialog(this);
        }
        private void RefreshData()
        {
            pictureBox1.Image = null;
            token = authTokenStore.GetAuthLoginToken();
            linkLabel1.Visible = token.IsAdmin;
            toolStripStatusLabel1.Text = token.Username;
            toolStripStatusLabel2.Text = token.IsAdmin ? "管理员" : "用户";
            toolStripStatusLabel3.Text = DateTime.Now.ToString("f");
            toolStripStatusLabel4.Text = "未连接";
            var wsUrl = _options.currentUrl.Replace("http://", "ws://").Replace("https://", "wss://").Replace("/api", "/ws") + "/heartbeat";
            toolStripStatusLabel5.Text = wsUrl;
            var wsUrl1 = _options.currentUrl.Replace("http://", "ws://").Replace("https://", "wss://").Replace("/api", "/ws") + "/message";
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(_options.From().LastDeployType);
            //textBox1.Text = Properties.Settings.Default.LastDeployPath;
            var cts = new CancellationTokenSource();
            try
            {
                Task.Run(() =>
                {

                    Client.ConnectAsync(wsUrl, cts.Token, c =>
                    {
                        c.OnReceive += OnHeartBeat;
                        c.OnOpen += OnHeartBeatOpen;
                        c.OnClose += OnHeartBeatClose;
                    }, true, true, 5, options =>
                    {
                        options.SetRequestHeader("x-token", authTokenStore.GetAuthToken());
                        options.SetRequestHeader("x-session", authTokenStore.GetSession());
                    });
                    Client.ConnectAsync(wsUrl1, CancellationToken.None, c =>
                    {
                        c.OnReceive += OnMessage;
                        c.OnOpen += OnHeartBeatOpen;
                        c.OnClose += OnHeartBeatClose;
                    }, true, true, 5, options =>
                    {
                        options.SetRequestHeader("x-token", authTokenStore.GetAuthToken());
                        options.SetRequestHeader("x-session", authTokenStore.GetSession());
                    });
                });

            }
            catch (Exception)
            {


            }

            var re1 = flurlClient.Request("Service", "GetByServer").AppendQueryParam("serverId", "")
                .GetJsonAsync<Resp<List<Service>>>().Result;
            if (re1.code == 200)
            {
                serviceBindingSource.DataSource = re1.data;

                if (_options.From().MainSelectedService != "")
                {
                    if (re1.data.Where(e => e.Id == _options.From().MainSelectedService.ToGuid()).Count() >= 1)
                    {
                        listBox2.SuspendLayout();
                        listBox2.SelectedValue = _options.From().MainSelectedService.ToGuid();
                        listBox2.Refresh();
                        try
                        {
                            if (!string.IsNullOrEmpty(_options.From().LastDeployPath))
                            {
                                lastDeployPathMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(_options.From().LastDeployPath);
                            }

                            if (lastDeployPathMap != null && lastDeployPathMap.ContainsKey(_options.From().MainSelectedService))
                            {
                                textBox1.Text = lastDeployPathMap.GetValueOrDefault(_options.From().MainSelectedService);
                            }
                            else
                            {
                                textBox1.Text = "";
                            }
                        }
                        catch (Exception)
                        {
                            textBox1.Text = "";
                        }


                    }
                }
            }

            if (!string.IsNullOrEmpty(token.Avatar))
            {
                var re2 = flurlClient.Request("User", "GetAvatar").AppendQueryParam("id", token.Avatar)
                    .GetStringAsync().Result;
                var aa = Convert.FromBase64String(re2);
                using (var ms = new MemoryStream(aa))
                {
                    pictureBox1.Image = Bitmap.FromStream(ms);
                }
            }

        }
        public class MyMessage
        {
            public string msg { get; set; }
        }
        private Task OnMessage(string arg)
        {
            var msg = JsonConvert.DeserializeObject<MyMessage>(arg);
            MessageBox.Show(msg.msg);
            return Task.CompletedTask;
        }

        public class HeartBeatMessage
        {
            public string name { get; set; }
            public DateTime data { get; set; }
            public bool isAdmin { get; set; }
        }
        private Task OnHeartBeat(string arg)
        {
            var msg = JsonConvert.DeserializeObject<HeartBeatMessage>(arg);
            toolStripStatusLabel3.Text = msg.data.ToChineseDateTime();
            toolStripStatusLabel1.Text = msg.name;
            toolStripStatusLabel2.Text = msg.isAdmin ? "管理员" : "开发者";
            return Task.CompletedTask;
        }

        private Task OnHeartBeatError(Exception exception)
        {
            MessageBox.Show(exception.Message);
            return Task.CompletedTask;
        }

        private Task OnHeartBeatClose(WebSocketCloseStatus arg1, string arg2)
        {
            return Task.Run(() =>
            {
                toolStripStatusLabel4.Text = "未连接";
                toolStripStatusLabel4.BackColor = Color.Red;
            });
        }

        private Task OnHeartBeatOpen()
        {

            return Task.Run(() =>
            {
                toolStripStatusLabel4.Text = "已连接";
                toolStripStatusLabel4.BackColor = Color.Green;
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userForm.ShowDialog(this);
            RefreshData();
        }

        private void 服务管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serverForm.ShowDialog(this);
            RefreshData();
        }

        private void 版本更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateForm.ShowDialog(this);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.TryAgain)
            {
                Application.Exit();
            }
            else
            {

            }

        }

        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.TryAgain;
            Close();

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            linkLabel1.ContextMenuStrip.Show(linkLabel1, 0, 0);
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                _options.From().MainSelectedService = listBox2.SelectedValue.ToString();
                _options.Save();

                if (lastDeployPathMap != null && lastDeployPathMap.ContainsKey(_options.From().MainSelectedService))
                {
                    textBox1.Text = lastDeployPathMap.GetValueOrDefault(_options.From().MainSelectedService);
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private async void button2_Click(object sender, EventArgs e)
        {
            var msg = "请确认部署以下文件:\n";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    msg += $"\n{textBox1.Text}/*.*";
                    break;
                case 1:
                    var sel = textBox1.Text.Split("|");
                    sel.ForEach(e =>
                    {
                        msg += e;
                    });

                    break;
                case 2:
                    msg += $"\n压缩包: {textBox1.Text}";
                    break;
                default:

                    break;
            }
            msg += $"\n↓\n{listBox2.Text}";
            if (MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            button2.Text = "压缩中...";
            button2.Enabled = false;
            if (comboBox1.SelectedIndex >= 0)
            {
                lastDeployPathMap.AddOrUpdate(_options.From().MainSelectedService, textBox1.Text, textBox1.Text);

                _options.From().LastDeployType = comboBox1.SelectedItem.ToString();
                _options.From().LastDeployPath = JsonConvert.SerializeObject(lastDeployPathMap);
                _options.Save();
            }
            var tmp = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "tmp");
            Directory.CreateDirectory(tmp);
            var tmpZip = Path.Join(tmp, DateTime.Now.GetTotalMilliseconds().ToString() + ".zip");
            var z = new ZipHelper();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    await z.CreateZipFromDirectory(textBox1.Text.Trim(), tmpZip);
                    break;
                case 1:
                    var sel = textBox1.Text.Split("|");
                    await z.CreateZipFromFiles(sel.ToList(), tmpZip);
                    break;
                case 2:
                    File.Copy(textBox1.Text.Trim(), tmpZip);
                    break;
                default:

                    break;
            }
            var a = stopwatch.ElapsedMilliseconds;
            button2.Text = "部署中...";
            using (FileStream fs = File.OpenRead(tmpZip))
            {
                var hash = fs.GetFileSha1();
                fs.Seek(0, SeekOrigin.Begin);
                var size = fs.Length;


                try
                {
                    var re = await flurlClient.Request("Deploy", "Deploy").PostMultipartAsync(mp =>
                    {
                        mp.AddFile("file", fs, "file");
                        mp.AddString("hash", hash);
                        mp.AddString("size", size.ToString());
                        mp.AddString("serviceId", listBox2.SelectedValue.ToString());
                    }).ReceiveJson<Resp<string>>();
                    if (re.code == 200)
                    {
                        var b = stopwatch.ElapsedMilliseconds - a;
                        MessageBox.Show($"部署成功 \n压缩耗时: {a}ms\n上传部署耗时: {b}ms");
                    }
                    else
                    {
                        MessageBox.Show($"部署失败:{re.message}");
                    }
                }
                catch (FlurlHttpException ex)
                {

                    var response = ex.GetResponseStringAsync().Result;
                    var res = $@"请求失败: /Deploy/Deploy
请求返回: {response}(如果这里为空, 则没有请求到目标服务)
状态码: {ex.StatusCode}
{ex.Message}
{ex.StackTrace}
";
                    throw new Exception(res);
                }



                File.Delete(tmpZip);
                button2.Text = "部署";
                button2.Enabled = true;
            }

        }

        private void serviceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                var statusResult = flurlClient.Request("Service", "ServiceStatus")
                    .AppendQueryParam("serviceId", listBox2.SelectedValue.ToString())
                    .GetJsonAsync<Resp<ServiceStatus>>().Result;
                if (statusResult.code == 200)
                {
                    updateServiceStatus(statusResult.data.Status);
                }
                else
                {
                    label17.Text = "异常";
                    label17.ForeColor = Color.DarkRed;
                    MessageBox.Show("获取服务状态, 远程服务器返回:\r\n" + statusResult.ex.Join("\r\n"));
                }

            }
            else
            {
                label17.Text = "";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    folderBrowserDialog1.Description = "选择项目发布目录";
                    folderBrowserDialog1.InitialDirectory = "C:\\";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = folderBrowserDialog1.SelectedPath;
                    }
                    break;
                case 1:
                    openFileDialog1.Title = "选择要部署的多个文件";
                    openFileDialog1.InitialDirectory = "C:\\";
                    openFileDialog1.Multiselect = true;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = openFileDialog1.FileNames.Join("|");
                    }
                    break;
                case 2:
                    openFileDialog1.Title = "选择项目打包压缩包";
                    openFileDialog1.InitialDirectory = "C:\\";
                    openFileDialog1.Multiselect = false;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = openFileDialog1.FileName;
                    }
                    break;
                default:

                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var c = listBox2.SelectedValue.ToString();
            var re = flurlClient.Request("Service", "ServiceAction")
                .AppendQueryParam("serviceId", c)
                .AppendQueryParam("actionType", ActionType.ActionReboot)
                .PostUrlEncodedAsync(new { serviceId = c, actionType = ActionType.ActionReboot }.ToQueryString())
                .ReceiveJson<Resp<ServiceStatus>>().Result;
            updateServiceStatus(re.data.Status);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var c = listBox2.SelectedValue.ToString();
            var re = flurlClient.Request("Service", "ServiceAction")
                                .AppendQueryParam("serviceId", c)
                .AppendQueryParam("actionType", ActionType.ActionStop)
                .PostUrlEncodedAsync(new { serviceId = c, actionType = ActionType.ActionStop }.ToQueryString())
                .ReceiveJson<Resp<ServiceStatus>>().Result;
            updateServiceStatus(re.data.Status);
        }
        private void updateServiceStatus(Status status)
        {
            switch (status)
            {
                case Status.Running:
                    label17.Text = "运行中";
                    label17.ForeColor = Color.Green;
                    break;
                case Status.Stoped:
                    label17.Text = "已停止";
                    label17.ForeColor = Color.Red;
                    break;
                case Status.NotFound:
                    label17.Text = "未找到";
                    label17.ForeColor = Color.DarkRed;
                    break;
                default:
                    label17.Text = "异常";
                    label17.ForeColor = Color.DarkRed;
                    break;
            }

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Text = $"部署工具客户端 v{VersionConst.VersionInt} @linx";
            RefreshData();
        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private async void button5_Click(object sender, EventArgs e)
        {
            var c = listBox2.SelectedValue.ToString();
            var svc = await flurlClient.Request("Service", "Get").AppendQueryParam("serviceId", c)
                .GetJsonAsync<Resp<Service>>();
            remoteDirectorySelectModalForm.SetOnlyView(svc.data.RealPath);
            remoteDirectorySelectModalForm.ShowDialog();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await flurlClient.Request("message").GetAsync();
        }
    }
}