using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace proje
{
    public partial class TakimDetay : Form
    {
        OleDbConnection baglanti;

        public TakimDetay()
        {
            InitializeComponent();

            baglanti = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            Application.StartupPath + @"\futbol.accdb");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Takım adı giriniz");
                return;
            }

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                OleDbCommand komut = new OleDbCommand(
                "SELECT * FROM Takimlar WHERE TakimAdi = ?", baglanti);

                komut.Parameters.AddWithValue("@p1", textBox1.Text);

                OleDbDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    textBox2.Text = dr["TakimAdi"].ToString();
                    textBox3.Text = dr["Baskan"].ToString();
                    textBox5.Text = dr["degeri"] != DBNull.Value ? dr["degeri"].ToString() : "";

                    int takimID = Convert.ToInt32(dr["TakimID"]);

                    // ✅ LOGO
                    if (dr["Logo"] != DBNull.Value)
                    {
                        byte[] resim = (byte[])dr["Logo"];
                        MemoryStream ms = new MemoryStream(resim);
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }

                    dr.Close();

                    // ✅ OYUNCU LİSTESİ (DÜZELTİLDİ)
                    DataTable dt = new DataTable();

                    OleDbDataAdapter da = new OleDbDataAdapter(
                    "SELECT AdSoyad, Pozisyon, Uyruk, degeri FROM Oyuncular WHERE TakimID=" + takimID,
                    baglanti);

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Takım bulunamadı");
                }

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}