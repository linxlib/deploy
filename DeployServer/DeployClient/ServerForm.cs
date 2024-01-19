
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
    public partial class ServerForm : Form
    {
        private ServiceModalForm _serviceModalForm;
        private List<Server> servers;
        private List<Service> services;
        private Server curServer;
        private Service curService;
        private IFlurlClient flurlClient;
        public ServerForm( ServiceModalForm form2,IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
            _serviceModalForm = form2;
        }

        private void RefreshData()
        {


            ServerSelectedChanged();

        }
        private void ServerSelectedChanged()
        {
            var re1 = flurlClient.Request("Service", "GetByServer").AppendQueryParam("serverId", "")
                .GetJsonAsync<Resp<List<Service>>>().Result;
            if (re1.code == 200)
            {
                services = re1.data;
                serviceBindingSource.DataSource = services;

                ServiceSelectedChanged();
                return;
            }
            else
            {
                MessageBox.Show("获取服务列表失败");
                return;
            }
        }
        private void ServiceSelectedChanged()
        {
            if (listBox2.SelectedIndex < 0)
            {
                serviceBindingSource1.DataSource = new Service();
                return;
            }
            var selectedService = listBox2.SelectedValue as Guid?;
            curService = services.Where(e => e.Id == selectedService).FirstOrDefault();
            if (curService != null)
            {
                serviceBindingSource1.DataSource = curService;
                return;
            }
            return;


        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _serviceModalForm.SetMode(Common.Mode.ModeAdd);
            _serviceModalForm.ShowDialog();
            RefreshData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //_serviceModalForm = Activator.CreateInstance<ServiceModalForm>();
            _serviceModalForm.SetMode(Common.Mode.ModeEdit,  (listBox2.SelectedValue as Guid?).ToString());
            _serviceModalForm.ShowDialog();
            RefreshData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sel = this.listBox2.SelectedValue;
            if (sel == null)
                return;


            if (MessageBox.Show($"是否删除服务[{services.Where(e => e.Id == sel as Guid?).FirstOrDefault().Name}]?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (flurlClient.Request("Service","DeleteService")
                                    .AppendQueryParam("serviceId", (sel as Guid?).ToString())
                    .PostUrlEncodedAsync(new { serviceId = (sel as Guid?).ToString()}.ToQueryString())
                    .ReceiveJson<Resp<bool>>().Result.code==200)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceSelectedChanged();
        }
    }
}
