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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoVet
{
    public partial class Vet : Form
    {
        SqlConnection con2 = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\gonxa\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

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

        #region Animal

        /// <summary>
        /// Inserir Animal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            SqlConnection con2 = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\gonxa\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("insert into Animais values (@Id,@nome,@dataNasc,@dataUltiConsu,@tipo,@raca,@sexo,@peso,@dono_contacto)", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", nomeTxt.Text);
            cmd.Parameters.AddWithValue("@dataNasc", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@dataUltiConsu", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@tipo", tipotxt.Text);
            cmd.Parameters.AddWithValue("@raca", Racatxt.Text);
            cmd.Parameters.AddWithValue("@sexo", sexoTxt.Text);
            cmd.Parameters.AddWithValue("@peso", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dono_contacto", donoContacottxt.Text);
            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Dados do Bicho adicionados");
        }

        /// <summary>
        /// Atualizar animal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();
            con2.Open();
            SqlCommand cmd = new SqlCommand("Update Animais set nome= @nome, dataNasc= @dataNasc, tipo= @tipo, raca= @raca, sexo= @sexo, peso= @peso, dono_contacto= @dono_contacto where Id = @Id", con2);

            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", nomeTxt.Text);
            cmd.Parameters.AddWithValue("@dataNasc", dateTimePicker1.Value);

            cmd.Parameters.AddWithValue("@tipo", tipotxt.Text);
            cmd.Parameters.AddWithValue("@raca", Racatxt.Text);
            cmd.Parameters.AddWithValue("@sexo", sexoTxt.Text);
            cmd.Parameters.AddWithValue("@peso", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dono_contacto", donoContacottxt.Text);
            //Restantes Campos
            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Atualizado com Sucesso");
        }

        /// <summary>
        /// Apagar aninal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("Delete Animais where Id = @Id", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Apagado com Sucesso");
        }

        /// <summary>
        /// Pesquisar animais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]") && textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

                {
                    if (con2.State == ConnectionState.Closed)
                        con2.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from Animais where Id like '%" + textBox1.Text + "%'", con2);
                cmd1.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd1;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            else if (textBox1.Text == "")
            {
                SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
                {
                    if (con2.State == ConnectionState.Closed)
                        con2.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from Animais ", con2);


                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd1;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("So Ids");
                textBox1.Text.Remove(textBox1.Text.Length - 1);
            }


        }

        #endregion

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

            con2.Open();
            SqlCommand cmd = new SqlCommand("Delete Animais where Id = @Id", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Apagado com Sucesso");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            SqlConnection con2 = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\gonxa\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

            con2.Open();
            SqlCommand cmd = new SqlCommand("insert into Animais values (@Id,@nome,@dataNasc,@tipo,@raca,@sexo,@peso,@dono_contacto)", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dataNasc", dateTimePicker1.Value);

            cmd.Parameters.AddWithValue("@tipo", tipotxt.Text);
            cmd.Parameters.AddWithValue("@raca", Racatxt.Text);
            cmd.Parameters.AddWithValue("@sexo", sexoTxt.Text);
            cmd.Parameters.AddWithValue("@peso", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dono_contacto", donoContacottxt.Text);
            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Dados do Bicho adicionados");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("Update Animais set nome= @nome, dataNasc= @dataNasc, tipo= @tipo, raca= @raca, sexo= @sexo, peso= @peso, dono_contacot= @dono_contacto where Id = @Id", con2);

            cmd.Parameters.AddWithValue("@Id", int.Parse(idTxt.Text));
            cmd.Parameters.AddWithValue("@nome", nomeTxt.Text);
            cmd.Parameters.AddWithValue("@dataNasc", dateTimePicker1.Value);

            cmd.Parameters.AddWithValue("@tipo", tipotxt.Text);
            cmd.Parameters.AddWithValue("@raca", Racatxt.Text);
            cmd.Parameters.AddWithValue("@sexo", sexoTxt.Text);
            cmd.Parameters.AddWithValue("@peso", pesoTxt.Text);
            cmd.Parameters.AddWithValue("@dono_contacto", donoContacottxt.Text);
            //Restantes Campos
            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Atualizado com Sucesso");
        }       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }


        //Medicos

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
 
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]") && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
                {
                    if (con2.State == ConnectionState.Closed)
                        con2.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from Medicos where Id like '%" + textBox2.Text + "%'", con2);
                cmd1.Parameters.AddWithValue("@Id", int.Parse(textBox2.Text));

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd1;
                dt.Clear();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            else if (textBox2.Text == "")
            {
                SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
                {
                    if (con2.State == ConnectionState.Closed)
                        con2.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from Medicos ", con2);


                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd1;
                dt.Clear();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            else
            {
                MessageBox.Show("So Ids");
                //textBox1.Text.Remove(textBox1.Text.Length - 1);
            }

            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]"))
            //{
            //    SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            //    {
            //        if (con2.State == ConnectionState.Closed)
            //            con2.Open();
            //    }
            //    SqlCommand cmd1 = new SqlCommand("select * from Medicos where Id like '%" + textBox2.Text + "%'", con2);
            //    cmd1.Parameters.AddWithValue("@Id", int.Parse(textBox2.Text));

            //    SqlDataAdapter da = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    da.SelectCommand = cmd1;
            //    dt.Clear();
            //    da.Fill(dt);

            //    dataGridView2.DataSource = dt;
            //}
            //else
            //{
            //    MessageBox.Show("So Ids");
            //    textBox1.Text.Remove(textBox1.Text.Length - 1);
            //}
        }

        private void apagarbtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("Delete Medicos where Id = @Id", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Apagado com Sucesso");
        }

        private void inserirbtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("insert into Medicos values (@Id,@nome,@contacto)", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@nome", textBox8.Text);
            cmd.Parameters.AddWithValue("@contacto", int.Parse(textBox6.Text));

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Dados do Medico adicionados");
        }

        private void atualizarbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("Update Medicos set nome= @nome,contacto= @contacto  where Id = @Id", con2);

            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@nome", textBox8.Text);
            cmd.Parameters.AddWithValue("@contacto", textBox6.Text);

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Atualizado com Sucesso");
        }

        private void Mostrar_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            {
                if (con.State == ConnectionState.Closed)
                    con2.Close();
                    con2.Open();
            }
            SqlCommand cmd1 = new SqlCommand("select * from Medicos ", con2);


            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);

            dataGridView2.DataSource = dt;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            {
                if (con2.State == ConnectionState.Closed)
                    con2.Open();
            }
            SqlCommand cmd1 = new SqlCommand("select * from Animais ", con2);


            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void apgbtn_Click(object sender, EventArgs e)
        {

        }

        

        

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxIdAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControlAgendarConsultas_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            SqlConnection con2 = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\gonxa\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

            //{
            //    if (con2.State == ConnectionState.Closed)
            //        con2.Open();
            //}

            try
            {
                con2.Open();
                string sql = "SELECT * From Medicos";

                SqlCommand CMD = new SqlCommand(sql, con2);
                SqlDataReader reader = CMD.ExecuteReader();
                comboBoxMedico.Items.Clear();

                while (reader.Read())
                {
                    comboBoxMedico.Items.Add(reader["Id"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ID's de médicos: " + ex.Message);
            }
            finally
            {
                con2.Close();
            }

            try
            {
                con2.Open();
                string sql = "SELECT * FROM Animais";

                SqlCommand CMD = new SqlCommand(sql, con2);
                SqlDataReader reader = CMD.ExecuteReader();
                comboBoxIdAnimal.Items.Clear();

                while (reader.Read())
                {
                    comboBoxIdAnimal.Items.Add(reader["Id"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar ID's de animais: " + ex.Message);
            }
            finally
            {
                con2.Close();
            }
            //SqlCommand cmd1 = new SqlCommand("select * from Animais ", con2);


            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cmd1;
            //dt.Clear();
            //da.Fill(dt);

            ////comboBoxIdAnimal.DataSource = dt;
            //comboBoxIdAnimal.Items.Add(dt);
        }

        #region Cosultas 

        /// <summary>
        /// Inserir consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();
            con2.Open();

            //string sqlAnimal = "SELECT Id FROM Animais Where nome ";
            //string sqlMedico = "SELECT * FROM Medicos";

            //SqlCommand cmdAnimal = new SqlCommand(sqlAnimal, con2);
            //SqlCommand cmdMedico = new SqlCommand(sqlMedico, con2);

            //SqlDataReader readerAnimal = cmdAnimal.ExecuteReader();
            //SqlDataReader readerMedico = cmdMedico.ExecuteReader();

            //dynamic medico = comboBoxIdAnimal.SelectedItem;
            //int idMedico = medico.Id;

            SqlCommand cmd = new SqlCommand("insert into Consultas values(@Id,@Animais_Id,@Medicos_Id,@Descrição,@Hora,@Tipo,@diagnostico,@prescricao,@ProximaData)", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxIdConsulta.Text));
            cmd.Parameters.AddWithValue("@Animais_Id", comboBoxIdAnimal.SelectedItem);
            cmd.Parameters.AddWithValue("@Medicos_Id", comboBoxMedico.SelectedItem);
            cmd.Parameters.AddWithValue("@Descrição", textBoxObs.Text);
            cmd.Parameters.AddWithValue("@Hora", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Tipo", textBoxTipoConsulta.Text);
            cmd.Parameters.AddWithValue("@diagnostico", textBoxDiagnostico.Text);
            cmd.Parameters.AddWithValue("@prescricao", textBoxPrescricao.Text);
            cmd.Parameters.AddWithValue("@ProximaData", dateTimePickerProximaData.Value);


            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Dados da consulta adicionados");


        }

        /// <summary>
        /// Atualizar Consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");

            con2.Close();

            con2.Open();
            SqlCommand cmd = new SqlCommand("Update Consultas set Id= @Id, Animais_Id= @Animais_Id, Medicos_Id= @Medicos_Id, Descrição= @Descrição, Hora= @Hora, Tipo= @Tipo, diagnostico= @diagnostico, prescricao= @prescricao, ProximaData= @ProximaData)", con2);

            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxIdConsulta.Text));
            cmd.Parameters.AddWithValue("@Animais_Id", comboBoxIdAnimal.SelectedItem);
            cmd.Parameters.AddWithValue("@Medicos_Id", comboBoxMedico.SelectedItem);
            cmd.Parameters.AddWithValue("@Descrição", textBoxObs.Text);
            cmd.Parameters.AddWithValue("@Hora", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Tipo", textBoxTipoConsulta.Text);
            cmd.Parameters.AddWithValue("@diagnostico", textBoxDiagnostico.Text);
            cmd.Parameters.AddWithValue("@prescricao", textBoxPrescricao.Text);
            cmd.Parameters.AddWithValue("@ProximaData", dateTimePickerProximaData.Value);

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Atualizado com Sucesso");
        }

        /// <summary>
        /// Apagar Consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apgbtn_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            con2.Close();
            con2.Open();
            SqlCommand cmd = new SqlCommand("Delete Consultas where Id = @Id", con2);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBoxIdConsulta.Text));

            cmd.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Apagado com Sucesso");
        }

        /// <summary>
        /// Evento click do botão Mostrar consultas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\pedro\\source\\repos\\ProjetoVet\\ProjetoVet\\DBAnimais.mdf; Integrated Security = True\r\n");
            {
                if (con2.State == ConnectionState.Closed)
                    con2.Open();
            }
            SqlCommand cmd1 = new SqlCommand("select * from Consultas ", con2);


            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);

            dataGridView3.DataSource = dt;

        }

        #endregion
    }
}

