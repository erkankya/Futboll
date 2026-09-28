using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace proje
{
    public partial class Anasayfa : Form
    {
        string yol;
        OleDbConnection baglanti;

        public Anasayfa()
        {
            InitializeComponent();
            
            
            yol = Application.StartupPath + @"\futbol.accdb";

            baglanti = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + yol);
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void süperligToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LigGetir(1);
        }

        private void bundesligaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LigGetir(2);
        }

        private void premierligToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LigGetir(3);
        }

        private void laligaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LigGetir(4);
        }

        private void lig1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LigGetir(5);
        }

        private void LigGetir(int ligID)
        {
            DataTable dt = new DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter(
            "SELECT * FROM Takimlar WHERE LigID=" + ligID, baglanti);

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void takımlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataGetir("SELECT * FROM Takimlar");
        }

        private void oyuncularToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataGetir("SELECT * FROM Oyuncular");
        }

        private void DataGetir(string sql)
        {
            DataTable dt = new DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter(sql, baglanti);

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
