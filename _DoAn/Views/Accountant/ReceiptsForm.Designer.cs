namespace _DoAn.Views.Accountant
{
    partial class ReceiptsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.dateTimePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReceipts = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnAdd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackColor = System.Drawing.Color.LightGreen;
            this.dateTimePicker1.BorderColor = System.Drawing.Color.Silver;
            this.dateTimePicker1.BorderRadius = 1;
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.Color = System.Drawing.Color.Silver;
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dateTimePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dateTimePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.dateTimePicker1.DisplayWeekNumbers = false;
            this.dateTimePicker1.DPHeight = 0;
            this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker1.FillDatePicker = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("dateTimePicker1.Icon")));
            this.dateTimePicker1.IconColor = System.Drawing.Color.Gray;
            this.dateTimePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dateTimePicker1.LeftTextMargin = 5;
            this.dateTimePicker1.Location = new System.Drawing.Point(370, 17);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(4, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 32);
            this.dateTimePicker1.TabIndex = 72;
            this.dateTimePicker1.Value = new System.DateTime(2023, 12, 6, 22, 26, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.Location = new System.Drawing.Point(254, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "Filter";
            // 
            // dgvReceipts
            // 
            this.dgvReceipts.AllowCustomTheming = true;
            this.dgvReceipts.AllowUserToAddRows = false;
            this.dgvReceipts.AllowUserToDeleteRows = false;
            this.dgvReceipts.AllowUserToResizeColumns = false;
            this.dgvReceipts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvReceipts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceipts.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceipts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReceipts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(111)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceipts.ColumnHeadersHeight = 40;
            this.dgvReceipts.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReceipts.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvReceipts.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReceipts.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(185)))), ((int)(((byte)(122)))));
            this.dgvReceipts.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReceipts.CurrentTheme.BackColor = System.Drawing.Color.ForestGreen;
            this.dgvReceipts.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dgvReceipts.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.dgvReceipts.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvReceipts.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReceipts.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(111)))), ((int)(((byte)(27)))));
            this.dgvReceipts.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReceipts.CurrentTheme.Name = null;
            this.dgvReceipts.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(231)))), ((int)(((byte)(210)))));
            this.dgvReceipts.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvReceipts.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReceipts.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(185)))), ((int)(((byte)(122)))));
            this.dgvReceipts.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(231)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(185)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceipts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceipts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReceipts.EnableHeadersVisualStyles = false;
            this.dgvReceipts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(188)))));
            this.dgvReceipts.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.dgvReceipts.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvReceipts.HeaderForeColor = System.Drawing.Color.White;
            this.dgvReceipts.Location = new System.Drawing.Point(0, 86);
            this.dgvReceipts.Margin = new System.Windows.Forms.Padding(6);
            this.dgvReceipts.Name = "dgvReceipts";
            this.dgvReceipts.ReadOnly = true;
            this.dgvReceipts.RowHeadersVisible = false;
            this.dgvReceipts.RowHeadersWidth = 51;
            this.dgvReceipts.RowTemplate.Height = 40;
            this.dgvReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipts.Size = new System.Drawing.Size(1495, 823);
            this.dgvReceipts.TabIndex = 75;
            this.dgvReceipts.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgvReceipts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceipts_CellContentClick_1);
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Incomplete",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(686, 20);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(160, 32);
            this.cbStatus.TabIndex = 76;
            this.cbStatus.Text = "Status";
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.Location = new System.Drawing.Point(47, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 27);
            this.label2.TabIndex = 77;
            this.label2.Text = "All of the receipts ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AllowAnimations = true;
            this.btnEdit.AllowMouseEffects = true;
            this.btnEdit.AllowToggling = false;
            this.btnEdit.AnimationSpeed = 200;
            this.btnEdit.AutoGenerateColors = false;
            this.btnEdit.AutoRoundBorders = false;
            this.btnEdit.AutoSizeLeftIcon = true;
            this.btnEdit.AutoSizeRightIcon = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEdit.ButtonText = "Edit";
            this.btnEdit.ButtonTextMarginLeft = 0;
            this.btnEdit.ColorContrastOnClick = 45;
            this.btnEdit.ColorContrastOnHover = 45;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnEdit.CustomizableEdges = borderEdges1;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEdit.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnEdit.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnEdit.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.Orange;
            this.btnEdit.IconLeft = ((System.Drawing.Image)(resources.GetObject("btnEdit.IconLeft")));
            this.btnEdit.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnEdit.IconMarginLeft = 11;
            this.btnEdit.IconPadding = 17;
            this.btnEdit.IconRight = null;
            this.btnEdit.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEdit.IconSize = 25;
            this.btnEdit.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnEdit.IdleBorderRadius = 0;
            this.btnEdit.IdleBorderThickness = 0;
            this.btnEdit.IdleFillColor = System.Drawing.Color.Empty;
            this.btnEdit.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.IdleIconLeftImage")));
            this.btnEdit.IdleIconRightImage = null;
            this.btnEdit.IndicateFocus = false;
            this.btnEdit.Location = new System.Drawing.Point(1312, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEdit.OnDisabledState.BorderRadius = 15;
            this.btnEdit.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEdit.OnDisabledState.BorderThickness = 1;
            this.btnEdit.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEdit.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEdit.OnDisabledState.IconLeftImage = null;
            this.btnEdit.OnDisabledState.IconRightImage = null;
            this.btnEdit.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(183)))), ((int)(((byte)(59)))));
            this.btnEdit.onHoverState.BorderRadius = 15;
            this.btnEdit.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEdit.onHoverState.BorderThickness = 1;
            this.btnEdit.onHoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnEdit.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(183)))), ((int)(((byte)(59)))));
            this.btnEdit.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.onHoverState.IconLeftImage")));
            this.btnEdit.onHoverState.IconRightImage = null;
            this.btnEdit.OnIdleState.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEdit.OnIdleState.BorderRadius = 15;
            this.btnEdit.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEdit.OnIdleState.BorderThickness = 1;
            this.btnEdit.OnIdleState.FillColor = System.Drawing.SystemColors.Control;
            this.btnEdit.OnIdleState.ForeColor = System.Drawing.Color.Orange;
            this.btnEdit.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.OnIdleState.IconLeftImage")));
            this.btnEdit.OnIdleState.IconRightImage = null;
            this.btnEdit.OnPressedState.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnEdit.OnPressedState.BorderRadius = 15;
            this.btnEdit.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEdit.OnPressedState.BorderThickness = 1;
            this.btnEdit.OnPressedState.FillColor = System.Drawing.SystemColors.Control;
            this.btnEdit.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.OnPressedState.IconLeftImage = null;
            this.btnEdit.OnPressedState.IconRightImage = null;
            this.btnEdit.Size = new System.Drawing.Size(120, 60);
            this.btnEdit.TabIndex = 79;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEdit.TextMarginLeft = 0;
            this.btnEdit.TextPadding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEdit.UseDefaultRadiusAndThickness = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.AllowAnimations = true;
            this.btnAdd.AllowMouseEffects = true;
            this.btnAdd.AllowToggling = false;
            this.btnAdd.AnimationSpeed = 200;
            this.btnAdd.AutoGenerateColors = false;
            this.btnAdd.AutoRoundBorders = false;
            this.btnAdd.AutoSizeLeftIcon = true;
            this.btnAdd.AutoSizeRightIcon = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.ButtonText = "Add";
            this.btnAdd.ButtonTextMarginLeft = 0;
            this.btnAdd.ColorContrastOnClick = 45;
            this.btnAdd.ColorContrastOnHover = 45;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAdd.CustomizableEdges = borderEdges2;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAdd.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnAdd.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnAdd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.IconLeft = ((System.Drawing.Image)(resources.GetObject("btnAdd.IconLeft")));
            this.btnAdd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnAdd.IconMarginLeft = 11;
            this.btnAdd.IconPadding = 17;
            this.btnAdd.IconRight = null;
            this.btnAdd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAdd.IconSize = 25;
            this.btnAdd.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnAdd.IdleBorderRadius = 0;
            this.btnAdd.IdleBorderThickness = 0;
            this.btnAdd.IdleFillColor = System.Drawing.Color.Empty;
            this.btnAdd.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.IdleIconLeftImage")));
            this.btnAdd.IdleIconRightImage = null;
            this.btnAdd.IndicateFocus = false;
            this.btnAdd.Location = new System.Drawing.Point(1153, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAdd.OnDisabledState.BorderRadius = 15;
            this.btnAdd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnDisabledState.BorderThickness = 1;
            this.btnAdd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAdd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAdd.OnDisabledState.IconLeftImage = null;
            this.btnAdd.OnDisabledState.IconRightImage = null;
            this.btnAdd.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.btnAdd.onHoverState.BorderRadius = 15;
            this.btnAdd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.onHoverState.BorderThickness = 1;
            this.btnAdd.onHoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAdd.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(168)))), ((int)(((byte)(80)))));
            this.btnAdd.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.onHoverState.IconLeftImage")));
            this.btnAdd.onHoverState.IconRightImage = null;
            this.btnAdd.OnIdleState.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdd.OnIdleState.BorderRadius = 15;
            this.btnAdd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnIdleState.BorderThickness = 1;
            this.btnAdd.OnIdleState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAdd.OnIdleState.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.OnIdleState.IconLeftImage")));
            this.btnAdd.OnIdleState.IconRightImage = null;
            this.btnAdd.OnPressedState.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAdd.OnPressedState.BorderRadius = 15;
            this.btnAdd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnPressedState.BorderThickness = 1;
            this.btnAdd.OnPressedState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAdd.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.OnPressedState.IconLeftImage = null;
            this.btnAdd.OnPressedState.IconRightImage = null;
            this.btnAdd.Size = new System.Drawing.Size(120, 60);
            this.btnAdd.TabIndex = 78;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.TextMarginLeft = 0;
            this.btnAdd.TextPadding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAdd.UseDefaultRadiusAndThickness = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ReceiptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 909);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dgvReceipts);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "ReceiptsForm";
            this.Text = "ReceiptsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuDatePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvReceipts;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnEdit;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAdd;
    }
}