namespace Caja
{
    partial class frm_Facturacion
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFinalizarFactura = new System.Windows.Forms.Button();
            this.txtCodigoServicio = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtCantidadProducto = new System.Windows.Forms.TextBox();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblITBIS = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.panelNuevaFactura = new System.Windows.Forms.GroupBox();
            this.panelDetalleFactura = new System.Windows.Forms.GroupBox();
            this.lblAlertaCodigoProducto = new System.Windows.Forms.Label();
            this.facturaDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Login = new Caja.DS_Login();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new Caja.DS_LoginTableAdapters.UsuariosTableAdapter();
            this.facturaDetalleTableAdapter = new Caja.DS_LoginTableAdapters.FacturaDetalleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.panelNuevaFactura.SuspendLayout();
            this.panelDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturación";
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(14, 164);
            this.dgvDetalleFactura.MultiSelect = false;
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(895, 271);
            this.dgvDetalleFactura.TabIndex = 17;
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnNuevaFactura.FlatAppearance.BorderSize = 0;
            this.btnNuevaFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFactura.Location = new System.Drawing.Point(806, 14);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(103, 33);
            this.btnNuevaFactura.TabIndex = 4;
            this.btnNuevaFactura.Text = "Nueva factura";
            this.btnNuevaFactura.UseVisualStyleBackColor = false;
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click);
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Items.AddRange(new object[] {
            "Consumidor final",
            "Crédito Fiscal"});
            this.cmbTipoFactura.Location = new System.Drawing.Point(364, 17);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(121, 26);
            this.cmbTipoFactura.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de factura";
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Location = new System.Drawing.Point(96, 20);
            this.txtIDCliente.MaxLength = 70;
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(121, 20);
            this.txtIDCliente.TabIndex = 1;
            this.txtIDCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCliente_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID de cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Método de pago";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Diferido"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(619, 17);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(121, 26);
            this.cmbMetodoPago.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(663, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Total a pagar:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(663, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "ITBIS:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(660, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = "Subtotal:";
            // 
            // btnFinalizarFactura
            // 
            this.btnFinalizarFactura.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFinalizarFactura.FlatAppearance.BorderSize = 0;
            this.btnFinalizarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarFactura.Location = new System.Drawing.Point(702, 118);
            this.btnFinalizarFactura.Name = "btnFinalizarFactura";
            this.btnFinalizarFactura.Size = new System.Drawing.Size(174, 31);
            this.btnFinalizarFactura.TabIndex = 8;
            this.btnFinalizarFactura.Text = "Facturar";
            this.btnFinalizarFactura.UseVisualStyleBackColor = false;
            this.btnFinalizarFactura.Click += new System.EventHandler(this.btnFinalizarFactura_Click);
            // 
            // txtCodigoServicio
            // 
            this.txtCodigoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoServicio.Location = new System.Drawing.Point(165, 49);
            this.txtCodigoServicio.MaxLength = 10;
            this.txtCodigoServicio.Name = "txtCodigoServicio";
            this.txtCodigoServicio.Size = new System.Drawing.Size(126, 24);
            this.txtCodigoServicio.TabIndex = 7;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(117, 124);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(174, 31);
            this.btnAgregarProducto.TabIndex = 7;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtCantidadProducto
            // 
            this.txtCantidadProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadProducto.Location = new System.Drawing.Point(165, 84);
            this.txtCantidadProducto.MaxLength = 10;
            this.txtCantidadProducto.Name = "txtCantidadProducto";
            this.txtCantidadProducto.Size = new System.Drawing.Size(126, 24);
            this.txtCantidadProducto.TabIndex = 6;
            this.txtCantidadProducto.Text = "0";
            this.txtCantidadProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidadProducto.Enter += new System.EventHandler(this.txtCantidadProducto_Enter);
            this.txtCantidadProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadProducto_KeyPress);
            this.txtCantidadProducto.Leave += new System.EventHandler(this.txtCantidadProducto_Leave);
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProducto.Location = new System.Drawing.Point(165, 19);
            this.txtCodigoProducto.MaxLength = 10;
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(126, 24);
            this.txtCodigoProducto.TabIndex = 5;
            this.txtCodigoProducto.Text = "0";
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.Enter += new System.EventHandler(this.txtCodigoProducto_Enter);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            this.txtCodigoProducto.Leave += new System.EventHandler(this.txtCodigoProducto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cantidad de producto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Código de producto:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(873, 84);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPagar.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(890, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 18);
            this.label7.TabIndex = 15;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblITBIS
            // 
            this.lblITBIS.AutoSize = true;
            this.lblITBIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblITBIS.Location = new System.Drawing.Point(879, 50);
            this.lblITBIS.Name = "lblITBIS";
            this.lblITBIS.Size = new System.Drawing.Size(0, 18);
            this.lblITBIS.TabIndex = 14;
            this.lblITBIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(873, 16);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(0, 18);
            this.lblSubtotal.TabIndex = 13;
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelNuevaFactura
            // 
            this.panelNuevaFactura.Controls.Add(this.label3);
            this.panelNuevaFactura.Controls.Add(this.cmbMetodoPago);
            this.panelNuevaFactura.Controls.Add(this.txtIDCliente);
            this.panelNuevaFactura.Controls.Add(this.btnNuevaFactura);
            this.panelNuevaFactura.Controls.Add(this.label2);
            this.panelNuevaFactura.Controls.Add(this.label4);
            this.panelNuevaFactura.Controls.Add(this.cmbTipoFactura);
            this.panelNuevaFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelNuevaFactura.Location = new System.Drawing.Point(12, 61);
            this.panelNuevaFactura.Name = "panelNuevaFactura";
            this.panelNuevaFactura.Size = new System.Drawing.Size(921, 56);
            this.panelNuevaFactura.TabIndex = 18;
            this.panelNuevaFactura.TabStop = false;
            this.panelNuevaFactura.Text = "Crear factura";
            // 
            // panelDetalleFactura
            // 
            this.panelDetalleFactura.Controls.Add(this.lblAlertaCodigoProducto);
            this.panelDetalleFactura.Controls.Add(this.label5);
            this.panelDetalleFactura.Controls.Add(this.lblTotalPagar);
            this.panelDetalleFactura.Controls.Add(this.lblSubtotal);
            this.panelDetalleFactura.Controls.Add(this.lblITBIS);
            this.panelDetalleFactura.Controls.Add(this.label8);
            this.panelDetalleFactura.Controls.Add(this.dgvDetalleFactura);
            this.panelDetalleFactura.Controls.Add(this.label9);
            this.panelDetalleFactura.Controls.Add(this.label6);
            this.panelDetalleFactura.Controls.Add(this.label10);
            this.panelDetalleFactura.Controls.Add(this.txtCodigoProducto);
            this.panelDetalleFactura.Controls.Add(this.txtCantidadProducto);
            this.panelDetalleFactura.Controls.Add(this.btnFinalizarFactura);
            this.panelDetalleFactura.Controls.Add(this.btnAgregarProducto);
            this.panelDetalleFactura.Controls.Add(this.txtCodigoServicio);
            this.panelDetalleFactura.Enabled = false;
            this.panelDetalleFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelDetalleFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDetalleFactura.Location = new System.Drawing.Point(12, 128);
            this.panelDetalleFactura.Name = "panelDetalleFactura";
            this.panelDetalleFactura.Size = new System.Drawing.Size(921, 443);
            this.panelDetalleFactura.TabIndex = 19;
            this.panelDetalleFactura.TabStop = false;
            this.panelDetalleFactura.Text = "Agregar productos";
            // 
            // lblAlertaCodigoProducto
            // 
            this.lblAlertaCodigoProducto.AutoSize = true;
            this.lblAlertaCodigoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAlertaCodigoProducto.Location = new System.Drawing.Point(298, 29);
            this.lblAlertaCodigoProducto.Name = "lblAlertaCodigoProducto";
            this.lblAlertaCodigoProducto.Size = new System.Drawing.Size(0, 13);
            this.lblAlertaCodigoProducto.TabIndex = 18;
            // 
            // facturaDetalleBindingSource
            // 
            this.facturaDetalleBindingSource.DataMember = "FacturaDetalle";
            this.facturaDetalleBindingSource.DataSource = this.dS_Login;
            // 
            // dS_Login
            // 
            this.dS_Login.DataSetName = "DS_Login";
            this.dS_Login.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.dS_Login;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // facturaDetalleTableAdapter
            // 
            this.facturaDetalleTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 583);
            this.Controls.Add(this.panelDetalleFactura);
            this.Controls.Add(this.panelNuevaFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Facturacion";
            this.Text = "frm_Facturacion";
            this.Load += new System.EventHandler(this.frm_Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.panelNuevaFactura.ResumeLayout(false);
            this.panelNuevaFactura.PerformLayout();
            this.panelDetalleFactura.ResumeLayout(false);
            this.panelDetalleFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DS_Login dS_Login;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private DS_LoginTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource facturaDetalleBindingSource;
        private DS_LoginTableAdapters.FacturaDetalleTableAdapter facturaDetalleTableAdapter;
        private System.Windows.Forms.TextBox txtCantidadProducto;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.TextBox txtCodigoServicio;
        private System.Windows.Forms.Button btnFinalizarFactura;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblITBIS;
        public System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.GroupBox panelNuevaFactura;
        private System.Windows.Forms.GroupBox panelDetalleFactura;
        private System.Windows.Forms.Label lblAlertaCodigoProducto;
    }
}