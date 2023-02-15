using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_store_management.Forms
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }
        string cnstr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security = True";

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                label4.ForeColor = ThemeColor.SecondaryColor;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            }

        }
        void Show()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daClient = new SqlDataAdapter("SELECT 客戶編號,公司名稱,連絡電話,地址 FROM 客戶", cn);
                DataSet ds = new DataSet();
                daClient.Fill(ds, "客戶");
                dataGridView1.DataSource = ds;
            }
               
            
        }
        void ShowData()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                //避免重複繫結
                dataGridView1.DataBindings.Clear();
                this.txtCId.DataBindings.Clear();
                this.txtCName.DataBindings.Clear();
                this.txtCphone.DataBindings.Clear();
                this.txtAddress.DataBindings.Clear();
                cn.ConnectionString = cnstr;
                SqlDataAdapter daClient = new SqlDataAdapter("SELECT 客戶編號,公司名稱,連絡電話,地址 FROM 客戶", cn);
                DataSet ds = new DataSet();
                daClient.Fill(ds, "客戶");     
                
                txtCId.DataBindings.Add("Text", ds, "客戶.客戶編號");
                txtCName.DataBindings.Add("Text", ds, "客戶.公司名稱");
                txtCphone.DataBindings.Add("Text", ds, "客戶.連絡電話");
                txtAddress.DataBindings.Add("Text", ds, "客戶.地址");

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "客戶";



            }
        }
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            
            
            LoadTheme();

            ShowData();
        }

        //新增btn
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            
                try
                {
                using (SqlConnection cn = new SqlConnection())
                    {
                        cn.ConnectionString = cnstr;
                        cn.Open();
                        string sqlStr = $"INSERT INTO 客戶(客戶編號,公司名稱,連絡電話,地址) VALUES('{txtCId.Text}',N'{txtCName.Text}','{txtCphone.Text}',N'{txtAddress.Text}')";
                        SqlCommand Cmd = new SqlCommand(sqlStr, cn);
                        Cmd.ExecuteNonQuery();
                    }
               
                ShowData();
                }
               

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            
               
        }


        //修改btn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            
                try
                {
                    using (SqlConnection cn = new SqlConnection())
                    {
                        cn.ConnectionString = cnstr;
                        cn.Open();
                        
                        string sqlStr = $"UPDATE 客戶 SET 公司名稱 = N'{txtCName.Text}', 連絡電話 ='{txtCphone.Text}',地址= N'{txtAddress.Text}' WHERE 客戶編號 = '{txtCId.Text}'";
                        SqlCommand Cmd = new SqlCommand(sqlStr, cn);
                        Cmd.ExecuteNonQuery();
                    }
                
                ShowData();
                 }
                
                

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message +"修改資料錯誤");
                }
            
        }


        //刪除btn
        private void btnDel_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show($"確定要刪除{txtCId.Text}的資料", "警告", mess);
                if (d == DialogResult.OK)
                {
                    string sqlStr1 = $"DELETE 訂單明細  FROM 客戶 INNER JOIN 訂貨主檔 ON 客戶.客戶編號 = 訂貨主檔.客戶編號 INNER JOIN 訂單明細 ON 訂貨主檔.訂單編號 = 訂單明細.訂單編號   WHERE 客戶.客戶編號 = '{txtCId.Text}'  ";
                    SqlCommand Cmd1 = new SqlCommand(sqlStr1, cn);
                    Cmd1.ExecuteNonQuery();

                    string sqlStr2 = $"DELETE  FROM 訂貨主檔 WHERE 訂貨主檔.客戶編號 = '{txtCId.Text}'";
                    SqlCommand Cmd2 = new SqlCommand(sqlStr2, cn);
                    Cmd2.ExecuteNonQuery();

                    string sqlStr = $"DELETE FROM 客戶 WHERE 客戶編號 = '{txtCId.Text}'";
                    SqlCommand Cmd = new SqlCommand(sqlStr, cn);
                    Cmd.ExecuteNonQuery();


                }
                    
                     
            }
            
            ShowData();
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            txtCId.Text = "";
            txtCName.Text = "";
            txtAddress.Text = "";
            txtCphone.Text = "";
        }
    }
}
