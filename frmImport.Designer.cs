namespace ArabaKirala
{
    partial class frmImport
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
            this.btndosya = new System.Windows.Forms.Button();
            this.btnyükle = new System.Windows.Forms.Button();
            this.txtdosya = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btndosya
            // 
            this.btndosya.BackColor = System.Drawing.Color.Gainsboro;
            this.btndosya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btndosya.ForeColor = System.Drawing.Color.Indigo;
            this.btndosya.Location = new System.Drawing.Point(429, 106);
            this.btndosya.Name = "btndosya";
            this.btndosya.Size = new System.Drawing.Size(138, 41);
            this.btndosya.TabIndex = 0;
            this.btndosya.Text = "DOSYA SEÇ";
            this.btndosya.UseVisualStyleBackColor = false;
            this.btndosya.Click += new System.EventHandler(this.btndosya_Click);
            // 
            // btnyükle
            // 
            this.btnyükle.BackColor = System.Drawing.Color.Gainsboro;
            this.btnyükle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyükle.ForeColor = System.Drawing.Color.Indigo;
            this.btnyükle.Location = new System.Drawing.Point(429, 175);
            this.btnyükle.Name = "btnyükle";
            this.btnyükle.Size = new System.Drawing.Size(138, 31);
            this.btnyükle.TabIndex = 1;
            this.btnyükle.Text = "YÜKLE";
            this.btnyükle.UseVisualStyleBackColor = false;
            this.btnyükle.Click += new System.EventHandler(this.btnyükle_Click);
            // 
            // txtdosya
            // 
            this.txtdosya.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdosya.Location = new System.Drawing.Point(89, 115);
            this.txtdosya.Name = "txtdosya";
            this.txtdosya.Size = new System.Drawing.Size(275, 22);
            this.txtdosya.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(85, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DOSYA SEÇİMİ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(86, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "*Bir text dosyasından araba bilgileri yükleme";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(643, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdosya);
            this.Controls.Add(this.btnyükle);
            this.Controls.Add(this.btndosya);
            this.Name = "frmImport";
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndosya;
        private System.Windows.Forms.Button btnyükle;
        private System.Windows.Forms.TextBox txtdosya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}