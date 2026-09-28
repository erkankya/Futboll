using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace proje
{
    public partial class Listeleme : Form
    {
        string yol;
        OleDbConnection baglanti;
        string tabloAdi = "";
        DataTable dt = new DataTable();

        public Listeleme()
        {
            InitializeComponent();

            yol = Application.StartupPath + @"\futbol.accdb";

            baglanti = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + yol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                tabloAdi = "Ligler";
            else if (radioButton2.Checked)
                tabloAdi = "Takimlar";
            else if (radioButton3.Checked)
                tabloAdi = "Oyuncular";
            else
            {
                MessageBox.Show("Seçim yapınız");
                return;
            }

            dt.Clear();

            OleDbDataAdapter da = new OleDbDataAdapter(
            "SELECT * FROM " + tabloAdi, baglanti);

            da.Fill(dt);

            listBox1.DataSource = null;

            if (tabloAdi == "Ligler")
            {
                listBox1.DisplayMember = "LigAdi";
                listBox1.ValueMember = "LigID";
            }
            else if (tabloAdi == "Takimlar")
            {
                listBox1.DisplayMember = "TakimAdi";
                listBox1.ValueMember = "TakimID";
            }
            else if (tabloAdi == "Oyuncular")
            {
                listBox1.DisplayMember = "AdSoyad";
                listBox1.ValueMember = "OyuncuID";
            }

            listBox1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null || tabloAdi == "")
            {
                MessageBox.Show("Silinecek öğe seçiniz");
                return;
            }

            baglanti.Open();

            int id = Convert.ToInt32(listBox1.SelectedValue);

            
            int takimID = 0;

            if (tabloAdi == "Oyuncular")
            {
                OleDbCommand getir = new OleDbCommand(
                "SELECT TakimID FROM Oyuncular WHERE OyuncuID=?", baglanti);

                getir.Parameters.AddWithValue("@p1", id);

                object sonuc = getir.ExecuteScalar();

                if (sonuc != null && sonuc != DBNull.Value)
                    takimID = Convert.ToInt32(sonuc);
            }

            
            string idKolon = "";

            if (tabloAdi == "Ligler") idKolon = "LigID";
            else if (tabloAdi == "Takimlar") idKolon = "TakimID";
            else if (tabloAdi == "Oyuncular") idKolon = "OyuncuID";

            OleDbCommand sil = new OleDbCommand(
            "DELETE FROM " + tabloAdi + " WHERE " + idKolon + "=?", baglanti);

            sil.Parameters.AddWithValue("@p1", id);
            sil.ExecuteNonQuery();

            if (tabloAdi == "Oyuncular")
                TakimDegerHesapla(takimID);

            baglanti.Close();

            MessageBox.Show("Silindi");

            button1_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null)
            {
                MessageBox.Show("Oyuncu seç");
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Yeni değer gir");
                return;
            }

            baglanti.Open();

            int oyuncuID = Convert.ToInt32(listBox1.SelectedValue);

            OleDbCommand getir = new OleDbCommand(
            "SELECT TakimID FROM Oyuncular WHERE OyuncuID=?", baglanti);

            getir.Parameters.AddWithValue("@p1", oyuncuID);

            int takimID = Convert.ToInt32(getir.ExecuteScalar());

            OleDbCommand guncelle = new OleDbCommand(
            "UPDATE Oyuncular SET degeri=? WHERE OyuncuID=?", baglanti);

            guncelle.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            guncelle.Parameters.AddWithValue("@p2", oyuncuID);

            guncelle.ExecuteNonQuery();

            TakimDegerHesapla(takimID);

            baglanti.Close();

            MessageBox.Show("Güncellendi");

            textBox1.Clear();
            button1_Click(null, null);
        }

        private void TakimDegerHesapla(int takimID)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            // oyuncu toplamı
            OleDbCommand toplam = new OleDbCommand(
            "SELECT SUM(degeri) FROM Oyuncular WHERE TakimID=" + takimID,
            baglanti);

            object sonuc = toplam.ExecuteScalar();

            int toplamDeger = 0;

            if (sonuc != null && sonuc != DBNull.Value)
                toplamDeger = Convert.ToInt32(sonuc);

            // ✅ DÜZELTİLEN SATIR
            OleDbCommand guncelle = new OleDbCommand(
            "UPDATE Takimlar SET degeri=" + toplamDeger + " WHERE TakimID=" + takimID,
            baglanti);

            guncelle.ExecuteNonQuery();

            baglanti.Close();
        }
    }
}
