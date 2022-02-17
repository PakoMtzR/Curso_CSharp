
namespace SistemaVentasFerreteria
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonModificarP = new System.Windows.Forms.Button();
            this.buttonAgregarP = new System.Windows.Forms.Button();
            this.buttonEliminarP = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.buttonBuscarM = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonBuscarE = new System.Windows.Forms.Button();
            this.TablaInventario2 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonActuTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaInventario2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(22, 312);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(100, 30);
            this.buttonCerrar.TabIndex = 0;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonModificarP
            // 
            this.buttonModificarP.Location = new System.Drawing.Point(22, 37);
            this.buttonModificarP.Name = "buttonModificarP";
            this.buttonModificarP.Size = new System.Drawing.Size(135, 70);
            this.buttonModificarP.TabIndex = 1;
            this.buttonModificarP.Text = "Mofidicar un Producto del Inventario";
            this.buttonModificarP.UseVisualStyleBackColor = true;
            this.buttonModificarP.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAgregarP
            // 
            this.buttonAgregarP.Location = new System.Drawing.Point(22, 113);
            this.buttonAgregarP.Name = "buttonAgregarP";
            this.buttonAgregarP.Size = new System.Drawing.Size(135, 70);
            this.buttonAgregarP.TabIndex = 2;
            this.buttonAgregarP.Text = "Agregar \r\nNuevo Producto\r\n";
            this.buttonAgregarP.UseVisualStyleBackColor = true;
            this.buttonAgregarP.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonEliminarP
            // 
            this.buttonEliminarP.Location = new System.Drawing.Point(22, 189);
            this.buttonEliminarP.Name = "buttonEliminarP";
            this.buttonEliminarP.Size = new System.Drawing.Size(135, 70);
            this.buttonEliminarP.TabIndex = 3;
            this.buttonEliminarP.Text = "Eliminar Producto\r\ndel Inventario\r\n";
            this.buttonEliminarP.UseVisualStyleBackColor = true;
            this.buttonEliminarP.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Enabled = false;
            this.labelNombre.Location = new System.Drawing.Point(218, 43);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(62, 17);
            this.labelNombre.TabIndex = 4;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Enabled = false;
            this.labelID.Location = new System.Drawing.Point(255, 75);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(25, 17);
            this.labelID.TabIndex = 5;
            this.labelID.Text = "ID:";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Enabled = false;
            this.labelMarca.Location = new System.Drawing.Point(229, 106);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(51, 17);
            this.labelMarca.TabIndex = 6;
            this.labelMarca.Text = "Marca:";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Enabled = false;
            this.labelStock.Location = new System.Drawing.Point(198, 133);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(82, 17);
            this.labelStock.TabIndex = 7;
            this.labelStock.Text = "Existencias:";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Enabled = false;
            this.labelPrecio.Location = new System.Drawing.Point(212, 164);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(68, 17);
            this.labelPrecio.TabIndex = 9;
            this.labelPrecio.Text = "Precio[$]:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Enabled = false;
            this.textBoxNombre.Location = new System.Drawing.Point(286, 38);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 22);
            this.textBoxNombre.TabIndex = 10;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(286, 70);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 22);
            this.textBoxID.TabIndex = 11;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Enabled = false;
            this.textBoxMarca.Location = new System.Drawing.Point(286, 101);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(100, 22);
            this.textBoxMarca.TabIndex = 12;
            // 
            // textBoxStock
            // 
            this.textBoxStock.Enabled = false;
            this.textBoxStock.Location = new System.Drawing.Point(286, 130);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(100, 22);
            this.textBoxStock.TabIndex = 13;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Enabled = false;
            this.textBoxPrecio.Location = new System.Drawing.Point(286, 161);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(100, 22);
            this.textBoxPrecio.TabIndex = 14;
            // 
            // buttonBuscarM
            // 
            this.buttonBuscarM.Enabled = false;
            this.buttonBuscarM.Location = new System.Drawing.Point(403, 34);
            this.buttonBuscarM.Name = "buttonBuscarM";
            this.buttonBuscarM.Size = new System.Drawing.Size(83, 30);
            this.buttonBuscarM.TabIndex = 17;
            this.buttonBuscarM.Text = "Buscar";
            this.buttonBuscarM.UseVisualStyleBackColor = true;
            this.buttonBuscarM.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Enabled = false;
            this.buttonAgregar.Location = new System.Drawing.Point(286, 209);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(100, 30);
            this.buttonAgregar.TabIndex = 18;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Enabled = false;
            this.buttonGuardar.Location = new System.Drawing.Point(286, 209);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(100, 30);
            this.buttonGuardar.TabIndex = 19;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.Location = new System.Drawing.Point(286, 209);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(100, 30);
            this.buttonEliminar.TabIndex = 20;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonBuscarE
            // 
            this.buttonBuscarE.Enabled = false;
            this.buttonBuscarE.Location = new System.Drawing.Point(403, 34);
            this.buttonBuscarE.Name = "buttonBuscarE";
            this.buttonBuscarE.Size = new System.Drawing.Size(83, 30);
            this.buttonBuscarE.TabIndex = 23;
            this.buttonBuscarE.Text = "Buscar";
            this.buttonBuscarE.UseVisualStyleBackColor = true;
            this.buttonBuscarE.Click += new System.EventHandler(this.buttonBuscarE_Click_1);
            // 
            // TablaInventario2
            // 
            this.TablaInventario2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaInventario2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.marca,
            this.stock,
            this.precio});
            this.TablaInventario2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TablaInventario2.Location = new System.Drawing.Point(555, 35);
            this.TablaInventario2.Name = "TablaInventario2";
            this.TablaInventario2.RowHeadersWidth = 51;
            this.TablaInventario2.RowTemplate.Height = 24;
            this.TablaInventario2.Size = new System.Drawing.Size(590, 225);
            this.TablaInventario2.TabIndex = 24;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Articulo";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.Width = 125;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.Width = 70;
            // 
            // stock
            // 
            this.stock.HeaderText = "Existencias";
            this.stock.MinimumWidth = 6;
            this.stock.Name = "stock";
            this.stock.Width = 70;
            // 
            // precio
            // 
            this.precio.HeaderText = "P.U";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.Width = 50;
            // 
            // buttonActuTabla
            // 
            this.buttonActuTabla.Location = new System.Drawing.Point(787, 265);
            this.buttonActuTabla.Name = "buttonActuTabla";
            this.buttonActuTabla.Size = new System.Drawing.Size(149, 37);
            this.buttonActuTabla.TabIndex = 25;
            this.buttonActuTabla.Text = "Actualizar";
            this.buttonActuTabla.UseVisualStyleBackColor = true;
            this.buttonActuTabla.Click += new System.EventHandler(this.buttonActuTabla_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 365);
            this.Controls.Add(this.buttonActuTabla);
            this.Controls.Add(this.TablaInventario2);
            this.Controls.Add(this.buttonBuscarE);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonBuscarM);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.buttonEliminarP);
            this.Controls.Add(this.buttonAgregarP);
            this.Controls.Add(this.buttonModificarP);
            this.Controls.Add(this.buttonCerrar);
            this.Name = "Form2";
            this.Text = "Gestor de Inventario";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaInventario2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonModificarP;
        private System.Windows.Forms.Button buttonAgregarP;
        private System.Windows.Forms.Button buttonEliminarP;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Button buttonBuscarM;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonBuscarE;
        private System.Windows.Forms.DataGridView TablaInventario2;
        private System.Windows.Forms.Button buttonActuTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
    }
}