using Entity;
using Flurl.Http;
using Flurl.Http.Configuration;
using Linx.Http;


namespace DeployClient
{
    public partial class RegisterForm : Form
    {
        private IFlurlClient flurlClient;
        public RegisterForm(IFlurlClientCache clients)
        {
            InitializeComponent();
            this.flurlClient = clients.Get("Cli");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Length <= 0)
            //{
            //    MessageBox.Show("请输入用户名");
            //    return;
            //}
            //if (!textBox2.Text.MatchEmail().isMatch)
            //{
            //    MessageBox.Show( "邮箱格式错误");
            //    return;
            //}
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            var resp = flurlClient.Request("User", "Register")
                                .AppendQueryParam("name", textBox1.Text)
                .AppendQueryParam("email", textBox2.Text)
                                .AppendQueryParam("password", textBox3.Text)

                .PostUrlEncodedAsync(new { name = textBox1.Text, email = textBox2.Text, password = textBox3.Text }.ToQueryString())
                .ReceiveJson<Resp<bool>>().Result;
            if (resp.data)
            {
                MessageBox.Show("注册成功");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("注册失败");
                return;
            }
        }
    }
}
