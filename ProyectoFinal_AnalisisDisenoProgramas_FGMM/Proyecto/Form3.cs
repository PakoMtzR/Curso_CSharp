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
using FireSharp;

namespace SistemaVentasFerreteria
{
    public partial class Form3 : Form
    {
        public Form3()
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
        
        private void Form3_Load(object sender, EventArgs e)
        {
            try 
            {
                client = new FirebaseClient(fconfing);
                llenarTabla(); 
            }
            catch { MessageBox.Show("[Error]: No fue posible conectarse a la base de datos"); }
        }

        public void llenarTabla()
        {
            // Extrae datos de la BD y los inserta en el Grid
            TablaInventario.Rows.Clear();
            int idTable = 1;
            bool exit = false;

            do
            {
                var result = client.Get("MiInventario/" + idTable.ToString());
                Producto producto = result.ResultAs<Producto>();

                if (producto != null)
                {
                    TablaInventario.Rows.Add(
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

        // Boton "Actualizar"
        private void button2_Click(object sender, EventArgs e)
        {
            try { llenarTabla(); }
            catch { MessageBox.Show("[Error]: No fue posible conectarse a la base de datos"); }
        }

        // Boton "Salir"
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}