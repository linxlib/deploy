using DeployClient.Common;
using DeployClient.Modals;
using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;

using Masuit.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeployClient
{
    public partial class ServiceModalForm : Form
    {


        private Mode _mode = Mode.ModeAdd;
        private string _serviceId = "";
        private Service service;
        private RemoteDirectorySelectModalForm remoteDialog;
        private AvailableServiceForm availableServiceForm;
        private IFlurlClient flurlClient;
        public ServiceModalForm( RemoteDirectorySelectModalForm remoteDialog, AvailableServiceForm availableServiceForm,IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
            this.remoteDialog = remoteDialog;
            this.availableServiceForm = availableServiceForm;
        }

        public void SetMode(Mode mode, string serviceId = "")
        {
            _mode = mode;
            _serviceId = serviceId;
        }

        private void RefreshData()
        {
            if (_mode == Mode.ModeAdd)
            {
                service = new Service();
                service.InDate = DateTime.Now;
                service.ServiceType = ServiceType.IIS;
                service.Name = "新服务";
                service.ServiceName = "新服务的服务名";
                serviceBindingSource.DataSource = service;

            }
            else
            {
                var re1 = flurlClient.Request("Service", "Get").AppendQueryParam("serviceId", _serviceId)
                    .GetJsonAsync<Resp<Service>>().Result;
                if (re1.code == 200)
                {
                    service = re1.data;
                }
                serviceBindingSource.DataSource = service;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_mode == Mode.ModeAdd)
            {
                var re = flurlClient.Request("Service", "AddService")
                    .PostJsonAsync(service).ReceiveJson<Resp<Service>>().Result;
                if (re.code == 200)
                {
                    MessageBox.Show("添加成功");
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show(re.message);
                }
            }
            else
            {
                var re = flurlClient.Request("Service", "UpdateService")
                    .PostJsonAsync(service).ReceiveJson<Resp<bool>>().Result;
                if (re.code == 200)
                {
                    MessageBox.Show("修改成功");
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show(re.message);
                }
            }
        }

        private void ServiceModalForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ServiceModalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            service = null;
            serviceBindingSource.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
            if (remoteDialog.ShowDialog() == DialogResult.OK)
            {
                service.RealPath = remoteDialog.dir;
                textBox4.Text = remoteDialog.dir;
            }

        }



        private void button4_ClickAsync(object sender, EventArgs e)
        {
            availableServiceForm.ShowDialog();
            if (availableServiceForm.currentSelected != null)
            {

                textBox1.Text = availableServiceForm.currentSelected.Name;

                textBox2.Text = availableServiceForm.currentSelected.ServiceName;
                textBox3.Text = availableServiceForm.currentSelected.Arg;
                textBox4.Text = availableServiceForm.currentSelected.RealPath;
                service.ListenUrl = availableServiceForm.currentSelected.ListenUrl;

            }

        }
    }
}
