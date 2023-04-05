namespace IksaTeslim
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.dosyaAc = new System.Windows.Forms.Button();
            this.textDosya = new System.Windows.Forms.TextBox();
            this.textIksakm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textIksano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTarih = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b3Kemerli = new System.Windows.Forms.RadioButton();
            this.b3Kemersiz = new System.Windows.Forms.RadioButton();
            this.c2Kemerli = new System.Windows.Forms.RadioButton();
            this.ciz = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dosyaAc
            // 
            this.dosyaAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaAc.Location = new System.Drawing.Point(121, 60);
            this.dosyaAc.Name = "dosyaAc";
            this.dosyaAc.Size = new System.Drawing.Size(94, 29);
            this.dosyaAc.TabIndex = 0;
            this.dosyaAc.Text = "Dosya Aç";
            this.dosyaAc.UseVisualStyleBackColor = true;
            this.dosyaAc.Click += new System.EventHandler(this.dosyaAc_Click);
            // 
            // textDosya
            // 
            this.textDosya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textDosya.Location = new System.Drawing.Point(21, 21);
            this.textDosya.Name = "textDosya";
            this.textDosya.Size = new System.Drawing.Size(305, 24);
            this.textDosya.TabIndex = 1;
            // 
            // textIksakm
            // 
            this.textIksakm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textIksakm.Location = new System.Drawing.Point(178, 110);
            this.textIksakm.Name = "textIksakm";
            this.textIksakm.Size = new System.Drawing.Size(148, 23);
            this.textIksakm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(21, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "İksa Kilometresi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "İksa Numarası";
            // 
            // textIksano
            // 
            this.textIksano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textIksano.Location = new System.Drawing.Point(178, 147);
            this.textIksano.Name = "textIksano";
            this.textIksano.Size = new System.Drawing.Size(148, 23);
            this.textIksano.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(21, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tarih";
            // 
            // textTarih
            // 
            this.textTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textTarih.Location = new System.Drawing.Point(178, 187);
            this.textTarih.Name = "textTarih";
            this.textTarih.Size = new System.Drawing.Size(148, 23);
            this.textTarih.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b3Kemerli);
            this.groupBox1.Controls.Add(this.b3Kemersiz);
            this.groupBox1.Controls.Add(this.c2Kemerli);
            this.groupBox1.Location = new System.Drawing.Point(24, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 120);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tünel Klas";
            // 
            // b3Kemerli
            // 
            this.b3Kemerli.AutoSize = true;
            this.b3Kemerli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.b3Kemerli.Location = new System.Drawing.Point(51, 87);
            this.b3Kemerli.Name = "b3Kemerli";
            this.b3Kemerli.Size = new System.Drawing.Size(97, 21);
            this.b3Kemerli.TabIndex = 2;
            this.b3Kemerli.Text = "B3 Kemerli";
            this.b3Kemerli.UseVisualStyleBackColor = true;
            // 
            // b3Kemersiz
            // 
            this.b3Kemersiz.AutoSize = true;
            this.b3Kemersiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.b3Kemersiz.Location = new System.Drawing.Point(51, 60);
            this.b3Kemersiz.Name = "b3Kemersiz";
            this.b3Kemersiz.Size = new System.Drawing.Size(108, 21);
            this.b3Kemersiz.TabIndex = 1;
            this.b3Kemersiz.Text = "B3 Kemersiz";
            this.b3Kemersiz.UseVisualStyleBackColor = true;
            // 
            // c2Kemerli
            // 
            this.c2Kemerli.AutoSize = true;
            this.c2Kemerli.Checked = true;
            this.c2Kemerli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.c2Kemerli.Location = new System.Drawing.Point(51, 33);
            this.c2Kemerli.Name = "c2Kemerli";
            this.c2Kemerli.Size = new System.Drawing.Size(97, 21);
            this.c2Kemerli.TabIndex = 0;
            this.c2Kemerli.TabStop = true;
            this.c2Kemerli.Text = "C2 Kemerli";
            this.c2Kemerli.UseVisualStyleBackColor = true;
            // 
            // ciz
            // 
            this.ciz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ciz.Location = new System.Drawing.Point(227, 281);
            this.ciz.Name = "ciz";
            this.ciz.Size = new System.Drawing.Size(110, 31);
            this.ciz.TabIndex = 9;
            this.ciz.Text = "Çiz...";
            this.ciz.UseVisualStyleBackColor = true;
            this.ciz.Click += new System.EventHandler(this.ciz_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Location = new System.Drawing.Point(106, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mehmet Zahit Kar - 2023 - v1.0";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 406);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ciz);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTarih);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textIksano);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textIksakm);
            this.Controls.Add(this.textDosya);
            this.Controls.Add(this.dosyaAc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaForm";
            this.Text = "İKSA TESLİMAT FORMU";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dosyaAc;
        private System.Windows.Forms.TextBox textDosya;
        private System.Windows.Forms.TextBox textIksakm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textIksano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTarih;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton b3Kemerli;
        private System.Windows.Forms.RadioButton b3Kemersiz;
        private System.Windows.Forms.RadioButton c2Kemerli;
        private System.Windows.Forms.Button ciz;
        private System.Windows.Forms.Label label4;
    }
}