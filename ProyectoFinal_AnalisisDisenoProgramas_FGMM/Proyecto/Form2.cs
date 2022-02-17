using System;
using System.Collections.Generic;
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
    public partial class Form2 : Form
    {
        
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            // Intentamos establecer conexion con la base de datos
            try 
            { 
                client = new FireSharp.FirebaseClient(fconfing);
                llenarTabla();
            }
            catch { MessageBox.Show("[Error de conexión]: No fue posible conectarse a la base de datos, intentelo mas tarde."); }
        }

        // Bototn para cerrar la ventana
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //======================================================================================
        // Configuracion de las opciones Modificar/Agregar/Eliminar un producto del inventario
        //======================================================================================
        //--------------------------------------------------------------------------------------
        // 1) Modificar un producto del inventario:
        //--------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            // Configuracion Inicial de la opcion Modificar
            buttonGuardar.Enabled = true;
            buttonAgregar.Enabled = false;
            buttonEliminar.Enabled = false;

            buttonGuardar.Visible = true;
            buttonAgregar.Visible = false;
            buttonEliminar.Visible = false;

            buttonBuscarE.Visible = false;
            buttonBuscarE.Enabled = false;
            buttonBuscarM.Enabled = true;
            buttonBuscarM.Visible = true;

            habilitandoIDCampos();
            limpiarTextsBoxs();
        }

        //--------------------------------------------------------------------------------------
        // 2) Agregar un nuevo producto al inventario   
        //--------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            // Configuracion Inicial de la opcion Modificar

            buttonGuardar.Enabled = false;
            buttonAgregar.Enabled = true;
            buttonEliminar.Enabled = false;

            buttonGuardar.Visible = false;
            buttonAgregar.Visible = true;
            buttonEliminar.Visible = false;

            buttonBuscarE.Visible = false;
            buttonBuscarE.Enabled = false;
            buttonBuscarM.Enabled = false;
            buttonBuscarM.Visible = false;

            habilitandoTodosCampos();
            limpiarTextsBoxs();
        }

        //--------------------------------------------------------------------------------------
        // 3) Eliminar un producto del inventario
        //--------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            buttonGuardar.Enabled = false;
            buttonAgregar.Enabled = false;
            buttonEliminar.Enabled = true;

            buttonGuardar.Visible = false;
            buttonAgregar.Visible = false;
            buttonEliminar.Visible = true;

            buttonBuscarE.Visible = true;
            buttonBuscarE.Enabled = true;
            buttonBuscarM.Enabled = false;
            buttonBuscarM.Visible = false;

            habilitandoIDCampos();
            limpiarTextsBoxs();
        }

        //======================================================================================
        // Botones
        //======================================================================================
        // Boton Buscar para modificar Producto
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try { buscarProducto(true); }
            catch { MessageBox.Show("[ERROR]: Falla en el sistema"); }
        }

        // Boton Buscar para eliminar un Producto
        private void buttonBuscarE_Click_1(object sender, EventArgs e)
        {
            try { buscarProducto(false); }
            catch { MessageBox.Show("[ERROR]: Falla en el sistema"); }
        }

        //======================================================================================
        // Configuracion de las opciones Modificar/Agregar/Eliminar un producto del inventario
        //======================================================================================
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto()
                {
                    nombre = textBoxNombre.Text.ToUpper(),
                    ID = Convert.ToInt32(textBoxID.Text),
                    marca = textBoxMarca.Text.ToUpper(),
                    precio = Convert.ToDouble(textBoxPrecio.Text),
                    stock = Convert.ToInt32(textBoxStock.Text)
                };
                var setter = client.Set("MiInventario/" + textBoxID.Text, producto);
                MessageBox.Show("Se ha agregado un nuevo producto al inventario");
            }
            catch { MessageBox.Show("[ERROR]: No se ha podido agregar el producto al inventario"); }
            limpiarTextsBoxs();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto()
                {
                    nombre = textBoxNombre.Text.ToUpper(),
                    ID = Convert.ToInt32(textBoxID.Text),
                    marca = textBoxMarca.Text.ToUpper(),
                    precio = Convert.ToDouble(textBoxPrecio.Text),
                    stock = Convert.ToInt32(textBoxStock.Text)
                };
                var setter = client.Update("MiInventario/" + textBoxID.Text, producto);
                MessageBox.Show("Se han guardado los cambios");
            }
            catch { MessageBox.Show("[ERROR]: No se han podido guardar los cambios"); }
            limpiarTextsBoxs();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = client.Delete("MiInventario/" + textBoxID.Text);
                MessageBox.Show("Se ha eliminado el articulo del inventario");
            }
            catch { MessageBox.Show("[ERROR]: No se ha podido eliminar el articulo del invenatrio"); }
            limpiarTextsBoxs();
        }

        //=================================================================
        //  Funciones Secundarias
        //=================================================================
        public void limpiarTextsBoxs()
        {
            textBoxNombre.Clear();
            textBoxID.Clear();
            textBoxMarca.Clear();
            textBoxStock.Clear();
            textBoxPrecio.Clear();
        }

        public void habilitandoIDCampos()
        {
            textBoxNombre.Enabled = false;
            textBoxID.Enabled = true;
            textBoxMarca.Enabled = false;
            textBoxStock.Enabled = false;
            textBoxPrecio.Enabled = false;

            labelNombre.Enabled = false;
            labelID.Enabled = true;
            labelMarca.Enabled = false;
            labelPrecio.Enabled = false;
            labelStock.Enabled = false;
        }

        public void habilitandoTodosCampos()
        {
            labelNombre.Enabled = true;
            labelID.Enabled = true;
            labelMarca.Enabled = true;
            labelStock.Enabled = true;
            labelPrecio.Enabled = true;

            textBoxNombre.Enabled = true;
            textBoxID.Enabled = true;
            textBoxMarca.Enabled = true;
            textBoxStock.Enabled = true;
            textBoxPrecio.Enabled = true;
        }

        public void buscarProducto(bool habilitarCampos)
        {
            var result = client.Get("MiInventario/" + textBoxID.Text);
            Producto producto = result.ResultAs<Producto>();

            if (producto != null)
            {
                textBoxNombre.Text = producto.nombre;
                textBoxID.Text = Convert.ToString(producto.ID);
                textBoxMarca.Text = producto.marca;
                textBoxPrecio.Text = Convert.ToString(producto.precio);
                textBoxStock.Text = Convert.ToString(producto.stock);

                if (habilitarCampos == true) habilitandoTodosCampos();
            }
            else
            {
                MessageBox.Show("El producto que busca no se encuentra en el inventario");
                limpiarTextsBoxs();
            }
        }
        public void llenarTabla()
        {
            // Extrae datos de la BD y los inserta en el Grid
            TablaInventario2.Rows.Clear();
            int idTable = 1;
            bool exit = false;

            do
            {
                var result = client.Get("MiInventario/" + idTable.ToString());
                Producto producto = result.ResultAs<Producto>();

                if (producto != null)
                {
                    TablaInventario2.Rows.Add(
                        producto.ID.ToString(),
                        producto.nombre,
                        producto.marca,
                        producto.stock.ToString(),
                        producto.precio.ToString()
                    );
                    idTable++;
                }
                else
                {
                    exit = true;
                }
            } while (exit == false);

        }

        private void buttonActuTabla_Click(object sender, EventArgs e)
        {
            try { llenarTabla(); }
            catch { MessageBox.Show("[ERROR]: No se pudo generar la tabla"); }
        }
    }
}