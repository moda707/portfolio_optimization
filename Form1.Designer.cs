namespace Portfolio_Optimization
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgAllSymbols = new System.Windows.Forms.DataGridView();
            this.dgSymbolsSummary = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitialCash = new System.Windows.Forms.TextBox();
            this.txtNAdd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtprofit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.txtTransCost = new System.Windows.Forms.TextBox();
            this.txtCurentCash = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMPeriod = new System.Windows.Forms.TextBox();
            this.cmbScop = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtHEven = new System.Windows.Forms.TextBox();
            this.txtSHEven = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDEven = new System.Windows.Forms.TextBox();
            this.txtSDEven = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSymCount = new System.Windows.Forms.TextBox();
            this.chktop50 = new System.Windows.Forms.RadioButton();
            this.chkall = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lstFinalSymbol = new System.Windows.Forms.ListBox();
            this.btnleftall = new System.Windows.Forms.Button();
            this.btnoneleft = new System.Windows.Forms.Button();
            this.btnrightall = new System.Windows.Forms.Button();
            this.btnoneright = new System.Windows.Forms.Button();
            this.lstFirstSymbol = new System.Windows.Forms.ListBox();
            this.txtsymbolsearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllSymbols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSymbolsSummary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAllSymbols
            // 
            this.dgAllSymbols.AllowUserToAddRows = false;
            this.dgAllSymbols.AllowUserToDeleteRows = false;
            this.dgAllSymbols.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAllSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllSymbols.Location = new System.Drawing.Point(0, 0);
            this.dgAllSymbols.Name = "dgAllSymbols";
            this.dgAllSymbols.ReadOnly = true;
            this.dgAllSymbols.Size = new System.Drawing.Size(557, 296);
            this.dgAllSymbols.TabIndex = 1012;
            // 
            // dgSymbolsSummary
            // 
            this.dgSymbolsSummary.AllowUserToAddRows = false;
            this.dgSymbolsSummary.AllowUserToDeleteRows = false;
            this.dgSymbolsSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSymbolsSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSymbolsSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSymbolsSummary.Location = new System.Drawing.Point(0, 0);
            this.dgSymbolsSummary.Name = "dgSymbolsSummary";
            this.dgSymbolsSummary.ReadOnly = true;
            this.dgSymbolsSummary.Size = new System.Drawing.Size(387, 296);
            this.dgSymbolsSummary.TabIndex = 1013;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInitialCash);
            this.groupBox1.Controls.Add(this.txtNAdd);
            this.groupBox1.Location = new System.Drawing.Point(5, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 68);
            this.groupBox1.TabIndex = 1014;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Params";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1019;
            this.label2.Text = "Initial Cash";
            // 
            // txtInitialCash
            // 
            this.txtInitialCash.Location = new System.Drawing.Point(70, 45);
            this.txtInitialCash.Name = "txtInitialCash";
            this.txtInitialCash.Size = new System.Drawing.Size(100, 20);
            this.txtInitialCash.TabIndex = 1;
            this.txtInitialCash.Text = "10000000";
            // 
            // txtNAdd
            // 
            this.txtNAdd.Location = new System.Drawing.Point(6, 19);
            this.txtNAdd.Name = "txtNAdd";
            this.txtNAdd.Size = new System.Drawing.Size(180, 20);
            this.txtNAdd.TabIndex = 0;
            this.txtNAdd.Text = "X:\\Combination\\LongTerm Training\\M5-20130705-20130831-C";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtprofit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnOptimize);
            this.groupBox2.Controls.Add(this.txtsum);
            this.groupBox2.Controls.Add(this.txtTransCost);
            this.groupBox2.Controls.Add(this.txtCurentCash);
            this.groupBox2.Location = new System.Drawing.Point(5, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 173);
            this.groupBox2.TabIndex = 1015;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(125, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 30);
            this.button4.TabIndex = 1021;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 30);
            this.button1.TabIndex = 1020;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtprofit
            // 
            this.txtprofit.Enabled = false;
            this.txtprofit.Location = new System.Drawing.Point(84, 77);
            this.txtprofit.Name = "txtprofit";
            this.txtprofit.Size = new System.Drawing.Size(50, 20);
            this.txtprofit.TabIndex = 1019;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1018;
            this.label3.Text = "Profit %";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-5, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 1018;
            this.label6.Text = "Transaction Cost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1018;
            this.label1.Text = "Portfolio Value";
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(6, 19);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(180, 30);
            this.btnOptimize.TabIndex = 0;
            this.btnOptimize.Text = "Run Simulation";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // txtsum
            // 
            this.txtsum.Enabled = false;
            this.txtsum.Location = new System.Drawing.Point(84, 129);
            this.txtsum.Name = "txtsum";
            this.txtsum.Size = new System.Drawing.Size(94, 20);
            this.txtsum.TabIndex = 1017;
            // 
            // txtTransCost
            // 
            this.txtTransCost.Enabled = false;
            this.txtTransCost.Location = new System.Drawing.Point(84, 103);
            this.txtTransCost.Name = "txtTransCost";
            this.txtTransCost.Size = new System.Drawing.Size(94, 20);
            this.txtTransCost.TabIndex = 1017;
            // 
            // txtCurentCash
            // 
            this.txtCurentCash.Enabled = false;
            this.txtCurentCash.Location = new System.Drawing.Point(84, 52);
            this.txtCurentCash.Name = "txtCurentCash";
            this.txtCurentCash.Size = new System.Drawing.Size(94, 20);
            this.txtCurentCash.TabIndex = 1017;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMPeriod);
            this.groupBox3.Controls.Add(this.cmbScop);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.txtHEven);
            this.groupBox3.Controls.Add(this.txtSHEven);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDEven);
            this.groupBox3.Controls.Add(this.txtSDEven);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(5, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 108);
            this.groupBox3.TabIndex = 1016;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Back Test Period";
            // 
            // txtMPeriod
            // 
            this.txtMPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMPeriod.Location = new System.Drawing.Point(46, 80);
            this.txtMPeriod.Name = "txtMPeriod";
            this.txtMPeriod.Size = new System.Drawing.Size(29, 20);
            this.txtMPeriod.TabIndex = 1008;
            this.txtMPeriod.Text = "6";
            // 
            // cmbScop
            // 
            this.cmbScop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbScop.FormattingEnabled = true;
            this.cmbScop.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "30",
            "60"});
            this.cmbScop.Location = new System.Drawing.Point(8, 81);
            this.cmbScop.Name = "cmbScop";
            this.cmbScop.Size = new System.Drawing.Size(34, 21);
            this.cmbScop.TabIndex = 1007;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(13, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 13);
            this.label40.TabIndex = 61;
            this.label40.Text = "Start";
            // 
            // txtHEven
            // 
            this.txtHEven.Location = new System.Drawing.Point(67, 54);
            this.txtHEven.Name = "txtHEven";
            this.txtHEven.Size = new System.Drawing.Size(56, 20);
            this.txtHEven.TabIndex = 7;
            this.txtHEven.Text = "121000";
            // 
            // txtSHEven
            // 
            this.txtSHEven.Location = new System.Drawing.Point(8, 55);
            this.txtSHEven.Name = "txtSHEven";
            this.txtSHEven.Size = new System.Drawing.Size(54, 20);
            this.txtSHEven.TabIndex = 5;
            this.txtSHEven.Text = "90000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "HEven";
            // 
            // txtDEven
            // 
            this.txtDEven.Location = new System.Drawing.Point(67, 32);
            this.txtDEven.Name = "txtDEven";
            this.txtDEven.Size = new System.Drawing.Size(56, 20);
            this.txtDEven.TabIndex = 6;
            this.txtDEven.Text = "20130831";
            // 
            // txtSDEven
            // 
            this.txtSDEven.Location = new System.Drawing.Point(8, 33);
            this.txtSDEven.Name = "txtSDEven";
            this.txtSDEven.Size = new System.Drawing.Size(54, 20);
            this.txtSDEven.TabIndex = 4;
            this.txtSDEven.Text = "20130715";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(76, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(26, 13);
            this.label41.TabIndex = 61;
            this.label41.Text = "End";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "DEven";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // chart1
            // 
            lineAnnotation3.Name = "LineAnnotation1";
            this.chart1.Annotations.Add(lineAnnotation3);
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Price";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(948, 302);
            this.chart1.TabIndex = 1018;
            this.chart1.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(948, 602);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 1019;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgAllSymbols);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgSymbolsSummary);
            this.splitContainer3.Size = new System.Drawing.Size(948, 296);
            this.splitContainer3.SplitterDistance = 557;
            this.splitContainer3.TabIndex = 1014;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1160, 602);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 1020;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtSymCount);
            this.groupBox5.Controls.Add(this.chktop50);
            this.groupBox5.Controls.Add(this.chkall);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.lstFinalSymbol);
            this.groupBox5.Controls.Add(this.btnleftall);
            this.groupBox5.Controls.Add(this.btnoneleft);
            this.groupBox5.Controls.Add(this.btnrightall);
            this.groupBox5.Controls.Add(this.btnoneright);
            this.groupBox5.Controls.Add(this.lstFirstSymbol);
            this.groupBox5.Controls.Add(this.txtsymbolsearch);
            this.groupBox5.Location = new System.Drawing.Point(5, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(195, 230);
            this.groupBox5.TabIndex = 1017;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Symbols";
            // 
            // txtSymCount
            // 
            this.txtSymCount.Enabled = false;
            this.txtSymCount.Location = new System.Drawing.Point(159, 62);
            this.txtSymCount.Name = "txtSymCount";
            this.txtSymCount.Size = new System.Drawing.Size(30, 20);
            this.txtSymCount.TabIndex = 58;
            this.txtSymCount.Text = "0";
            // 
            // chktop50
            // 
            this.chktop50.AutoSize = true;
            this.chktop50.Location = new System.Drawing.Point(10, 39);
            this.chktop50.Name = "chktop50";
            this.chktop50.Size = new System.Drawing.Size(112, 17);
            this.chktop50.TabIndex = 57;
            this.chktop50.Text = "Top 50 By Volume";
            this.chktop50.UseVisualStyleBackColor = true;
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Checked = true;
            this.chkall.Location = new System.Drawing.Point(10, 16);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(36, 17);
            this.chkall.TabIndex = 56;
            this.chkall.TabStop = true;
            this.chkall.Text = "All";
            this.chkall.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 23);
            this.button3.TabIndex = 55;
            this.button3.Text = "Export";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstFinalSymbol
            // 
            this.lstFinalSymbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstFinalSymbol.FormattingEnabled = true;
            this.lstFinalSymbol.Location = new System.Drawing.Point(101, 84);
            this.lstFinalSymbol.Name = "lstFinalSymbol";
            this.lstFinalSymbol.Size = new System.Drawing.Size(89, 82);
            this.lstFinalSymbol.TabIndex = 50;
            this.lstFinalSymbol.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFinalSymbol_MouseDoubleClick);
            // 
            // btnleftall
            // 
            this.btnleftall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnleftall.Location = new System.Drawing.Point(101, 172);
            this.btnleftall.Name = "btnleftall";
            this.btnleftall.Size = new System.Drawing.Size(28, 23);
            this.btnleftall.TabIndex = 51;
            this.btnleftall.Text = "<<";
            this.btnleftall.UseVisualStyleBackColor = true;
            this.btnleftall.Click += new System.EventHandler(this.btnoneleft_Click);
            // 
            // btnoneleft
            // 
            this.btnoneleft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnoneleft.Location = new System.Drawing.Point(135, 172);
            this.btnoneleft.Name = "btnoneleft";
            this.btnoneleft.Size = new System.Drawing.Size(28, 23);
            this.btnoneleft.TabIndex = 51;
            this.btnoneleft.Text = "<";
            this.btnoneleft.UseVisualStyleBackColor = true;
            this.btnoneleft.Click += new System.EventHandler(this.btnleftall_Click);
            // 
            // btnrightall
            // 
            this.btnrightall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnrightall.Location = new System.Drawing.Point(68, 172);
            this.btnrightall.Name = "btnrightall";
            this.btnrightall.Size = new System.Drawing.Size(27, 23);
            this.btnrightall.TabIndex = 52;
            this.btnrightall.Text = ">>";
            this.btnrightall.UseVisualStyleBackColor = true;
            this.btnrightall.Click += new System.EventHandler(this.btnrightall_Click);
            // 
            // btnoneright
            // 
            this.btnoneright.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnoneright.Location = new System.Drawing.Point(35, 172);
            this.btnoneright.Name = "btnoneright";
            this.btnoneright.Size = new System.Drawing.Size(27, 23);
            this.btnoneright.TabIndex = 52;
            this.btnoneright.Text = ">";
            this.btnoneright.UseVisualStyleBackColor = true;
            this.btnoneright.Click += new System.EventHandler(this.btnoneright_Click);
            // 
            // lstFirstSymbol
            // 
            this.lstFirstSymbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstFirstSymbol.FormattingEnabled = true;
            this.lstFirstSymbol.Location = new System.Drawing.Point(10, 84);
            this.lstFirstSymbol.Name = "lstFirstSymbol";
            this.lstFirstSymbol.Size = new System.Drawing.Size(85, 82);
            this.lstFirstSymbol.TabIndex = 53;
            this.lstFirstSymbol.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFirstSymbol_MouseDoubleClick);
            // 
            // txtsymbolsearch
            // 
            this.txtsymbolsearch.Location = new System.Drawing.Point(9, 62);
            this.txtsymbolsearch.Name = "txtsymbolsearch";
            this.txtsymbolsearch.Size = new System.Drawing.Size(145, 20);
            this.txtsymbolsearch.TabIndex = 49;
            this.txtsymbolsearch.TextChanged += new System.EventHandler(this.txtsymbolsearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 602);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllSymbols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSymbolsSummary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAllSymbols;
        private System.Windows.Forms.DataGridView dgSymbolsSummary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMPeriod;
        private System.Windows.Forms.ComboBox cmbScop;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtHEven;
        private System.Windows.Forms.TextBox txtSHEven;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDEven;
        private System.Windows.Forms.TextBox txtSDEven;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInitialCash;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtCurentCash;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtprofit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransCost;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSymCount;
        private System.Windows.Forms.RadioButton chktop50;
        private System.Windows.Forms.RadioButton chkall;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstFinalSymbol;
        private System.Windows.Forms.Button btnleftall;
        private System.Windows.Forms.Button btnoneleft;
        private System.Windows.Forms.Button btnrightall;
        private System.Windows.Forms.Button btnoneright;
        private System.Windows.Forms.ListBox lstFirstSymbol;
        private System.Windows.Forms.TextBox txtsymbolsearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}

