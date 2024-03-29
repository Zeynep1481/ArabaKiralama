namespace ArabaKirala
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button5 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gainsboro;
            this.button5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button5.ImageIndex = 1;
            this.button5.ImageList = this.ımageList1;
            this.button5.Location = new System.Drawing.Point(304, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 137);
            this.button5.TabIndex = 4;
            this.button5.Text = "Sözleşme";
            this.button5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "araçlisteleme.png");
            this.ımageList1.Images.SetKeyName(1, "sözlesşemeee.png");
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button4.ImageIndex = 0;
            this.button4.ImageList = this.ımageList1;
            this.button4.Location = new System.Drawing.Point(77, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(186, 137);
            this.button4.TabIndex = 3;
            this.button4.Text = "Araç Listeleme";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::ArabaKirala.Properties.Resources.WhatsApp_Image_2023_12_06_at_13_00_43;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(574, 412);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "Form2";
            this.Text = "MÜŞTERİ SAYFASI";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList ımageList1;
    }
}