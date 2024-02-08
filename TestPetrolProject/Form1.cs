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
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listele();


		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			double kursunsuz95, litre, tutar;
			kursunsuz95 =Convert.ToDouble(LblKursunsuz95.Text)*Convert.ToDouble(numericUpDown1.Value);
			Txtkursunsuz95fiyat.Text =kursunsuz95.ToString();
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			double kursunsuz97, litre, tutar;
			kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text) * Convert.ToDouble(numericUpDown2.Value);
			Txtkursunsuz97fiyat.Text = kursunsuz97.ToString();
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			double EuroDizel, litre, tutar;
			EuroDizel = Convert.ToDouble(LblEuroDizel.Text) * Convert.ToDouble(numericUpDown3.Value);
			TxtEurodizelfiyat.Text = EuroDizel.ToString();
		}
		private void numericUpDown4_ValueChanged(object sender, EventArgs e)
		{
			double yeniProDizel, litre, tutar;
			yeniProDizel = Convert.ToDouble(LblYeniProDizel.Text) * Convert.ToDouble(numericUpDown4.Value);
			Txtyeniprodizefiyat.Text = yeniProDizel.ToString();
		}

		private void numericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			double gaz, litre, tutar;
			gaz = Convert.ToDouble(LblGaz.Text) * Convert.ToDouble(numericUpDown5.Value);
			Txtgazfiyat.Text = gaz.ToString();
		}
	}
}
