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
    public partial class UserForm : Form
    {
        private List<Entity.User> users = new List<Entity.User>();
        private UserModalForm _userModalForm;
        private IFlurlClient flurlClient;
        public UserForm(UserModalForm userModalForm, IFlurlClientCache clients)
        {
            InitializeComponent();

            _userModalForm = userModalForm;
            this.flurlClient = clients.Get("Cli");
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var r = flurlClient.Request("User", "GetUsers")
                .AppendQueryParam("isEnable", !checkBox1.Checked).GetJsonAsync<Resp<List<User>>>().Result;
            users = r.data;
            userBindingSource.DataSource = users;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;

            button5.Enabled = !users[rowIndex].Enable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _userModalForm.SetMode(Common.Mode.ModeAdd);
            _userModalForm.ShowDialog(this);
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var userID = users[rowIndex].Id.ToString();
            _userModalForm.SetMode(Common.Mode.ModeEdit, userID);
            _userModalForm.ShowDialog(this);

            RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var user = users[rowIndex];
            if (MessageBox.Show("是否删除用户?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                user.Enable = false;
                if (flurlClient.Request("User","DelUser")
                    .AppendQueryParam("userId", user.Id.ToString())
                    .PostUrlEncodedAsync(new { userId = user.Id.ToString()}.ToQueryString())
                    .ReceiveJson<Resp<bool>>().Result.code == 200)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var user = users[rowIndex];
            if (MessageBox.Show("是否停用用户, 停用后需要重新审核方可登录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                user.Enable = false;
                if (flurlClient.Request("User","Update")
                    .PostJsonAsync(user).ReceiveJson<Resp<User>>().Result.code == 200)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("停用失败");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var curRow = this.dataGridView1.CurrentRow;
            if (curRow == null)
                return;
            var rowIndex = curRow.Index;
            var user = users[rowIndex];
            if (user.Enable)
            {
                MessageBox.Show("无需审核");
                return;
            }

            if (MessageBox.Show("是否审核用户, 审核后方可登录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (flurlClient.Request("User","Approve")
                                    .AppendQueryParam("userId", user.Id.ToString())
                    .PostUrlEncodedAsync(new { userId=user.Id.ToString()})
                    .ReceiveJson<Resp<bool>>().Result.code == 200)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("审核失败");
                }
            }
        }


    }


}
