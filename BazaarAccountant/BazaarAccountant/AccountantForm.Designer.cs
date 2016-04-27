namespace BazaarAccountant
{
    partial class AccountantForm
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
            this.buttonPoorSales = new System.Windows.Forms.Button();
            this.buttonAverageSales = new System.Windows.Forms.Button();
            this.buttonAllSales = new System.Windows.Forms.Button();
            this.buttonBestSales = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPoorSales
            // 
            this.buttonPoorSales.Location = new System.Drawing.Point(12, 441);
            this.buttonPoorSales.Name = "buttonPoorSales";
            this.buttonPoorSales.Size = new System.Drawing.Size(144, 45);
            this.buttonPoorSales.TabIndex = 1;
            this.buttonPoorSales.Text = "Poor sales (<= 30%)";
            this.buttonPoorSales.UseVisualStyleBackColor = true;
            this.buttonPoorSales.Click += new System.EventHandler(this.buttonPoorSales_Click);
            // 
            // buttonAverageSales
            // 
            this.buttonAverageSales.Location = new System.Drawing.Point(328, 442);
            this.buttonAverageSales.Name = "buttonAverageSales";
            this.buttonAverageSales.Size = new System.Drawing.Size(144, 45);
            this.buttonAverageSales.TabIndex = 2;
            this.buttonAverageSales.Text = "Average sales (>30% & <70%)";
            this.buttonAverageSales.UseVisualStyleBackColor = true;
            this.buttonAverageSales.Click += new System.EventHandler(this.buttonAverageSales_Click);
            // 
            // buttonAllSales
            // 
            this.buttonAllSales.Location = new System.Drawing.Point(994, 442);
            this.buttonAllSales.Name = "buttonAllSales";
            this.buttonAllSales.Size = new System.Drawing.Size(144, 45);
            this.buttonAllSales.TabIndex = 3;
            this.buttonAllSales.Text = "All sales";
            this.buttonAllSales.UseVisualStyleBackColor = true;
            this.buttonAllSales.Click += new System.EventHandler(this.buttonAllSales_Click);
            // 
            // buttonBestSales
            // 
            this.buttonBestSales.Location = new System.Drawing.Point(661, 441);
            this.buttonBestSales.Name = "buttonBestSales";
            this.buttonBestSales.Size = new System.Drawing.Size(144, 45);
            this.buttonBestSales.TabIndex = 4;
            this.buttonBestSales.Text = "Best sales (>=70%)";
            this.buttonBestSales.UseVisualStyleBackColor = true;
            this.buttonBestSales.Click += new System.EventHandler(this.buttonBestSales_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToResizeColumns = false;
            this.dataGridViewProducts.AllowUserToResizeRows = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1120, 53);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProducts_ColumnHeaderMouseClick);
            // 
            // AccountantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 498);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.buttonBestSales);
            this.Controls.Add(this.buttonAllSales);
            this.Controls.Add(this.buttonAverageSales);
            this.Controls.Add(this.buttonPoorSales);
            this.Name = "AccountantForm";
            this.Text = "Accountant form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPoorSales;
        private System.Windows.Forms.Button buttonAverageSales;
        private System.Windows.Forms.Button buttonAllSales;
        private System.Windows.Forms.Button buttonBestSales;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
    }
}

