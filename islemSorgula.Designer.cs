namespace DövizOfisiXML
{
    partial class islemSorgula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(islemSorgula));
            this.btnSorgu_TC = new System.Windows.Forms.Button();
            this.btnSorgu_Tarih = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDolarAlis = new System.Windows.Forms.Button();
            this.btnDolarSatis = new System.Windows.Forms.Button();
            this.btnEuroAlis = new System.Windows.Forms.Button();
            this.btnEuroSatis = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.mskTCN = new System.Windows.Forms.MaskedTextBox();
            this.txtIsım = new System.Windows.Forms.TextBox();
            this.btnSorgu_isim = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSorgu_TC
            // 
            this.btnSorgu_TC.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSorgu_TC.Location = new System.Drawing.Point(50, 64);
            this.btnSorgu_TC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSorgu_TC.Name = "btnSorgu_TC";
            this.btnSorgu_TC.Size = new System.Drawing.Size(219, 61);
            this.btnSorgu_TC.TabIndex = 0;
            this.btnSorgu_TC.Text = "TC Kimlik Numarasına Göre Sorgula";
            this.btnSorgu_TC.UseVisualStyleBackColor = false;
            this.btnSorgu_TC.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSorgu_Tarih
            // 
            this.btnSorgu_Tarih.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSorgu_Tarih.Location = new System.Drawing.Point(296, 64);
            this.btnSorgu_Tarih.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSorgu_Tarih.Name = "btnSorgu_Tarih";
            this.btnSorgu_Tarih.Size = new System.Drawing.Size(215, 61);
            this.btnSorgu_Tarih.TabIndex = 2;
            this.btnSorgu_Tarih.Text = "Tarihe Göre Sorgula";
            this.btnSorgu_Tarih.UseVisualStyleBackColor = false;
            this.btnSorgu_Tarih.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(-4, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1255, 314);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1249, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnDolarAlis
            // 
            this.btnDolarAlis.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDolarAlis.Location = new System.Drawing.Point(770, 17);
            this.btnDolarAlis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDolarAlis.Name = "btnDolarAlis";
            this.btnDolarAlis.Size = new System.Drawing.Size(225, 40);
            this.btnDolarAlis.TabIndex = 7;
            this.btnDolarAlis.Text = "Dolar Alışlarını Göster";
            this.btnDolarAlis.UseVisualStyleBackColor = false;
            this.btnDolarAlis.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDolarSatis
            // 
            this.btnDolarSatis.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDolarSatis.Location = new System.Drawing.Point(770, 77);
            this.btnDolarSatis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDolarSatis.Name = "btnDolarSatis";
            this.btnDolarSatis.Size = new System.Drawing.Size(225, 44);
            this.btnDolarSatis.TabIndex = 8;
            this.btnDolarSatis.Text = "Dolar Satışlarını Göster";
            this.btnDolarSatis.UseVisualStyleBackColor = false;
            this.btnDolarSatis.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEuroAlis
            // 
            this.btnEuroAlis.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEuroAlis.Location = new System.Drawing.Point(1020, 18);
            this.btnEuroAlis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEuroAlis.Name = "btnEuroAlis";
            this.btnEuroAlis.Size = new System.Drawing.Size(231, 39);
            this.btnEuroAlis.TabIndex = 9;
            this.btnEuroAlis.Text = "Euro Alışlarını Göster";
            this.btnEuroAlis.UseVisualStyleBackColor = false;
            this.btnEuroAlis.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnEuroSatis
            // 
            this.btnEuroSatis.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEuroSatis.Location = new System.Drawing.Point(1020, 77);
            this.btnEuroSatis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEuroSatis.Name = "btnEuroSatis";
            this.btnEuroSatis.Size = new System.Drawing.Size(231, 44);
            this.btnEuroSatis.TabIndex = 10;
            this.btnEuroSatis.Text = "Euro Satışlarını Göster";
            this.btnEuroSatis.UseVisualStyleBackColor = false;
            this.btnEuroSatis.Click += new System.EventHandler(this.button6_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(296, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(215, 30);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // mskTCN
            // 
            this.mskTCN.Location = new System.Drawing.Point(98, 24);
            this.mskTCN.Mask = "00000000000";
            this.mskTCN.Name = "mskTCN";
            this.mskTCN.Size = new System.Drawing.Size(116, 30);
            this.mskTCN.TabIndex = 12;
            this.mskTCN.TextChanged += new System.EventHandler(this.mskTCN_TextChanged);
            // 
            // txtIsım
            // 
            this.txtIsım.Location = new System.Drawing.Point(543, 20);
            this.txtIsım.Name = "txtIsım";
            this.txtIsım.Size = new System.Drawing.Size(200, 30);
            this.txtIsım.TabIndex = 13;
            this.txtIsım.TextChanged += new System.EventHandler(this.txtIsım_TextChanged);
            // 
            // btnSorgu_isim
            // 
            this.btnSorgu_isim.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSorgu_isim.Location = new System.Drawing.Point(543, 62);
            this.btnSorgu_isim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSorgu_isim.Name = "btnSorgu_isim";
            this.btnSorgu_isim.Size = new System.Drawing.Size(200, 61);
            this.btnSorgu_isim.TabIndex = 14;
            this.btnSorgu_isim.Text = "İsme Göre Sorgula";
            this.btnSorgu_isim.UseVisualStyleBackColor = false;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeri.BackgroundImage")));
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(50, 45);
            this.btnGeri.TabIndex = 15;
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // islemSorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1285, 469);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnSorgu_isim);
            this.Controls.Add(this.txtIsım);
            this.Controls.Add(this.mskTCN);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnEuroSatis);
            this.Controls.Add(this.btnEuroAlis);
            this.Controls.Add(this.btnDolarSatis);
            this.Controls.Add(this.btnDolarAlis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSorgu_Tarih);
            this.Controls.Add(this.btnSorgu_TC);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "islemSorgula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Sorgula";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSorgu_TC;
        private System.Windows.Forms.Button btnSorgu_Tarih;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDolarAlis;
        private System.Windows.Forms.Button btnDolarSatis;
        private System.Windows.Forms.Button btnEuroAlis;
        private System.Windows.Forms.Button btnEuroSatis;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MaskedTextBox mskTCN;
        private System.Windows.Forms.TextBox txtIsım;
        private System.Windows.Forms.Button btnSorgu_isim;
        private System.Windows.Forms.Button btnGeri;
    }
}