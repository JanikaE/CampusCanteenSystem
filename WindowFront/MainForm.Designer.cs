namespace WindowFront
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TimerPort = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            LabelPortTips = new Label();
            LableWebTips = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            TextBoxName = new TextBox();
            LableName = new Label();
            TimerNet = new System.Windows.Forms.Timer(components);
            LableMoney = new Label();
            TextBoxMoney = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TimerPort
            // 
            TimerPort.Interval = 300;
            TimerPort.Tick += TimerPort_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.90206F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.0979385F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4319248F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.56808F));
            tableLayoutPanel1.Size = new Size(776, 426);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(LabelPortTips, 0, 1);
            tableLayoutPanel2.Controls.Add(LableWebTips, 0, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel2.Size = new Size(272, 64);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // LabelPortTips
            // 
            LabelPortTips.Anchor = AnchorStyles.Left;
            LabelPortTips.AutoSize = true;
            LabelPortTips.Location = new Point(3, 36);
            LabelPortTips.Name = "LabelPortTips";
            LabelPortTips.Size = new Size(70, 20);
            LabelPortTips.TabIndex = 3;
            LabelPortTips.Text = "PortTips";
            LabelPortTips.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LableWebTips
            // 
            LableWebTips.Anchor = AnchorStyles.Left;
            LableWebTips.AutoSize = true;
            LableWebTips.Location = new Point(3, 4);
            LableWebTips.Name = "LableWebTips";
            LableWebTips.Size = new Size(73, 20);
            LableWebTips.TabIndex = 2;
            LableWebTips.Text = "WebTips";
            LableWebTips.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(TextBoxName, 0, 1);
            tableLayoutPanel3.Controls.Add(LableName, 0, 0);
            tableLayoutPanel3.Controls.Add(LableMoney, 0, 3);
            tableLayoutPanel3.Controls.Add(TextBoxMoney, 0, 4);
            tableLayoutPanel3.Location = new Point(592, 73);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 47.12644F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 52.87356F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 192F));
            tableLayoutPanel3.Size = new Size(181, 350);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Left;
            TextBoxName.Enabled = false;
            TextBoxName.Location = new Point(3, 69);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.ReadOnly = true;
            TextBoxName.Size = new Size(125, 27);
            TextBoxName.TabIndex = 0;
            // 
            // LableName
            // 
            LableName.Anchor = AnchorStyles.Left;
            LableName.AutoSize = true;
            LableName.Location = new Point(3, 16);
            LableName.Name = "LableName";
            LableName.Size = new Size(54, 20);
            LableName.TabIndex = 1;
            LableName.Text = "姓名：";
            // 
            // TimerNet
            // 
            TimerNet.Enabled = true;
            TimerNet.Interval = 5000;
            TimerNet.Tick += TimerNet_Tick;
            // 
            // LableMoney
            // 
            LableMoney.Anchor = AnchorStyles.Left;
            LableMoney.AutoSize = true;
            LableMoney.Location = new Point(3, 125);
            LableMoney.Name = "LableMoney";
            LableMoney.Size = new Size(54, 20);
            LableMoney.TabIndex = 2;
            LableMoney.Text = "余额：";
            // 
            // TextBoxMoney
            // 
            TextBoxMoney.Anchor = AnchorStyles.Left;
            TextBoxMoney.Enabled = false;
            TextBoxMoney.Location = new Point(3, 240);
            TextBoxMoney.Name = "TextBoxMoney";
            TextBoxMoney.ReadOnly = true;
            TextBoxMoney.Size = new Size(125, 27);
            TextBoxMoney.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer TimerPort;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label LableWebTips;
        private Label LabelPortTips;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox TextBoxName;
        private Label LableName;
        private System.Windows.Forms.Timer TimerNet;
        private Label LableMoney;
        private TextBox TextBoxMoney;
    }
}
