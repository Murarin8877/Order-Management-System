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
    public partial class FormOrders : Form
    {
        public FormOrders()
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

            }
            dataGvOrder.EnableHeadersVisualStyles = false;
            dataGvOrder.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dataGvOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);

            dataGv_Items.EnableHeadersVisualStyles = false;
            dataGv_Items.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dataGv_Items.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGv_Items.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);

            dataGv_Products.EnableHeadersVisualStyles = false;
            dataGv_Products.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dataGv_Products.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGv_Products.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            
            




        }
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True");
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";
        private void populate()
        {
            cn.Open();
            string query = "select 產品編號,產品名稱,單價 from 產品資料";
            SqlDataAdapter sda = new SqlDataAdapter(query, cn);
            SqlCommandBuilder Order = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGv_Products.DataSource = ds.Tables[0];
            cn.Close();
            
        }
        private void populate_Order()
        {
            cn.Open();
            string query = "select * from 訂貨主檔";
            SqlDataAdapter sda = new SqlDataAdapter(query, cn);
            SqlCommandBuilder Order = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds,"訂貨主檔");
            dataGvOrder.DataSource = ds.Tables[0];
            cn.Close();


        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadTheme();
            
            lblDate.Text = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd");
            //populate();
            populate_Order();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";
                SqlDataAdapter daProduct = new SqlDataAdapter("SELECT 產品編號,產品名稱,單價 FROM 產品資料", cn);
                DataSet ds = new DataSet();
                daProduct.Fill(ds, "產品資料");
                cn.Open();
                //Textbox 資料繫結
                
                txtProname.DataBindings.Add("Text", ds, "產品資料.產品名稱");
                txtPrice.DataBindings.Add("Text", ds, "產品資料.單價");
                txtPID.DataBindings.Add("Text", ds, "產品資料.產品編號");
                
                dataGv_Products.DataMember = "產品資料";
                //DataGridview 資料繫結
                dataGv_Products.DataSource = ds;
                dataGv_Products.DataMember = "產品資料";

                //抓取訂單編號的最大值 來讓資料不會重複
                //SqlCommand cmdOrder_id;
                //cmdOrder_id = new SqlCommand("SELECT Max(訂單編號)+1  From 訂貨主檔", cn);
                //txtOrderid.Text = $"{cmdOrder_id.ExecuteScalar()}";

                //點選資料表 自動帶出客戶編號 刪除用
                SqlDataAdapter daOrder = new SqlDataAdapter("SELECT * FROM 訂貨主檔", cn);
                DataSet ds1 = new DataSet();
                daOrder.Fill(ds1, "訂貨主檔");
                txtCustormsID.DataBindings.Add("Text", ds1, "訂貨主檔.客戶編號");
                txtOrderid.DataBindings.Add("Text", ds1, "訂貨主檔.訂單編號");
                dataGvOrder.DataSource = ds1;
                dataGvOrder.DataMember = "訂貨主檔";



            }
            
        }

        private void dataGv_Products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        int Grdtotal = 0,n=0;



        //判斷訂單編號有無重複
        public void CheckOrderId() 
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                SqlCommand cmd2 = new SqlCommand($"SELECT 訂單編號 FROM 訂貨主檔 WHERE 訂單編號 ={txtOrderid.Text}", cn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("訂單編號重複 請按下取得編號按鈕");
                }

            }
            cn.Close();
        }

        public void CheckCustormsID()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT 客戶編號 FROM 客戶 WHERE 客戶編號 = '{txtCustormsID.Text.Replace("'", "''")}'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("請先新增客戶資料表");
                }

            }
        }
        //新增訂單的按鈕
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if(Grdtotal==0)
            {
                MessageBox.Show("請新增產品");
            }
            else
            {
                //CheckCustormsID();
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    cn.Open();
                    CheckOrderId();
                    CheckCustormsID();
                    cn.Close();
                    if (txtCustormsID.Text == "" || lblbtotal.Text == "")
                    {
                        MessageBox.Show("請輸入資料");
                    }
                    else
                    {
                        try
                        {
                            cn.Open();
                            //SqlCommand cmdOrder_id;
                            //cmdOrder_id = new SqlCommand("SELECT Max(訂單編號)+1  From 訂貨主檔", cn);
                            //txtOrderid.Text = $"{cmdOrder_id.ExecuteScalar()}";
                            string query = $"INSERT INTO 訂貨主檔(訂單編號,客戶編號,訂單日期,商品總額) VALUES('{txtOrderid.Text}','{txtCustormsID.Text}','{lblDate.Text}','{int.Parse(lblbtotal.Text)}')";
                            SqlCommand cmd = new SqlCommand(query, cn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("新增成功");
                            //MessageBox.Show($"{dataGv_Items.Rows[0].Cells[1].Value.ToString().Trim()}");
                            //MessageBox.Show($"{dataGv_Items.Rows[1].Cells[3].GetType()}");

                            //新增訂單明細資料
                            for (int i = 0; i < dataGv_Items.Rows.Count - 1; i++)
                            {
                                string query1 = $"INSERT INTO 訂單明細(訂單編號,產品編號,單價,數量) VALUES('{txtOrderid.Text}','{dataGv_Items.Rows[i].Cells[1].Value.ToString().Trim()}','{dataGv_Items.Rows[i].Cells[3].Value}','{dataGv_Items.Rows[i].Cells[4].Value}')";
                                SqlCommand cmd1 = new SqlCommand(query1, cn);
                                cmd1.ExecuteNonQuery();
                            }
                            cn.Close();
                            populate_Order();
                            //populate_OrderDetails();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                        Grdtotal = 0;


                    }
                    DataTable dt = dataGv_Items.DataSource as DataTable;
                    dataGv_Items.DataSource = dt;
                    dataGv_Items.Rows.Clear();
                    lblbtotal.Text = "";
                }

            }






        }

        void populate_OrderDetails()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    cn.Open();
                   

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGv_Items);

                    string  tmp2="",tmp3="";
                    for (int i = 0; i < dataGv_Items.RowCount; i++)
                    {
                        string tmp1 = dataGv_Items.Rows[i].Cells[1].Value != null ? dataGv_Items.Rows[i].Cells[1].Value.ToString() : "";

                        
                            //tmp1 = dataGv_Items.Rows[i].Cells[1].Value.ToString();
                            //tmp2 = dataGv_Items.Rows[i].Cells[3].Value.ToString();
                            //tmp3 = dataGv_Items.Rows[i].Cells[4].Value.ToString();
                            //MessageBox.Show($"{int.Parse(tmp1)}");
                            string query1 = $"INSERT INTO 訂單明細(訂單編號,產品編號) VALUES('{txtOrderid.Text}','{int.Parse(tmp1)}')";
                            SqlCommand cmd = new SqlCommand(query1, cn);
                            cmd.ExecuteNonQuery();
                        
                        
                        
                    }
                    
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
        }


        //刪除訂單btn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCustormsID.Text == "")
            {
                MessageBox.Show("請輸入客戶編號");
            }
            else
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection())
                    {
                        cn.ConnectionString = cnstr;
                        cn.Open();
                        MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                        DialogResult d = MessageBox.Show($"確定要刪除第{txtOrderid.Text}筆的資料", "警告", mess);
                        if (d == DialogResult.OK)
                        {
                            string sqlStr1 = $"DELETE FROM 訂單明細 WHERE 訂單編號 = {txtOrderid.Text} ";
                            SqlCommand Cmd1 = new SqlCommand(sqlStr1, cn);
                            Cmd1.ExecuteNonQuery();
                            string sqlStr = $"DELETE FROM 訂貨主檔 WHERE 訂單編號 = {txtOrderid.Text} ";
                            SqlCommand Cmd = new SqlCommand(sqlStr, cn);
                            Cmd.ExecuteNonQuery();
                            
                        }
                        
                    }
                    ShowdataGvOrder();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message+"錯誤");
                }
            }
        }


        //取得dataGvOrder的資料表
        void ShowdataGvOrder()
        {
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
               
                
                SqlDataAdapter daOrder = new SqlDataAdapter("SELECT * FROM 訂貨主檔", cn);
                DataSet ds1 = new DataSet();
                daOrder.Fill(ds1, "訂貨主檔");
                dataGvOrder.DataBindings.Clear();
                this.txtOrderid.DataBindings.Clear();
                this.txtCustormsID.DataBindings.Clear();
                txtCustormsID.DataBindings.Add("Text", ds1, "訂貨主檔.客戶編號");
                txtOrderid.DataBindings.Add("Text", ds1, "訂貨主檔.訂單編號");
                dataGvOrder.DataSource = ds1;
                dataGvOrder.DataMember = "訂貨主檔";
            }
        }

        //取得目前訂單編號按鈕
        private void btnGetID_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|store.mdf;" + "Integrated Security=True";

                cn.Open();
                //抓取訂單編號的最大值 來讓資料不會重複
                SqlCommand cmdOrder_id;
                cmdOrder_id = new SqlCommand("SELECT Max(訂單編號)+1  From 訂貨主檔", cn);
                txtOrderid.Text = $"{cmdOrder_id.ExecuteScalar()}";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form FromPrint = new FormPrint();
            FromPrint.Show();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblbtotal_Click(object sender, EventArgs e)
        {

        }
        int delete_total;
        private void btnDItems_Click(object sender, EventArgs e)
        {
            if (Grdtotal != 0)
            {
                try
                {
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult d = MessageBox.Show($"確定要刪除此列", "警告", mess);
                    if (d == DialogResult.OK)
                    {
                        delete_total = 0;



                        foreach (DataGridViewCell oneCell in dataGv_Items.SelectedCells)
                        {
                            if (oneCell.Selected)
                            {
                                if (oneCell.ColumnIndex == 0)
                                {
                                    lblbtotal.Text = "";
                                }
                                dataGv_Items.Rows.RemoveAt(oneCell.RowIndex);
                                //lblbtotal.Text = prev_Total.ToString();
                            }
                        }
                        //抓取dataGv_Items的總額 來讓總金額能隨著資料刪減變動
                        for (int i = dataGv_Items.RowCount - 1; i >= 0; i--)
                        {
                            delete_total += Convert.ToInt32(dataGv_Items.Rows[i].Cells[5].Value);
                            //MessageBox.Show($"{Convert.ToInt32(dataGv_Items.Rows[i].Cells[5].Value)}");

                        }
                        // Grdtotal 為增加商品的總金額 所以要同步更新
                        Grdtotal = delete_total;
                        lblbtotal.Text = delete_total.ToString();

                    }
                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message + "錯誤");
                }
            }
            else
            {
                MessageBox.Show( "請新增產品");
            }
           
        }

        private void dataGv_Items_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("更改後");
        }

        int prev_Total;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //增加商品按鈕
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProname.Text == "" || txtQty.Text == "")
                {
                    MessageBox.Show("請輸入資料");
                    txtQty.Focus();
                }
                else
                {
                    int count1 = int.Parse(txtPrice.Text);
                    int count2 = int.Parse(txtQty.Text);
                    int total = count1 * count2;
                    prev_Total += Grdtotal;
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGv_Items);
                    newRow.Cells[0].Value = n + 1;
                    newRow.Cells[1].Value = txtPID.Text;
                    newRow.Cells[2].Value = txtProname.Text;
                    newRow.Cells[3].Value = txtPrice.Text;
                    newRow.Cells[4].Value = txtQty.Text;
                    newRow.Cells[5].Value = total.ToString();
                    dataGv_Items.Rows.Add(newRow);
                    n++;
                    Grdtotal = Grdtotal + total;
                    lblbtotal.Text = Grdtotal.ToString();
                }
            }
            catch (Exception)
            {
                lblbtotal.Text = "";
                
                throw;
            }
            
            


        }
    }
}
