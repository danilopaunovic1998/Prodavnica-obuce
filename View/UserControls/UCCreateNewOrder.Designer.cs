
namespace View.UserControls
{
    partial class UCCreateNewOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPremiumUser = new System.Windows.Forms.TextBox();
            this.btnFindPremiumUser = new System.Windows.Forms.Button();
            this.dtpDateOfCreation = new System.Windows.Forms.DateTimePicker();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbPaid = new System.Windows.Forms.CheckBox();
            this.chkBonus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(53, 154);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Size = new System.Drawing.Size(397, 146);
            this.dgvOrderItems.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date of creation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Premium user:";
            // 
            // txtPremiumUser
            // 
            this.txtPremiumUser.Location = new System.Drawing.Point(186, 73);
            this.txtPremiumUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtPremiumUser.Name = "txtPremiumUser";
            this.txtPremiumUser.Size = new System.Drawing.Size(186, 20);
            this.txtPremiumUser.TabIndex = 4;
            // 
            // btnFindPremiumUser
            // 
            this.btnFindPremiumUser.Location = new System.Drawing.Point(375, 73);
            this.btnFindPremiumUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindPremiumUser.Name = "btnFindPremiumUser";
            this.btnFindPremiumUser.Size = new System.Drawing.Size(46, 21);
            this.btnFindPremiumUser.TabIndex = 6;
            this.btnFindPremiumUser.Text = "Find";
            this.btnFindPremiumUser.UseVisualStyleBackColor = true;
            this.btnFindPremiumUser.Click += new System.EventHandler(this.btnFindPremiumUser_Click);
            // 
            // dtpDateOfCreation
            // 
            this.dtpDateOfCreation.Location = new System.Drawing.Point(186, 50);
            this.dtpDateOfCreation.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateOfCreation.Name = "dtpDateOfCreation";
            this.dtpDateOfCreation.Size = new System.Drawing.Size(186, 20);
            this.dtpDateOfCreation.TabIndex = 7;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(97, 124);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(114, 25);
            this.btnAddItem.TabIndex = 8;
            this.btnAddItem.Text = "Add item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(307, 124);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(114, 25);
            this.btnRemoveItem.TabIndex = 9;
            this.btnRemoveItem.Text = "Remove item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(100, 315);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Amount:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(307, 312);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 24);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save order";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Create order!";
            // 
            // ckbPaid
            // 
            this.ckbPaid.AutoSize = true;
            this.ckbPaid.Location = new System.Drawing.Point(322, 96);
            this.ckbPaid.Margin = new System.Windows.Forms.Padding(2);
            this.ckbPaid.Name = "ckbPaid";
            this.ckbPaid.Size = new System.Drawing.Size(61, 19);
            this.ckbPaid.TabIndex = 14;
            this.ckbPaid.Text = "Paid?";
            this.ckbPaid.UseVisualStyleBackColor = true;
            // 
            // chkBonus
            // 
            this.chkBonus.AutoSize = true;
            this.chkBonus.Location = new System.Drawing.Point(186, 96);
            this.chkBonus.Margin = new System.Windows.Forms.Padding(2);
            this.chkBonus.Name = "chkBonus";
            this.chkBonus.Size = new System.Drawing.Size(95, 19);
            this.chkBonus.TabIndex = 15;
            this.chkBonus.Text = "Use bonus?";
            this.chkBonus.UseVisualStyleBackColor = true;
            // 
            // UCCreateNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkBonus);
            this.Controls.Add(this.ckbPaid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dtpDateOfCreation);
            this.Controls.Add(this.btnFindPremiumUser);
            this.Controls.Add(this.txtPremiumUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrderItems);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCCreateNewOrder";
            this.Size = new System.Drawing.Size(504, 358);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPremiumUser;
        private System.Windows.Forms.Button btnFindPremiumUser;
        private System.Windows.Forms.DateTimePicker dtpDateOfCreation;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbPaid;
        private System.Windows.Forms.CheckBox chkBonus;
    }
}
