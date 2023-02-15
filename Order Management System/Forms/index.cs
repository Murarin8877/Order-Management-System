using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Grocery_store_management.Forms;

namespace Grocery_store_management
{
    public partial class index : Form
    {
        string str_i;
        private Menu anotherForm;
        public static string data = "";
        
        public index()
        {
            InitializeComponent();
            anotherForm = new Menu();
        }
        
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;" + "Integrated Security=True");

        public string Str_i { get => tb_account.Text; set => str_i = tb_account.Text; }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_password.PasswordChar = '*';
            tb_password.MaxLength = 14;
            tb_account.Focus();
            data = tb_account.Text;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            string useraccount, userpassword;
            useraccount = tb_account.Text;
            userpassword = tb_password.Text;
            if (tb_account.Text == string.Empty || tb_password.Text == string.Empty)
            {
                MessageBox.Show("員工編號及密碼不能為空值");
                tb_account.Text = "";
                tb_password.Text = "";
            }
            else
            {
                try
                {
                    string sqlstr = "SELECT * FROM 進貨組 WHERE 員工編號 COLLATE Chinese_PRC_CS_AS = '" + tb_account.Text + "' AND 員工密碼 COLLATE Chinese_PRC_CS_AS = '" + tb_password.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sqlstr, cn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("!!!登入成功!!!");
                        //Form f2 = new FormProduct(tb_account.Text);
                        //FormProduct.lab
                        //f2.ShowDialog();
                        data = tb_account.Text;

                        anotherForm = new Menu();
                        anotherForm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("!!!員工編號或密碼錯誤!!!");
                        tb_account.Text = "";
                        tb_password.Text = "";
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error:{ex.Message}");
                }
                finally
                {
                    cn.Close();
                }
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tb_account.Clear();
            tb_password.Clear();
            tb_account.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            DialogResult d = MessageBox.Show($"確定要離開", "警告", mess);
            if (d == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

    }
}
