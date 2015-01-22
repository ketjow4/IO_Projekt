namespace IO_Projekt.Payments
{
    partial class PaymentsForm
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
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.buttonPaid = new System.Windows.Forms.Button();
            this.buttonUnpaid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(115, 12);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(132, 21);
            this.comboBoxUser.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(35, 15);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(65, 13);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Użytkownik:";
            // 
            // dgvPayments
            // 
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(12, 48);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.Size = new System.Drawing.Size(569, 202);
            this.dgvPayments.TabIndex = 2;
            // 
            // buttonPaid
            // 
            this.buttonPaid.Location = new System.Drawing.Point(275, 10);
            this.buttonPaid.Name = "buttonPaid";
            this.buttonPaid.Size = new System.Drawing.Size(112, 23);
            this.buttonPaid.TabIndex = 3;
            this.buttonPaid.Text = "Pokaż zaplacone";
            this.buttonPaid.UseVisualStyleBackColor = true;
            this.buttonPaid.Click += new System.EventHandler(this.buttonPaid_Click);
            // 
            // buttonUnpaid
            // 
            this.buttonUnpaid.Location = new System.Drawing.Point(424, 10);
            this.buttonUnpaid.Name = "buttonUnpaid";
            this.buttonUnpaid.Size = new System.Drawing.Size(112, 23);
            this.buttonUnpaid.TabIndex = 4;
            this.buttonUnpaid.Text = "Pokaż niezaplacone";
            this.buttonUnpaid.UseVisualStyleBackColor = true;
            // 
            // PaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 262);
            this.Controls.Add(this.buttonUnpaid);
            this.Controls.Add(this.buttonPaid);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.comboBoxUser);
            this.Name = "PaymentsForm";
            this.Text = "PaymentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Button buttonPaid;
        private System.Windows.Forms.Button buttonUnpaid;
    }
}