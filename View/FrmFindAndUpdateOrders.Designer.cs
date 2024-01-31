
namespace View
{
    partial class FrmFindAndUpdateOrders
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPremiumUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateCriteria = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkbIsPaid = new System.Windows.Forms.CheckBox();
            this.btnFindPremiumUser = new System.Windows.Forms.Button();
            this.btnFindOrder = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(3, 279);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1310, 430);
            this.dgvOrders.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find Order That You Want To Change";
            // 
            // txtPremiumUser
            // 
            this.txtPremiumUser.Location = new System.Drawing.Point(521, 167);
            this.txtPremiumUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPremiumUser.Name = "txtPremiumUser";
            this.txtPremiumUser.Size = new System.Drawing.Size(373, 22);
            this.txtPremiumUser.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Premium User:";
            // 
            // dtpDateCriteria
            // 
            this.dtpDateCriteria.Location = new System.Drawing.Point(521, 113);
            this.dtpDateCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateCriteria.Name = "dtpDateCriteria";
            this.dtpDateCriteria.Size = new System.Drawing.Size(373, 22);
            this.dtpDateCriteria.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Created Before This Date:";
            // 
            // chkbIsPaid
            // 
            this.chkbIsPaid.AutoSize = true;
            this.chkbIsPaid.Location = new System.Drawing.Point(911, 113);
            this.chkbIsPaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkbIsPaid.Name = "chkbIsPaid";
            this.chkbIsPaid.Size = new System.Drawing.Size(66, 21);
            this.chkbIsPaid.TabIndex = 8;
            this.chkbIsPaid.Text = "Paid?";
            this.chkbIsPaid.UseVisualStyleBackColor = true;
            // 
            // btnFindPremiumUser
            // 
            this.btnFindPremiumUser.Location = new System.Drawing.Point(911, 165);
            this.btnFindPremiumUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFindPremiumUser.Name = "btnFindPremiumUser";
            this.btnFindPremiumUser.Size = new System.Drawing.Size(100, 28);
            this.btnFindPremiumUser.TabIndex = 9;
            this.btnFindPremiumUser.Text = "Find";
            this.btnFindPremiumUser.UseVisualStyleBackColor = true;
            this.btnFindPremiumUser.Click += new System.EventHandler(this.btnFindPremiumUser_Click);
            // 
            // btnFindOrder
            // 
            this.btnFindOrder.Location = new System.Drawing.Point(415, 217);
            this.btnFindOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFindOrder.Name = "btnFindOrder";
            this.btnFindOrder.Size = new System.Drawing.Size(481, 38);
            this.btnFindOrder.TabIndex = 10;
            this.btnFindOrder.Text = "Find orders";
            this.btnFindOrder.UseVisualStyleBackColor = true;
            this.btnFindOrder.Click += new System.EventHandler(this.btnFindOrder_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(939, 217);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(161, 38);
            this.btnChange.TabIndex = 11;
            this.btnChange.Text = "View";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // FrmFindAndUpdateOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 700);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnFindOrder);
            this.Controls.Add(this.btnFindPremiumUser);
            this.Controls.Add(this.chkbIsPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateCriteria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPremiumUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrders);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmFindAndUpdateOrders";
            this.Text = "FrmFindAndUpdateOrders";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPremiumUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateCriteria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkbIsPaid;
        private System.Windows.Forms.Button btnFindPremiumUser;
        private System.Windows.Forms.Button btnFindOrder;
        private System.Windows.Forms.Button btnChange;
    }
}