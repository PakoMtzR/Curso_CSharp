using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SistemaVentasFerreteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Configuracion para conectarse a la base de datos
        IFirebaseConfig fconfing = new FirebaseConfig()
        {
            AuthSecret = "ZHwRnpmGBioVRUUtqlviNZ8DqA6PTfWC9rulGCIq",
            BasePath = "https://ferreteria-94e73-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        // Creando la variable total para guardar el total a pagar de la compra
        double total = 0;   // <-- Variable Global

        private void Form1_Load(object sender, EventArgs e)
        {
            // Intenta establecer conexion con la base de datos
            try
            {
                client = new FireSharp.FirebaseClient(fconfing);
                generarTabla();
            }
            catch { MessageBox.Show("[Error de conexión]: No fue posible conectarse a la base de datos, intentelo mas tarde."); }
        }

        //=================================================================================
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxID.Text.Trim().Length > 0)
                textBoxCant.Enabled = true;
            else textBoxCant.Enabled = false;
        }
        private void textBoxCant_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCant.Text.Trim().Length > 0)
                buttonAgregar.Enabled = true;
            else buttonAgregar.Enabled = false;
        }

        // Boton Agregar
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturamos la cantidad de articulos que requiere el usuario
                int cantidad = Convert.ToInt32(textBoxCant.Text);

                // Accedemos al directorio de la base de datos donde se encuentra el articulo "MiInventario/ID"
                var data = client.Get("MiInventario/" + textBoxID.Text);

                //Guardamos la respuesta en un objeto de la clase producto
                Producto producto = data.ResultAs<Producto>();

                if (producto != null)
                {
                    // Verificamos si existen suficientes existencias del articulo
                    if (cantidad <= producto.stock)
                    {
                        // Vaciamos los datos en la tabla
                        TablaVentas.Rows.Add(producto.ID, producto.nombre, producto.marca, producto.precio, cantidad.ToString(), (producto.precio * cantidad).ToString());

                        // sumamos al total a pagar
                        total += producto.precio * cantidad;
                        labelTOTAL.Text = "$" + total.ToString();
                    }
                    else if (producto.stock != 0)
                    {
                        // No hay suficientes existencias
                        MessageBox.Show("Solo hay " + producto.stock.ToString() + " existencias de este articulo");
                    }
                    else MessageBox.Show("No hay existencias de este articulo");
                }
                else
                {
                    // Entonces el articulo que buscan no esta en el inventario
                    MessageBox.Show("El articulo no existe en el inventario");
                }
                // Limpiamos los cuadros de texto
                textBoxID.Clear();
                textBoxCant.Clear();
            }
            catch { MessageBox.Show("[ERROR]: Error del Sistema :'v"); } // No se pudo agregar el producto al "carrito" (tabla)
        }

        // Boton Realizar Compra
        private void buttonCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Recorremos los articulos reglon por renglon
                for (int i = 0; i < TablaVentas.RowCount - 1; i++)
                {
                    // Obtenemos los datos del articulo para poder actualizarlos
                    var result = client.Get("MiInventario/" + TablaVentas.Rows[i].Cells[0].Value.ToString());
                    Producto producto = result.ResultAs<Producto>();

                    // Actualizamos el stock del articulo
                    Producto actualizacion = new Producto()
                    {
                        nombre = producto.nombre,
                        ID = producto.ID,
                        marca = producto.marca,
                        precio = producto.precio,
                        stock = producto.stock - Convert.ToInt32(TablaVentas.Rows[i].Cells[4].Value)
                    };
                    var setter = client.Update("MiInventario/" + TablaVentas.Rows[i].Cells[0].Value.ToString(), actualizacion);
                }
                generarTabla(); // Regeneramos la tabla en limpio
                MessageBox.Show("Compra Exitosa!"); // Mensaje de proceso completado
            }
            catch { MessageBox.Show("[ERROR]: No se pudo realizar la compra"); }  
        }

        // Cancelar la compra
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            generarTabla();
        }

        //======================================================
        //  Opciones: 
        //======================================================
        // Abrimos el gestor de Inventario
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 inventario = new Form2();
            inventario.ShowDialog();
        }

        // Ver el inventario
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 verInventario = new Form3();
            verInventario.Show();
        }

        // Cerramos la ventana
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //======================================================
        //  Funcoines Secundarias
        //======================================================
        // Generamos la tabla
        public void generarTabla()
        {
            // Limpiamos los cuadros de Texto
            textBoxID.Clear();
            textBoxCant.Clear();

            // Limpiamos la tabla
            TablaVentas.Rows.Clear();

            // Limpiamos el total
            total = 0;
            labelTOTAL.Text = "$ " + total.ToString();
        }
    }
}