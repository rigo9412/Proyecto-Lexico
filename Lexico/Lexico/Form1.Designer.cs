namespace Lexico
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabla = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.DgTabla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.abrirCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgTabla)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(39, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(395, 357);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(38, 452);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(396, 169);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(359, 49);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbrir,
            this.MenuGuardar,
            this.menuTabla});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1075, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuAbrir
            // 
            this.MenuAbrir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCodigo,
            this.abrirTokens});
            this.MenuAbrir.Name = "MenuAbrir";
            this.MenuAbrir.Size = new System.Drawing.Size(45, 20);
            this.MenuAbrir.Text = "Abrir";
            this.MenuAbrir.Click += new System.EventHandler(this.MenuAbrir_Click);
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarCodigo,
            this.guardarTokens});
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(61, 20);
            this.MenuGuardar.Text = "Guardar";
            this.MenuGuardar.Click += new System.EventHandler(this.MenuGuardar_Click);
            // 
            // menuTabla
            // 
            this.menuTabla.Name = "menuTabla";
            this.menuTabla.Size = new System.Drawing.Size(52, 20);
            this.menuTabla.Text = "Matriz";
            this.menuTabla.Click += new System.EventHandler(this.menuTabla_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(359, 627);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // DgTabla
            // 
            this.DgTabla.AllowUserToAddRows = false;
            this.DgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DgTabla.Location = new System.Drawing.Point(477, 78);
            this.DgTabla.Name = "DgTabla";
            this.DgTabla.Size = new System.Drawing.Size(496, 566);
            this.DgTabla.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TOKEN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CATEGORIA";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "VALOR";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 34);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(950, 600);
            this.dataGridView1.TabIndex = 0;
            // 
            // abrirCodigo
            // 
            this.abrirCodigo.Name = "abrirCodigo";
            this.abrirCodigo.Size = new System.Drawing.Size(178, 22);
            this.abrirCodigo.Text = "Archivo con codigo";
            this.abrirCodigo.Click += new System.EventHandler(this.abrirCodigo_Click);
            // 
            // abrirTokens
            // 
            this.abrirTokens.Name = "abrirTokens";
            this.abrirTokens.Size = new System.Drawing.Size(178, 22);
            this.abrirTokens.Text = "Archivo con tokens";
            this.abrirTokens.Click += new System.EventHandler(this.abrirTokens_Click);
            // 
            // guardarCodigo
            // 
            this.guardarCodigo.Name = "guardarCodigo";
            this.guardarCodigo.Size = new System.Drawing.Size(158, 22);
            this.guardarCodigo.Text = "Guardar Codigo";
            this.guardarCodigo.Click += new System.EventHandler(this.guardarCodigo_Click_1);
            // 
            // guardarTokens
            // 
            this.guardarTokens.Name = "guardarTokens";
            this.guardarTokens.Size = new System.Drawing.Size(158, 22);
            this.guardarTokens.Text = "Guardas Tokens";
            this.guardarTokens.Click += new System.EventHandler(this.guardarTokens_Click_1);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgTabla);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgTabla)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrir;
        private System.Windows.Forms.ToolStripMenuItem MenuGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView DgTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem menuTabla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem abrirCodigo;
        private System.Windows.Forms.ToolStripMenuItem abrirTokens;
        private System.Windows.Forms.ToolStripMenuItem guardarCodigo;
        private System.Windows.Forms.ToolStripMenuItem guardarTokens;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

