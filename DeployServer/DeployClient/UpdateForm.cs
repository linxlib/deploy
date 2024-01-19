using DeployClient.Common;
using DeployClient.Modals;
using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
using Linx.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeployClient
{
    public partial class UpdateForm : Form
    {
        private List<Entity.Version> versions;
        private UpdateModalForm updateModalForm;
        private UpdateLatestModalForm updateLatestModalForm;
        private IFlurlClient flurlClient;
        public UpdateForm( UpdateModalForm updateModalForm, UpdateLatestModalForm updateLatestModalForm,IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
            this.updateModalForm = updateModalForm;
            this.updateLatestModalForm = updateLatestModalForm;
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            RefreshDataAsync();
        }
        private async void RefreshDataAsync()
        {
            var n =  await flurlClient.Request("Version", "CheckUpdate")
                .AppendQueryParam("version", -1)
                .GetJsonAsync<Resp<Entity.Version>>();
            if (n.code == 200)
            {
                var newest = n.data;
                label2.Text = newest.VersionInt.ToString();
            }


            var list = await flurlClient.Request("Version", "GetVersions")
                .GetJsonAsync<Resp<List<Entity.Version>>>();
            versions = list.data;
            versionBindingSource.DataSource = versions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (updateModalForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataAsync();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var selectedVersion = versions[rowIndex];
            await flurlClient.Request("Version", "RemoveVersion")
                .AppendQueryParam("id", selectedVersion.Id.ToString())
                .PostUrlEncodedAsync(new { id = selectedVersion.Id.ToString() }.ToQueryString()).ReceiveString();
            RefreshDataAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var selectedVersion = versions[rowIndex];
            MessageBox.Show(selectedVersion.ReleaseLog);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var selectedVersion = versions[rowIndex];
            selectedVersion.IsPublish = true;
            selectedVersion.PublishTime = DateTime.Now;

            var re = await flurlClient.Request("Version", "Publish")
                .PostJsonAsync(selectedVersion).ReceiveJson<Resp<bool>>();
            if (re.code == 200)
            {
                MessageBox.Show("发布成功");
                RefreshDataAsync();
            }
            else
            {
                MessageBox.Show(re.message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateLatestModalForm.ShowDialog();
        }
    }
}
