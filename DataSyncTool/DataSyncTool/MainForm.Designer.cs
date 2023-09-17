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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // labelSourceDb
            // 
            this.labelSourceDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceDb.Location = new System.Drawing.Point(57, 270);
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
            this.comboBoxSourceDb.Location = new System.Drawing.Point(178, 270);
            this.comboBoxSourceDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSourceDb.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxSourceDb.Name = "comboBoxSourceDb";
            this.comboBoxSourceDb.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxSourceDb.Size = new System.Drawing.Size(271, 43);
            this.comboBoxSourceDb.TabIndex = 1;
            this.comboBoxSourceDb.Text = "-请选择数据库-";
            this.comboBoxSourceDb.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxSourceDb.Watermark = "";
            this.comboBoxSourceDb.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceDb_SelectedIndexChanged);
            // 
            // labelTargetDb
            // 
            this.labelTargetDb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTargetDb.Location = new System.Drawing.Point(467, 268);
            this.labelTargetDb.Name = "labelTargetDb";
            this.labelTargetDb.Size = new System.Drawing.Size(133, 45);
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
            this.comboBoxTargetDb.Location = new System.Drawing.Point(607, 268);
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
            this.labelSourceTable.Location = new System.Drawing.Point(96, 336);
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
            this.comboBoxSourceTable.Location = new System.Drawing.Point(178, 336);
            this.comboBoxSourceTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSourceTable.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxSourceTable.Name = "comboBoxSourceTable";
            this.comboBoxSourceTable.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxSourceTable.Size = new System.Drawing.Size(271, 43);
            this.comboBoxSourceTable.TabIndex = 5;
            this.comboBoxSourceTable.Text = "-请选择数据表-";
            this.comboBoxSourceTable.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxSourceTable.Watermark = "";
            // 
            // labelTargetTable
            // 
            this.labelTargetTable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTargetTable.Location = new System.Drawing.Point(504, 334);
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
            this.comboBoxTargetTable.Location = new System.Drawing.Point(607, 334);
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
            this.buttonSync.Location = new System.Drawing.Point(394, 546);
            this.buttonSync.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(309, 53);
            this.buttonSync.TabIndex = 8;
            this.buttonSync.Text = "开始同步";
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.FillColor = System.Drawing.Color.White;
            this.resultRichTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultRichTextBox.Location = new System.Drawing.Point(38, 669);
            this.resultRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultRichTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.resultRichTextBox.ShowText = false;
            this.resultRichTextBox.Size = new System.Drawing.Size(947, 250);
            this.resultRichTextBox.TabIndex = 9;
            this.resultRichTextBox.Text = "resultRichTextBox";
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
            this.sourceServerTextBox.Size = new System.Drawing.Size(271, 46);
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
            this.sourceUsernameTextBox.Size = new System.Drawing.Size(271, 46);
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
            this.sourcePasswordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.sourcePasswordTextBox.Name = "sourcePasswordTextBox";
            this.sourcePasswordTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.sourcePasswordTextBox.ShowText = false;
            this.sourcePasswordTextBox.Size = new System.Drawing.Size(271, 46);
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
            this.targetPasswordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.targetPasswordTextBox.Name = "targetPasswordTextBox";
            this.targetPasswordTextBox.Padding = new System.Windows.Forms.Padding(5);
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
            this.sourceConnectButton.Location = new System.Drawing.Point(219, 428);
            this.sourceConnectButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.sourceConnectButton.Name = "sourceConnectButton";
            this.sourceConnectButton.Size = new System.Drawing.Size(190, 55);
            this.sourceConnectButton.TabIndex = 6;
            this.sourceConnectButton.Text = "连接源数据库";
            this.sourceConnectButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceConnectButton.Click += new System.EventHandler(this.sourceConnectButton_Click);
            // 
            // targetConnectButton
            // 
            this.targetConnectButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetConnectButton.Location = new System.Drawing.Point(680, 428);
            this.targetConnectButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.targetConnectButton.Name = "targetConnectButton";
            this.targetConnectButton.Size = new System.Drawing.Size(200, 55);
            this.targetConnectButton.TabIndex = 7;
            this.targetConnectButton.Text = "连接目标数据库";
            this.targetConnectButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetConnectButton.Click += new System.EventHandler(this.targetConnectButton_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel1.Location = new System.Drawing.Point(69, 80);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(102, 46);
            this.uiLabel1.TabIndex = 10;
            this.uiLabel1.Text = "源服务器:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel2.Location = new System.Drawing.Point(89, 136);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(82, 46);
            this.uiLabel2.TabIndex = 11;
            this.uiLabel2.Text = "用户名:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel3.Location = new System.Drawing.Point(111, 204);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(60, 46);
            this.uiLabel3.TabIndex = 12;
            this.uiLabel3.Text = "密码:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel4.Location = new System.Drawing.Point(535, 204);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(65, 46);
            this.uiLabel4.TabIndex = 15;
            this.uiLabel4.Text = "密码:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel5.Location = new System.Drawing.Point(513, 136);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(77, 46);
            this.uiLabel5.TabIndex = 14;
            this.uiLabel5.Text = "用户名:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel6.Location = new System.Drawing.Point(475, 80);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(125, 46);
            this.uiLabel6.TabIndex = 13;
            this.uiLabel6.Text = "目标服务器:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1034, 949);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.sourceServerTextBox);
            this.Controls.Add(this.sourceUsernameTextBox);
            this.Controls.Add(this.sourcePasswordTextBox);
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

        private UILabel uiLabel1;
        private UILabel uiLabel2;
        private UILabel uiLabel3;
        private UILabel uiLabel4;
        private UILabel uiLabel5;
        private UILabel uiLabel6;
    }
}