namespace _DoAn.Views.Statistic
{
    partial class StatisticsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbBillToday = new System.Windows.Forms.Label();
            this.lbBillThisMonth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbProduct = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSumProduct = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbRevenueToday = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbRevenueThisMonth = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgvBestSeller = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvEmployee = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.lbstt = new System.Windows.Forms.Label();
            this.lbViewAllBill = new Bunifu.UI.WinForms.BunifuLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBestSeller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuDatePicker1.Color = System.Drawing.Color.LightGray;
            this.bunifuDatePicker1.CustomFormat = "dd-MM-yyyy";
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(46, 27);
            this.bunifuDatePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 35);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(221, 35);
            this.bunifuDatePicker1.TabIndex = 32;
            this.bunifuDatePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.lbBillToday);
            this.panel1.Controls.Add(this.lbBillThisMonth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(46, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 150);
            this.panel1.TabIndex = 13;
            // 
            // lbBillToday
            // 
            this.lbBillToday.AutoSize = true;
            this.lbBillToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbBillToday.ForeColor = System.Drawing.Color.White;
            this.lbBillToday.Location = new System.Drawing.Point(73, 96);
            this.lbBillToday.Name = "lbBillToday";
            this.lbBillToday.Size = new System.Drawing.Size(75, 24);
            this.lbBillToday.TabIndex = 36;
            this.lbBillToday.Text = "500.000";
            // 
            // lbBillThisMonth
            // 
            this.lbBillThisMonth.AutoSize = true;
            this.lbBillThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbBillThisMonth.ForeColor = System.Drawing.Color.White;
            this.lbBillThisMonth.Location = new System.Drawing.Point(14, 49);
            this.lbBillThisMonth.Name = "lbBillThisMonth";
            this.lbBillThisMonth.Size = new System.Drawing.Size(177, 37);
            this.lbBillThisMonth.TabIndex = 35;
            this.lbBillThisMonth.Text = "10.000.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Today:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Bills of month";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkMagenta;
            this.panel2.Controls.Add(this.lbProduct);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbSumProduct);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(395, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 150);
            this.panel2.TabIndex = 34;
            // 
            // lbProduct
            // 
            this.lbProduct.AutoSize = true;
            this.lbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbProduct.ForeColor = System.Drawing.Color.White;
            this.lbProduct.Location = new System.Drawing.Point(83, 96);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(75, 24);
            this.lbProduct.TabIndex = 38;
            this.lbProduct.Text = "500.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 24);
            this.label5.TabIndex = 37;
            this.label5.Text = "Today:";
            // 
            // lbSumProduct
            // 
            this.lbSumProduct.AutoSize = true;
            this.lbSumProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbSumProduct.ForeColor = System.Drawing.Color.White;
            this.lbSumProduct.Location = new System.Drawing.Point(19, 49);
            this.lbSumProduct.Name = "lbSumProduct";
            this.lbSumProduct.Size = new System.Drawing.Size(177, 37);
            this.lbSumProduct.TabIndex = 36;
            this.lbSumProduct.Text = "10.000.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Products sold month";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.lbRevenueToday);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lbRevenueThisMonth);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(748, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 150);
            this.panel3.TabIndex = 35;
            // 
            // lbRevenueToday
            // 
            this.lbRevenueToday.AutoSize = true;
            this.lbRevenueToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbRevenueToday.ForeColor = System.Drawing.Color.White;
            this.lbRevenueToday.Location = new System.Drawing.Point(86, 96);
            this.lbRevenueToday.Name = "lbRevenueToday";
            this.lbRevenueToday.Size = new System.Drawing.Size(75, 24);
            this.lbRevenueToday.TabIndex = 39;
            this.lbRevenueToday.Text = "500.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(24, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 24);
            this.label9.TabIndex = 38;
            this.label9.Text = "Today:";
            // 
            // lbRevenueThisMonth
            // 
            this.lbRevenueThisMonth.AutoSize = true;
            this.lbRevenueThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbRevenueThisMonth.ForeColor = System.Drawing.Color.White;
            this.lbRevenueThisMonth.Location = new System.Drawing.Point(22, 49);
            this.lbRevenueThisMonth.Name = "lbRevenueThisMonth";
            this.lbRevenueThisMonth.Size = new System.Drawing.Size(177, 37);
            this.lbRevenueThisMonth.TabIndex = 37;
            this.lbRevenueThisMonth.Text = "10.000.000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "Revenue this month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1172, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "Best-Selling products";
            // 
            // dtgvBestSeller
            // 
            this.dtgvBestSeller.AllowCustomTheming = true;
            this.dtgvBestSeller.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dtgvBestSeller.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvBestSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBestSeller.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvBestSeller.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvBestSeller.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvBestSeller.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvBestSeller.ColumnHeadersHeight = 40;
            this.dtgvBestSeller.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dtgvBestSeller.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtgvBestSeller.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgvBestSeller.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtgvBestSeller.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvBestSeller.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dtgvBestSeller.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dtgvBestSeller.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.dtgvBestSeller.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dtgvBestSeller.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvBestSeller.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dtgvBestSeller.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtgvBestSeller.CurrentTheme.Name = null;
            this.dtgvBestSeller.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvBestSeller.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtgvBestSeller.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgvBestSeller.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtgvBestSeller.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvBestSeller.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvBestSeller.EnableHeadersVisualStyles = false;
            this.dtgvBestSeller.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dtgvBestSeller.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.dtgvBestSeller.HeaderBgColor = System.Drawing.Color.Empty;
            this.dtgvBestSeller.HeaderForeColor = System.Drawing.Color.White;
            this.dtgvBestSeller.Location = new System.Drawing.Point(1085, 75);
            this.dtgvBestSeller.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvBestSeller.Name = "dtgvBestSeller";
            this.dtgvBestSeller.ReadOnly = true;
            this.dtgvBestSeller.RowHeadersVisible = false;
            this.dtgvBestSeller.RowHeadersWidth = 62;
            this.dtgvBestSeller.RowTemplate.Height = 40;
            this.dtgvBestSeller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvBestSeller.Size = new System.Drawing.Size(380, 309);
            this.dtgvBestSeller.TabIndex = 1;
            this.dtgvBestSeller.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.LimeGreen;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(46, 252);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(794, 666);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // dtgvEmployee
            // 
            this.dtgvEmployee.AllowCustomTheming = true;
            this.dtgvEmployee.AllowUserToAddRows = false;
            this.dtgvEmployee.AllowUserToDeleteRows = false;
            this.dtgvEmployee.AllowUserToResizeColumns = false;
            this.dtgvEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dtgvEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvEmployee.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvEmployee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvEmployee.ColumnHeadersHeight = 40;
            this.dtgvEmployee.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dtgvEmployee.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtgvEmployee.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgvEmployee.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtgvEmployee.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvEmployee.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dtgvEmployee.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dtgvEmployee.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.dtgvEmployee.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dtgvEmployee.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvEmployee.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dtgvEmployee.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtgvEmployee.CurrentTheme.Name = null;
            this.dtgvEmployee.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvEmployee.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtgvEmployee.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgvEmployee.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtgvEmployee.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvEmployee.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvEmployee.EnableHeadersVisualStyles = false;
            this.dtgvEmployee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dtgvEmployee.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.dtgvEmployee.HeaderBgColor = System.Drawing.Color.Empty;
            this.dtgvEmployee.HeaderForeColor = System.Drawing.Color.White;
            this.dtgvEmployee.Location = new System.Drawing.Point(777, 435);
            this.dtgvEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvEmployee.Name = "dtgvEmployee";
            this.dtgvEmployee.ReadOnly = true;
            this.dtgvEmployee.RowHeadersVisible = false;
            this.dtgvEmployee.RowHeadersWidth = 62;
            this.dtgvEmployee.RowTemplate.Height = 40;
            this.dtgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvEmployee.Size = new System.Drawing.Size(688, 431);
            this.dtgvEmployee.TabIndex = 37;
            this.dtgvEmployee.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.LimeGreen;
            this.dtgvEmployee.DoubleClick += new System.EventHandler(this.dtgvEmployee_DoubleClick);
            // 
            // lbstt
            // 
            this.lbstt.AutoSize = true;
            this.lbstt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lbstt.Location = new System.Drawing.Point(1079, 402);
            this.lbstt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbstt.Name = "lbstt";
            this.lbstt.Size = new System.Drawing.Size(285, 31);
            this.lbstt.TabIndex = 38;
            this.lbstt.Text = "Follow sale activities";
            // 
            // lbViewAllBill
            // 
            this.lbViewAllBill.AllowParentOverrides = false;
            this.lbViewAllBill.AutoEllipsis = false;
            this.lbViewAllBill.BackColor = System.Drawing.Color.LightGreen;
            this.lbViewAllBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbViewAllBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbViewAllBill.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbViewAllBill.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbViewAllBill.Location = new System.Drawing.Point(777, 376);
            this.lbViewAllBill.Margin = new System.Windows.Forms.Padding(2);
            this.lbViewAllBill.Name = "lbViewAllBill";
            this.lbViewAllBill.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbViewAllBill.Size = new System.Drawing.Size(185, 32);
            this.lbViewAllBill.TabIndex = 47;
            this.lbViewAllBill.Text = "View sales statuses";
            this.lbViewAllBill.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbViewAllBill.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lbViewAllBill.Click += new System.EventHandler(this.lbViewAllBill_Click);
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 909);
            this.Controls.Add(this.lbViewAllBill);
            this.Controls.Add(this.lbstt);
            this.Controls.Add(this.dtgvEmployee);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dtgvBestSeller);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuDatePicker1);
            this.Name = "StatisticsView";
            this.Text = "StatisticView";
            this.Load += new System.EventHandler(this.StatisticsView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBestSeller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbBillThisMonth;
        private System.Windows.Forms.Label lbBillToday;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSumProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRevenueToday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbRevenueThisMonth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuDataGridView dtgvBestSeller;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Bunifu.UI.WinForms.BunifuDataGridView dtgvEmployee;
        private System.Windows.Forms.Label lbstt;
        private Bunifu.UI.WinForms.BunifuLabel lbViewAllBill;
    }
}