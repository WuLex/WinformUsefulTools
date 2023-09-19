using Sunny.UI;

namespace DataSyncTool
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
            this.labelSourceDb = new Sunny.UI.UILabel();
            this.comboBoxSourceDb = new Sunny.UI.UIComboBox();
            this.labelTargetDb = new Sunny.UI.UILabel();
            this.comboBoxTargetDb = new Sunny.UI.UIComboBox();
            this.labelSourceTable = new Sunny.UI.UILabel();
            this.comboBoxSourceTable = new Sunny.UI.UIComboBox();
            this.labelTargetTable = new Sunny.UI.UILabel();
            this.comboBoxTargetTable = new Sunny.UI.UIComboBox();
            this.buttonSync = new Sunny.UI.UIButton();
            this.resultRichTextBox = new Sunny.UI.UIRichTextBox();
            this.sourceServerTextBox = new Sunny.UI.UITextBox();
            this.sourceUsernameTextBox = new Sunny.UI.UITextBox();
            this.sourcePasswordTextBox = new Sunny.UI.UITextBox();
            this.targetServerTextBox = new Sunny.UI.UITextBox();
            this.targetUsernameTextBox = new Sunny.UI.UITextBox();
            this.targetPasswordTextBox = new Sunny.UI.UITextBox();
            this.sourceConnectButton = new Sunny.UI.UIButton();
            this.targetConnectButton = new Sunny.UI.UIButton();
            this.uisourceServerLabel = new Sunny.UI.UILabel();
            this.uisourceUsernameLabel = new Sunny.UI.UILabel();
            this.uisourcePasswordLabel = new Sunny.UI.UILabel();
            this.uitargetPasswordLabel = new Sunny.UI.UILabel();
            this.uitargetUsernameLabel = new Sunny.UI.UILabel();
            this.uitargetServerLabel = new Sunny.UI.UILabel();
            this.uiStartSchedulerButton = new Sunny.UI.UIButton();
            this.uiStopSchedulerButton = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // labelSourceDb
            // 
            this.labelSourceDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceDb.Location = new System.Drawing.Point(57, 360);
            this.labelSourceDb.Name = "labelSourceDb";
            this.labelSourceDb.Size = new System.Drawing.Size(114, 43);
            this.labelSourceDb.TabIndex = 0;
            this.labelSourceDb.Text = "源数据库：";
            this.labelSourceDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxSourceDb
            // 
            this.comboBoxSourceDb.DataSource = null;
            this.comboBoxSourceDb.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBoxSourceDb.FillColor = System.Drawing.Color.White;
            this.comboBoxSourceDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxSourceDb.Location = new System.Drawing.Point(178, 358);
            this.comboBoxSourceDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSourceDb.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxSourceDb.Name = "comboBoxSourceDb";
            this.comboBoxSourceDb.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxSourceDb.Size = new System.Drawing.Size(281, 45);
            this.comboBoxSourceDb.TabIndex = 1;
            this.comboBoxSourceDb.Text = "-请选择数据库-";
            this.comboBoxSourceDb.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxSourceDb.Watermark = "";
            this.comboBoxSourceDb.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceDb_SelectedIndexChanged);
            // 
            // labelTargetDb
            // 
            this.labelTargetDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTargetDb.Location = new System.Drawing.Point(466, 358);
            this.labelTargetDb.Name = "labelTargetDb";
            this.labelTargetDb.Size = new System.Drawing.Size(135, 47);
            this.labelTargetDb.TabIndex = 2;
            this.labelTargetDb.Text = "目标数据库：";
            this.labelTargetDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxTargetDb
            // 
            this.comboBoxTargetDb.DataSource = null;
            this.comboBoxTargetDb.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBoxTargetDb.FillColor = System.Drawing.Color.White;
            this.comboBoxTargetDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTargetDb.Location = new System.Drawing.Point(607, 358);
            this.comboBoxTargetDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTargetDb.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxTargetDb.Name = "comboBoxTargetDb";
            this.comboBoxTargetDb.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxTargetDb.Size = new System.Drawing.Size(308, 45);
            this.comboBoxTargetDb.TabIndex = 3;
            this.comboBoxTargetDb.Text = "-请选择数据库-";
            this.comboBoxTargetDb.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxTargetDb.Watermark = "";
            this.comboBoxTargetDb.SelectedIndexChanged += new System.EventHandler(this.comboBoxTargetDb_SelectedIndexChanged);
            // 
            // labelSourceTable
            // 
            this.labelSourceTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceTable.Location = new System.Drawing.Point(96, 426);
            this.labelSourceTable.Name = "labelSourceTable";
            this.labelSourceTable.Size = new System.Drawing.Size(75, 43);
            this.labelSourceTable.TabIndex = 4;
            this.labelSourceTable.Text = "源表：";
            this.labelSourceTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxSourceTable
            // 
            this.comboBoxSourceTable.DataSource = null;
            this.comboBoxSourceTable.FillColor = System.Drawing.Color.White;
            this.comboBoxSourceTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxSourceTable.Location = new System.Drawing.Point(178, 424);
            this.comboBoxSourceTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSourceTable.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxSourceTable.Name = "comboBoxSourceTable";
            this.comboBoxSourceTable.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxSourceTable.Size = new System.Drawing.Size(281, 45);
            this.comboBoxSourceTable.TabIndex = 5;
            this.comboBoxSourceTable.Text = "-请选择数据表-";
            this.comboBoxSourceTable.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxSourceTable.Watermark = "";
            // 
            // labelTargetTable
            // 
            this.labelTargetTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTargetTable.Location = new System.Drawing.Point(504, 424);
            this.labelTargetTable.Name = "labelTargetTable";
            this.labelTargetTable.Size = new System.Drawing.Size(96, 45);
            this.labelTargetTable.TabIndex = 6;
            this.labelTargetTable.Text = "目标表：";
            this.labelTargetTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxTargetTable
            // 
            this.comboBoxTargetTable.DataSource = null;
            this.comboBoxTargetTable.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBoxTargetTable.FillColor = System.Drawing.Color.White;
            this.comboBoxTargetTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTargetTable.Location = new System.Drawing.Point(607, 424);
            this.comboBoxTargetTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTargetTable.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxTargetTable.Name = "comboBoxTargetTable";
            this.comboBoxTargetTable.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxTargetTable.Size = new System.Drawing.Size(308, 45);
            this.comboBoxTargetTable.TabIndex = 7;
            this.comboBoxTargetTable.Text = "-请选择数据表-";
            this.comboBoxTargetTable.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxTargetTable.Watermark = "";
            // 
            // buttonSync
            // 
            this.buttonSync.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSync.Location = new System.Drawing.Point(376, 494);
            this.buttonSync.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(322, 53);
            this.buttonSync.TabIndex = 8;
            this.buttonSync.Text = "开始同步";
            this.buttonSync.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.FillColor = System.Drawing.Color.White;
            this.resultRichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultRichTextBox.Location = new System.Drawing.Point(57, 566);
            this.resultRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultRichTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.resultRichTextBox.ShowText = false;
            this.resultRichTextBox.Size = new System.Drawing.Size(912, 180);
            this.resultRichTextBox.TabIndex = 9;
            this.resultRichTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sourceServerTextBox
            // 
            this.sourceServerTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.sourceServerTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceServerTextBox.Location = new System.Drawing.Point(178, 80);
            this.sourceServerTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourceServerTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.sourceServerTextBox.Name = "sourceServerTextBox";
            this.sourceServerTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.sourceServerTextBox.ShowText = false;
            this.sourceServerTextBox.Size = new System.Drawing.Size(281, 46);
            this.sourceServerTextBox.TabIndex = 0;
            this.sourceServerTextBox.Text = "127.0.0.1";
            this.sourceServerTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.sourceServerTextBox.Watermark = "";
            this.sourceServerTextBox.TextChanged += new System.EventHandler(this.sourceServerTextBox_TextChanged);
            // 
            // sourceUsernameTextBox
            // 
            this.sourceUsernameTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.sourceUsernameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceUsernameTextBox.Location = new System.Drawing.Point(178, 136);
            this.sourceUsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourceUsernameTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.sourceUsernameTextBox.Name = "sourceUsernameTextBox";
            this.sourceUsernameTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.sourceUsernameTextBox.ShowText = false;
            this.sourceUsernameTextBox.Size = new System.Drawing.Size(281, 46);
            this.sourceUsernameTextBox.TabIndex = 1;
            this.sourceUsernameTextBox.Text = "sa";
            this.sourceUsernameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.sourceUsernameTextBox.Watermark = "";
            this.sourceUsernameTextBox.TextChanged += new System.EventHandler(this.sourceUsernameTextBox_TextChanged);
            // 
            // sourcePasswordTextBox
            // 
            this.sourcePasswordTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.sourcePasswordTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourcePasswordTextBox.Location = new System.Drawing.Point(178, 204);
            this.sourcePasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourcePasswordTextBox.MaxLength = 32;
            this.sourcePasswordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.sourcePasswordTextBox.Name = "sourcePasswordTextBox";
            this.sourcePasswordTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.sourcePasswordTextBox.PasswordChar = '*';
            this.sourcePasswordTextBox.ShowText = false;
            this.sourcePasswordTextBox.Size = new System.Drawing.Size(281, 46);
            this.sourcePasswordTextBox.TabIndex = 2;
            this.sourcePasswordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.sourcePasswordTextBox.Watermark = "";
            this.sourcePasswordTextBox.TextChanged += new System.EventHandler(this.sourcePasswordTextBox_TextChanged);
            // 
            // targetServerTextBox
            // 
            this.targetServerTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.targetServerTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetServerTextBox.Location = new System.Drawing.Point(607, 80);
            this.targetServerTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetServerTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.targetServerTextBox.Name = "targetServerTextBox";
            this.targetServerTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.targetServerTextBox.ShowText = false;
            this.targetServerTextBox.Size = new System.Drawing.Size(308, 46);
            this.targetServerTextBox.TabIndex = 3;
            this.targetServerTextBox.Text = "127.0.0.1";
            this.targetServerTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.targetServerTextBox.Watermark = "";
            this.targetServerTextBox.TextChanged += new System.EventHandler(this.targetServerTextBox_TextChanged);
            // 
            // targetUsernameTextBox
            // 
            this.targetUsernameTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.targetUsernameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetUsernameTextBox.Location = new System.Drawing.Point(607, 136);
            this.targetUsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetUsernameTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.targetUsernameTextBox.Name = "targetUsernameTextBox";
            this.targetUsernameTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.targetUsernameTextBox.ShowText = false;
            this.targetUsernameTextBox.Size = new System.Drawing.Size(308, 46);
            this.targetUsernameTextBox.TabIndex = 4;
            this.targetUsernameTextBox.Text = "sa";
            this.targetUsernameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.targetUsernameTextBox.Watermark = "";
            this.targetUsernameTextBox.TextChanged += new System.EventHandler(this.targetUsernameTextBox_TextChanged);
            // 
            // targetPasswordTextBox
            // 
            this.targetPasswordTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.targetPasswordTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetPasswordTextBox.Location = new System.Drawing.Point(607, 204);
            this.targetPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetPasswordTextBox.MaxLength = 32;
            this.targetPasswordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.targetPasswordTextBox.Name = "targetPasswordTextBox";
            this.targetPasswordTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.targetPasswordTextBox.PasswordChar = '*';
            this.targetPasswordTextBox.ShowText = false;
            this.targetPasswordTextBox.Size = new System.Drawing.Size(308, 46);
            this.targetPasswordTextBox.TabIndex = 5;
            this.targetPasswordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.targetPasswordTextBox.Watermark = "";
            this.targetPasswordTextBox.TextChanged += new System.EventHandler(this.targetPasswordTextBox_TextChanged);
            // 
            // sourceConnectButton
            // 
            this.sourceConnectButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceConnectButton.Location = new System.Drawing.Point(214, 272);
            this.sourceConnectButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.sourceConnectButton.Name = "sourceConnectButton";
            this.sourceConnectButton.Size = new System.Drawing.Size(200, 55);
            this.sourceConnectButton.TabIndex = 6;
            this.sourceConnectButton.Text = "加载源数据库";
            this.sourceConnectButton.Click += new System.EventHandler(this.sourceConnectButton_Click);
            // 
            // targetConnectButton
            // 
            this.targetConnectButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetConnectButton.Location = new System.Drawing.Point(657, 272);
            this.targetConnectButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.targetConnectButton.Name = "targetConnectButton";
            this.targetConnectButton.Size = new System.Drawing.Size(200, 55);
            this.targetConnectButton.TabIndex = 7;
            this.targetConnectButton.Text = "加载目标数据库";
            this.targetConnectButton.Click += new System.EventHandler(this.targetConnectButton_Click);
            // 
            // uisourceServerLabel
            // 
            this.uisourceServerLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uisourceServerLabel.Location = new System.Drawing.Point(73, 80);
            this.uisourceServerLabel.Name = "uisourceServerLabel";
            this.uisourceServerLabel.Size = new System.Drawing.Size(98, 46);
            this.uisourceServerLabel.TabIndex = 10;
            this.uisourceServerLabel.Text = "源服务器:";
            this.uisourceServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uisourceUsernameLabel
            // 
            this.uisourceUsernameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uisourceUsernameLabel.Location = new System.Drawing.Point(87, 136);
            this.uisourceUsernameLabel.Name = "uisourceUsernameLabel";
            this.uisourceUsernameLabel.Size = new System.Drawing.Size(84, 46);
            this.uisourceUsernameLabel.TabIndex = 11;
            this.uisourceUsernameLabel.Text = "用户名:";
            this.uisourceUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uisourcePasswordLabel
            // 
            this.uisourcePasswordLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uisourcePasswordLabel.Location = new System.Drawing.Point(106, 204);
            this.uisourcePasswordLabel.Name = "uisourcePasswordLabel";
            this.uisourcePasswordLabel.Size = new System.Drawing.Size(65, 46);
            this.uisourcePasswordLabel.TabIndex = 12;
            this.uisourcePasswordLabel.Text = "密码:";
            this.uisourcePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitargetPasswordLabel
            // 
            this.uitargetPasswordLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uitargetPasswordLabel.Location = new System.Drawing.Point(530, 204);
            this.uitargetPasswordLabel.Name = "uitargetPasswordLabel";
            this.uitargetPasswordLabel.Size = new System.Drawing.Size(70, 46);
            this.uitargetPasswordLabel.TabIndex = 15;
            this.uitargetPasswordLabel.Text = "密码:";
            this.uitargetPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitargetUsernameLabel
            // 
            this.uitargetUsernameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uitargetUsernameLabel.Location = new System.Drawing.Point(513, 136);
            this.uitargetUsernameLabel.Name = "uitargetUsernameLabel";
            this.uitargetUsernameLabel.Size = new System.Drawing.Size(77, 46);
            this.uitargetUsernameLabel.TabIndex = 14;
            this.uitargetUsernameLabel.Text = "用户名:";
            this.uitargetUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uitargetServerLabel
            // 
            this.uitargetServerLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uitargetServerLabel.Location = new System.Drawing.Point(475, 80);
            this.uitargetServerLabel.Name = "uitargetServerLabel";
            this.uitargetServerLabel.Size = new System.Drawing.Size(125, 46);
            this.uitargetServerLabel.TabIndex = 13;
            this.uitargetServerLabel.Text = "目标服务器:";
            this.uitargetServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiStartSchedulerButton
            // 
            this.uiStartSchedulerButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiStartSchedulerButton.Location = new System.Drawing.Point(178, 776);
            this.uiStartSchedulerButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiStartSchedulerButton.Name = "uiStartSchedulerButton";
            this.uiStartSchedulerButton.Size = new System.Drawing.Size(281, 53);
            this.uiStartSchedulerButton.TabIndex = 16;
            this.uiStartSchedulerButton.Text = "启动调度程序";
            this.uiStartSchedulerButton.Click += new System.EventHandler(this.uiStartSchedulerButton_Click);
            // 
            // uiStopSchedulerButton
            // 
            this.uiStopSchedulerButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiStopSchedulerButton.Location = new System.Drawing.Point(607, 776);
            this.uiStopSchedulerButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiStopSchedulerButton.Name = "uiStopSchedulerButton";
            this.uiStopSchedulerButton.Size = new System.Drawing.Size(308, 53);
            this.uiStopSchedulerButton.TabIndex = 17;
            this.uiStopSchedulerButton.Text = "停止调度程序";
            this.uiStopSchedulerButton.Click += new System.EventHandler(this.uiStopSchedulerButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1048, 877);
            this.Controls.Add(this.uiStopSchedulerButton);
            this.Controls.Add(this.uiStartSchedulerButton);
            this.Controls.Add(this.uitargetPasswordLabel);
            this.Controls.Add(this.uitargetUsernameLabel);
            this.Controls.Add(this.uitargetServerLabel);
            this.Controls.Add(this.sourcePasswordTextBox);
            this.Controls.Add(this.uisourcePasswordLabel);
            this.Controls.Add(this.uisourceUsernameLabel);
            this.Controls.Add(this.uisourceServerLabel);
            this.Controls.Add(this.sourceServerTextBox);
            this.Controls.Add(this.sourceUsernameTextBox);
            this.Controls.Add(this.targetServerTextBox);
            this.Controls.Add(this.targetUsernameTextBox);
            this.Controls.Add(this.targetPasswordTextBox);
            this.Controls.Add(this.sourceConnectButton);
            this.Controls.Add(this.targetConnectButton);
            this.Controls.Add(this.resultRichTextBox);
            this.Controls.Add(this.labelSourceDb);
            this.Controls.Add(this.comboBoxSourceDb);
            this.Controls.Add(this.labelTargetDb);
            this.Controls.Add(this.comboBoxTargetDb);
            this.Controls.Add(this.labelSourceTable);
            this.Controls.Add(this.comboBoxSourceTable);
            this.Controls.Add(this.labelTargetTable);
            this.Controls.Add(this.comboBoxTargetTable);
            this.Controls.Add(this.buttonSync);
            this.Name = "MainForm";
            this.Text = "数据同步工具";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 667, 567);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private UILabel labelSourceDb;
        private UIComboBox comboBoxSourceDb;
        private UILabel labelTargetDb;
        private UIComboBox comboBoxTargetDb;
        private UILabel labelSourceTable;
        private UIComboBox comboBoxSourceTable ;
        private UILabel labelTargetTable;
        private UIComboBox comboBoxTargetTable;
        private UIButton buttonSync;
        private UIRichTextBox resultRichTextBox;


        private UITextBox sourceServerTextBox;
        private UITextBox sourceUsernameTextBox;
        private UITextBox sourcePasswordTextBox;
        private UITextBox targetServerTextBox;
        private UITextBox targetUsernameTextBox;
        private UITextBox targetPasswordTextBox;

        private UIButton sourceConnectButton;
        private UIButton targetConnectButton;

        #endregion

        private UILabel uisourceServerLabel;
        private UILabel uisourceUsernameLabel;
        private UILabel uisourcePasswordLabel;
        private UILabel uitargetPasswordLabel;
        private UILabel uitargetUsernameLabel;
        private UILabel uitargetServerLabel;
        private UIButton uiStartSchedulerButton;
        private UIButton uiStopSchedulerButton;
    }
}