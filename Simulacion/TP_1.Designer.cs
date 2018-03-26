namespace Simulacion
{
    partial class TP_1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.d = new System.Windows.Forms.TabPage();
            this.btn_reestablecer_panel_multiplicativo = new System.Windows.Forms.Button();
            this.btn_generar_aleatorios = new System.Windows.Forms.Button();
            this.grilla_multiplicativo = new System.Windows.Forms.DataGridView();
            this.txt_g = new System.Windows.Forms.TextBox();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_m = new System.Windows.Forms.TextBox();
            this.txt_c = new System.Windows.Forms.TextBox();
            this.txt_a = new System.Windows.Forms.TextBox();
            this.txt_semilla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.column_n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_xi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.d.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_multiplicativo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.d);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1022, 543);
            this.tabControl1.TabIndex = 0;
            // 
            // d
            // 
            this.d.Controls.Add(this.btn_reestablecer_panel_multiplicativo);
            this.d.Controls.Add(this.btn_generar_aleatorios);
            this.d.Controls.Add(this.grilla_multiplicativo);
            this.d.Controls.Add(this.txt_g);
            this.d.Controls.Add(this.txt_k);
            this.d.Controls.Add(this.label6);
            this.d.Controls.Add(this.label5);
            this.d.Controls.Add(this.txt_m);
            this.d.Controls.Add(this.txt_c);
            this.d.Controls.Add(this.txt_a);
            this.d.Controls.Add(this.txt_semilla);
            this.d.Controls.Add(this.label4);
            this.d.Controls.Add(this.label3);
            this.d.Controls.Add(this.label2);
            this.d.Controls.Add(this.label1);
            this.d.Location = new System.Drawing.Point(4, 22);
            this.d.Name = "d";
            this.d.Padding = new System.Windows.Forms.Padding(3);
            this.d.Size = new System.Drawing.Size(1014, 517);
            this.d.TabIndex = 0;
            this.d.Text = "Congruencial Multiplicativo";
            this.d.UseVisualStyleBackColor = true;
            // 
            // btn_reestablecer_panel_multiplicativo
            // 
            this.btn_reestablecer_panel_multiplicativo.Location = new System.Drawing.Point(650, 67);
            this.btn_reestablecer_panel_multiplicativo.Name = "btn_reestablecer_panel_multiplicativo";
            this.btn_reestablecer_panel_multiplicativo.Size = new System.Drawing.Size(212, 40);
            this.btn_reestablecer_panel_multiplicativo.TabIndex = 14;
            this.btn_reestablecer_panel_multiplicativo.Text = "Reestablecer";
            this.btn_reestablecer_panel_multiplicativo.UseVisualStyleBackColor = true;
            this.btn_reestablecer_panel_multiplicativo.Click += new System.EventHandler(this.btn_reestablecer_panel_multiplicativo_Click);
            // 
            // btn_generar_aleatorios
            // 
            this.btn_generar_aleatorios.Location = new System.Drawing.Point(650, 16);
            this.btn_generar_aleatorios.Name = "btn_generar_aleatorios";
            this.btn_generar_aleatorios.Size = new System.Drawing.Size(212, 40);
            this.btn_generar_aleatorios.TabIndex = 13;
            this.btn_generar_aleatorios.Text = "Generar números aleatorios";
            this.btn_generar_aleatorios.UseVisualStyleBackColor = true;
            this.btn_generar_aleatorios.Click += new System.EventHandler(this.btn_generar_aleatorios_Click);
            // 
            // grilla_multiplicativo
            // 
            this.grilla_multiplicativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_multiplicativo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_n,
            this.column_xi,
            this.column});
            this.grilla_multiplicativo.Location = new System.Drawing.Point(17, 135);
            this.grilla_multiplicativo.Name = "grilla_multiplicativo";
            this.grilla_multiplicativo.Size = new System.Drawing.Size(451, 352);
            this.grilla_multiplicativo.TabIndex = 12;
            // 
            // txt_g
            // 
            this.txt_g.Location = new System.Drawing.Point(492, 84);
            this.txt_g.Name = "txt_g";
            this.txt_g.Size = new System.Drawing.Size(100, 20);
            this.txt_g.TabIndex = 11;
            this.txt_g.TextChanged += new System.EventHandler(this.txt_g_TextChanged);
            // 
            // txt_k
            // 
            this.txt_k.Location = new System.Drawing.Point(492, 51);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(100, 20);
            this.txt_k.TabIndex = 10;
            this.txt_k.TextChanged += new System.EventHandler(this.txt_k_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(410, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "g";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(411, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "k";
            // 
            // txt_m
            // 
            this.txt_m.Location = new System.Drawing.Point(492, 20);
            this.txt_m.Name = "txt_m";
            this.txt_m.Size = new System.Drawing.Size(100, 20);
            this.txt_m.TabIndex = 7;
            // 
            // txt_c
            // 
            this.txt_c.Location = new System.Drawing.Point(109, 84);
            this.txt_c.Name = "txt_c";
            this.txt_c.Size = new System.Drawing.Size(100, 20);
            this.txt_c.TabIndex = 6;
            // 
            // txt_a
            // 
            this.txt_a.Location = new System.Drawing.Point(109, 55);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(100, 20);
            this.txt_a.TabIndex = 5;
            // 
            // txt_semilla
            // 
            this.txt_semilla.Location = new System.Drawing.Point(109, 27);
            this.txt_semilla.Name = "txt_semilla";
            this.txt_semilla.Size = new System.Drawing.Size(100, 20);
            this.txt_semilla.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "c";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semilla";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1014, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Congruencial Aditivo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // column_n
            // 
            this.column_n.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_n.HeaderText = "n";
            this.column_n.Name = "column_n";
            // 
            // column_xi
            // 
            this.column_xi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_xi.HeaderText = "Xi";
            this.column_xi.Name = "column_xi";
            // 
            // column
            // 
            this.column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column.HeaderText = "ri";
            this.column.Name = "column";
            // 
            // TP_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 567);
            this.Controls.Add(this.tabControl1);
            this.Name = "TP_1";
            this.Text = "TP 1";
            this.tabControl1.ResumeLayout(false);
            this.d.ResumeLayout(false);
            this.d.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_multiplicativo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage d;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_g;
        private System.Windows.Forms.TextBox txt_k;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_m;
        private System.Windows.Forms.TextBox txt_c;
        private System.Windows.Forms.TextBox txt_a;
        private System.Windows.Forms.TextBox txt_semilla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reestablecer_panel_multiplicativo;
        private System.Windows.Forms.Button btn_generar_aleatorios;
        private System.Windows.Forms.DataGridView grilla_multiplicativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_n;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_xi;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
    }
}

