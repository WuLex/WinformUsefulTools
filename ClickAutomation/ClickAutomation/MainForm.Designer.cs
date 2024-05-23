using Sunny.UI;
using System.Windows.Forms;

namespace ClickAutomation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private UIListBox actionsListBox;
        private UIIntegerUpDown xNumericUpDown;
        private UIIntegerUpDown yNumericUpDown;
        private UIComboBox clickTypeComboBox;
        private UIButton startButton;
        private UIButton stopButton;
        private UIButton addButton;
        private UIButton importButton;
        private UIButton exportButton;
        private UICheckBox loopCheckBox;
        private UIIntegerUpDown delayNumericUpDown;
        private UIButton insertDelayButton;
        private UILabel label1;
        private UILabel label2;
        private UILabel label3;
        private UILabel label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.actionsListBox = new Sunny.UI.UIListBox();
            this.xNumericUpDown = new Sunny.UI.UIIntegerUpDown();
            this.yNumericUpDown = new Sunny.UI.UIIntegerUpDown();
            this.clickTypeComboBox = new Sunny.UI.UIComboBox();
            this.startButton = new Sunny.UI.UIButton();
            this.stopButton = new Sunny.UI.UIButton();
            this.addButton = new Sunny.UI.UIButton();
            this.importButton = new Sunny.UI.UIButton();
            this.exportButton = new Sunny.UI.UIButton();
            this.loopCheckBox = new Sunny.UI.UICheckBox();
            this.delayNumericUpDown = new Sunny.UI.UIIntegerUpDown();
            this.insertDelayButton = new Sunny.UI.UIButton();
            this.label1 = new Sunny.UI.UILabel();
            this.label2 = new Sunny.UI.UILabel();
            this.label3 = new Sunny.UI.UILabel();
            this.label4 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // actionsListBox
            // 
            this.actionsListBox.FillColor = System.Drawing.Color.White;
            this.actionsListBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.actionsListBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.actionsListBox.ItemSelectForeColor = System.Drawing.Color.White;
            this.actionsListBox.Location = new System.Drawing.Point(12, 55);
            this.actionsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.actionsListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.actionsListBox.Name = "actionsListBox";
            this.actionsListBox.Padding = new System.Windows.Forms.Padding(2);
            this.actionsListBox.ShowText = false;
            this.actionsListBox.Size = new System.Drawing.Size(344, 524);
            this.actionsListBox.TabIndex = 0;
            this.actionsListBox.Text = null;
            // 
            // xNumericUpDown
            // 
            this.xNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.xNumericUpDown.Location = new System.Drawing.Point(481, 108);
            this.xNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xNumericUpDown.Maximum = 1920;
            this.xNumericUpDown.Minimum = 0;
            this.xNumericUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.xNumericUpDown.Name = "xNumericUpDown";
            this.xNumericUpDown.ShowText = false;
            this.xNumericUpDown.Size = new System.Drawing.Size(150, 34);
            this.xNumericUpDown.TabIndex = 1;
            this.xNumericUpDown.Text = null;
            this.xNumericUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yNumericUpDown
            // 
            this.yNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yNumericUpDown.Location = new System.Drawing.Point(481, 152);
            this.yNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yNumericUpDown.Maximum = 1080;
            this.yNumericUpDown.Minimum = 0;
            this.yNumericUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.yNumericUpDown.Name = "yNumericUpDown";
            this.yNumericUpDown.ShowText = false;
            this.yNumericUpDown.Size = new System.Drawing.Size(150, 34);
            this.yNumericUpDown.TabIndex = 2;
            this.yNumericUpDown.Text = null;
            this.yNumericUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clickTypeComboBox
            // 
            this.clickTypeComboBox.DataSource = null;
            this.clickTypeComboBox.FillColor = System.Drawing.Color.White;
            this.clickTypeComboBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clickTypeComboBox.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.clickTypeComboBox.Items.AddRange(new object[] {
            "左键单击",
            "左键双击",
            "右键单击",
            "右键双击"});
            this.clickTypeComboBox.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.clickTypeComboBox.Location = new System.Drawing.Point(481, 207);
            this.clickTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clickTypeComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.clickTypeComboBox.Name = "clickTypeComboBox";
            this.clickTypeComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.clickTypeComboBox.Size = new System.Drawing.Size(150, 38);
            this.clickTypeComboBox.SymbolSize = 24;
            this.clickTypeComboBox.TabIndex = 3;
            this.clickTypeComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.clickTypeComboBox.Watermark = "";
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.FillColor = System.Drawing.Color.SteelBlue;
            this.startButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(376, 401);
            this.startButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.startButton.Name = "startButton";
            this.startButton.RectColor = System.Drawing.Color.SteelBlue;
            this.startButton.Size = new System.Drawing.Size(99, 47);
            this.startButton.Style = Sunny.UI.UIStyle.Custom;
            this.startButton.TabIndex = 4;
            this.startButton.Text = "开始";
            this.startButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopButton.FillColor = System.Drawing.Color.IndianRed;
            this.stopButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopButton.Location = new System.Drawing.Point(502, 401);
            this.stopButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.stopButton.Name = "stopButton";
            this.stopButton.RectColor = System.Drawing.Color.IndianRed;
            this.stopButton.Size = new System.Drawing.Size(98, 47);
            this.stopButton.Style = Sunny.UI.UIStyle.Custom;
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "停止";
            this.stopButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // addButton
            // 
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FillColor = System.Drawing.Color.LightGreen;
            this.addButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(629, 401);
            this.addButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.addButton.Name = "addButton";
            this.addButton.RectColor = System.Drawing.Color.LightGreen;
            this.addButton.Size = new System.Drawing.Size(95, 47);
            this.addButton.Style = Sunny.UI.UIStyle.Custom;
            this.addButton.TabIndex = 6;
            this.addButton.Text = "添加";
            this.addButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // importButton
            // 
            this.importButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importButton.FillColor = System.Drawing.Color.LightSkyBlue;
            this.importButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.importButton.Location = new System.Drawing.Point(750, 401);
            this.importButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.importButton.Name = "importButton";
            this.importButton.RectColor = System.Drawing.Color.LightSkyBlue;
            this.importButton.Size = new System.Drawing.Size(104, 47);
            this.importButton.Style = Sunny.UI.UIStyle.Custom;
            this.importButton.TabIndex = 7;
            this.importButton.Text = "导入";
            this.importButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportButton.FillColor = System.Drawing.Color.LightSkyBlue;
            this.exportButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exportButton.Location = new System.Drawing.Point(870, 401);
            this.exportButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.exportButton.Name = "exportButton";
            this.exportButton.RectColor = System.Drawing.Color.LightSkyBlue;
            this.exportButton.Size = new System.Drawing.Size(98, 47);
            this.exportButton.Style = Sunny.UI.UIStyle.Custom;
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "导出";
            this.exportButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loopCheckBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loopCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.loopCheckBox.Location = new System.Drawing.Point(375, 352);
            this.loopCheckBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.loopCheckBox.Size = new System.Drawing.Size(111, 24);
            this.loopCheckBox.TabIndex = 9;
            this.loopCheckBox.Text = "循环执行";
            // 
            // delayNumericUpDown
            // 
            this.delayNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.delayNumericUpDown.Location = new System.Drawing.Point(481, 256);
            this.delayNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delayNumericUpDown.Maximum = 10000;
            this.delayNumericUpDown.Minimum = 100;
            this.delayNumericUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.delayNumericUpDown.Name = "delayNumericUpDown";
            this.delayNumericUpDown.ShowText = false;
            this.delayNumericUpDown.Size = new System.Drawing.Size(150, 34);
            this.delayNumericUpDown.TabIndex = 0;
            this.delayNumericUpDown.Text = null;
            this.delayNumericUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.delayNumericUpDown.Value = 1000;
            // 
            // insertDelayButton
            // 
            this.insertDelayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertDelayButton.FillColor = System.Drawing.Color.SkyBlue;
            this.insertDelayButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.insertDelayButton.Location = new System.Drawing.Point(653, 249);
            this.insertDelayButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.insertDelayButton.Name = "insertDelayButton";
            this.insertDelayButton.RectColor = System.Drawing.Color.SkyBlue;
            this.insertDelayButton.Size = new System.Drawing.Size(149, 41);
            this.insertDelayButton.Style = Sunny.UI.UIStyle.Custom;
            this.insertDelayButton.TabIndex = 11;
            this.insertDelayButton.Text = "插入延时";
            this.insertDelayButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.insertDelayButton.Click += new System.EventHandler(this.insertDelayButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(376, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 34);
            this.label1.TabIndex = 12;
            this.label1.Text = "延迟时间:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(383, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 34);
            this.label2.TabIndex = 13;
            this.label2.Text = "X轴坐标:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(383, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 34);
            this.label3.TabIndex = 14;
            this.label3.Text = "Y轴坐标:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(374, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 39);
            this.label4.TabIndex = 15;
            this.label4.Text = "鼠标模式:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(991, 601);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionsListBox);
            this.Controls.Add(this.xNumericUpDown);
            this.Controls.Add(this.yNumericUpDown);
            this.Controls.Add(this.clickTypeComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loopCheckBox);
            this.Controls.Add(this.delayNumericUpDown);
            this.Controls.Add(this.insertDelayButton);
            this.Name = "MainForm";
            this.Text = "点击自动器";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 991, 601);
            this.ResumeLayout(false);

        }
    }
}
