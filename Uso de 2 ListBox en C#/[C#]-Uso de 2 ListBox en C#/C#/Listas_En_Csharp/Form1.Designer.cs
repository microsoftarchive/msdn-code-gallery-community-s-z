namespace Listas_En_Csharp
{
    partial class FormularioPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            this.ListaIzq = new System.Windows.Forms.ListBox();
            this.ListaDer = new System.Windows.Forms.ListBox();
            this.DerTodos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IzqTodos = new System.Windows.Forms.Button();
            this.IzqUno = new System.Windows.Forms.Button();
            this.DerUno = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblitemsDer = new System.Windows.Forms.Label();
            this.lblitemsIzq = new System.Windows.Forms.Label();
            this.btonOrdenar = new System.Windows.Forms.Button();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.BotonBorar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNuevoElem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btonOrdenar0 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaIzq
            // 
            this.ListaIzq.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ListaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListaIzq.FormattingEnabled = true;
            this.ListaIzq.Location = new System.Drawing.Point(15, 47);
            this.ListaIzq.Name = "ListaIzq";
            this.ListaIzq.Size = new System.Drawing.Size(120, 210);
            this.ListaIzq.TabIndex = 0;
            // 
            // ListaDer
            // 
            this.ListaDer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ListaDer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaDer.FormattingEnabled = true;
            this.ListaDer.Location = new System.Drawing.Point(198, 49);
            this.ListaDer.Name = "ListaDer";
            this.ListaDer.Size = new System.Drawing.Size(120, 208);
            this.ListaDer.TabIndex = 1;
            // 
            // DerTodos
            // 
            this.DerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DerTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DerTodos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DerTodos.Image = ((System.Drawing.Image)(resources.GetObject("DerTodos.Image")));
            this.DerTodos.Location = new System.Drawing.Point(3, 12);
            this.DerTodos.Name = "DerTodos";
            this.DerTodos.Size = new System.Drawing.Size(42, 33);
            this.DerTodos.TabIndex = 2;
            this.DerTodos.Text = ">>";
            this.DerTodos.UseVisualStyleBackColor = true;
            this.DerTodos.Click += new System.EventHandler(this.DerTodos_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IzqTodos);
            this.panel1.Controls.Add(this.IzqUno);
            this.panel1.Controls.Add(this.DerUno);
            this.panel1.Controls.Add(this.DerTodos);
            this.panel1.Location = new System.Drawing.Point(141, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 210);
            this.panel1.TabIndex = 3;
            // 
            // IzqTodos
            // 
            this.IzqTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IzqTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IzqTodos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IzqTodos.Image = ((System.Drawing.Image)(resources.GetObject("IzqTodos.Image")));
            this.IzqTodos.Location = new System.Drawing.Point(3, 161);
            this.IzqTodos.Name = "IzqTodos";
            this.IzqTodos.Size = new System.Drawing.Size(42, 33);
            this.IzqTodos.TabIndex = 5;
            this.IzqTodos.Text = "<<";
            this.IzqTodos.UseVisualStyleBackColor = true;
            this.IzqTodos.Click += new System.EventHandler(this.IzqTodos_Click);
            // 
            // IzqUno
            // 
            this.IzqUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IzqUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IzqUno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IzqUno.Image = ((System.Drawing.Image)(resources.GetObject("IzqUno.Image")));
            this.IzqUno.Location = new System.Drawing.Point(3, 111);
            this.IzqUno.Name = "IzqUno";
            this.IzqUno.Size = new System.Drawing.Size(42, 33);
            this.IzqUno.TabIndex = 4;
            this.IzqUno.Text = "<";
            this.IzqUno.UseVisualStyleBackColor = true;
            this.IzqUno.Click += new System.EventHandler(this.IzqUno_Click);
            // 
            // DerUno
            // 
            this.DerUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DerUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DerUno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DerUno.Image = ((System.Drawing.Image)(resources.GetObject("DerUno.Image")));
            this.DerUno.Location = new System.Drawing.Point(3, 61);
            this.DerUno.Name = "DerUno";
            this.DerUno.Size = new System.Drawing.Size(42, 33);
            this.DerUno.TabIndex = 3;
            this.DerUno.Text = ">";
            this.DerUno.UseVisualStyleBackColor = true;
            this.DerUno.Click += new System.EventHandler(this.DerUno_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btonOrdenar0);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblitemsDer);
            this.panel2.Controls.Add(this.lblitemsIzq);
            this.panel2.Controls.Add(this.btonOrdenar);
            this.panel2.Controls.Add(this.ListaIzq);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.ListaDer);
            this.panel2.Location = new System.Drawing.Point(12, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 325);
            this.panel2.TabIndex = 4;
            // 
            // lblitemsDer
            // 
            this.lblitemsDer.AutoSize = true;
            this.lblitemsDer.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblitemsDer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblitemsDer.Location = new System.Drawing.Point(194, 21);
            this.lblitemsDer.Name = "lblitemsDer";
            this.lblitemsDer.Size = new System.Drawing.Size(50, 23);
            this.lblitemsDer.TabIndex = 10;
            this.lblitemsDer.Text = "label2";
            // 
            // lblitemsIzq
            // 
            this.lblitemsIzq.AutoSize = true;
            this.lblitemsIzq.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblitemsIzq.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblitemsIzq.Location = new System.Drawing.Point(11, 21);
            this.lblitemsIzq.Name = "lblitemsIzq";
            this.lblitemsIzq.Size = new System.Drawing.Size(50, 23);
            this.lblitemsIzq.TabIndex = 9;
            this.lblitemsIzq.Text = "label2";
            // 
            // btonOrdenar
            // 
            this.btonOrdenar.BackColor = System.Drawing.SystemColors.ControlText;
            this.btonOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonOrdenar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.btonOrdenar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btonOrdenar.Location = new System.Drawing.Point(198, 283);
            this.btonOrdenar.Name = "btonOrdenar";
            this.btonOrdenar.Size = new System.Drawing.Size(82, 33);
            this.btonOrdenar.TabIndex = 8;
            this.btonOrdenar.Text = "Ordenar";
            this.btonOrdenar.UseVisualStyleBackColor = false;
            this.btonOrdenar.Click += new System.EventHandler(this.btonOrdenar_Click);
            // 
            // botonAgregar
            // 
            this.botonAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonAgregar.BackgroundImage")));
            this.botonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAgregar.Location = new System.Drawing.Point(131, 34);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(36, 36);
            this.botonAgregar.TabIndex = 5;
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // BotonBorar
            // 
            this.BotonBorar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonBorar.BackgroundImage")));
            this.BotonBorar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonBorar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonBorar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BotonBorar.Location = new System.Drawing.Point(172, 33);
            this.BotonBorar.Name = "BotonBorar";
            this.BotonBorar.Size = new System.Drawing.Size(36, 36);
            this.BotonBorar.TabIndex = 6;
            this.BotonBorar.UseVisualStyleBackColor = true;
            this.BotonBorar.Click += new System.EventHandler(this.BotonBorar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNuevoElem);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.botonAgregar);
            this.panel3.Controls.Add(this.BotonBorar);
            this.panel3.Location = new System.Drawing.Point(12, 362);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 77);
            this.panel3.TabIndex = 7;
            // 
            // txtNuevoElem
            // 
            this.txtNuevoElem.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNuevoElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevoElem.Location = new System.Drawing.Point(5, 35);
            this.txtNuevoElem.Multiline = true;
            this.txtNuevoElem.Name = "txtNuevoElem";
            this.txtNuevoElem.Size = new System.Drawing.Size(117, 36);
            this.txtNuevoElem.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nuevo Elemento +:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(11, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Lista 1.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(194, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lista 2.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(375, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "By: asael1234";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btonOrdenar0
            // 
            this.btonOrdenar0.BackColor = System.Drawing.SystemColors.ControlText;
            this.btonOrdenar0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonOrdenar0.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.btonOrdenar0.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btonOrdenar0.Location = new System.Drawing.Point(15, 283);
            this.btonOrdenar0.Name = "btonOrdenar0";
            this.btonOrdenar0.Size = new System.Drawing.Size(82, 33);
            this.btonOrdenar0.TabIndex = 13;
            this.btonOrdenar0.Text = "Ordenar";
            this.btonOrdenar0.UseVisualStyleBackColor = false;
            this.btonOrdenar0.Click += new System.EventHandler(this.btonOrdenar0_Click);
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(484, 441);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas en Csharp::Edit By asael1234";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListaIzq;
        private System.Windows.Forms.ListBox ListaDer;
        private System.Windows.Forms.Button DerTodos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button BotonBorar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNuevoElem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IzqTodos;
        private System.Windows.Forms.Button IzqUno;
        private System.Windows.Forms.Button DerUno;
        private System.Windows.Forms.Button btonOrdenar;
        private System.Windows.Forms.Label lblitemsDer;
        private System.Windows.Forms.Label lblitemsIzq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btonOrdenar0;
    }
}

