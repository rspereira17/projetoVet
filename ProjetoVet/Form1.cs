using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoVet
{
    public partial class Vet : Form
    {
        public Vet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Animais values (@Id,@nome,@dataNasc,@dataUltiConsu,@tipo,@raca,@sexo,@peso)", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dataNasc", dataNascTxt.Text);
            cmd.Parameters.AddWithValue("@dataUltiConsu", dataConsutxt.Text);
            cmd.Parameters.AddWithValue("@tipo", tipotxt.Text);
            cmd.Parameters.AddWithValue("@raca", Racatxt.Text);
            cmd.Parameters.AddWithValue("@sexo", sexoTxt.Text);
            cmd.Parameters.AddWithValue("@peso", pesoTxt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Dados do Bicho adicionados");
        }


        

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Animais where Id = @Id", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(idTxt.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Apagado com Sucesso");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pedro\\source\\repos\\VendasProje\\VendasProje\\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Clientes set nome= @nome, email= @email, nif= @nif, profissao= @profissao where Id = @Id", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", nomeTxt.Text);
           //Restantes Campos
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Atualizado com Sucesso");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pedro\\source\\repos\\VendasProje\\VendasProje\\Database1.mdf;Integrated Security=True");
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("select * from Animais where Id like '%" + idTxt.Text + "%'", con);
            cmd1.Parameters.AddWithValue("@ID", int.Parse(idTxt.Text));

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }




    }

