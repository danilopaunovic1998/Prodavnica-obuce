
namespace View
{
    partial class FrmViewPremiumUsers
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
            this.dgvPremiumUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremiumUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPremiumUsers
            // 
            this.dgvPremiumUsers.AllowUserToAddRows = false;
            this.dgvPremiumUsers.AllowUserToDeleteRows = false;
            this.dgvPremiumUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPremiumUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPremiumUsers.Location = new System.Drawing.Point(0, 132);
            this.dgvPremiumUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPremiumUsers.Name = "dgvPremiumUsers";
            this.dgvPremiumUsers.ReadOnly = true;
            this.dgvPremiumUsers.RowHeadersWidth = 51;
            this.dgvPremiumUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPremiumUsers.Size = new System.Drawing.Size(699, 321);
            this.dgvPremiumUsers.TabIndex = 0;
            this.dgvPremiumUsers.DoubleClick += new System.EventHandler(this.dgvPremiumUsers_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Premium Users that meet the criteria";
            // 
            // FrmViewPremiumUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPremiumUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmViewPremiumUsers";
            this.Text = "FrmViewPremiumUsers";
            this.Load += new System.EventHandler(this.FrmViewPremiumUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremiumUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPremiumUsers;
        private System.Windows.Forms.Label label1;
    }
}