namespace PresentationLayer.Forms
{
	partial class Bazaar
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
			this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
			this.comboBoxProducts = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanelProducts = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelBuy = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxQuantity = new System.Windows.Forms.TextBox();
			this.buttonBuy = new System.Windows.Forms.Button();
			this.listBoxSelectedCategories = new System.Windows.Forms.ListBox();
			this.tableLayoutPanelFilterSelectButtons = new System.Windows.Forms.TableLayoutPanel();
			this.buttonFilterCategory = new System.Windows.Forms.Button();
			this.buttonSelectCategory = new System.Windows.Forms.Button();
			this.listBoxFilteredCategories = new System.Windows.Forms.ListBox();
			this.labelSelectedCategories = new System.Windows.Forms.Label();
			this.labelFilteredCategories = new System.Windows.Forms.Label();
			this.buttonViewCart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
			this.tableLayoutPanelProducts.SuspendLayout();
			this.tableLayoutPanelBuy.SuspendLayout();
			this.tableLayoutPanelFilterSelectButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewProducts
			// 
			this.dataGridViewProducts.AllowUserToAddRows = false;
			this.dataGridViewProducts.AllowUserToDeleteRows = false;
			this.dataGridViewProducts.AllowUserToOrderColumns = true;
			this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewProducts.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewProducts.Name = "dataGridViewProducts";
			this.dataGridViewProducts.ReadOnly = true;
			this.dataGridViewProducts.Size = new System.Drawing.Size(668, 237);
			this.dataGridViewProducts.TabIndex = 0;
			// 
			// comboBoxProducts
			// 
			this.comboBoxProducts.FormattingEnabled = true;
			this.comboBoxProducts.Location = new System.Drawing.Point(3, 3);
			this.comboBoxProducts.Name = "comboBoxProducts";
			this.comboBoxProducts.Size = new System.Drawing.Size(165, 21);
			this.comboBoxProducts.TabIndex = 1;
			this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
			// 
			// tableLayoutPanelProducts
			// 
			this.tableLayoutPanelProducts.ColumnCount = 4;
			this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
			this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
			this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelProducts.Controls.Add(this.tableLayoutPanelBuy, 0, 1);
			this.tableLayoutPanelProducts.Controls.Add(this.listBoxSelectedCategories, 1, 0);
			this.tableLayoutPanelProducts.Controls.Add(this.tableLayoutPanelFilterSelectButtons, 2, 0);
			this.tableLayoutPanelProducts.Controls.Add(this.listBoxFilteredCategories, 3, 0);
			this.tableLayoutPanelProducts.Controls.Add(this.dataGridViewProducts, 0, 0);
			this.tableLayoutPanelProducts.Location = new System.Drawing.Point(12, 66);
			this.tableLayoutPanelProducts.Name = "tableLayoutPanelProducts";
			this.tableLayoutPanelProducts.RowCount = 2;
			this.tableLayoutPanelProducts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.54864F));
			this.tableLayoutPanelProducts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.45136F));
			this.tableLayoutPanelProducts.Size = new System.Drawing.Size(1029, 278);
			this.tableLayoutPanelProducts.TabIndex = 2;
			// 
			// tableLayoutPanelBuy
			// 
			this.tableLayoutPanelBuy.ColumnCount = 3;
			this.tableLayoutPanelBuy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelBuy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
			this.tableLayoutPanelBuy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
			this.tableLayoutPanelBuy.Controls.Add(this.textBoxQuantity, 1, 0);
			this.tableLayoutPanelBuy.Controls.Add(this.comboBoxProducts, 0, 0);
			this.tableLayoutPanelBuy.Controls.Add(this.buttonBuy, 2, 0);
			this.tableLayoutPanelBuy.Location = new System.Drawing.Point(3, 246);
			this.tableLayoutPanelBuy.Name = "tableLayoutPanelBuy";
			this.tableLayoutPanelBuy.RowCount = 1;
			this.tableLayoutPanelBuy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelBuy.Size = new System.Drawing.Size(308, 29);
			this.tableLayoutPanelBuy.TabIndex = 1;
			// 
			// textBoxQuantity
			// 
			this.textBoxQuantity.Location = new System.Drawing.Point(174, 3);
			this.textBoxQuantity.Name = "textBoxQuantity";
			this.textBoxQuantity.Size = new System.Drawing.Size(59, 20);
			this.textBoxQuantity.TabIndex = 3;
			// 
			// buttonBuy
			// 
			this.buttonBuy.Location = new System.Drawing.Point(239, 3);
			this.buttonBuy.Name = "buttonBuy";
			this.buttonBuy.Size = new System.Drawing.Size(65, 23);
			this.buttonBuy.TabIndex = 4;
			this.buttonBuy.Text = "Buy";
			this.buttonBuy.UseVisualStyleBackColor = true;
			this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
			// 
			// listBoxSelectedCategories
			// 
			this.listBoxSelectedCategories.FormattingEnabled = true;
			this.listBoxSelectedCategories.Location = new System.Drawing.Point(677, 3);
			this.listBoxSelectedCategories.Name = "listBoxSelectedCategories";
			this.listBoxSelectedCategories.Size = new System.Drawing.Size(137, 225);
			this.listBoxSelectedCategories.TabIndex = 2;
			// 
			// tableLayoutPanelFilterSelectButtons
			// 
			this.tableLayoutPanelFilterSelectButtons.ColumnCount = 1;
			this.tableLayoutPanelFilterSelectButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelFilterSelectButtons.Controls.Add(this.buttonFilterCategory, 0, 0);
			this.tableLayoutPanelFilterSelectButtons.Controls.Add(this.buttonSelectCategory, 0, 1);
			this.tableLayoutPanelFilterSelectButtons.Location = new System.Drawing.Point(820, 3);
			this.tableLayoutPanelFilterSelectButtons.Name = "tableLayoutPanelFilterSelectButtons";
			this.tableLayoutPanelFilterSelectButtons.RowCount = 2;
			this.tableLayoutPanelFilterSelectButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelFilterSelectButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelFilterSelectButtons.Size = new System.Drawing.Size(37, 58);
			this.tableLayoutPanelFilterSelectButtons.TabIndex = 3;
			// 
			// buttonFilterCategory
			// 
			this.buttonFilterCategory.Location = new System.Drawing.Point(3, 3);
			this.buttonFilterCategory.Name = "buttonFilterCategory";
			this.buttonFilterCategory.Size = new System.Drawing.Size(31, 23);
			this.buttonFilterCategory.TabIndex = 0;
			this.buttonFilterCategory.Text = ">";
			this.buttonFilterCategory.UseVisualStyleBackColor = true;
			this.buttonFilterCategory.Click += new System.EventHandler(this.buttonFilterCategory_Click);
			// 
			// buttonSelectCategory
			// 
			this.buttonSelectCategory.Location = new System.Drawing.Point(3, 32);
			this.buttonSelectCategory.Name = "buttonSelectCategory";
			this.buttonSelectCategory.Size = new System.Drawing.Size(31, 23);
			this.buttonSelectCategory.TabIndex = 1;
			this.buttonSelectCategory.Text = "<";
			this.buttonSelectCategory.UseVisualStyleBackColor = true;
			this.buttonSelectCategory.Click += new System.EventHandler(this.buttonSelectCategory_Click);
			// 
			// listBoxFilteredCategories
			// 
			this.listBoxFilteredCategories.FormattingEnabled = true;
			this.listBoxFilteredCategories.Location = new System.Drawing.Point(863, 3);
			this.listBoxFilteredCategories.Name = "listBoxFilteredCategories";
			this.listBoxFilteredCategories.Size = new System.Drawing.Size(163, 225);
			this.listBoxFilteredCategories.TabIndex = 4;
			// 
			// labelSelectedCategories
			// 
			this.labelSelectedCategories.AutoSize = true;
			this.labelSelectedCategories.Location = new System.Drawing.Point(686, 48);
			this.labelSelectedCategories.Name = "labelSelectedCategories";
			this.labelSelectedCategories.Size = new System.Drawing.Size(101, 13);
			this.labelSelectedCategories.TabIndex = 3;
			this.labelSelectedCategories.Text = "Selected categories";
			// 
			// labelFilteredCategories
			// 
			this.labelFilteredCategories.AutoSize = true;
			this.labelFilteredCategories.Location = new System.Drawing.Point(872, 50);
			this.labelFilteredCategories.Name = "labelFilteredCategories";
			this.labelFilteredCategories.Size = new System.Drawing.Size(93, 13);
			this.labelFilteredCategories.TabIndex = 4;
			this.labelFilteredCategories.Text = "Filtered categories";
			// 
			// buttonViewCart
			// 
			this.buttonViewCart.Location = new System.Drawing.Point(933, 13);
			this.buttonViewCart.Name = "buttonViewCart";
			this.buttonViewCart.Size = new System.Drawing.Size(105, 34);
			this.buttonViewCart.TabIndex = 5;
			this.buttonViewCart.Text = "View cart";
			this.buttonViewCart.UseVisualStyleBackColor = true;
			this.buttonViewCart.Click += new System.EventHandler(this.buttonViewCart_Click);
			// 
			// Bazaar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1053, 369);
			this.Controls.Add(this.buttonViewCart);
			this.Controls.Add(this.labelFilteredCategories);
			this.Controls.Add(this.labelSelectedCategories);
			this.Controls.Add(this.tableLayoutPanelProducts);
			this.Name = "Bazaar";
			this.Text = "Bazaar";
			this.Shown += new System.EventHandler(this.Bazaar_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
			this.tableLayoutPanelProducts.ResumeLayout(false);
			this.tableLayoutPanelBuy.ResumeLayout(false);
			this.tableLayoutPanelBuy.PerformLayout();
			this.tableLayoutPanelFilterSelectButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewProducts;
		private System.Windows.Forms.ComboBox comboBoxProducts;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProducts;
		private System.Windows.Forms.TextBox textBoxQuantity;
		private System.Windows.Forms.Button buttonBuy;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBuy;
		private System.Windows.Forms.ListBox listBoxSelectedCategories;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilterSelectButtons;
		private System.Windows.Forms.Button buttonFilterCategory;
		private System.Windows.Forms.Button buttonSelectCategory;
		private System.Windows.Forms.ListBox listBoxFilteredCategories;
		private System.Windows.Forms.Label labelSelectedCategories;
		private System.Windows.Forms.Label labelFilteredCategories;
		private System.Windows.Forms.Button buttonViewCart;

	}
}

