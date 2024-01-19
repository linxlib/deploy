using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
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
    public partial class UpdateLatestModalForm : Form
    {

        private IFlurlClient flurlClient;
        public UpdateLatestModalForm( IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
        }

        private async void RefreshDataAsync()
        {
        }

        private void UpdateLatestModalForm_Shown(object sender, EventArgs e)
        {
            RefreshDataAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
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
                

                        var re = await flurlClient.Request("Version", "UploadLastestFile")
                            .PostMultipartAsync(mp =>
                            {
                                mp.AddFile("file", fs, "update.zip");
                                mp.AddString("hash", hash);
                                mp.AddString("size", size.ToString());
                            }).ReceiveJson<Resp<string>>();
                        if (re.code == 200)
                        {
                            label10.Text = size.ToString();
                            label11.Text = hash;
                            label12.Text = re.data;
                        }

                    

                }
                }
        }
    }
}
