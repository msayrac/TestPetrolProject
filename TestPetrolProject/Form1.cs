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
using System.Security.Policy;

namespace TestPetrolProject
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		SqlConnection connection = new SqlConnection(@"Data Source=msyc;Initial Catalog=TestPetrol;Integrated Security=True");

		void listele()
		{
			//Kursunsuz95
			connection.Open();
			SqlCommand command = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Kursunsuz95'", connection);
			SqlDataReader dr = command.ExecuteReader();

			while (dr.Read())
			{
				LblKursunsuz95.Text = dr[3].ToString();
				progressBar1.Value = int.Parse(dr[4].ToString());
				LblKursunsuz95litre.Text = dr[4].ToString();
			}
			connection.Close();

			//Kursunsuz97
			connection.Open();
			SqlCommand command2 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Kursunsuz97'", connection);
			SqlDataReader dr2 = command2.ExecuteReader();

			while (dr2.Read())
			{
				LblKursunsuz97.Text = dr2[3].ToString();
				progressBar2.Value = int.Parse(dr2[4].ToString());
				LblKursunsuz97litre.Text = dr2[4].ToString();
			}
			connection.Close();

			//EuroDizel
			connection.Open();
			SqlCommand command3 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='EuroDizel10'", connection);
			SqlDataReader dr3 = command3.ExecuteReader();

			while (dr3.Read())
			{
				LblEuroDizel.Text = dr3[3].ToString();
				progressBar3.Value = int.Parse(dr3[4].ToString());
				LblEuroDizelLitre.Text = dr3[4].ToString();
			}
			connection.Close();

			//YeniProDizel        
			connection.Open();
			SqlCommand command4 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='YeniProDizel'", connection);
			SqlDataReader dr4 = command4.ExecuteReader();

			while (dr4.Read())
			{
				LblYeniProDizel.Text = dr4[3].ToString();
				progressBar4.Value = int.Parse(dr4[4].ToString());
				LblYeniProDizelLitre.Text = dr4[4].ToString();
			}
			connection.Close();

			//Gaz         
			connection.Open();
			SqlCommand command5 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Gaz'", connection);
			SqlDataReader dr5 = command5.ExecuteReader();

			while (dr5.Read())
			{
				LblGaz.Text = dr5[3].ToString();
				progressBar5.Value = int.Parse(dr5[4].ToString());
				LblGazLitre.Text = dr5[4].ToString();
			}
			connection.Close();

			connection.Open();
			SqlCommand command6 = new SqlCommand("Select * From TBLKASA", connection);

			SqlDataReader dr6 = command6.ExecuteReader();

			while (dr6.Read())
			{
				LblKasaText.Text = dr6[0].ToString();
			}
			connection.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listele();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			double kursunsuz95, litre, tutar;
			litre = Convert.ToDouble(numericUpDown1.Value);
			kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
			tutar = kursunsuz95 * litre;
			Txtkursunsuz95fiyat.Text = tutar.ToString();
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			double kursunsuz97, litre, tutar;
			litre = Convert.ToDouble(numericUpDown2.Value);
			kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
			tutar = kursunsuz97 * litre;
			Txtkursunsuz97fiyat.Text = tutar.ToString();
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			double EuroDizel, litre, tutar;
			litre = Convert.ToDouble(numericUpDown3.Value);
			EuroDizel = Convert.ToDouble(LblEuroDizel.Text);
			tutar = EuroDizel * litre;
			TxtEurodizelfiyat.Text = tutar.ToString();
		}
		private void numericUpDown4_ValueChanged(object sender, EventArgs e)
		{
			double yeniProDizel, litre, tutar;
			litre = Convert.ToDouble(numericUpDown4.Value);
			yeniProDizel = Convert.ToDouble(LblYeniProDizel.Text);
			tutar = yeniProDizel * litre;
			Txtyeniprodizefiyat.Text = tutar.ToString();
		}

		private void numericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			double gaz, litre, tutar;
			litre = Convert.ToDouble(numericUpDown5.Value);
			gaz = Convert.ToDouble(LblGaz.Text);
			tutar = gaz * litre;
			Txtgazfiyat.Text = tutar.ToString();
		}

		private void BtnDepoDoldur_Click(object sender, EventArgs e)
		{
			if (numericUpDown1.Value != 0)
			{
				connection.Open();
				SqlCommand komut = new SqlCommand("insert into TBLHARAKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);

				komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
				komut.Parameters.AddWithValue("@p2", "Kursunsuz95");
				double litre = Convert.ToDouble(numericUpDown1.Value);
				double kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);

				komut.Parameters.AddWithValue("@p3", litre.ToString());
				double tutar = litre * kursunsuz95;
				komut.Parameters.AddWithValue("@p4", decimal.Parse(tutar.ToString()));

				komut.ExecuteNonQuery();
				connection.Close();

				connection.Open();
				SqlCommand komut2 = new SqlCommand("update TBLKASA Set MIKTAR = MIKTAR+@p1", connection);

				komut2.Parameters.AddWithValue("@p1", decimal.Parse(Txtkursunsuz95fiyat.Text));
				komut2.ExecuteNonQuery();

				connection.Close();
				MessageBox.Show("Satış Yapıldı");
				connection.Open();

				SqlCommand komut3 = new SqlCommand("update TBLBENZIN Set STOK=STOK-@p1 Where PETROLTUR='Kursunsuz95'", connection);
				komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
				komut3.ExecuteNonQuery();
				connection.Close();
				listele();
			}

			if (numericUpDown2.Value != 0)
			{
				connection.Open();
				SqlCommand komut = new SqlCommand("insert into TBLHARAKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);

				komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
				komut.Parameters.AddWithValue("@p2", "Kursunsuz97");
				double litre = Convert.ToDouble(numericUpDown2.Value);
				double Kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);

				komut.Parameters.AddWithValue("@p3", litre.ToString());
				double tutar = litre * Kursunsuz97;
				komut.Parameters.AddWithValue("@p4", decimal.Parse(tutar.ToString()));

				komut.ExecuteNonQuery();
				connection.Close();

				connection.Open();
				SqlCommand komut2 = new SqlCommand("update TBLKASA Set MIKTAR = MIKTAR+@p1", connection);

				komut2.Parameters.AddWithValue("@p1", decimal.Parse(Txtkursunsuz97fiyat.Text));
				komut2.ExecuteNonQuery();

				connection.Close();
				MessageBox.Show("Satış Yapıldı");
				connection.Open();

				SqlCommand komut3 = new SqlCommand("update TBLBENZIN Set STOK=STOK-@p1 Where PETROLTUR='Kursunsuz97'", connection);
				komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
				komut3.ExecuteNonQuery();
				connection.Close();
				listele();
			}








		}
	}
}
