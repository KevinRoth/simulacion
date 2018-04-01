namespace Simulacion
{
    partial class Grafica1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_compro_1 = new System.Windows.Forms.Button();
            this.txt_chicierto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.intervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuenciaEsp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFrecuenciaEsperada = new System.Windows.Forms.Label();
            this.histogramaGenerado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramaGenerado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_compro_1);
            this.groupBox3.Controls.Add(this.txt_chicierto);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(728, 520);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(200, 91);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hipotesis";
            // 
            // btn_compro_1
            // 
            this.btn_compro_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_compro_1.Location = new System.Drawing.Point(7, 51);
            this.btn_compro_1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_compro_1.Name = "btn_compro_1";
            this.btn_compro_1.Size = new System.Drawing.Size(80, 30);
            this.btn_compro_1.TabIndex = 35;
            this.btn_compro_1.Text = "Comprobar";
            this.btn_compro_1.UseVisualStyleBackColor = true;
            this.btn_compro_1.Click += new System.EventHandler(this.btn_compro_Click_1);
            // 
            // txt_chicierto
            // 
            this.txt_chicierto.Location = new System.Drawing.Point(89, 25);
            this.txt_chicierto.Margin = new System.Windows.Forms.Padding(2);
            this.txt_chicierto.Name = "txt_chicierto";
            this.txt_chicierto.Size = new System.Drawing.Size(96, 19);
            this.txt_chicierto.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Ingrese valor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(728, 431);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(200, 73);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Cuadrado Observado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intervalo,
            this.frecuencia,
            this.frecuenciaEsp,
            this.calculo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 352);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(700, 275);
            this.dataGridView1.TabIndex = 37;
            // 
            // intervalo
            // 
            this.intervalo.HeaderText = "Intervalo";
            this.intervalo.Name = "intervalo";
            this.intervalo.Width = 150;
            // 
            // frecuencia
            // 
            this.frecuencia.HeaderText = "Frecuencia Observada";
            this.frecuencia.Name = "frecuencia";
            // 
            // frecuenciaEsp
            // 
            this.frecuenciaEsp.HeaderText = "Frecuencia Esperada";
            this.frecuenciaEsp.Name = "frecuenciaEsp";
            // 
            // calculo
            // 
            this.calculo.HeaderText = "Calculo";
            this.calculo.Name = "calculo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFrecuenciaEsperada);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(728, 362);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frecuencia esperada";
            // 
            // lblFrecuenciaEsperada
            // 
            this.lblFrecuenciaEsperada.AutoSize = true;
            this.lblFrecuenciaEsperada.Location = new System.Drawing.Point(23, 32);
            this.lblFrecuenciaEsperada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrecuenciaEsperada.Name = "lblFrecuenciaEsperada";
            this.lblFrecuenciaEsperada.Size = new System.Drawing.Size(0, 13);
            this.lblFrecuenciaEsperada.TabIndex = 0;
            // 
            // histogramaGenerado
            // 
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.Title = "Intervalos";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.Maximum = 100D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.Title = "Frecuencia";
            chartArea3.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.Name = "ChartArea1";
            this.histogramaGenerado.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.histogramaGenerado.Legends.Add(legend3);
            this.histogramaGenerado.Location = new System.Drawing.Point(12, 12);
            this.histogramaGenerado.Name = "histogramaGenerado";
            this.histogramaGenerado.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series3.IsValueShownAsLabel = true;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.histogramaGenerado.Series.Add(series3);
            this.histogramaGenerado.Size = new System.Drawing.Size(1014, 335);
            this.histogramaGenerado.TabIndex = 35;
            this.histogramaGenerado.Text = "chart1";
            // 
            // Grafica1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 703);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.histogramaGenerado);
            this.Name = "Grafica1";
            this.Text = "Grafica1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramaGenerado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_compro_1;
        private System.Windows.Forms.TextBox txt_chicierto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalo;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuenciaEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFrecuenciaEsperada;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramaGenerado;
    }
}