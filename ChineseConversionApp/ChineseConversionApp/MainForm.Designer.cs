namespace ChineseConversionApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rootFolderLabel = new Sunny.UI.UILabel();
            this.rootFolderTextBox = new Sunny.UI.UITextBox();
            this.selectFolderButtonSymbolButton = new Sunny.UI.UISymbolButton();
            this.convertSymbolButton = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // rootFolderLabel
            // 
            this.rootFolderLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rootFolderLabel.Location = new System.Drawing.Point(12, 107);
            this.rootFolderLabel.Name = "rootFolderLabel";
            this.rootFolderLabel.Size = new System.Drawing.Size(141, 29);
            this.rootFolderLabel.TabIndex = 4;
            this.rootFolderLabel.Text = "根文件夹路径:";
            this.rootFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.rootFolderTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rootFolderTextBox.Location = new System.Drawing.Point(160, 92);
            this.rootFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rootFolderTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.rootFolderTextBox.ShowText = false;
            this.rootFolderTextBox.Size = new System.Drawing.Size(430, 44);
            this.rootFolderTextBox.TabIndex = 7;
            this.rootFolderTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.rootFolderTextBox.Watermark = "";
            // 
            // selectFolderButtonSymbolButton
            // 
            this.selectFolderButtonSymbolButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFolderButtonSymbolButton.Location = new System.Drawing.Point(597, 92);
            this.selectFolderButtonSymbolButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.selectFolderButtonSymbolButton.Name = "selectFolderButtonSymbolButton";
            this.selectFolderButtonSymbolButton.Size = new System.Drawing.Size(175, 44);
            this.selectFolderButtonSymbolButton.Symbol = 61717;
            this.selectFolderButtonSymbolButton.TabIndex = 8;
            this.selectFolderButtonSymbolButton.Text = "选择文件夹";
            this.selectFolderButtonSymbolButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // convertSymbolButton
            // 
            this.convertSymbolButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.convertSymbolButton.Location = new System.Drawing.Point(597, 159);
            this.convertSymbolButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.convertSymbolButton.Name = "convertSymbolButton";
            this.convertSymbolButton.Size = new System.Drawing.Size(175, 44);
            this.convertSymbolButton.Symbol = 61639;
            this.convertSymbolButton.TabIndex = 9;
            this.convertSymbolButton.Text = "繁体转简体";
            this.convertSymbolButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(839, 460);
            this.Controls.Add(this.convertSymbolButton);
            this.Controls.Add(this.selectFolderButtonSymbolButton);
            this.Controls.Add(this.rootFolderTextBox);
            this.Controls.Add(this.rootFolderLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "繁体中文转简体中文工具";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 681, 230);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel rootFolderLabel;
        private Sunny.UI.UITextBox rootFolderTextBox;
        private Sunny.UI.UISymbolButton selectFolderButtonSymbolButton;
        private Sunny.UI.UISymbolButton convertSymbolButton;
    }
}