
namespace Grocery_store_management.Forms
{
    partial class FormSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.訂單編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.產品編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.產品名稱DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單價DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.數量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.總額DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.storeDataSet1 = new Grocery_store_management.storeDataSet1();
            this.txtSearchdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dataTable2TableAdapter = new Grocery_store_management.storeDataSet1TableAdapters.DataTable2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.訂單編號DataGridViewTextBoxColumn,
            this.客戶編號DataGridViewTextBoxColumn,
            this.產品編號DataGridViewTextBoxColumn,
            this.產品名稱DataGridViewTextBoxColumn,
            this.單價DataGridViewTextBoxColumn,
            this.數量DataGridViewTextBoxColumn,
            this.總額DataGridViewTextBoxColumn,
            this.訂單日期DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataTable2BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 81);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(969, 477);
            this.dataGridView1.TabIndex = 0;
            // 
            // 訂單編號DataGridViewTextBoxColumn
            // 
            this.訂單編號DataGridViewTextBoxColumn.DataPropertyName = "訂單編號";
            this.訂單編號DataGridViewTextBoxColumn.HeaderText = "訂單編號";
            this.訂單編號DataGridViewTextBoxColumn.Name = "訂單編號DataGridViewTextBoxColumn";
            // 
            // 客戶編號DataGridViewTextBoxColumn
            // 
            this.客戶編號DataGridViewTextBoxColumn.DataPropertyName = "客戶編號";
            this.客戶編號DataGridViewTextBoxColumn.HeaderText = "客戶編號";
            this.客戶編號DataGridViewTextBoxColumn.Name = "客戶編號DataGridViewTextBoxColumn";
            // 
            // 產品編號DataGridViewTextBoxColumn
            // 
            this.產品編號DataGridViewTextBoxColumn.DataPropertyName = "產品編號";
            this.產品編號DataGridViewTextBoxColumn.HeaderText = "產品編號";
            this.產品編號DataGridViewTextBoxColumn.Name = "產品編號DataGridViewTextBoxColumn";
            this.產品編號DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 產品名稱DataGridViewTextBoxColumn
            // 
            this.產品名稱DataGridViewTextBoxColumn.DataPropertyName = "產品名稱";
            this.產品名稱DataGridViewTextBoxColumn.HeaderText = "產品名稱";
            this.產品名稱DataGridViewTextBoxColumn.Name = "產品名稱DataGridViewTextBoxColumn";
            // 
            // 單價DataGridViewTextBoxColumn
            // 
            this.單價DataGridViewTextBoxColumn.DataPropertyName = "單價";
            this.單價DataGridViewTextBoxColumn.HeaderText = "單價";
            this.單價DataGridViewTextBoxColumn.Name = "單價DataGridViewTextBoxColumn";
            // 
            // 數量DataGridViewTextBoxColumn
            // 
            this.數量DataGridViewTextBoxColumn.DataPropertyName = "數量";
            this.數量DataGridViewTextBoxColumn.HeaderText = "數量";
            this.數量DataGridViewTextBoxColumn.Name = "數量DataGridViewTextBoxColumn";
            // 
            // 總額DataGridViewTextBoxColumn
            // 
            this.總額DataGridViewTextBoxColumn.DataPropertyName = "總額";
            this.總額DataGridViewTextBoxColumn.HeaderText = "總額";
            this.總額DataGridViewTextBoxColumn.Name = "總額DataGridViewTextBoxColumn";
            this.總額DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 訂單日期DataGridViewTextBoxColumn
            // 
            this.訂單日期DataGridViewTextBoxColumn.DataPropertyName = "訂單日期";
            this.訂單日期DataGridViewTextBoxColumn.HeaderText = "訂單日期";
            this.訂單日期DataGridViewTextBoxColumn.Name = "訂單日期DataGridViewTextBoxColumn";
            // 
            // dataTable2BindingSource
            // 
            this.dataTable2BindingSource.DataMember = "DataTable2";
            this.dataTable2BindingSource.DataSource = this.storeDataSet1;
            // 
            // storeDataSet1
            // 
            this.storeDataSet1.DataSetName = "storeDataSet1";
            this.storeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSearchdate
            // 
            this.txtSearchdate.AutoSize = true;
            this.txtSearchdate.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSearchdate.Location = new System.Drawing.Point(295, 46);
            this.txtSearchdate.Name = "txtSearchdate";
            this.txtSearchdate.Size = new System.Drawing.Size(123, 19);
            this.txtSearchdate.TabIndex = 2;
            this.txtSearchdate.Text = "搜尋訂單日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "訂單明細";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(441, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Value = new System.DateTime(2022, 12, 10, 0, 0, 0, 0);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(797, 37);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 32);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "顯示所有";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // dataTable2TableAdapter
            // 
            this.dataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 578);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSearchdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label txtSearchdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.BindingSource dataTable2BindingSource;
        private storeDataSet1TableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 訂單編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品名稱DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單價DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 數量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 總額DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 訂單日期DataGridViewTextBoxColumn;
        private storeDataSet1 storeDataSet1;
    }
}