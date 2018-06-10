namespace Simulacion
{
    partial class TP_COLAS
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
            this.btn_simular = new System.Windows.Forms.Button();
            this.gb_cantidades = new System.Windows.Forms.GroupBox();
            this.txt_hasta = new System.Windows.Forms.TextBox();
            this.txt_desde = new System.Windows.Forms.TextBox();
            this.txt_dias = new System.Windows.Forms.TextBox();
            this.lbl_dias = new System.Windows.Forms.Label();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.dgv_simulaciones = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_cantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(255, 37);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(126, 23);
            this.btn_simular.TabIndex = 12;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // gb_cantidades
            // 
            this.gb_cantidades.Controls.Add(this.txt_hasta);
            this.gb_cantidades.Controls.Add(this.txt_desde);
            this.gb_cantidades.Controls.Add(this.txt_dias);
            this.gb_cantidades.Controls.Add(this.lbl_dias);
            this.gb_cantidades.Controls.Add(this.lbl_hasta);
            this.gb_cantidades.Controls.Add(this.lbl_desde);
            this.gb_cantidades.Location = new System.Drawing.Point(12, 12);
            this.gb_cantidades.Name = "gb_cantidades";
            this.gb_cantidades.Size = new System.Drawing.Size(179, 114);
            this.gb_cantidades.TabIndex = 11;
            this.gb_cantidades.TabStop = false;
            this.gb_cantidades.Text = "Cantidades:";
            // 
            // txt_hasta
            // 
            this.txt_hasta.Location = new System.Drawing.Point(124, 77);
            this.txt_hasta.Name = "txt_hasta";
            this.txt_hasta.Size = new System.Drawing.Size(37, 20);
            this.txt_hasta.TabIndex = 5;
            this.txt_hasta.Text = "100";
            // 
            // txt_desde
            // 
            this.txt_desde.Location = new System.Drawing.Point(124, 52);
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(37, 20);
            this.txt_desde.TabIndex = 4;
            this.txt_desde.Text = "1";
            // 
            // txt_dias
            // 
            this.txt_dias.Location = new System.Drawing.Point(124, 27);
            this.txt_dias.Name = "txt_dias";
            this.txt_dias.Size = new System.Drawing.Size(37, 20);
            this.txt_dias.TabIndex = 3;
            this.txt_dias.Text = "30";
            // 
            // lbl_dias
            // 
            this.lbl_dias.AutoSize = true;
            this.lbl_dias.Location = new System.Drawing.Point(21, 30);
            this.lbl_dias.Name = "lbl_dias";
            this.lbl_dias.Size = new System.Drawing.Size(33, 13);
            this.lbl_dias.TabIndex = 2;
            this.lbl_dias.Text = "Días:";
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(21, 79);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(74, 13);
            this.lbl_hasta.TabIndex = 1;
            this.lbl_hasta.Text = "Mostrar hasta:";
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(21, 55);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(77, 13);
            this.lbl_desde.TabIndex = 0;
            this.lbl_desde.Text = "Mostrar desde:";
            // 
            // dgv_simulaciones
            // 
            this.dgv_simulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_simulaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column4,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column26,
            this.Column5,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column27,
            this.Column28,
            this.Column30,
            this.Column29,
            this.Column31});
            this.dgv_simulaciones.Location = new System.Drawing.Point(24, 132);
            this.dgv_simulaciones.Name = "dgv_simulaciones";
            this.dgv_simulaciones.Size = new System.Drawing.Size(1258, 461);
            this.dgv_simulaciones.TabIndex = 13;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Dia";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Reloj";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Evento";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Rnd Llegada Auto Continente";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Tiempo entre Llegadas Auto Continente";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Proxima Llegada Auto Continente";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "RND Llegada Camion Continente";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Tiempo entre Llegadas Camion Continente";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Proxima Llegada Camion Continente";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "RND Llegada Auto Isla";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Tiempo entre Llegada Auto Isla";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Proxima Llegada Auto Isla";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "RND Llegada Camion Isla";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Tiempo entre Llegada Camion Isla";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Proxima Llegada Camion Isla";
            this.Column17.Name = "Column17";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Lugar Transbordador 1";
            this.Column4.Name = "Column4";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Estado Transbordador 1";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "RND CARGA T1";
            this.Column19.Name = "Column19";
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Tiempo entre Cargas T1";
            this.Column20.Name = "Column20";
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Proxima Carga ";
            this.Column21.Name = "Column21";
            // 
            // Column26
            // 
            this.Column26.HeaderText = "Capacidad T1";
            this.Column26.Name = "Column26";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Lugar Transbordador 2";
            this.Column5.Name = "Column5";
            // 
            // Column22
            // 
            this.Column22.HeaderText = "Estado Transbordador 2";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "RND Carga T2";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.HeaderText = "Tiempo entre Cargas T2";
            this.Column24.Name = "Column24";
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Proxima Carga T2";
            this.Column25.Name = "Column25";
            // 
            // Column27
            // 
            this.Column27.HeaderText = "Capacidad T2";
            this.Column27.Name = "Column27";
            // 
            // Column28
            // 
            this.Column28.HeaderText = "Cola Vehiculos Continente";
            this.Column28.Name = "Column28";
            // 
            // Column30
            // 
            this.Column30.HeaderText = "Maxima Cola Vehiculos Continente";
            this.Column30.Name = "Column30";
            // 
            // Column29
            // 
            this.Column29.HeaderText = "Cola Vehiculos Isla";
            this.Column29.Name = "Column29";
            // 
            // Column31
            // 
            this.Column31.HeaderText = "Maxima Cola Vehiculos Continente";
            this.Column31.Name = "Column31";
            // 
            // TP_COLAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 605);
            this.Controls.Add(this.dgv_simulaciones);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.gb_cantidades);
            this.Name = "TP_COLAS";
            this.Text = "TP_COLAS";
            this.gb_cantidades.ResumeLayout(false);
            this.gb_cantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.GroupBox gb_cantidades;
        private System.Windows.Forms.TextBox txt_hasta;
        private System.Windows.Forms.TextBox txt_desde;
        private System.Windows.Forms.TextBox txt_dias;
        private System.Windows.Forms.Label lbl_dias;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.DataGridView dgv_simulaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
    }
}