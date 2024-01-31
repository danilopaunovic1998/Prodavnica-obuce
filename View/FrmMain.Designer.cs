
namespace View
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.footwearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFootwearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findFootwearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.premiumUSerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPremiumUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPremiumUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStoreEmployee = new System.Windows.Forms.Label();
            this.findAndUpdateOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footwearToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.premiumUSerToolStripMenuItem,
            this.orderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(555, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // footwearToolStripMenuItem
            // 
            this.footwearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFootwearToolStripMenuItem,
            this.findFootwearToolStripMenuItem});
            this.footwearToolStripMenuItem.Name = "footwearToolStripMenuItem";
            this.footwearToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.footwearToolStripMenuItem.Text = "Footwear";
            // 
            // addFootwearToolStripMenuItem
            // 
            this.addFootwearToolStripMenuItem.Name = "addFootwearToolStripMenuItem";
            this.addFootwearToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addFootwearToolStripMenuItem.Text = "Add New Footwear";
            this.addFootwearToolStripMenuItem.Click += new System.EventHandler(this.addFootwearToolStripMenuItem_Click);
            // 
            // findFootwearToolStripMenuItem
            // 
            this.findFootwearToolStripMenuItem.Name = "findFootwearToolStripMenuItem";
            this.findFootwearToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.findFootwearToolStripMenuItem.Text = "Find Footwear";
            this.findFootwearToolStripMenuItem.Click += new System.EventHandler(this.findFootwearToolStripMenuItem_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSupplierToolStripMenuItem,
            this.findSupplierToolStripMenuItem});
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.supplierToolStripMenuItem.Text = "Supplier";
            // 
            // addNewSupplierToolStripMenuItem
            // 
            this.addNewSupplierToolStripMenuItem.Name = "addNewSupplierToolStripMenuItem";
            this.addNewSupplierToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addNewSupplierToolStripMenuItem.Text = "Add New Supplier";
            this.addNewSupplierToolStripMenuItem.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem_Click);
            // 
            // findSupplierToolStripMenuItem
            // 
            this.findSupplierToolStripMenuItem.Name = "findSupplierToolStripMenuItem";
            this.findSupplierToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.findSupplierToolStripMenuItem.Text = "Find Supplier";
            this.findSupplierToolStripMenuItem.Click += new System.EventHandler(this.findSupplierToolStripMenuItem_Click);
            // 
            // premiumUSerToolStripMenuItem
            // 
            this.premiumUSerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPremiumUserToolStripMenuItem,
            this.findPremiumUserToolStripMenuItem});
            this.premiumUSerToolStripMenuItem.Name = "premiumUSerToolStripMenuItem";
            this.premiumUSerToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.premiumUSerToolStripMenuItem.Text = "Premium User";
            // 
            // addNewPremiumUserToolStripMenuItem
            // 
            this.addNewPremiumUserToolStripMenuItem.Name = "addNewPremiumUserToolStripMenuItem";
            this.addNewPremiumUserToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.addNewPremiumUserToolStripMenuItem.Text = "Add New Premium User";
            this.addNewPremiumUserToolStripMenuItem.Click += new System.EventHandler(this.addNewPremiumUserToolStripMenuItem_Click);
            // 
            // findPremiumUserToolStripMenuItem
            // 
            this.findPremiumUserToolStripMenuItem.Name = "findPremiumUserToolStripMenuItem";
            this.findPremiumUserToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.findPremiumUserToolStripMenuItem.Text = "Find Premium User";
            this.findPremiumUserToolStripMenuItem.Click += new System.EventHandler(this.findPremiumUserToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewOrderToolStripMenuItem,
            this.findAndUpdateOrdersToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // createNewOrderToolStripMenuItem
            // 
            this.createNewOrderToolStripMenuItem.Name = "createNewOrderToolStripMenuItem";
            this.createNewOrderToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.createNewOrderToolStripMenuItem.Text = "Create New Order";
            this.createNewOrderToolStripMenuItem.Click += new System.EventHandler(this.createNewOrderToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(25, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 358);
            this.panel1.TabIndex = 1;
            // 
            // lblStoreEmployee
            // 
            this.lblStoreEmployee.AutoSize = true;
            this.lblStoreEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreEmployee.Location = new System.Drawing.Point(22, 48);
            this.lblStoreEmployee.Name = "lblStoreEmployee";
            this.lblStoreEmployee.Size = new System.Drawing.Size(42, 18);
            this.lblStoreEmployee.TabIndex = 0;
            this.lblStoreEmployee.Text = "Daki";
            // 
            // findAndUpdateOrdersToolStripMenuItem
            // 
            this.findAndUpdateOrdersToolStripMenuItem.Name = "findAndUpdateOrdersToolStripMenuItem";
            this.findAndUpdateOrdersToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.findAndUpdateOrdersToolStripMenuItem.Text = "Find And Update Orders";
            this.findAndUpdateOrdersToolStripMenuItem.Click += new System.EventHandler(this.findAndUpdateOrdersToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 474);
            this.Controls.Add(this.lblStoreEmployee);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Home page";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem footwearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFootwearToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStoreEmployee;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem premiumUSerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPremiumUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findPremiumUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findFootwearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAndUpdateOrdersToolStripMenuItem;
    }
}