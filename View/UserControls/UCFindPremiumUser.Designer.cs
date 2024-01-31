
namespace View.UserControls
{
    partial class UCFindPremiumUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindPremiumUser = new System.Windows.Forms.Button();
            this.txtCriteria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find premium user!";
            // 
            // btnFindPremiumUser
            // 
            this.btnFindPremiumUser.Location = new System.Drawing.Point(130, 220);
            this.btnFindPremiumUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindPremiumUser.Name = "btnFindPremiumUser";
            this.btnFindPremiumUser.Size = new System.Drawing.Size(173, 32);
            this.btnFindPremiumUser.TabIndex = 5;
            this.btnFindPremiumUser.Text = "Find";
            this.btnFindPremiumUser.UseVisualStyleBackColor = true;
            this.btnFindPremiumUser.Click += new System.EventHandler(this.btnFindPremiumUser_Click);
            // 
            // txtCriteria
            // 
            this.txtCriteria.Location = new System.Drawing.Point(82, 151);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.Size = new System.Drawing.Size(268, 22);
            this.txtCriteria.TabIndex = 6;
            // 
            // UCFindPremiumUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.btnFindPremiumUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCFindPremiumUser";
            this.Size = new System.Drawing.Size(429, 358);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindPremiumUser;
        private System.Windows.Forms.TextBox txtCriteria;
    }
}
