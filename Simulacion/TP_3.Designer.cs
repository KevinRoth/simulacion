namespace Simulacion
{
    partial class TP_3
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_uniforme_cantidad_intervalos = new System.Windows.Forms.TextBox();
            this.btn_uniforme_grafica = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.grilla_uniforme = new System.Windows.Forms.DataGridView();
            this.btn_uniforme_reestablecer = new System.Windows.Forms.Button();
            this.btn_uniforme_generar = new System.Windows.Forms.Button();
            this.txt_uniforme_cantidad_variables = new System.Windows.Forms.TextBox();
            this.txt_uniforme_b = new System.Windows.Forms.TextBox();
            this.txt_uniforme_a = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_exponencial_cantidad_intervalos = new System.Windows.Forms.TextBox();
            this.btn_exponencial_generar_grafico = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.grilla_exponencial = new System.Windows.Forms.DataGridView();
            this.btn_exponencial_reestablecer = new System.Windows.Forms.Button();
            this.btn_exponencial_generar_aleatorio = new System.Windows.Forms.Button();
            this.txt_exponencial_cantidad_variables = new System.Windows.Forms.TextBox();
            this.txt_exponencial_lambda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_lambda = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_normal_cantidad_intervalos = new System.Windows.Forms.TextBox();
            this.btn_normal_generar_grafica = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.grilla_normal = new System.Windows.Forms.DataGridView();
            this.btn_normal_reestablecer = new System.Windows.Forms.Button();
            this.btn_normal_generar_variables = new System.Windows.Forms.Button();
            this.txt_normal_cantidad_variables = new System.Windows.Forms.TextBox();
            this.txt_normal_desviacion = new System.Windows.Forms.TextBox();
            this.txt_normal_media = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_poisson_cantidad_intervalos = new System.Windows.Forms.TextBox();
            this.btn_poisson_generar_grafica = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.grilla_poisson = new System.Windows.Forms.DataGridView();
            this.btn_poisson_reestablecer = new System.Windows.Forms.Button();
            this.btn_poisson_generar_aleatorios = new System.Windows.Forms.Button();
            this.txt_poisson_cantidad_variables = new System.Windows.Forms.TextBox();
            this.txt_poisson_lambda = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_uniforme)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_exponencial)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_normal)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_poisson)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1137, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_uniforme_cantidad_intervalos);
            this.tabPage1.Controls.Add(this.btn_uniforme_grafica);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.grilla_uniforme);
            this.tabPage1.Controls.Add(this.btn_uniforme_reestablecer);
            this.tabPage1.Controls.Add(this.btn_uniforme_generar);
            this.tabPage1.Controls.Add(this.txt_uniforme_cantidad_variables);
            this.tabPage1.Controls.Add(this.txt_uniforme_b);
            this.tabPage1.Controls.Add(this.txt_uniforme_a);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1129, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Uniforme";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_uniforme_cantidad_intervalos
            // 
            this.txt_uniforme_cantidad_intervalos.Location = new System.Drawing.Point(377, 219);
            this.txt_uniforme_cantidad_intervalos.Name = "txt_uniforme_cantidad_intervalos";
            this.txt_uniforme_cantidad_intervalos.Size = new System.Drawing.Size(100, 20);
            this.txt_uniforme_cantidad_intervalos.TabIndex = 11;
            // 
            // btn_uniforme_grafica
            // 
            this.btn_uniforme_grafica.Location = new System.Drawing.Point(377, 254);
            this.btn_uniforme_grafica.Name = "btn_uniforme_grafica";
            this.btn_uniforme_grafica.Size = new System.Drawing.Size(131, 33);
            this.btn_uniforme_grafica.TabIndex = 10;
            this.btn_uniforme_grafica.Text = "Generar grafica";
            this.btn_uniforme_grafica.UseVisualStyleBackColor = true;
            this.btn_uniforme_grafica.Click += new System.EventHandler(this.btn_uniforme_grafica_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(374, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Cantidad de intervalos";
            // 
            // grilla_uniforme
            // 
            this.grilla_uniforme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_uniforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_uniforme.Location = new System.Drawing.Point(6, 147);
            this.grilla_uniforme.Name = "grilla_uniforme";
            this.grilla_uniforme.Size = new System.Drawing.Size(348, 278);
            this.grilla_uniforme.TabIndex = 8;
            // 
            // btn_uniforme_reestablecer
            // 
            this.btn_uniforme_reestablecer.Location = new System.Drawing.Point(272, 21);
            this.btn_uniforme_reestablecer.Name = "btn_uniforme_reestablecer";
            this.btn_uniforme_reestablecer.Size = new System.Drawing.Size(131, 33);
            this.btn_uniforme_reestablecer.TabIndex = 7;
            this.btn_uniforme_reestablecer.Text = "Reestablecer";
            this.btn_uniforme_reestablecer.UseVisualStyleBackColor = true;
            this.btn_uniforme_reestablecer.Click += new System.EventHandler(this.btn_uniforme_reestablecer_Click);
            // 
            // btn_uniforme_generar
            // 
            this.btn_uniforme_generar.Location = new System.Drawing.Point(272, 72);
            this.btn_uniforme_generar.Name = "btn_uniforme_generar";
            this.btn_uniforme_generar.Size = new System.Drawing.Size(131, 33);
            this.btn_uniforme_generar.TabIndex = 6;
            this.btn_uniforme_generar.Text = "Generar";
            this.btn_uniforme_generar.UseVisualStyleBackColor = true;
            this.btn_uniforme_generar.Click += new System.EventHandler(this.btn_uniforme_generar_Click);
            // 
            // txt_uniforme_cantidad_variables
            // 
            this.txt_uniforme_cantidad_variables.Location = new System.Drawing.Point(137, 84);
            this.txt_uniforme_cantidad_variables.Name = "txt_uniforme_cantidad_variables";
            this.txt_uniforme_cantidad_variables.Size = new System.Drawing.Size(100, 20);
            this.txt_uniforme_cantidad_variables.TabIndex = 5;
            // 
            // txt_uniforme_b
            // 
            this.txt_uniforme_b.Location = new System.Drawing.Point(137, 52);
            this.txt_uniforme_b.Name = "txt_uniforme_b";
            this.txt_uniforme_b.Size = new System.Drawing.Size(100, 20);
            this.txt_uniforme_b.TabIndex = 4;
            // 
            // txt_uniforme_a
            // 
            this.txt_uniforme_a.Location = new System.Drawing.Point(137, 21);
            this.txt_uniforme_a.Name = "txt_uniforme_a";
            this.txt_uniforme_a.Size = new System.Drawing.Size(100, 20);
            this.txt_uniforme_a.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad de variables";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "b";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "a";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_exponencial_cantidad_intervalos);
            this.tabPage2.Controls.Add(this.btn_exponencial_generar_grafico);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.grilla_exponencial);
            this.tabPage2.Controls.Add(this.btn_exponencial_reestablecer);
            this.tabPage2.Controls.Add(this.btn_exponencial_generar_aleatorio);
            this.tabPage2.Controls.Add(this.txt_exponencial_cantidad_variables);
            this.tabPage2.Controls.Add(this.txt_exponencial_lambda);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txt_lambda);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1129, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exponencial";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_exponencial_cantidad_intervalos
            // 
            this.txt_exponencial_cantidad_intervalos.Location = new System.Drawing.Point(383, 228);
            this.txt_exponencial_cantidad_intervalos.Name = "txt_exponencial_cantidad_intervalos";
            this.txt_exponencial_cantidad_intervalos.Size = new System.Drawing.Size(100, 20);
            this.txt_exponencial_cantidad_intervalos.TabIndex = 18;
            // 
            // btn_exponencial_generar_grafico
            // 
            this.btn_exponencial_generar_grafico.Location = new System.Drawing.Point(383, 263);
            this.btn_exponencial_generar_grafico.Name = "btn_exponencial_generar_grafico";
            this.btn_exponencial_generar_grafico.Size = new System.Drawing.Size(131, 33);
            this.btn_exponencial_generar_grafico.TabIndex = 17;
            this.btn_exponencial_generar_grafico.Text = "Generar grafica";
            this.btn_exponencial_generar_grafico.UseVisualStyleBackColor = true;
            this.btn_exponencial_generar_grafico.Click += new System.EventHandler(this.btn_exponencial_generar_grafico_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(380, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Cantidad de intervalos";
            // 
            // grilla_exponencial
            // 
            this.grilla_exponencial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_exponencial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_exponencial.Location = new System.Drawing.Point(3, 158);
            this.grilla_exponencial.Name = "grilla_exponencial";
            this.grilla_exponencial.Size = new System.Drawing.Size(341, 276);
            this.grilla_exponencial.TabIndex = 15;
            // 
            // btn_exponencial_reestablecer
            // 
            this.btn_exponencial_reestablecer.Location = new System.Drawing.Point(313, 35);
            this.btn_exponencial_reestablecer.Name = "btn_exponencial_reestablecer";
            this.btn_exponencial_reestablecer.Size = new System.Drawing.Size(131, 33);
            this.btn_exponencial_reestablecer.TabIndex = 14;
            this.btn_exponencial_reestablecer.Text = "Reestablecer";
            this.btn_exponencial_reestablecer.UseVisualStyleBackColor = true;
            this.btn_exponencial_reestablecer.Click += new System.EventHandler(this.btn_exponencial_reestablecer_Click);
            // 
            // btn_exponencial_generar_aleatorio
            // 
            this.btn_exponencial_generar_aleatorio.Location = new System.Drawing.Point(313, 86);
            this.btn_exponencial_generar_aleatorio.Name = "btn_exponencial_generar_aleatorio";
            this.btn_exponencial_generar_aleatorio.Size = new System.Drawing.Size(131, 33);
            this.btn_exponencial_generar_aleatorio.TabIndex = 13;
            this.btn_exponencial_generar_aleatorio.Text = "Generar";
            this.btn_exponencial_generar_aleatorio.UseVisualStyleBackColor = true;
            this.btn_exponencial_generar_aleatorio.Click += new System.EventHandler(this.btn_exponencial_generar_aleatorio_Click);
            // 
            // txt_exponencial_cantidad_variables
            // 
            this.txt_exponencial_cantidad_variables.Location = new System.Drawing.Point(135, 59);
            this.txt_exponencial_cantidad_variables.Name = "txt_exponencial_cantidad_variables";
            this.txt_exponencial_cantidad_variables.Size = new System.Drawing.Size(100, 20);
            this.txt_exponencial_cantidad_variables.TabIndex = 10;
            // 
            // txt_exponencial_lambda
            // 
            this.txt_exponencial_lambda.Location = new System.Drawing.Point(135, 32);
            this.txt_exponencial_lambda.Name = "txt_exponencial_lambda";
            this.txt_exponencial_lambda.Size = new System.Drawing.Size(100, 20);
            this.txt_exponencial_lambda.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cantidad de variables";
            // 
            // txt_lambda
            // 
            this.txt_lambda.AutoSize = true;
            this.txt_lambda.Location = new System.Drawing.Point(20, 35);
            this.txt_lambda.Name = "txt_lambda";
            this.txt_lambda.Size = new System.Drawing.Size(45, 13);
            this.txt_lambda.TabIndex = 6;
            this.txt_lambda.Text = "Lambda";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txt_normal_cantidad_intervalos);
            this.tabPage3.Controls.Add(this.btn_normal_generar_grafica);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.grilla_normal);
            this.tabPage3.Controls.Add(this.btn_normal_reestablecer);
            this.tabPage3.Controls.Add(this.btn_normal_generar_variables);
            this.tabPage3.Controls.Add(this.txt_normal_cantidad_variables);
            this.tabPage3.Controls.Add(this.txt_normal_desviacion);
            this.tabPage3.Controls.Add(this.txt_normal_media);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1129, 446);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Normal";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cantidad de variables";
            // 
            // txt_normal_cantidad_intervalos
            // 
            this.txt_normal_cantidad_intervalos.Location = new System.Drawing.Point(388, 235);
            this.txt_normal_cantidad_intervalos.Name = "txt_normal_cantidad_intervalos";
            this.txt_normal_cantidad_intervalos.Size = new System.Drawing.Size(100, 20);
            this.txt_normal_cantidad_intervalos.TabIndex = 17;
            // 
            // btn_normal_generar_grafica
            // 
            this.btn_normal_generar_grafica.Location = new System.Drawing.Point(388, 270);
            this.btn_normal_generar_grafica.Name = "btn_normal_generar_grafica";
            this.btn_normal_generar_grafica.Size = new System.Drawing.Size(131, 33);
            this.btn_normal_generar_grafica.TabIndex = 16;
            this.btn_normal_generar_grafica.Text = "Generar grafica";
            this.btn_normal_generar_grafica.UseVisualStyleBackColor = true;
            this.btn_normal_generar_grafica.Click += new System.EventHandler(this.btn_normal_generar_grafica_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(385, 206);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Cantidad de intervalos";
            // 
            // grilla_normal
            // 
            this.grilla_normal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_normal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.grilla_normal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_normal.Location = new System.Drawing.Point(9, 156);
            this.grilla_normal.Name = "grilla_normal";
            this.grilla_normal.Size = new System.Drawing.Size(356, 262);
            this.grilla_normal.TabIndex = 14;
            // 
            // btn_normal_reestablecer
            // 
            this.btn_normal_reestablecer.Location = new System.Drawing.Point(309, 30);
            this.btn_normal_reestablecer.Name = "btn_normal_reestablecer";
            this.btn_normal_reestablecer.Size = new System.Drawing.Size(131, 33);
            this.btn_normal_reestablecer.TabIndex = 13;
            this.btn_normal_reestablecer.Text = "Reestablecer";
            this.btn_normal_reestablecer.UseVisualStyleBackColor = true;
            this.btn_normal_reestablecer.Click += new System.EventHandler(this.btn_normal_reestablecer_Click);
            // 
            // btn_normal_generar_variables
            // 
            this.btn_normal_generar_variables.Location = new System.Drawing.Point(309, 81);
            this.btn_normal_generar_variables.Name = "btn_normal_generar_variables";
            this.btn_normal_generar_variables.Size = new System.Drawing.Size(131, 33);
            this.btn_normal_generar_variables.TabIndex = 12;
            this.btn_normal_generar_variables.Text = "Generar";
            this.btn_normal_generar_variables.UseVisualStyleBackColor = true;
            this.btn_normal_generar_variables.Click += new System.EventHandler(this.btn_normal_generar_variables_Click);
            // 
            // txt_normal_cantidad_variables
            // 
            this.txt_normal_cantidad_variables.Location = new System.Drawing.Point(124, 86);
            this.txt_normal_cantidad_variables.Name = "txt_normal_cantidad_variables";
            this.txt_normal_cantidad_variables.Size = new System.Drawing.Size(100, 20);
            this.txt_normal_cantidad_variables.TabIndex = 11;
            // 
            // txt_normal_desviacion
            // 
            this.txt_normal_desviacion.Location = new System.Drawing.Point(124, 56);
            this.txt_normal_desviacion.Name = "txt_normal_desviacion";
            this.txt_normal_desviacion.Size = new System.Drawing.Size(100, 20);
            this.txt_normal_desviacion.TabIndex = 10;
            // 
            // txt_normal_media
            // 
            this.txt_normal_media.Location = new System.Drawing.Point(124, 27);
            this.txt_normal_media.Name = "txt_normal_media";
            this.txt_normal_media.Size = new System.Drawing.Size(100, 20);
            this.txt_normal_media.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Desviacion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Media";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txt_poisson_cantidad_intervalos);
            this.tabPage4.Controls.Add(this.btn_poisson_generar_grafica);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.grilla_poisson);
            this.tabPage4.Controls.Add(this.btn_poisson_reestablecer);
            this.tabPage4.Controls.Add(this.btn_poisson_generar_aleatorios);
            this.tabPage4.Controls.Add(this.txt_poisson_cantidad_variables);
            this.tabPage4.Controls.Add(this.txt_poisson_lambda);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1129, 446);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Poisson";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_poisson_cantidad_intervalos
            // 
            this.txt_poisson_cantidad_intervalos.Location = new System.Drawing.Point(380, 222);
            this.txt_poisson_cantidad_intervalos.Name = "txt_poisson_cantidad_intervalos";
            this.txt_poisson_cantidad_intervalos.Size = new System.Drawing.Size(100, 20);
            this.txt_poisson_cantidad_intervalos.TabIndex = 17;
            // 
            // btn_poisson_generar_grafica
            // 
            this.btn_poisson_generar_grafica.Location = new System.Drawing.Point(380, 257);
            this.btn_poisson_generar_grafica.Name = "btn_poisson_generar_grafica";
            this.btn_poisson_generar_grafica.Size = new System.Drawing.Size(131, 33);
            this.btn_poisson_generar_grafica.TabIndex = 16;
            this.btn_poisson_generar_grafica.Text = "Generar grafica";
            this.btn_poisson_generar_grafica.UseVisualStyleBackColor = true;
            this.btn_poisson_generar_grafica.Click += new System.EventHandler(this.btn_poisson_generar_grafica_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(377, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Cantidad de intervalos";
            // 
            // grilla_poisson
            // 
            this.grilla_poisson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilla_poisson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla_poisson.Location = new System.Drawing.Point(12, 144);
            this.grilla_poisson.Name = "grilla_poisson";
            this.grilla_poisson.Size = new System.Drawing.Size(344, 290);
            this.grilla_poisson.TabIndex = 14;
            // 
            // btn_poisson_reestablecer
            // 
            this.btn_poisson_reestablecer.Location = new System.Drawing.Point(247, 18);
            this.btn_poisson_reestablecer.Name = "btn_poisson_reestablecer";
            this.btn_poisson_reestablecer.Size = new System.Drawing.Size(131, 33);
            this.btn_poisson_reestablecer.TabIndex = 13;
            this.btn_poisson_reestablecer.Text = "Reestablecer";
            this.btn_poisson_reestablecer.UseVisualStyleBackColor = true;
            this.btn_poisson_reestablecer.Click += new System.EventHandler(this.btn_poisson_reestablecer_Click);
            // 
            // btn_poisson_generar_aleatorios
            // 
            this.btn_poisson_generar_aleatorios.Location = new System.Drawing.Point(247, 69);
            this.btn_poisson_generar_aleatorios.Name = "btn_poisson_generar_aleatorios";
            this.btn_poisson_generar_aleatorios.Size = new System.Drawing.Size(131, 33);
            this.btn_poisson_generar_aleatorios.TabIndex = 12;
            this.btn_poisson_generar_aleatorios.Text = "Generar";
            this.btn_poisson_generar_aleatorios.UseVisualStyleBackColor = true;
            this.btn_poisson_generar_aleatorios.Click += new System.EventHandler(this.btn_poisson_generar_aleatorios_Click);
            // 
            // txt_poisson_cantidad_variables
            // 
            this.txt_poisson_cantidad_variables.Location = new System.Drawing.Point(126, 51);
            this.txt_poisson_cantidad_variables.Name = "txt_poisson_cantidad_variables";
            this.txt_poisson_cantidad_variables.Size = new System.Drawing.Size(100, 20);
            this.txt_poisson_cantidad_variables.TabIndex = 11;
            // 
            // txt_poisson_lambda
            // 
            this.txt_poisson_lambda.Location = new System.Drawing.Point(126, 25);
            this.txt_poisson_lambda.Name = "txt_poisson_lambda";
            this.txt_poisson_lambda.Size = new System.Drawing.Size(100, 20);
            this.txt_poisson_lambda.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cantidad de variables";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Lambda";
            // 
            // TP_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 467);
            this.Controls.Add(this.tabControl1);
            this.Name = "TP_3";
            this.Text = "TP_3";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_uniforme)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_exponencial)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_normal)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla_poisson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt_uniforme_cantidad_variables;
        private System.Windows.Forms.TextBox txt_uniforme_b;
        private System.Windows.Forms.TextBox txt_uniforme_a;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_exponencial_cantidad_variables;
        private System.Windows.Forms.TextBox txt_exponencial_lambda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txt_lambda;
        private System.Windows.Forms.TextBox txt_normal_cantidad_variables;
        private System.Windows.Forms.TextBox txt_normal_desviacion;
        private System.Windows.Forms.TextBox txt_normal_media;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_poisson_cantidad_variables;
        private System.Windows.Forms.TextBox txt_poisson_lambda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_uniforme_generar;
        private System.Windows.Forms.Button btn_uniforme_reestablecer;
        private System.Windows.Forms.DataGridView grilla_uniforme;
        private System.Windows.Forms.TextBox txt_uniforme_cantidad_intervalos;
        private System.Windows.Forms.Button btn_uniforme_grafica;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_exponencial_cantidad_intervalos;
        private System.Windows.Forms.Button btn_exponencial_generar_grafico;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView grilla_exponencial;
        private System.Windows.Forms.Button btn_exponencial_reestablecer;
        private System.Windows.Forms.Button btn_exponencial_generar_aleatorio;
        private System.Windows.Forms.TextBox txt_normal_cantidad_intervalos;
        private System.Windows.Forms.Button btn_normal_generar_grafica;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView grilla_normal;
        private System.Windows.Forms.Button btn_normal_reestablecer;
        private System.Windows.Forms.Button btn_normal_generar_variables;
        private System.Windows.Forms.TextBox txt_poisson_cantidad_intervalos;
        private System.Windows.Forms.Button btn_poisson_generar_grafica;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView grilla_poisson;
        private System.Windows.Forms.Button btn_poisson_reestablecer;
        private System.Windows.Forms.Button btn_poisson_generar_aleatorios;
        private System.Windows.Forms.Label label4;
    }
}