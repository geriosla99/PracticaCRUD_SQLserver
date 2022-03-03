using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PracticaCRUD_SQLserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("conexion existosa");

            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {

            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PracticaGrafica";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtTelefono.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtCodigo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO PracticaGrafica (telfono, direccion, nombre, codigoAlumno)VALUES(@telfono, @direccion, @nombre, @codigoAlumno)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@telfono", txtTelefono.Text);
            cmd1.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd1.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@codigoAlumno", txtCodigo.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron AGREGADOS con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE PracticaGrafica SET telfono=@telfono, direccion=@direccion, nombre=@nombre, codigoAlumno=@codigoAlumno WHERE codigoAlumno=@codigoAlumno";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@telfono", txtTelefono.Text);
            cmd2.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@codigoAlumno", txtCodigo.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron ACTUAILIZADOS con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Conexion.Conectar();
            string eliminar = "DELETE FROM PracticaGrafica WHERE codigoAlumno=@codigoAlumno";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

            cmd3.Parameters.AddWithValue("@telfono", txtTelefono.Text);
            cmd3.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd3.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd3.Parameters.AddWithValue("@codigoAlumno", txtCodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron ELIMINADOS con exito");

            dataGridView1.DataSource = llenar_grid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
        }
    }
}
