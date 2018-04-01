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
            this.btn_reestablecer_mixto = new System.Windows.Forms.Button();
            this.btn_generar_aleatorios = new System.Windows.Forms.Button();
            this.grilla_mixto = new System.Windows.Forms.DataGridView();
            this.column_n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_xi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btn_reestablecer_multiplicativo = new System.Windows.Forms.Button();
            this.btn_generar_aleatorios_multiplicativo = new System.Windows.Forms.Button();
            this.grilla_multiplicativo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_g_multiplicativo = new System.Windows.Forms.TextBox();
            this.txt_k_multiplicativo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_m_multiplicativo = new System.Windows.Forms.TextBox();
            this.txt_a_multiplicativo = new System.Windows.Forms.TextBox();
            this.txt_semilla_multiplicativo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_generar_aleatorio_mixto = new System.Windows.Forms.Button();
            this.btn_generar_aleatorio_multiplicativo = new System.Windows.Forms.Button();
            this.btn_graficar_mixto = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_cantidad_intervalos_mixto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_graficar_multiplicativo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cantidad_intervalos_multiplicativo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.d.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_mixto)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_multiplicativo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.d.Controls.Add(this.btn_graficar_mixto);
            this.d.Controls.Add(this.groupBox3);
            this.d.Controls.Add(this.btn_generar_aleatorio_mixto);
            this.d.Controls.Add(this.btn_reestablecer_mixto);
            this.d.Controls.Add(this.btn_generar_aleatorios);
            this.d.Controls.Add(this.grilla_mixto);
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
            this.d.Text = "Congruencial Mixto";
            this.d.UseVisualStyleBackColor = true;
            // 
            // btn_reestablecer_mixto
            // 
            this.btn_reestablecer_mixto.Location = new System.Drawing.Point(612, 72);
            this.btn_reestablecer_mixto.Name = "btn_reestablecer_mixto";
            this.btn_reestablecer_mixto.Size = new System.Drawing.Size(212, 40);
            this.btn_reestablecer_mixto.TabIndex = 14;
            this.btn_reestablecer_mixto.Text = "Reestablecer";
            this.btn_reestablecer_mixto.UseVisualStyleBackColor = true;
            this.btn_reestablecer_mixto.Click += new System.EventHandler(this.btn_reestablecer_panel_multiplicativo_Click);
            // 
            // btn_generar_aleatorios
            // 
            this.btn_generar_aleatorios.Location = new System.Drawing.Point(612, 16);
            this.btn_generar_aleatorios.Name = "btn_generar_aleatorios";
            this.btn_generar_aleatorios.Size = new System.Drawing.Size(212, 40);
            this.btn_generar_aleatorios.TabIndex = 13;
            this.btn_generar_aleatorios.Text = "Generar números aleatorios";
            this.btn_generar_aleatorios.UseVisualStyleBackColor = true;
            this.btn_generar_aleatorios.Click += new System.EventHandler(this.btn_generar_aleatorios_Click);
            // 
            // grilla_mixto
            // 
            this.grilla_mixto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_mixto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_n,
            this.column_xi,
            this.column});
            this.grilla_mixto.Location = new System.Drawing.Point(17, 135);
            this.grilla_mixto.Name = "grilla_mixto";
            this.grilla_mixto.Size = new System.Drawing.Size(451, 352);
            this.grilla_mixto.TabIndex = 12;
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
            this.tabPage2.Controls.Add(this.btn_graficar_multiplicativo);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btn_generar_aleatorio_multiplicativo);
            this.tabPage2.Controls.Add(this.btn_reestablecer_multiplicativo);
            this.tabPage2.Controls.Add(this.btn_generar_aleatorios_multiplicativo);
            this.tabPage2.Controls.Add(this.grilla_multiplicativo);
            this.tabPage2.Controls.Add(this.txt_g_multiplicativo);
            this.tabPage2.Controls.Add(this.txt_k_multiplicativo);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txt_m_multiplicativo);
            this.tabPage2.Controls.Add(this.txt_a_multiplicativo);
            this.tabPage2.Controls.Add(this.txt_semilla_multiplicativo);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1014, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Congruencial Multiplicativo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_reestablecer_multiplicativo
            // 
            this.btn_reestablecer_multiplicativo.Location = new System.Drawing.Point(635, 71);
            this.btn_reestablecer_multiplicativo.Name = "btn_reestablecer_multiplicativo";
            this.btn_reestablecer_multiplicativo.Size = new System.Drawing.Size(212, 40);
            this.btn_reestablecer_multiplicativo.TabIndex = 29;
            this.btn_reestablecer_multiplicativo.Text = "Reestablecer";
            this.btn_reestablecer_multiplicativo.UseVisualStyleBackColor = true;
            this.btn_reestablecer_multiplicativo.Click += new System.EventHandler(this.btn_reestablecer_multiplicativo_Click);
            // 
            // btn_generar_aleatorios_multiplicativo
            // 
            this.btn_generar_aleatorios_multiplicativo.Location = new System.Drawing.Point(635, 20);
            this.btn_generar_aleatorios_multiplicativo.Name = "btn_generar_aleatorios_multiplicativo";
            this.btn_generar_aleatorios_multiplicativo.Size = new System.Drawing.Size(212, 40);
            this.btn_generar_aleatorios_multiplicativo.TabIndex = 28;
            this.btn_generar_aleatorios_multiplicativo.Text = "Generar números aleatorios";
            this.btn_generar_aleatorios_multiplicativo.UseVisualStyleBackColor = true;
            this.btn_generar_aleatorios_multiplicativo.Click += new System.EventHandler(this.btn_generar_aleatorios_multiplicativo_Click);
            // 
            // grilla_multiplicativo
            // 
            this.grilla_multiplicativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_multiplicativo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.grilla_multiplicativo.Location = new System.Drawing.Point(36, 139);
            this.grilla_multiplicativo.Name = "grilla_multiplicativo";
            this.grilla_multiplicativo.Size = new System.Drawing.Size(451, 352);
            this.grilla_multiplicativo.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "n";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Xi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "ri";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // txt_g_multiplicativo
            // 
            this.txt_g_multiplicativo.Location = new System.Drawing.Point(511, 88);
            this.txt_g_multiplicativo.Name = "txt_g_multiplicativo";
            this.txt_g_multiplicativo.Size = new System.Drawing.Size(100, 20);
            this.txt_g_multiplicativo.TabIndex = 26;
            this.txt_g_multiplicativo.TextChanged += new System.EventHandler(this.txt_g_multiplicativo_TextChanged);
            // 
            // txt_k_multiplicativo
            // 
            this.txt_k_multiplicativo.Location = new System.Drawing.Point(511, 55);
            this.txt_k_multiplicativo.Name = "txt_k_multiplicativo";
            this.txt_k_multiplicativo.Size = new System.Drawing.Size(100, 20);
            this.txt_k_multiplicativo.TabIndex = 25;
            this.txt_k_multiplicativo.TextChanged += new System.EventHandler(this.txt_k_multiplicativo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(429, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "g";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(430, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "k";
            // 
            // txt_m_multiplicativo
            // 
            this.txt_m_multiplicativo.Location = new System.Drawing.Point(511, 24);
            this.txt_m_multiplicativo.Name = "txt_m_multiplicativo";
            this.txt_m_multiplicativo.Size = new System.Drawing.Size(100, 20);
            this.txt_m_multiplicativo.TabIndex = 22;
            // 
            // txt_a_multiplicativo
            // 
            this.txt_a_multiplicativo.Location = new System.Drawing.Point(128, 59);
            this.txt_a_multiplicativo.Name = "txt_a_multiplicativo";
            this.txt_a_multiplicativo.Size = new System.Drawing.Size(100, 20);
            this.txt_a_multiplicativo.TabIndex = 20;
            // 
            // txt_semilla_multiplicativo
            // 
            this.txt_semilla_multiplicativo.Location = new System.Drawing.Point(128, 31);
            this.txt_semilla_multiplicativo.Name = "txt_semilla_multiplicativo";
            this.txt_semilla_multiplicativo.Size = new System.Drawing.Size(100, 20);
            this.txt_semilla_multiplicativo.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(430, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "m";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(47, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "a";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(47, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "Semilla";
            // 
            // btn_generar_aleatorio_mixto
            // 
            this.btn_generar_aleatorio_mixto.Location = new System.Drawing.Point(830, 15);
            this.btn_generar_aleatorio_mixto.Name = "btn_generar_aleatorio_mixto";
            this.btn_generar_aleatorio_mixto.Size = new System.Drawing.Size(51, 40);
            this.btn_generar_aleatorio_mixto.TabIndex = 15;
            this.btn_generar_aleatorio_mixto.Text = "+1";
            this.btn_generar_aleatorio_mixto.UseVisualStyleBackColor = true;
            this.btn_generar_aleatorio_mixto.Click += new System.EventHandler(this.btn_generar_aleatorio_1_Click);
            // 
            // btn_generar_aleatorio_multiplicativo
            // 
            this.btn_generar_aleatorio_multiplicativo.Location = new System.Drawing.Point(853, 20);
            this.btn_generar_aleatorio_multiplicativo.Name = "btn_generar_aleatorio_multiplicativo";
            this.btn_generar_aleatorio_multiplicativo.Size = new System.Drawing.Size(43, 40);
            this.btn_generar_aleatorio_multiplicativo.TabIndex = 30;
            this.btn_generar_aleatorio_multiplicativo.Text = "+1";
            this.btn_generar_aleatorio_multiplicativo.UseVisualStyleBackColor = true;
            this.btn_generar_aleatorio_multiplicativo.Click += new System.EventHandler(this.btn_generar_aleatorio_multiplicativo_Click);
            // 
            // btn_graficar_mixto
            // 
            this.btn_graficar_mixto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_graficar_mixto.Location = new System.Drawing.Point(535, 218);
            this.btn_graficar_mixto.Margin = new System.Windows.Forms.Padding(2);
            this.btn_graficar_mixto.Name = "btn_graficar_mixto";
            this.btn_graficar_mixto.Size = new System.Drawing.Size(68, 36);
            this.btn_graficar_mixto.TabIndex = 17;
            this.btn_graficar_mixto.Text = "Graficar";
            this.btn_graficar_mixto.UseVisualStyleBackColor = true;
            this.btn_graficar_mixto.Click += new System.EventHandler(this.btn_graficar_mixto_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_cantidad_intervalos_mixto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(535, 161);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(158, 52);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Histograma";
            // 
            // txt_cantidad_intervalos_mixto
            // 
            this.txt_cantidad_intervalos_mixto.Location = new System.Drawing.Point(77, 24);
            this.txt_cantidad_intervalos_mixto.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cantidad_intervalos_mixto.Name = "txt_cantidad_intervalos_mixto";
            this.txt_cantidad_intervalos_mixto.Size = new System.Drawing.Size(59, 19);
            this.txt_cantidad_intervalos_mixto.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Intervalos";
            // 
            // btn_graficar_multiplicativo
            // 
            this.btn_graficar_multiplicativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_graficar_multiplicativo.Location = new System.Drawing.Point(604, 216);
            this.btn_graficar_multiplicativo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_graficar_multiplicativo.Name = "btn_graficar_multiplicativo";
            this.btn_graficar_multiplicativo.Size = new System.Drawing.Size(68, 36);
            this.btn_graficar_multiplicativo.TabIndex = 32;
            this.btn_graficar_multiplicativo.Text = "Graficar";
            this.btn_graficar_multiplicativo.UseVisualStyleBackColor = true;
            this.btn_graficar_multiplicativo.Click += new System.EventHandler(this.btn_graficar_multiplicativo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_cantidad_intervalos_multiplicativo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(604, 159);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(158, 52);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Histograma";
            // 
            // txt_cantidad_intervalos_multiplicativo
            // 
            this.txt_cantidad_intervalos_multiplicativo.Location = new System.Drawing.Point(77, 24);
            this.txt_cantidad_intervalos_multiplicativo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cantidad_intervalos_multiplicativo.Name = "txt_cantidad_intervalos_multiplicativo";
            this.txt_cantidad_intervalos_multiplicativo.Size = new System.Drawing.Size(59, 19);
            this.txt_cantidad_intervalos_multiplicativo.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Intervalos";
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
            ((System.ComponentModel.ISupportInitialize)(this.grilla_mixto)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_multiplicativo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btn_reestablecer_mixto;
        private System.Windows.Forms.Button btn_generar_aleatorios;
        private System.Windows.Forms.DataGridView grilla_mixto;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_n;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_xi;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
        private System.Windows.Forms.Button btn_reestablecer_multiplicativo;
        private System.Windows.Forms.Button btn_generar_aleatorios_multiplicativo;
        private System.Windows.Forms.DataGridView grilla_multiplicativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox txt_g_multiplicativo;
        private System.Windows.Forms.TextBox txt_k_multiplicativo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_m_multiplicativo;
        private System.Windows.Forms.TextBox txt_a_multiplicativo;
        private System.Windows.Forms.TextBox txt_semilla_multiplicativo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_generar_aleatorio_mixto;
        private System.Windows.Forms.Button btn_generar_aleatorio_multiplicativo;
        private System.Windows.Forms.Button btn_graficar_mixto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_cantidad_intervalos_mixto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_graficar_multiplicativo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_cantidad_intervalos_multiplicativo;
        private System.Windows.Forms.Label label13;
    }
}

