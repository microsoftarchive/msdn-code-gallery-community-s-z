namespace CSharp_XML1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_crear_XML = new System.Windows.Forms.Button();
            this.txt_idEmpleado = new System.Windows.Forms.TextBox();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_agr_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_agr_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_agr_Edad = new System.Windows.Forms.TextBox();
            this.bt_agregar = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_elim_IdEmpleado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Eliminar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_crear_XML
            // 
            this.bt_crear_XML.Location = new System.Drawing.Point(89, 100);
            this.bt_crear_XML.Name = "bt_crear_XML";
            this.bt_crear_XML.Size = new System.Drawing.Size(75, 23);
            this.bt_crear_XML.TabIndex = 0;
            this.bt_crear_XML.Text = "Crear XML";
            this.bt_crear_XML.UseVisualStyleBackColor = true;
            this.bt_crear_XML.Click += new System.EventHandler(this.bt_crear_XML_Click);
            // 
            // txt_idEmpleado
            // 
            this.txt_idEmpleado.Location = new System.Drawing.Point(16, 68);
            this.txt_idEmpleado.Name = "txt_idEmpleado";
            this.txt_idEmpleado.Size = new System.Drawing.Size(100, 20);
            this.txt_idEmpleado.TabIndex = 1;
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(122, 66);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(75, 23);
            this.bt_buscar.TabIndex = 2;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(281, 262);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bt_crear_XML);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(273, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.bt_buscar);
            this.tabPage2.Controls.Add(this.txt_idEmpleado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(273, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buscar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bt_agregar);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txt_agr_Edad);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.txt_agr_nombre);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txt_agr_id);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(273, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Insertar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_agr_id
            // 
            this.txt_agr_id.Location = new System.Drawing.Point(97, 35);
            this.txt_agr_id.Name = "txt_agr_id";
            this.txt_agr_id.Size = new System.Drawing.Size(100, 20);
            this.txt_agr_id.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // txt_agr_nombre
            // 
            this.txt_agr_nombre.Location = new System.Drawing.Point(97, 61);
            this.txt_agr_nombre.Name = "txt_agr_nombre";
            this.txt_agr_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_agr_nombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Edad";
            // 
            // txt_agr_Edad
            // 
            this.txt_agr_Edad.Location = new System.Drawing.Point(97, 87);
            this.txt_agr_Edad.Name = "txt_agr_Edad";
            this.txt_agr_Edad.Size = new System.Drawing.Size(100, 20);
            this.txt_agr_Edad.TabIndex = 4;
            // 
            // bt_agregar
            // 
            this.bt_agregar.Location = new System.Drawing.Point(97, 123);
            this.bt_agregar.Name = "bt_agregar";
            this.bt_agregar.Size = new System.Drawing.Size(75, 23);
            this.bt_agregar.TabIndex = 6;
            this.bt_agregar.Text = "Agregar";
            this.bt_agregar.UseVisualStyleBackColor = true;
            this.bt_agregar.Click += new System.EventHandler(this.bt_agregar_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bt_Eliminar);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.txt_elim_IdEmpleado);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(273, 236);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Eliminar";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_elim_IdEmpleado
            // 
            this.txt_elim_IdEmpleado.Location = new System.Drawing.Point(109, 26);
            this.txt_elim_IdEmpleado.Name = "txt_elim_IdEmpleado";
            this.txt_elim_IdEmpleado.Size = new System.Drawing.Size(100, 20);
            this.txt_elim_IdEmpleado.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "ID Empleado";
            // 
            // bt_Eliminar
            // 
            this.bt_Eliminar.Location = new System.Drawing.Point(119, 52);
            this.bt_Eliminar.Name = "bt_Eliminar";
            this.bt_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.bt_Eliminar.TabIndex = 2;
            this.bt_Eliminar.Text = "Eliminar";
            this.bt_Eliminar.UseVisualStyleBackColor = true;
            this.bt_Eliminar.Click += new System.EventHandler(this.bt_Eliminar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "ID Empleado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_crear_XML;
        private System.Windows.Forms.TextBox txt_idEmpleado;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bt_agregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_agr_Edad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_agr_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_agr_id;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button bt_Eliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_elim_IdEmpleado;
        private System.Windows.Forms.Label label5;
    }
}

