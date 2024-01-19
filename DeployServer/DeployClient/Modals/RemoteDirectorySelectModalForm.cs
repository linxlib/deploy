using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;

using System;
using System.Collections;
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
    public partial class RemoteDirectorySelectModalForm : Form
    {
        private IFlurlClient flurlClient;
        private PathItem current;
        private string sub = "";
        private bool onlyView;
        public RemoteDirectorySelectModalForm(IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
        }
        public void SetOnlyView(string path)
        {
            sub = path;
            onlyView = true;
        }

        private void RemoteDirectorySelectModalForm_Shown(object sender, EventArgs e)
        {
            List<PathItem> list1;
            if (onlyView)
            {
                label2.Text = sub;
                list1 = GetSub(sub);
                button1.Enabled = false;
            }
            else
            {
                label2.Text = "C:\\";
                list1 = GetSub("C:\\");
                button1.Enabled = true;
            }
            list1.ForEach(item =>
            {
                treeView1.Nodes.Add(new TreeNode
                {
                    Text = item.Text,
                    Tag = item,
                    ImageIndex = item.PathType == ItemType.File ? 0 : 1,

                });
            });


        }
        private List<PathItem> GetSub(string root)
        {
            return flurlClient.Request("Service", "DirTree").AppendQueryParam("path", root).AppendQueryParam("serverId", "")
                .GetJsonAsync<Resp<List<PathItem>>>().Result.data;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            current = e.Node?.Tag as PathItem;
            label3.Text = current.FullPath;
            if (current.PathType == ItemType.Directory)
            {
                var children = GetSub(current.FullPath);
                children.ForEach(item =>
                {
                    e.Node.Nodes.Add(new TreeNode
                    {
                        Text = item.Text,
                        Tag = item,
                        ImageIndex = item.PathType == ItemType.File ? 0 : 1,
                    });
                });
                e.Node.Expand();

            }


        }
        public string dir { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (current.PathType == ItemType.File)
            {
                dir = Path.GetDirectoryName(current.FullPath);
            }
            else
            {
                dir = current.FullPath;
            }


            DialogResult = DialogResult.OK;

            Close();
        }

        private void RemoteDirectorySelectModalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            onlyView = false;
            sub = "";
        }
    }
}
