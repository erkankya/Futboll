using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace proje
{
    public partial class OyuncuEkle : Form
    {
        OleDbConnection baglanti;
        string resimyolu = "";

        public OyuncuEkle()
        {
            InitializeComponent();

            // ✅ EN KRİTİK – DOĞRU BAĞLANTI
            baglanti = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            Application.StartupPath + @"\futbol.accdb");
        }

        private void OyuncuEkle_Load(object sender, EventArgs e)
        {
            // ✅ bağlantı kontrol
            if (baglanti == null)
            {
                MessageBox.Show("Bağlantı oluşturulamadı!");
                return;
            }

            DataTable dt = new DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter(
            "SELECT TakimID, TakimAdi FROM Takimlar", baglanti);

            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TakimAdi";
            comboBox1.ValueMember = "TakimID";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Oyuncu adı boş"); return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Değer boş"); return;
            }

            baglanti.Open();

            int takimID = Convert.ToInt32(comboBox1.SelectedValue);

            byte[] resim = null;
            if (resimyolu != "")
                resim = File.ReadAllBytes(resimyolu);

            // ✅ DOĞRU INSERT (kolon isimleri DB ile aynı!)
            OleDbCommand komut = new OleDbCommand(
            "INSERT INTO Oyuncular (AdSoyad, TakimID, Uyruk, Pozisyon, degeri, Ayak, DogumTarihi) " +
            "VALUES (?,?,?,?,?,?,?)", baglanti);

            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", takimID);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p4", textBox3.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@p6", textBox5.Text);
            komut.Parameters.AddWithValue("@p7", DateTime.Parse(textBox6.Text));

            komut.ExecuteNonQuery();

            // ✅ FOTO EKLEME
            if (resim != null)
            {
                OleDbCommand idcmd = new OleDbCommand(
                "SELECT MAX(OyuncuID) FROM Oyuncular", baglanti);

                int id = Convert.ToInt32(idcmd.ExecuteScalar());

                OleDbCommand guncelle = new OleDbCommand(
                "UPDATE Oyuncular SET Foto=? WHERE OyuncuID=" + id, baglanti);

                guncelle.Parameters.AddWithValue("@p1", resim);

                guncelle.ExecuteNonQuery();
            }

            // ✅ TAKIM DEĞER GÜNCELLE
            TakimDegerHesapla(takimID);

            baglanti.Close();

            MessageBox.Show("Oyuncu eklendi");

            // ✅ TEMİZLE
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            pictureBox1.Image = null;
        }

        // ✅ TAKIM DEĞER HESAP
        private void TakimDegerHesapla(int takimID)
        {
            OleDbCommand toplam = new OleDbCommand(
            "SELECT SUM(degeri) FROM Oyuncular WHERE TakimID=" + takimID,
            baglanti);

            object sonuc = toplam.ExecuteScalar();

            int toplamDeger = 0;

            if (sonuc != null && sonuc != DBNull.Value)
                toplamDeger = Convert.ToInt32(sonuc);

            OleDbCommand guncelle = new OleDbCommand(
            "UPDATE Takimlar SET degeri=" + toplamDeger + " WHERE TakimID=" + takimID,
            baglanti);

            guncelle.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog sec = new OpenFileDialog();
            sec.Filter = "Resim|*.jpg;*.png;*.jpeg";

            if (sec.ShowDialog() == DialogResult.OK)
            {
                resimyolu = sec.FileName;
                pictureBox1.Image = Image.FromFile(resimyolu);
            }
        }

        
    }
}