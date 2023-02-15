using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
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
using ReportDataSource = Microsoft.Reporting.WebForms.ReportDataSource;

namespace Grocery_store_management.Forms
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'storeDataSet1.DataTable1' 資料表。您可以視需要進行移動或移除。
            this.dataTable1TableAdapter.Fill(this.storeDataSet1.DataTable1);
           

           
            // TODO: 這行程式碼會將資料載入 'storeDataSet1.DataTable1' 資料表。您可以視需要進行移動或移除。
            this.dataTable1TableAdapter.Fill(this.storeDataSet1.DataTable1);

            this.reportViewer1.RefreshReport();
            //SqlConnection cn = new SqlConnection();
            //string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";
            //cn.ConnectionString = cnstr;
            //cn.Open();
            //SqlDataAdapter daOrderId = new SqlDataAdapter("SELECT 訂單編號 FROM 訂貨主檔", cn);
            //DataSet ds = new DataSet();
            //daOrderId.Fill(ds, "訂貨主檔");
            //comboBox1.DataSource = ds;
            //comboBox1.DisplayMember = "訂貨主檔.訂單編號";
        }
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.FillOrderId2(this.storeDataSet1.DataTable1, Convert.ToInt32(textBox1.Text));
            this.reportViewer1.RefreshReport();
            //try
            //{
            //    SqlConnection conn = new SqlConnection(cnstr);
            //    SqlCommand cmd = new SqlCommand($"SELECT 訂單明細.訂單編號, 訂單明細.產品編號, 訂單明細.單價, 訂單明細.數量, 訂貨主檔.客戶編號, 客戶.公司名稱, 訂單明細.單價 * 訂單明細.數量 AS 總額, 產品資料.產品名稱 FROM 客戶 INNER JOIN 訂貨主檔 ON 客戶.客戶編號 = 訂貨主檔.客戶編號 INNER JOIN訂單明細 ON 訂貨主檔.訂單編號 = 訂單明細.訂單編號 INNER JOIN產品資料 ON 訂單明細.產品編號 = 產品資料.產品編號WHERE(訂單明細.訂單編號 = {textBox1.Text})", conn);
            //    cmd.CommandType = CommandType.Text;
            //    conn.Open();

            //    DataTable dt = new DataTable();
            //    dt.Load(cmd.ExecuteReader());

            //    ReportDataSource reportDSDetail = new Microsoft.Reporting.WebForms.ReportDataSource("DataSetUserRegi", dt);
            //    this.reportViewer1.LocalReport.DataSources.Clear();
            //    //this.reportViewer1.LocalReport.DataSources.Add();
            //    this.reportViewer1.LocalReport.Refresh();
            //    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //    this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            //    this.reportViewer1.RefreshReport();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //    this.dataTable1TableAdapter.FillOrderId(this.storeDataSet1.DataTable1,Convert.ToInt32( textBox1.Text));
        //    this.reportViewer1.RefreshReport();
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
