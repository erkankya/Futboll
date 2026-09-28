using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace proje
{
    public partial class TakimEkle : Form
    {

        string yol;
        OleDbConnection baglanti;
        private string resimyolu;

        public TakimEkle()
        {
            InitializeComponent();

            yol = Application.StartupPath + @"\futbol.accdb";

            baglanti = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + yol);
        }

        private void TakimEkle_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT LigID, LigAdi FROM Ligler", baglanti);
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "LigAdi";
            comboBox1.ValueMember = "LigID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sec = new OpenFileDialog();
            sec.Filter = "Resim|*.jpg;*.png;*.jpeg";

            if (sec.ShowDialog() == DialogResult.OK)
            {
                resimyolu = sec.FileName;
                pictureBox1.Image = Image.FromFile(resimyolu);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();

                baglanti.Open();

                string sql = "INSERT INTO Takimlar (TakimAdi, LigID, Baskan, KurulusTarihi) VALUES ('"
                    + textBox1.Text + "', '"
                    + comboBox1.SelectedValue.ToString() + "', '"
                    + textBox2.Text + "', '"
                    + textBox3.Text + "')";

                OleDbCommand komut = new OleDbCommand(sql, baglanti);
                komut.ExecuteNonQuery();

                byte[] resim = null;

                if (resimyolu != "")
                    resim = File.ReadAllBytes(resimyolu);

                if (resim != null)
                {
                    OleDbCommand komut2 = new OleDbCommand("SELECT MAX(TakimID) FROM Takimlar", baglanti);
                    int id = Convert.ToInt32(komut2.ExecuteScalar());

                    OleDbCommand komut3 = new OleDbCommand("UPDATE Takimlar SET Logo=? WHERE TakimID=" + id, baglanti);
                    komut3.Parameters.AddWithValue("@p1", resim);
                    komut3.ExecuteNonQuery();
                }

                MessageBox.Show("Takım eklendi");

                textBox1.Clear(); // takım adı
                textBox2.Clear(); // başkan
                textBox3.Clear(); // (varsa ek alan)

                pictureBox1.Image = null;

                comboBox1.SelectedIndex = -1;

                

                resimyolu = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }
    }
}