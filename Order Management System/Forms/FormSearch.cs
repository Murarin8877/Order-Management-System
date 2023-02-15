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


namespace Grocery_store_management.Forms
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }
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
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            }

        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // TODO: 這行程式碼會將資料載入 'storeDataSet1.DataTable2' 資料表。您可以視需要進行移動或移除。
            this.dataTable2TableAdapter.Fill(this.storeDataSet1.DataTable2);
            // TODO: 這行程式碼會將資料載入 'storeDataSet1.DataTable2' 資料表。您可以視需要進行移動或移除。
            this.dataTable2TableAdapter.Fill(this.storeDataSet1.DataTable2);
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection())
            {


                dataGridView1.DataSource = dataTable2TableAdapter.GetData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using(SqlConnection cn = new SqlConnection())
            {
                
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";
                SqlDataAdapter daOrder = new SqlDataAdapter("SELECT 訂單明細.訂單編號, 訂單明細.產品編號, 訂單明細.單價, 訂單明細.數量, 訂貨主檔.客戶編號, 訂貨主檔.訂單日期,(訂單明細.單價 * 訂單明細.數量) AS 總額, 產品資料.產品名稱 FROM 客戶 INNER JOIN 訂貨主檔 ON 客戶.客戶編號 = 訂貨主檔.客戶編號 INNER JOIN 訂單明細 ON 訂貨主檔.訂單編號 = 訂單明細.訂單編號 INNER JOIN   產品資料 ON 訂單明細.產品編號 = 產品資料.產品編號", cn);
                daOrder.Fill(ds,"訂單");
                DataTable dtOrder = ds.Tables["訂單"];
                var date1 = dateTimePicker1.Value.ToString("yyyy/M/d");
                var result = from d in dtOrder.AsEnumerable() where d.Field<string>("訂單日期") == date1
                             select new
                             {
                                 訂單編號 = d.Field<int>("訂單編號"),
                                 客戶編號 = d.Field<string>("客戶編號"),
                                 產品編號 = d.Field<int>("產品編號"),
                                 產品名稱 = d.Field<string>("產品名稱"),
                                 單價 = d.Field<int>("單價"),
                                 數量 = d.Field<int>("數量"),
                                 總額 = d.Field<int>("總額"),
                                 訂單日期 = d.Field<string>("訂單日期")
                             };
                             
                dataGridView1.DataSource = result.ToList();
            }
            
           

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dataTable2TableAdapter.GetData();

        }

        
    }
}
