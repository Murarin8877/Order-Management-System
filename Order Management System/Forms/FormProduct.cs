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

    public partial class FormProduct : Form
    {

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
                btn_add.BackColor = ThemeColor.SecondaryColor;
                btn_add.ForeColor = Color.White;

                btn_del.BackColor = ThemeColor.SecondaryColor;
                btn_del.ForeColor = Color.White;

                btn_update.BackColor = ThemeColor.SecondaryColor;
                btn_update.ForeColor = Color.White;

                btn_find.BackColor= ThemeColor.SecondaryColor;
                btn_find.ForeColor = Color.White;

                bt_showall.BackColor = ThemeColor.SecondaryColor;
                bt_showall.ForeColor = Color.White;

                bt_update_no.BackColor = ThemeColor.SecondaryColor;
                bt_update_no.ForeColor = Color.White;

                bt_update_ok.BackColor = ThemeColor.SecondaryColor;
                bt_update_ok.ForeColor = Color.White;

                bt_delete.BackColor = ThemeColor.SecondaryColor;
                bt_delete.ForeColor = Color.White;

                bt_del_cancel.BackColor = ThemeColor.SecondaryColor;
                bt_del_cancel.ForeColor = Color.White;

                bt_find_no.BackColor = ThemeColor.SecondaryColor;
                bt_find_no.ForeColor = Color.White;

                button_find_ok.BackColor = ThemeColor.SecondaryColor;
                button_find_ok.ForeColor = Color.White;


                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            }

        }
        public static int temp = 0;
        public FormProduct()
        {
            InitializeComponent();
        }
        public FormProduct(string text)
        {
            InitializeComponent();

            label9.Text = text;
        }
        private new string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }
        private new string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }
        string cnstr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|Database1.mdf;" + "Integrated Security =True";

        void showdata()
        {
            if (label9.Text == "S01")
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    SqlDataAdapter da = new SqlDataAdapter("SELECT 進貨人員編號,訂單編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 總進貨清單 WHERE 進貨人員編號 = '" + label9.Text + "'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "總進貨清單");
                    dataGridView1.DataSource = ds.Tables["總進貨清單"];
                }
            }
            else if (label9.Text == "S02")
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    SqlDataAdapter da = new SqlDataAdapter("SELECT 進貨人員編號,訂單編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 總進貨清單 WHERE 進貨人員編號 = '" + label9.Text + "'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "總進貨清單");
                    dataGridView1.DataSource = ds.Tables["總進貨清單"];
                }
            }
            else
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    SqlDataAdapter da = new SqlDataAdapter("SELECT 進貨人員編號,訂單編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 總進貨清單", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "總進貨清單");
                    dataGridView1.DataSource = ds.Tables["總進貨清單"];
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnstr;
                    cn.Open();
                    SqlCommand lastno;
                    lastno = new SqlCommand("SELECT TOP 1 * FROM 總進貨清單 WHERE 進貨人員編號 = '" + label9.Text + "' ORDER BY 訂單編號 DESC", cn);
                    SqlDataReader dr = lastno.ExecuteReader();
                    while (dr.Read())
                    {
                        label10.Text = dr[2].ToString();
                    }
                    dr.Close();
                    if (label10.Text == "")
                    {
                        label10.Text = $"{label9.Text}001";
                    }
                    else
                    {
                        string left = Left(label10.Text, 3);
                        string right = Right(label10.Text, 3);
                        int add = 1;
                        add += int.Parse(right);
                        string no = String.Format("{0:000}", Convert.ToInt16(add));
                        label10.Text = left + no;
                    }

                    DataRowView dataviewcompany = cb_company.SelectedItem as DataRowView;
                    string value_company = string.Empty;
                    if (dataviewcompany != null)
                    {
                        value_company = dataviewcompany.Row["進貨商"] as string;

                    }

                    DataRowView dataviewTypes = cb_Types.SelectedItem as DataRowView;
                    string value_cbTypes = string.Empty;
                    if (dataviewTypes != null)
                    {
                        value_cbTypes = dataviewTypes.Row["產品類別"] as string;

                    }

                    DataRowView dataviewproduct = cb_productname.SelectedItem as DataRowView;
                    string value_cbproduct = string.Empty;
                    if (dataviewproduct != null)
                    {
                        value_cbproduct = dataviewproduct.Row["產品名稱"] as string;
                    }

                    SqlCommand cmd = new SqlCommand("InsertProduct", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@no", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@orderno", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@company", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@types", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@productname", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@prize", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@describe", SqlDbType.NVarChar));
                    cmd.Parameters["@no"].Value = label9.Text.ToString();
                    cmd.Parameters["@orderno"].Value = label10.Text;
                    cmd.Parameters["@company"].Value = value_company;
                    cmd.Parameters["@types"].Value = value_cbTypes;
                    cmd.Parameters["@productname"].Value = value_cbproduct;
                    cmd.Parameters["@prize"].Value = int.Parse(tb_prize.Text);
                    cmd.Parameters["@stock"].Value = int.Parse(tb_stock.Text);
                    cmd.Parameters["@describe"].Value = tb_describe.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("新增成功");
                }
                showdata();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ",新增資料發生錯誤");
            }
        }


        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadTheme();
            cb_Company();
            cb_product();
            cb_types();
            this.label9.Text = index.data;

            showdata();

            //可以再賦值給靜態成員，方便其他窗體呼叫

        }

        void cb_Company()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daproduct = new SqlDataAdapter("SELECT 進貨商編號,進貨商 FROM 進貨商", cn);
                DataSet dsproduct = new DataSet();
                daproduct.Fill(dsproduct);
                cb_company.DataSource = dsproduct.Tables[0];
                cb_company.DisplayMember = "進貨商";
                cb_company.ValueMember = "進貨商編號";
                cb_company.Text = "請選擇進貨商";
            }
        }

        void cb_product()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daproduct = new SqlDataAdapter("SELECT 產品編號,產品名稱 FROM 產品", cn);
                DataSet dsproduct = new DataSet();
                daproduct.Fill(dsproduct);
                cb_productname.DataSource = dsproduct.Tables[0];
                cb_productname.DisplayMember = "產品名稱";
                cb_productname.ValueMember = "產品編號";
                cb_productname.Text = "請選擇產品名稱";
            }
        }


        void cb_types()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter datypes = new SqlDataAdapter("SELECT 產品類別編號,產品類別 FROM 產品類別", cn);
                DataSet dstypes = new DataSet();
                datypes.Fill(dstypes);
                cb_Types.DataSource = dstypes.Tables[0];
                cb_Types.DisplayMember = "產品類別";
                cb_Types.ValueMember = "產品類別編號";
                cb_Types.Text = "請選擇產品類別";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var company = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            var types = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            var productname = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            var prize = dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            var stock = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            var describe = dataGridView1.Rows[e.RowIndex].Cells[7].Value;
            cb_company.Text = company.ToString();
            cb_Types.Text = types.ToString();
            cb_productname.Text = productname.ToString();
            tb_prize.Text = prize.ToString();
            tb_stock.Text = stock.ToString();
            tb_describe.Text = describe.ToString();
            label7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            temp += 1;
            if (temp == 1)
            {
                panel_updata.Visible = true;
                btn_add.Visible = false;
                btn_update.Visible = false;
                btn_del.Visible = false;
                btn_find.Visible = false;
            }
            else if (temp >= 2)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection())
                    {
                        cn.ConnectionString = cnstr;
                        cn.Open();
                        temp = 0;
                        label7.Text += $"已執行1 temp -->{temp.ToString()}";
                        //公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述

                        DataRowView dataviewcompany = cb_company.SelectedItem as DataRowView;
                        string value_company = string.Empty;
                        if (dataviewcompany != null)
                        {
                            value_company = dataviewcompany.Row["進貨商"] as string;

                        }

                        DataRowView dataviewTypes = cb_Types.SelectedItem as DataRowView;
                        string value_cbTypes = string.Empty;
                        if (dataviewTypes != null)
                        {
                            value_cbTypes = dataviewTypes.Row["產品類別"] as string;

                        }

                        DataRowView dataviewproduct = cb_productname.SelectedItem as DataRowView;
                        string value_cbproduct = string.Empty;
                        if (dataviewproduct != null)
                        {
                            value_cbproduct = dataviewproduct.Row["產品名稱"] as string;
                        }

                        //string sqlstr = $"UPDATE 總進貨清單 SET 公司名稱 = @company,商品總類 = @types,商品名稱 = @productname,每單位價格={int.Parse(tb_prize.Text)},庫存 ={int.Parse(tb_stock.Text)} ,商品描述 = @describe WHERE 訂單編號 = '{tb_orderno.Text.Replace("'", "''")}'";
                        SqlCommand cmd = new SqlCommand("UpdateProduct", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@no", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("@orderno", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("@company", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("@types", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("@productname", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("@prize", SqlDbType.Float));
                        cmd.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@describe", SqlDbType.NVarChar));
                        cmd.Parameters["@no"].Value = label9.Text.ToString();
                        cmd.Parameters["@orderno"].Value = tb_orderno.Text;
                        cmd.Parameters["@company"].Value = value_company;
                        cmd.Parameters["@types"].Value = value_cbTypes;
                        cmd.Parameters["@productname"].Value = value_cbproduct;
                        cmd.Parameters["@prize"].Value = int.Parse(tb_prize.Text);
                        cmd.Parameters["@stock"].Value = int.Parse(tb_stock.Text);
                        cmd.Parameters["@describe"].Value = tb_describe.Text;
                        cmd.ExecuteNonQuery();
                        cb_company.Text = "請選擇進貨商";
                        cb_Types.Text = "請選擇產品類別";
                        cb_productname.Text = "請選擇產品名稱";
                        tb_prize.Text = "";
                        tb_stock.Text = "";
                        tb_describe.Text = "";
                        MessageBox.Show("!!!更新成功!!!");
                        lb_show_orderno.Text = "";
                        temp = 0;
                        label7.Text += $"已執行3 temp -->{temp.ToString()}";
                        btn_add.Visible = true;
                        btn_update.Visible = true;
                        btn_del.Visible = true;
                        btn_find.Visible = true;
                    }
                    showdata();
                }
                catch (Exception ex)
                {
                    temp = 0;
                    label7.Text += $"已執行4 temp -->{temp.ToString()}";
                    cb_company.Text = "請選擇進貨公司";
                    cb_Types.Text = "請選擇產品類別";
                    cb_productname.Text = "請選擇產品名稱";
                    tb_prize.Text = "";
                    tb_stock.Text = "";
                    tb_describe.Text = "";
                    MessageBox.Show(ex.ToString(), "更新資料發生錯誤");
                    lb_show_orderno.Text = "";
                    lb_show_orderno.Visible = false;
                    btn_add.Visible = true;
                    btn_update.Visible = true;
                    btn_del.Visible = true;
                    btn_find.Visible = true;
                }
            }
        }

        private void bt_update_ok_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                string sqlcount = "SELECT COUNT(*) FROM 總進貨清單 WHERE 訂單編號 COLLATE Chinese_PRC_CS_AS = '" + tb_orderno.Text + "'";
                SqlCommand count = new SqlCommand(sqlcount, cn);
                SqlDataReader dr = count.ExecuteReader();
                label7.Text += "已執行";
                if (dr.Read())
                {
                    label7.Text += $"{dr[0].ToString()}";
                    if (dr[0].ToString() == "0")
                    {
                        DialogResult result = MessageBox.Show("無此筆訂單編號", "!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            tb_orderno.Text = "";
                            panel_updata.Visible = true;
                            btn_add.Visible = false;
                            btn_update.Visible = false;
                            btn_del.Visible = false;
                            btn_find.Visible = false;
                        }
                    }
                    else
                    {
                        lb_show_orderno.Text = $"目前欲更新的訂單編號：{tb_orderno.Text}";
                        lb_show_orderno.Visible = true;
                        panel_updata.Visible = false;
                        cb_company.Text = "";
                        cb_Types.Text = "";
                        cb_productname.Text = "";
                        tb_prize.Text = "";
                        tb_stock.Text = "";
                        tb_describe.Text = "";
                        btn_add.Visible = false;
                        btn_del.Visible = false;
                        btn_update.Visible = true;
                        btn_find.Visible = false;
                        
                    }

                }
                dr.Close();
            }
        }
        private void bt_update_no_Click(object sender, EventArgs e)
        {
            lb_show_orderno.Text = "";
            lb_show_orderno.Visible = false;
            panel_updata.Visible = false;
            btn_add.Visible = true;
            btn_del.Visible = true;
            btn_update.Visible = true;
            btn_find.Visible = true;
            temp = 0;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            panel_del.Visible = true;
            btn_add.Visible = false;
            btn_update.Visible = false;
            btn_find.Visible = false;
            btn_del.Visible = false;
            showdata();
        }

        private void bt_del_cancel_Click(object sender, EventArgs e)
        {
            panel_del.Visible = false;
            tb_del.Text = "";
            btn_add.Visible = true;
            btn_update.Visible = true;
            btn_del.Visible = true;
            btn_find.Visible = true;
        }

        private void bt_delete_Click_1(object sender, EventArgs e)
        {
            panel_del.Visible = false;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                string sqlcount = "SELECT COUNT(*) FROM 總進貨清單 WHERE 訂單編號 COLLATE Chinese_PRC_CS_AS = '" + tb_del.Text + "'";
                SqlCommand count = new SqlCommand(sqlcount, cn);
                SqlDataReader dr = count.ExecuteReader();
                label7.Text += "已執行";
                if (dr.Read())
                {
                    label7.Text += $"{dr[0].ToString()}";
                    if (dr[0].ToString() == "0")
                    {
                        DialogResult result = MessageBox.Show("無此筆資料", "!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            tb_del.Text = "";
                            panel_del.Visible = true;
                            btn_add.Visible = false;
                            btn_update.Visible = false;
                            btn_del.Visible = false;
                            btn_find.Visible = false;

                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show($"是否刪除編號{tb_del.Text}的資料", "!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            using (SqlConnection cndel = new SqlConnection())
                            {
                                cndel.ConnectionString = cnstr;
                                cndel.Open();
                                //string sqldel = $"DELETE FROM 總進貨清單 WHERE 訂單編號 ='{tb_del.Text}'";
                                SqlCommand cmd = new SqlCommand("DeleteProduct", cndel);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@orderno", SqlDbType.NVarChar));
                                cmd.Parameters["@orderno"].Value = tb_del.Text;
                                cmd.ExecuteNonQuery();
                                cndel.Close();
                            }
                            showdata();
                            tb_del.Text = "";
                            panel_del.Visible = false;
                            btn_add.Visible = true;
                            btn_update.Visible = true;
                            btn_del.Visible = true;
                            btn_find.Visible = true;
                        }
                        else
                        {
                            tb_del.Text = "";
                            panel_del.Visible = true;
                            btn_add.Visible = false;
                            btn_update.Visible = false;
                            btn_del.Visible = false;
                            btn_find.Visible = false;
                        }
                    }
                }
                dr.Close();

            }
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            panel_find.Visible = true;
            btn_add.Visible = false;
            btn_update.Visible = false;
            btn_del.Visible = false;
            btn_find.Visible = false;
            //"SELECT 編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 進貨商 WHERE 編號 = 'find'", cn
        }

        private void button_find_ok_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                cn.Open();
                string sqlcount = "SELECT COUNT(*) FROM 總進貨清單 WHERE 訂單編號 COLLATE Chinese_PRC_CS_AS = '" + tb_find.Text + "'";
                SqlCommand count = new SqlCommand(sqlcount, cn);
                SqlDataReader dr = count.ExecuteReader();
                label7.Text += "已執行";
                if (dr.Read())
                {
                    label7.Text += $"{dr[0].ToString()}";
                    if (dr[0].ToString() == "0")
                    {
                        DialogResult result = MessageBox.Show("無此筆資料", "!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            tb_find.Text = "";
                            panel_find.Visible = true;
                            btn_add.Visible = false;
                            btn_update.Visible = false;
                            btn_del.Visible = false;
                            btn_find.Visible = false;

                        }
                    }
                    else
                    {
                        dr.Close();
                        string findstr = $"SELECT 進貨人員編號,訂單編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 總進貨清單 WHERE 訂單編號 COLLATE Chinese_PRC_CS_AS = '" + tb_find.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(findstr, cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "總進貨清單");
                        dataGridView1.DataSource = ds.Tables["總進貨清單"];
                        label7.Text = tb_find.Text;
                        panel_find.Visible = false;
                        btn_add.Visible = true;
                        btn_update.Visible = true;
                        btn_del.Visible = true;
                        btn_find.Visible = true;

                        //cn.ConnectionString = cnstr;
                        //SqlDataAdapter da = new SqlDataAdapter("SELECT 進貨人員編號,訂單編號,公司名稱,商品總類,商品名稱,每單位價格,庫存,商品描述 FROM 總進貨清單 WHERE 進貨人員編號 = '" + label9.Text + "'", cn);
                        //DataSet ds = new DataSet();
                        //da.Fill(ds, "總進貨清單");
                        //dataGridView1.DataSource = ds.Tables["總進貨清單"];

                    }

                }
                dr.Close();
            }
        }

        private void bt_find_no_Click(object sender, EventArgs e)
        {
            panel_find.Visible = false;
            btn_add.Visible = true;
            btn_del.Visible = true;
            btn_update.Visible = true;
            btn_find.Visible = true;
        }

        private void bt_showall_Click(object sender, EventArgs e)
        {
            showdata();
        }
    }
}
