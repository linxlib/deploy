using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeployClient.Modals
{
    public partial class AvailableServiceForm : Form
    {
        private List<Service> iisServiceList;
        public Service? currentSelected;
        private IFlurlClient flurlClient;
        public AvailableServiceForm(IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
        }

        private async void AvailableServiceForm_Shown(object sender, EventArgs e)
        {
            var result = await flurlClient.Request("Service", "IISServiceList").GetJsonAsync<Resp<List<Service>>>();
            iisServiceList = result.data;

            serviceBindingSource.DataSource = iisServiceList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            if (index != -1)
            {
                currentSelected = iisServiceList[index];
            } else
            {
                currentSelected = null;
            }
            DialogResult = DialogResult.OK;
            Close();
      
        }
    }
}
