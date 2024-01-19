using DeployClient.Common;
using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
using Masuit.Tools;
using Masuit.Tools.Security;


namespace DeployClient
{
    public partial class UserModalForm : Form
    {
        private Mode _mode = Mode.ModeAdd;
        private string _userId = string.Empty;
        private Entity.User _user;
        private IFlurlClient flurlClient;
        public UserModalForm(IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
            
        }
        public void SetMode(Mode mode, string userId = "")
        {
            _mode = mode;
            _userId = userId;
        }


        public void RefreshData()
        {
            pictureBox1.Image = null;
            if (_mode == Mode.ModeEdit)
            {
                var r = flurlClient.Request("User","GetUser").AppendQueryParam("userId", _userId).GetJsonAsync<Resp<Entity.User>>().Result;
                _user = r.data;
                button3.Enabled = true;
                button3.Text = "修改密码";
                if (!string.IsNullOrEmpty(_user.Avatar))
                {
                    try
                    {
                        var re1 = flurlClient.Request("User", "GetAvatar").AppendQueryParam("id", _user.Avatar)
                    .GetStringAsync().Result;
                        var aa = Convert.FromBase64String(re1);
                        using (var ms = new MemoryStream(aa))
                        {
                            pictureBox1.Image = Bitmap.FromStream(ms);
                        }
                    }
                    catch(Exception)
                    {

                    }
                    
                }
            }
            else
            {
                _user = new Entity.User();
                _user.InDate = DateTime.Now;
                _user.IsAdmin = false;
                _user.Enable = true;
                _user.Password = "123456".MDString("deploy");
                button3.Enabled = false;
                button3.Text = "默认密码";
            }
            bindingSource1.DataSource = _user;
        }

        private void UserModalForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_mode == Mode.ModeEdit)
            {
                var re = flurlClient.Request("User", "Update")
                    .PostJsonAsync(_user).ReceiveJson<Resp<Entity.User>>().Result;
                if (re.code == 200)
                {
                    MessageBox.Show("修改成功");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("修改失败:" + re.message);
                }
            }
            else
            {
                var r = flurlClient.Request("User", "Add")
                    .PostJsonAsync(_user).ReceiveJson<Resp<Entity.User>>().Result;
                if ( r.code== 200)
                {
                    MessageBox.Show("添加成功");
                    Close();
                    return;
                } else
                {
                    MessageBox.Show($"{r.ToJsonString()}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            InputBoxItem[] items = new InputBoxItem[] {
                new InputBoxItem("新密码", true)
            };
            InputBox input = InputBox.Show("修改密码", items, InputBoxButtons.OKCancel);
            if (input.Result == InputBoxResult.OK)
            {
                _user.Password = input.Items["新密码"].MDString("deploy");
                _user.EditDate = DateTime.Now;
                var re = flurlClient.Request("User", "Update")
                    .PostJsonAsync(_user).ReceiveJson<Resp<Entity.User>>().Result;
                if (re.code == 200)
                {
                    MessageBox.Show("修改成功");
                    RefreshData();
                    return;
                }
                else
                {
                    MessageBox.Show(re.message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //上传头像
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = File.OpenRead(openFileDialog1.FileName))
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fs))
                        {
                            var bs = binaryReader.ReadBytes((int)fs.Length);

                            var re = flurlClient.Request("User", "UploadAvatar")
                                .PostMultipartAsync(mp =>
                                {
                                    mp.AddFile("file", fs, "file");
                                    mp.AddString("fileName", Path.GetFileName(openFileDialog1.FileName));
                                }).ReceiveJson<Resp<string>>().Result;
                            var id = re.data;
                            _user.Avatar = id;
                            var re1 = flurlClient.Request("User", "GetAvatar").AppendQueryParam("id", id)
                    .GetStringAsync().Result;
                            var aa = Convert.FromBase64String(re1);
                            using (var ms = new MemoryStream(aa))
                            {
                                
                                pictureBox1.Image = Bitmap.FromStream(ms);
                            }


                        }
                    }
                }
                catch (Exception)
                {


                }
               


            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _user.Avatar = "";
            pictureBox1.Image = null;
        }
    }
}
