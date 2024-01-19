using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
using Linx.Http;
using Masuit.Tools.Files;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeployClient.Modals
{
    public partial class UpdateModalForm : Form
    {
        private Entity.Version version;
        private IFlurlClient flurlClient;
        public UpdateModalForm(IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
        }

        private async void RefreshDataAsync()
        {
            version = new Entity.Version
            {
                Name = "vx.x.x",
                VersionInt = 0,
                ReleaseLog = "",
                InDate = DateTime.Now,
                IsPublish = false,
                IsDelete = false,

            };
            versionBindingSource.DataSource = version;
        }

        private void UpdateModalForm_Shown(object sender, EventArgs e)
        {
            RefreshDataAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var result0 = await flurlClient.Request("Version", "CheckUpdate")
                .AppendQueryParam("version", -1)
                .GetJsonAsync<Resp<Entity.Version>>();
            if (result0.code == 200 )
            {
                var newst = result0.data;
                if (newst.VersionInt >= version.VersionInt)
                {
                    MessageBox.Show($"当前最新版本[{newst.VersionInt}], 请设置为比该版本更大");
                    return;
                }

            }
            if (string.IsNullOrEmpty(version.DownloadID))
            {
                MessageBox.Show("请上传更新包");
                return;
            }
            if (string.IsNullOrEmpty(version.Name))
            {
                MessageBox.Show("请输入版本");
                return;
            }
            if (string.IsNullOrEmpty(version.ReleaseLog))
            {
                MessageBox.Show("请输入更新日志");
                return;
            }

            var result = await flurlClient.Request("Version", "AddVersion").PostJsonAsync(version).ReceiveJson<Resp<bool>>();
            if (result.code == 200)
            {
                MessageBox.Show("添加成功, 请返回发布版本");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            else
            {
                MessageBox.Show(result.message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( version.DownloadID))
            {
                await flurlClient.Request("Version", "RemoveVersionFile")
                                    .AppendQueryParam("id", version.DownloadID)
                    .PostUrlEncodedAsync(new { id = version.DownloadID }.ToQueryString());
                label10.Text = "0";
                label11.Text = "";
                label12.Text = "";
            }

            openFileDialog1.Filter = "更新包|*.zip";
            openFileDialog1.Title = "选择更新包";
            openFileDialog1.FileName = "update.zip";
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (var fs = File.OpenRead(openFileDialog1.FileName))
                {
                    var hash = fs.GetFileSha1();
                    fs.Seek(0, SeekOrigin.Begin);
                    var size = fs.Length;
                   
                        var re = await flurlClient.Request("Version", "UploadUpdateFile").PostMultipartAsync(mp =>
                        {
                            mp.AddFile("file", fs, "file");
                            mp.AddString("hash", hash);
                            mp.AddString("size", size.ToString());
                        }).ReceiveJson<Resp<string>>();
                        if (re.code == 200)
                        {
                            label10.Text = size.ToString();
                            label11.Text = hash;
                            label12.Text = re.data;

                            versionBindingSource.DataSource = version;

                        }

                    

                }
                }
        }
    }
}
