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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
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
            this.btnCreateBill = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBestSeller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(17, 20);
            this.bunifuDatePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 35);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(201, 35);
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
            this.panel1.Location = new System.Drawing.Point(17, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 136);
            this.panel1.TabIndex = 13;
            // 
            // lbBillToday
            // 
            this.lbBillToday.AutoSize = true;
            this.lbBillToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBillToday.ForeColor = System.Drawing.Color.White;
            this.lbBillToday.Location = new System.Drawing.Point(73, 96);
            this.lbBillToday.Name = "lbBillToday";
            this.lbBillToday.Size = new System.Drawing.Size(67, 20);
            this.lbBillToday.TabIndex = 36;
            this.lbBillToday.Text = "500.000";
            // 
            // lbBillThisMonth
            // 
            this.lbBillThisMonth.AutoSize = true;
            this.lbBillThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBillThisMonth.ForeColor = System.Drawing.Color.White;
            this.lbBillThisMonth.Location = new System.Drawing.Point(14, 49);
            this.lbBillThisMonth.Name = "lbBillThisMonth";
            this.lbBillThisMonth.Size = new System.Drawing.Size(159, 33);
            this.lbBillThisMonth.TabIndex = 35;
            this.lbBillThisMonth.Text = "10.000.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Today:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
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
            this.panel2.Location = new System.Drawing.Point(336, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 136);
            this.panel2.TabIndex = 34;
            // 
            // lbProduct
            // 
            this.lbProduct.AutoSize = true;
            this.lbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduct.ForeColor = System.Drawing.Color.White;
            this.lbProduct.Location = new System.Drawing.Point(83, 96);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(67, 20);
            this.lbProduct.TabIndex = 38;
            this.lbProduct.Text = "500.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Today:";
            // 
            // lbSumProduct
            // 
            this.lbSumProduct.AutoSize = true;
            this.lbSumProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumProduct.ForeColor = System.Drawing.Color.White;
            this.lbSumProduct.Location = new System.Drawing.Point(19, 49);
            this.lbSumProduct.Name = "lbSumProduct";
            this.lbSumProduct.Size = new System.Drawing.Size(159, 33);
            this.lbSumProduct.TabIndex = 36;
            this.lbSumProduct.Text = "10.000.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
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
            this.panel3.Location = new System.Drawing.Point(655, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 136);
            this.panel3.TabIndex = 35;
            // 
            // lbRevenueToday
            // 
            this.lbRevenueToday.AutoSize = true;
            this.lbRevenueToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueToday.ForeColor = System.Drawing.Color.White;
            this.lbRevenueToday.Location = new System.Drawing.Point(86, 96);
            this.lbRevenueToday.Name = "lbRevenueToday";
            this.lbRevenueToday.Size = new System.Drawing.Size(67, 20);
            this.lbRevenueToday.TabIndex = 39;
            this.lbRevenueToday.Text = "500.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(24, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Today:";
            // 
            // lbRevenueThisMonth
            // 
            this.lbRevenueThisMonth.AutoSize = true;
            this.lbRevenueThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueThisMonth.ForeColor = System.Drawing.Color.White;
            this.lbRevenueThisMonth.Location = new System.Drawing.Point(22, 49);
            this.lbRevenueThisMonth.Name = "lbRevenueThisMonth";
            this.lbRevenueThisMonth.Size = new System.Drawing.Size(159, 33);
            this.lbRevenueThisMonth.TabIndex = 37;
            this.lbRevenueThisMonth.Text = "10.000.000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Revenue this month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(716, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 24);
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
            this.dtgvBestSeller.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
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
            this.dtgvBestSeller.Location = new System.Drawing.Point(677, 283);
            this.dtgvBestSeller.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvBestSeller.Name = "dtgvBestSeller";
            this.dtgvBestSeller.ReadOnly = true;
            this.dtgvBestSeller.RowHeadersVisible = false;
            this.dtgvBestSeller.RowHeadersWidth = 62;
            this.dtgvBestSeller.RowTemplate.Height = 40;
            this.dtgvBestSeller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvBestSeller.Size = new System.Drawing.Size(287, 304);
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
            this.chart1.Location = new System.Drawing.Point(12, 223);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(652, 388);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.AllowAnimations = true;
            this.btnCreateBill.AllowMouseEffects = true;
            this.btnCreateBill.AllowToggling = false;
            this.btnCreateBill.AnimationSpeed = 200;
            this.btnCreateBill.AutoGenerateColors = false;
            this.btnCreateBill.AutoRoundBorders = false;
            this.btnCreateBill.AutoSizeLeftIcon = true;
            this.btnCreateBill.AutoSizeRightIcon = true;
            this.btnCreateBill.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateBill.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnCreateBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.BackgroundImage")));
            this.btnCreateBill.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCreateBill.ButtonText = "Create";
            this.btnCreateBill.ButtonTextMarginLeft = 0;
            this.btnCreateBill.ColorContrastOnClick = 45;
            this.btnCreateBill.ColorContrastOnHover = 45;
            this.btnCreateBill.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnCreateBill.CustomizableEdges = borderEdges1;
            this.btnCreateBill.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateBill.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCreateBill.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnCreateBill.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnCreateBill.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCreateBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateBill.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnCreateBill.IconLeft = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.IconLeft")));
            this.btnCreateBill.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateBill.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCreateBill.IconLeftPadding = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnCreateBill.IconMarginLeft = 11;
            this.btnCreateBill.IconPadding = 10;
            this.btnCreateBill.IconRight = null;
            this.btnCreateBill.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateBill.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCreateBill.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCreateBill.IconSize = 25;
            this.btnCreateBill.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnCreateBill.IdleBorderRadius = 0;
            this.btnCreateBill.IdleBorderThickness = 0;
            this.btnCreateBill.IdleFillColor = System.Drawing.Color.Empty;
            this.btnCreateBill.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.IdleIconLeftImage")));
            this.btnCreateBill.IdleIconRightImage = null;
            this.btnCreateBill.IndicateFocus = false;
            this.btnCreateBill.Location = new System.Drawing.Point(809, 12);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCreateBill.OnDisabledState.BorderRadius = 15;
            this.btnCreateBill.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCreateBill.OnDisabledState.BorderThickness = 1;
            this.btnCreateBill.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCreateBill.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCreateBill.OnDisabledState.IconLeftImage = null;
            this.btnCreateBill.OnDisabledState.IconRightImage = null;
            this.btnCreateBill.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCreateBill.onHoverState.BorderRadius = 15;
            this.btnCreateBill.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCreateBill.onHoverState.BorderThickness = 1;
            this.btnCreateBill.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCreateBill.onHoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateBill.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.onHoverState.IconLeftImage")));
            this.btnCreateBill.onHoverState.IconRightImage = null;
            this.btnCreateBill.OnIdleState.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCreateBill.OnIdleState.BorderRadius = 15;
            this.btnCreateBill.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCreateBill.OnIdleState.BorderThickness = 1;
            this.btnCreateBill.OnIdleState.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCreateBill.OnIdleState.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnCreateBill.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnCreateBill.OnIdleState.IconLeftImage")));
            this.btnCreateBill.OnIdleState.IconRightImage = null;
            this.btnCreateBill.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCreateBill.OnPressedState.BorderRadius = 15;
            this.btnCreateBill.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCreateBill.OnPressedState.BorderThickness = 1;
            this.btnCreateBill.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCreateBill.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCreateBill.OnPressedState.IconLeftImage = null;
            this.btnCreateBill.OnPressedState.IconRightImage = null;
            this.btnCreateBill.Size = new System.Drawing.Size(136, 50);
            this.btnCreateBill.TabIndex = 48;
            this.btnCreateBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCreateBill.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCreateBill.TextMarginLeft = 0;
            this.btnCreateBill.TextPadding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCreateBill.UseDefaultRadiusAndThickness = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 623);
            this.Controls.Add(this.btnCreateBill);
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
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCreateBill;
    }
}