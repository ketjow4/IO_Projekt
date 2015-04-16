namespace IO_Projekt.Payments
{
    partial class Platnosci
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
            this.comboBoxUzytkownik = new System.Windows.Forms.ComboBox();
            this.labelUzytkownik = new System.Windows.Forms.Label();
            this.dgvPlatnosci = new System.Windows.Forms.DataGridView();
            this.buttonPaid = new System.Windows.Forms.Button();
            this.buttonUnpaid = new System.Windows.Forms.Button();
            this.btnZaplac = new System.Windows.Forms.Button();
            this.promocjaSwiateczna = new System.Windows.Forms.CheckBox();
            this.nowozency = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatnosci)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUser
            // 
            this.comboBoxUzytkownik.FormattingEnabled = true;
            this.comboBoxUzytkownik.Location = new System.Drawing.Point(115, 12);
            this.comboBoxUzytkownik.Name = "comboBoxUser";
            this.comboBoxUzytkownik.Size = new System.Drawing.Size(132, 21);
            this.comboBoxUzytkownik.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUzytkownik.AutoSize = true;
            this.labelUzytkownik.Location = new System.Drawing.Point(35, 15);
            this.labelUzytkownik.Name = "labelUser";
            this.labelUzytkownik.Size = new System.Drawing.Size(65, 13);
            this.labelUzytkownik.TabIndex = 1;
            this.labelUzytkownik.Text = "Użytkownik:";
            // 
            // dgvPayments
            // 
            this.dgvPlatnosci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlatnosci.Location = new System.Drawing.Point(12, 48);
            this.dgvPlatnosci.Name = "dgvPayments";
            this.dgvPlatnosci.Size = new System.Drawing.Size(569, 202);
            this.dgvPlatnosci.TabIndex = 2;
            // 
            // buttonPaid
            // 
            this.buttonPaid.Location = new System.Drawing.Point(275, 10);
            this.buttonPaid.Name = "buttonPaid";
            this.buttonPaid.Size = new System.Drawing.Size(112, 23);
            this.buttonPaid.TabIndex = 3;
            this.buttonPaid.Text = "Pokaż zaplacone";
            this.buttonPaid.UseVisualStyleBackColor = true;
            this.buttonPaid.Click += new System.EventHandler(this.buttonZaplacone_Click);
            // 
            // buttonUnpaid
            // 
            this.buttonUnpaid.Location = new System.Drawing.Point(424, 10);
            this.buttonUnpaid.Name = "buttonUnpaid";
            this.buttonUnpaid.Size = new System.Drawing.Size(112, 23);
            this.buttonUnpaid.TabIndex = 4;
            this.buttonUnpaid.Text = "Pokaż niezaplacone";
            this.buttonUnpaid.UseVisualStyleBackColor = true;
            this.buttonUnpaid.Click += new System.EventHandler(this.buttonNiezaplacone_Click);
            // 
            // btnPay
            // 
            this.btnZaplac.Location = new System.Drawing.Point(441, 266);
            this.btnZaplac.Name = "btnPay";
            this.btnZaplac.Size = new System.Drawing.Size(95, 23);
            this.btnZaplac.TabIndex = 5;
            this.btnZaplac.Text = "Zapłać";
            this.btnZaplac.UseVisualStyleBackColor = true;
            this.btnZaplac.Click += new System.EventHandler(this.btnZaplac_Click);
            // 
            // promocjaSwiateczna
            // 
            this.promocjaSwiateczna.AutoSize = true;
            this.promocjaSwiateczna.Location = new System.Drawing.Point(12, 272);
            this.promocjaSwiateczna.Name = "promocjaSwiateczna";
            this.promocjaSwiateczna.Size = new System.Drawing.Size(128, 17);
            this.promocjaSwiateczna.TabIndex = 6;
            this.promocjaSwiateczna.Text = "Promocja Świąteczna";
            this.promocjaSwiateczna.UseVisualStyleBackColor = true;
            // 
            // nowozency
            // 
            this.nowozency.AutoSize = true;
            this.nowozency.Location = new System.Drawing.Point(146, 270);
            this.nowozency.Name = "nowozency";
            this.nowozency.Size = new System.Drawing.Size(82, 17);
            this.nowozency.TabIndex = 7;
            this.nowozency.Text = "Nowożeńcy";
            this.nowozency.UseVisualStyleBackColor = true;
            // 
            // PaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 301);
            this.Controls.Add(this.nowozency);
            this.Controls.Add(this.promocjaSwiateczna);
            this.Controls.Add(this.btnZaplac);
            this.Controls.Add(this.buttonUnpaid);
            this.Controls.Add(this.buttonPaid);
            this.Controls.Add(this.dgvPlatnosci);
            this.Controls.Add(this.labelUzytkownik);
            this.Controls.Add(this.comboBoxUzytkownik);
            this.Name = "PaymentsForm";
            this.Text = "PaymentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatnosci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUzytkownik;
        private System.Windows.Forms.Label labelUzytkownik;
        private System.Windows.Forms.DataGridView dgvPlatnosci;
        private System.Windows.Forms.Button buttonPaid;
        private System.Windows.Forms.Button buttonUnpaid;
        private System.Windows.Forms.Button btnZaplac;
        private System.Windows.Forms.CheckBox promocjaSwiateczna;
        private System.Windows.Forms.CheckBox nowozency;
    }
}