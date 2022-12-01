namespace Portfolio_Optimization
{
    partial class FormSelectDecisionMaker
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
            this.chkIndicator = new System.Windows.Forms.ComboBox();
            this.chkSymbol = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtHEven = new System.Windows.Forms.TextBox();
            this.txtSHEven = new System.Windows.Forms.TextBox();
            this.txtDEven = new System.Windows.Forms.TextBox();
            this.txtSDEven = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.chkScope = new System.Windows.Forms.ComboBox();
            this.txtMPeriod = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkIndicator
            // 
            this.chkIndicator.FormattingEnabled = true;
            this.chkIndicator.Location = new System.Drawing.Point(6, 19);
            this.chkIndicator.Name = "chkIndicator";
            this.chkIndicator.Size = new System.Drawing.Size(112, 21);
            this.chkIndicator.TabIndex = 0;
            // 
            // chkSymbol
            // 
            this.chkSymbol.FormattingEnabled = true;
            this.chkSymbol.Location = new System.Drawing.Point(6, 46);
            this.chkSymbol.Name = "chkSymbol";
            this.chkSymbol.Size = new System.Drawing.Size(112, 21);
            this.chkSymbol.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkScope);
            this.groupBox3.Controls.Add(this.txtMPeriod);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.txtHEven);
            this.groupBox3.Controls.Add(this.txtSHEven);
            this.groupBox3.Controls.Add(this.txtDEven);
            this.groupBox3.Controls.Add(this.txtSDEven);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Location = new System.Drawing.Point(2, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 116);
            this.groupBox3.TabIndex = 1017;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time";
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
            this.txtSDEven.Text = "20130801";
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
            // chkScope
            // 
            this.chkScope.FormattingEnabled = true;
            this.chkScope.Location = new System.Drawing.Point(8, 81);
            this.chkScope.Name = "chkScope";
            this.chkScope.Size = new System.Drawing.Size(54, 21);
            this.chkScope.TabIndex = 1018;
            // 
            // txtMPeriod
            // 
            this.txtMPeriod.Location = new System.Drawing.Point(67, 82);
            this.txtMPeriod.Name = "txtMPeriod";
            this.txtMPeriod.Size = new System.Drawing.Size(56, 20);
            this.txtMPeriod.TabIndex = 1019;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIndicator);
            this.groupBox1.Controls.Add(this.chkSymbol);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 78);
            this.groupBox1.TabIndex = 1018;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1020;
            this.button2.Text = "Add Parameter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(136, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(250, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 208);
            this.tableLayoutPanel1.TabIndex = 1021;
            // 
            // FormSelectDecisionMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 249);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Name = "FormSelectDecisionMaker";
            this.Text = "FormSelectDecisionMaker";
            this.Load += new System.EventHandler(this.FormSelectDecisionMaker_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox chkIndicator;
        private System.Windows.Forms.ComboBox chkSymbol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtHEven;
        private System.Windows.Forms.TextBox txtSHEven;
        private System.Windows.Forms.TextBox txtDEven;
        private System.Windows.Forms.TextBox txtSDEven;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox chkScope;
        private System.Windows.Forms.TextBox txtMPeriod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}