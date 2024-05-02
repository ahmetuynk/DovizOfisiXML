using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace DövizOfisiXML
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        //Kendi sunucu adınızı /* */ arasındaki alanına yapıştırın ve arından /* */ ları silin:
        SqlConnection conn = new SqlConnection("Data Source=/* */;Initial Catalog=Doviz;Integrated Security=True");

        void listele_islemler() //GEÇMİŞ İŞLEMLERİ LİSTELEME
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLISLEMLER", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void kasagetir() //KASADA BULUNAN PARA
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLKASA", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblTL.Text = dr[0].ToString();
                lblEUR.Text = dr[1].ToString();
                lblUSD.Text = dr[2].ToString();
            }

            conn.Close();
        }
        void temizle()
        {
            txtMiktar.TextChanged -= txtMiktar_TextChanged;
            rdbAlis.Checked = false;
            rdbSatis.Checked = false;
            rdbEur.Checked = false;
            rdbUSD.Checked = false;
            txtKur.Text = "";
            txtMiktar.Text = "";
            txtTutar.Text = "";
            txtKalan.Text = "";
            lblDurum.Text = "";
            txtAdSoyad.Text = "";
            lblMiktarBirim.Text = "";
            lblTutarBirim.Text = "";
            mskTC.Text = "";
            lblAdSoyad.ForeColor = Color.White;
            lblMiktar.ForeColor = Color.White;
            lblTC.ForeColor = Color.White;
            btnSatisYap1.Enabled = false;
            btnAlisYap.Enabled = false;
            txtMiktar.TextChanged += txtMiktar_TextChanged;
        }


        private bool IsValidName(string name) // Ad soyadın geçerliliğini kontrol et
        {
            // Ad soyad sadece harfler içermeli
            return !Regex.IsMatch(name, @"[^a-zA-ZğüşıöçĞÜŞİÖÇ\s]");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            temizle();

            kasagetir();

            btnAlisYap.Enabled = false;
            btnSatisYap1.Enabled = false;

            string adressForToday = "https://www.tcmb.gov.tr/kurlar/today.xml"; //Kur bilgileri alınıyor.
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(adressForToday);

            string dollarBuying = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;

            lblDolarAlis.Text = dollarBuying;

            string dollarSelling = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dollarSelling;

            string euroBuying = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroBuying;

            string euroSelling = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euroSelling;
        }

        private void buttonDolarAlis_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Dolar Alışı Gerçekleştiriyorsunuz";
            btnSatisYap1.Enabled = false;
            btnAlisYap.Enabled = true;
            txtKur.Text = lblDolarAlis.Text;
            rdbUSD.Checked = true;
            rdbAlis.Checked = true;
            lblMiktarBirim.Text = "USD";
            lblTutarBirim.Text = "TL";
            txtMiktar.Focus();
        }

        private void btnDolarSatis_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Dolar Satışı Gerçekleştiriyorsunuz";
            btnAlisYap.Enabled = false;
            btnSatisYap1.Enabled = true;
            lblMiktarBirim.Text = "TL";
            lblTutarBirim.Text = "USD";
            txtKur.Text = lblDolarSatis.Text;
            rdbUSD.Checked = true;
            rdbSatis.Checked = true;
            txtMiktar.Text = "";
            txtMiktar.Focus();

        }

        private void btnEuroAlis_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Euro Alışı Gerçekleştiriyorsunuz";
            btnSatisYap1.Enabled = false;
            btnAlisYap.Enabled = true;
            lblMiktarBirim.Text = "EUR";
            lblTutarBirim.Text = "TL";
            txtKur.Text = lblEuroAlis.Text;
            rdbEur.Checked = true;
            rdbAlis.Checked = true;
            txtMiktar.Text = "";
            txtMiktar.Focus();
        }

        private void btnEuroSatis_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Euro Satışı Gerçekleştiriyorsunuz";
            btnAlisYap.Enabled = false;
            btnSatisYap1.Enabled = true;
            lblMiktarBirim.Text = "TL";
            lblTutarBirim.Text = "EUR";
            txtKur.Text = lblEuroSatis.Text;
            rdbEur.Checked = true;
            rdbSatis.Checked = true;
            txtMiktar.Text = "";
            txtMiktar.Focus();
        }

        private void txtKur_TextChanged_1(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".", ",");

        }

        private void txtMiktar_TextChanged(object sender, EventArgs e) //işlem yapılacak para birimine göre karşılık hesaplama
        {
            decimal miktar, kur, tutar;


            if (!decimal.TryParse(txtMiktar.Text, out miktar))
            {
                //MessageBox.Show("Miktar boş bırakılamaz");
                txtMiktar.Text = "00,00";
                return;
            }

            if (rdbAlis.Checked == true)
            {
                kur = decimal.Parse(txtKur.Text);
                tutar = (miktar * kur);
                txtTutar.Text = tutar.ToString("00.00");
            }

            if (rdbSatis.Checked == true)
            {
                kur = decimal.Parse(txtKur.Text);
                tutar = (miktar / kur);
                txtTutar.Text = tutar.ToString("00.00");
                decimal kalan = miktar % kur;
                txtKalan.Text = kalan.ToString("00.00");
            }

        }

        private void btnAlisYap_Click_1(object sender, EventArgs e) //ALIS YAP BUTONU
        {
            string errormessage = "";

            if (string.IsNullOrEmpty(txtAdSoyad.Text))
            {
                errormessage += "Ad Soyad boş bırakılamaz.\n";
                lblAdSoyad.ForeColor = Color.Red;

            }

            else if (!IsValidName(txtAdSoyad.Text))
            {
                errormessage += "Ad Soyad özel karakter veya sayı içeremez.\n";
                lblAdSoyad.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(txtMiktar.Text) || txtTutar.Text=="00,00")
            {
                errormessage += "Miktar boş veya 0 olamaz, geçerli bir miktar girin.\n";
                lblMiktar.ForeColor = Color.Red;
            }

            if (mskTC.Text.Length < mskTC.Mask.Length)
            {
                errormessage += "TC Kimlik No alanını eksiksiz doldurunuz.\n";
                lblTC.ForeColor = Color.Red;
            }

            if (!string.IsNullOrEmpty(errormessage))
            {
                MessageBox.Show(errormessage);
                return;
            }

            errormessage = "";

            if (decimal.Parse(txtTutar.Text) > decimal.Parse(lblTL.Text)) //KASA KONTROL
            {
                MessageBox.Show("Kasada işlemi gerçekleştirmek için yeterli TL bulunmamaktadır");
                return;
            }

            else
            {
                conn.Open();
                if (rdbUSD.Checked == true && rdbAlis.Checked == true) //DOLAR ALIMI YAPILIYORSA
                {
                    SqlCommand cmd = new SqlCommand("Update TBLKASA set DOLAR+=@p1,TL-=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(txtMiktar.Text));
                    cmd.Parameters.AddWithValue("@p2", Convert.ToDecimal(txtTutar.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Insert into TBLISLEMLER (islemtipi,alınanTutar,verilenTutar,musteriTC,MusteriAdSoyad) values(@1,@2,@3,@4,@5)", conn);
                    cmd2.Parameters.AddWithValue("@1", "Dolar Alışı");
                    cmd2.Parameters.AddWithValue("@2", decimal.Parse(txtMiktar.Text));
                    cmd2.Parameters.AddWithValue("@3", decimal.Parse(txtTutar.Text));
                    cmd2.Parameters.AddWithValue("@4", mskTC.Text);
                    cmd2.Parameters.AddWithValue("@5", txtAdSoyad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Dolar alımı gerçekleşmiştir");
                }
                if (rdbEur.Checked == true && rdbAlis.Checked == true) //EURO ALIMI YAPILIYORSA
                {
                    if (decimal.Parse(txtTutar.Text) > decimal.Parse(lblTL.Text))
                    {
                        MessageBox.Show("Kasada işlemi gerçekleştirmek için yeterli TL bulunmamaktadır");
                    }
                    SqlCommand cmd = new SqlCommand("Update TBLKASA set EURO+=@p1,TL-=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(txtMiktar.Text));
                    cmd.Parameters.AddWithValue("@p2", Convert.ToDecimal(txtTutar.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Insert into TBLISLEMLER (islemtipi,alınanTutar,verilenTutar,musteriTC,MusteriAdSoyad) values(@1,@2,@3,@4,@5)", conn);
                    cmd2.Parameters.AddWithValue("@1", "Euro Alışı");
                    cmd2.Parameters.AddWithValue("@2", decimal.Parse(txtMiktar.Text));
                    cmd2.Parameters.AddWithValue("@3", decimal.Parse(txtTutar.Text));
                    cmd2.Parameters.AddWithValue("@4", mskTC.Text);
                    cmd2.Parameters.AddWithValue("@5", txtAdSoyad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Euro alımı gerçekleşmiştir");
                }
            }
            conn.Close();
            listele_islemler();
            kasagetir();
            temizle();
            txtMiktar.Text = "";

        }
        private void btnSatisYap1_Click(object sender, EventArgs e) //SATIŞ YAP BUTONU
        {

            string errormessage = "";

            if (string.IsNullOrEmpty(txtAdSoyad.Text))
            {
                errormessage += "Ad Soyad boş bırakılamaz.\n";
                lblAdSoyad.ForeColor = Color.Red;

            }

            else if (!IsValidName(txtAdSoyad.Text))
            {
                errormessage += "Ad Soyad özel karakter veya sayı içeremez.\n";
                lblAdSoyad.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(txtMiktar.Text) || txtTutar.Text == "00,00")
            {
                errormessage += "Miktar boş veya 0 olamaz, geçerli bir miktar girin.\n";
                lblMiktar.ForeColor = Color.Red;
            }

            if (mskTC.Text.Length < mskTC.Mask.Length)
            {
                errormessage += "TC Kimlik No alanını eksiksiz doldurunuz.\n";
                lblTC.ForeColor = Color.Red;
            }

            if (!string.IsNullOrEmpty(errormessage))
            {
                MessageBox.Show(errormessage);
                return;
            }

            errormessage = "";


            conn.Open();
            if (rdbUSD.Checked == true && rdbSatis.Checked == true) //DOLAR SATIŞI YAPILIYORSA
            {
                if (decimal.Parse(txtTutar.Text) > decimal.Parse(lblUSD.Text)) //KASA KONTROL
                {
                    MessageBox.Show("Kasada işlemi gerçekleştirmek için yeterli USD bulunmamaktadır");
                    return;
                }

                else
                {
                    SqlCommand cmd = new SqlCommand("Update TBLKASA set DOLAR-=@p1,TL+=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(txtTutar.Text));
                    cmd.Parameters.AddWithValue("@p2", Convert.ToDecimal(txtMiktar.Text));
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("Insert into TBLISLEMLER (islemtipi,alınanTutar,verilenTutar,musteriTC,MusteriAdSoyad) values(@1,@2,@3,@4,@5)", conn);
                    cmd2.Parameters.AddWithValue("@1", "Dolar Satışı");
                    cmd2.Parameters.AddWithValue("@2", decimal.Parse(txtMiktar.Text));
                    cmd2.Parameters.AddWithValue("@3", decimal.Parse(txtTutar.Text));
                    cmd2.Parameters.AddWithValue("@4", mskTC.Text);
                    cmd2.Parameters.AddWithValue("@5", txtAdSoyad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Dolar satışı gerçekleşmiştir");
                }
            }

            if (rdbEur.Checked == true && rdbSatis.Checked == true) //EURO SATIŞI YAPILIYORSA
            {
                if (decimal.Parse(txtTutar.Text) > decimal.Parse(lblEUR.Text)) //KASA KONTROL
                {
                    MessageBox.Show("Kasada işlemi gerçekleştirmek için yeterli EUR bulunmamaktadır");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update TBLKASA set EURO-=@p1,TL+=@p2", conn);
                    cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(txtTutar.Text));
                    cmd.Parameters.AddWithValue("@p2", Convert.ToDecimal(txtMiktar.Text));
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("Insert into TBLISLEMLER (islemtipi,alınanTutar,verilenTutar,musteriTC,MusteriAdSoyad) values(@1,@2,@3,@4,@5)", conn);
                    cmd2.Parameters.AddWithValue("@1", "Euro Satışı");
                    cmd2.Parameters.AddWithValue("@2", decimal.Parse(txtMiktar.Text));
                    cmd2.Parameters.AddWithValue("@3", decimal.Parse(txtTutar.Text));
                    cmd2.Parameters.AddWithValue("@4", mskTC.Text);
                    cmd2.Parameters.AddWithValue("@5", txtAdSoyad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Euro satışı gerçekleşmiştir");
                }
            }
            conn.Close();
            listele_islemler();
            kasagetir();
            temizle();
            txtMiktar.Text = "";
        }

        private void btnIslemler_Click(object sender, EventArgs e) //geçmiş işlemleri listeleme butonu
        {
            listele_islemler();
        }

        private void btnislemiptal_Click(object sender, EventArgs e) //işlem iptal etme butonu
        {
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //seçilen işleme ait bilgileri textboxa taşıma
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            txtAdSoyad.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            mskTC.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtMiktar.Focus();
        }

        private void btnSorgula_Click(object sender, EventArgs e) //işlem sorgulama formuna yönlendirme
        {
            islemSorgula f = new islemSorgula();
            f.Show();
        }
    }
}