using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Compucentro
{
    public partial class DatosServicio : BaseSalir
    {
        public DatosServicio()
        {
            InitializeComponent();
        }

        private void DatosServicio_Load(object sender, EventArgs e)
        {
           
        }

        public string ConsultaOrden()
        {
            conexion.Conectar();
            string query = "select max (idOrden) as ID from Orden";
            SqlCommand cmd = new SqlCommand(query, conexion.Conectar());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["ID"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public void InsertaOrdenServicio()
        {
            conexion.Conectar();
            string Alta = dateRecepcion.Value.ToShortDateString();
            string insertar = "INSERT INTO Orden(Status,FechaRecepcion) VALUES(@FechaRecepcion,@Status)";
            SqlCommand cmd1 = new SqlCommand(insertar, conexion.Conectar());
            cmd1.Parameters.AddWithValue("@FechaRecepcion", Alta);
            cmd1.Parameters.AddWithValue("@Status", 1);

            cmd1.ExecuteNonQuery();
            //MessageBox.Show("Los datos fueron agregados con exito");
        }

        public void InsertaUsuario()
        {
            conexion.Conectar();
            string Alta = dateRecepcion.Value.ToShortDateString();
            string insertar = "insert into Usuario(idRango,Nombre,Paterno,Materno,Telefono,Celular,Direccion) VALUES (@rango,@nombre,@paterno,@materno,@telefono,@celular,@direccion)";
            SqlCommand cmd1 = new SqlCommand(insertar, conexion.Conectar());
            cmd1.Parameters.AddWithValue("@rango", 1);
            cmd1.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@paterno", txtPaterno.Text);
            cmd1.Parameters.AddWithValue("@materno", txtMaterno.Text);
            cmd1.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd1.Parameters.AddWithValue("@celular", txtCelular.Text);
            cmd1.Parameters.AddWithValue("@direccion", txtDireccion.Text);

            cmd1.ExecuteNonQuery();
            //MessageBox.Show("Los datos fueron agregados con exito");
        }

        public void InsertaEquipo()
        {
            conexion.Conectar();
            string insertar = "insert into Equipo(Tipo,Modelo,Serie) values (@Tipo,@Modelo,@Serie)";
            SqlCommand cmd1 = new SqlCommand(insertar, conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Tipo", cmbTipo.Text);
            cmd1.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            cmd1.Parameters.AddWithValue("@Serie", txtSerie.Text);

            cmd1.ExecuteNonQuery();
            //MessageBox.Show("Los datos fueron agregados con exito");
        }

        public void InsertaComplemento()
        {
            conexion.Conectar();
            string insertar = "insert into Complemento(accesorios,fallaC) values (@accesorios,@fallaC)";
            SqlCommand cmd1 = new SqlCommand(insertar, conexion.Conectar());
            cmd1.Parameters.AddWithValue("@accesorios", txtAccesorios.Text);
            cmd1.Parameters.AddWithValue("@fallaC", txtFalla.Text);

            cmd1.ExecuteNonQuery();
            //MessageBox.Show("Los datos fueron agregados con exito");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas efectuar una nueva orden de servicio? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                 InsertaOrdenServicio();
                txtOrden.Text = ConsultaOrden();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas guardar el servicio servicio? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                InsertaUsuario();
                InsertaEquipo();
                InsertaComplemento();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Imprimir;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            //Font tipoTexto = new Font("Arial", 10, FontStyle.Bold);
            Font font = new Font("Arial", 10, FontStyle.Bold);
             e.Graphics.DrawImage(pictureBox1.Image, 2, 5);
            /* e.Graphics.DrawString(txtTitulo.Text, font, Brushes.Black, new Rectangle(65, 10, 150, 20));
             //e.Graphics.DrawString(txtTitulo.Text, font, Brushes.Black, 50, 130);
             Bitmap varbmp = new Bitmap(este.Image);
             Image img = este.Image;
             e.Graphics.DrawImage(img, new Rectangle(20, 30, 185, 50));
             e.Graphics.DrawString("*" + txtCodigo.Text + "*", font, Brushes.Black, new Rectangle(75, 85, 150, 20)); */
        }
    }
}
