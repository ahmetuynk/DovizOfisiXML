using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DövizOfisiXML
{
    public partial class islemSorgula : Form
    {
        public islemSorgula()
        {
            InitializeComponent();
        }

        //Kendi sunucu adınızı /* */ arasındaki alanına yapıştırın ve arından /* */ ları silin:
        SqlConnection conn = new SqlConnection("//Data Source =/* */; Initial Catalog = Doviz; Integrated Security = True");

        void tipegöresorgula()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from TBLISLEMLER where islemTipi=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", islemtipi);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            islemtipi = "";
        }

        private void button1_Click(object sender, EventArgs e) //TC KIMLIGE GORE SORGU
        {
            if (mskTCN.Text.Length < mskTCN.Mask.Length)
            {
                MessageBox.Show("TC Kimlik No alanını eksiksiz doldurunuz");
                mskTCN.Focus();
                return;
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLISLEMLER where musteriTC=" + mskTCN.Text, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mskTCN.Text = "";
        }

        string islemtipi;

        private void button2_Click(object sender, EventArgs e)
        {
            islemtipi = "Dolar Alışı";
            tipegöresorgula();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            islemtipi = "Dolar Satışı";
            tipegöresorgula();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            islemtipi = "Euro Alışı";
            tipegöresorgula();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            islemtipi = "Euro Satışı";
            tipegöresorgula();
        }

        private void button3_Click(object sender, EventArgs e)//TARİHE GÇRE SORGULAMA
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLISLEMLER WHERE CONVERT(date, Tarih)=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", dateTimePicker1.Value.Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void txtIsım_TextChanged(object sender, EventArgs e) //İSME GÖRE SORGULAMA
        {
            string metin = "%" + txtIsım.Text + "%";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from TBLISLEMLER where musteriAdSoyad like @metin", conn);
            cmd.Parameters.AddWithValue("@metin", metin);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void mskTCN_TextChanged(object sender, EventArgs e)
        {
            string tc = Convert.ToString(mskTCN.Text);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLISLEMLER WHERE musteriTC LIKE @tc+'%'", conn);
            cmd.Parameters.AddWithValue("@tc", tc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaForm fr = new AnaForm();
            fr.Show();
            this.Hide();
        }


    }
}

