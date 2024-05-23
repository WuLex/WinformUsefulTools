using ClickAutomation.Common;
using Sunny.UI;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace ClickAutomation
{
    public partial class MainForm : UIForm
    {
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_LEFTDBLCLK = 0x0020;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private const uint MOUSEEVENTF_RIGHTDBLCLK = 0x0040;

        private Timer actionTimer;
        private int actionIndex = 0;
        private bool isRunning = false;

        public MainForm()
        {
            InitializeComponent();
            actionTimer = new Timer();
            actionTimer.Interval = 1000; // Ĭ��1��
            actionTimer.Tick += ActionTimer_Tick;
        }

        private void ActionTimer_Tick(object sender, EventArgs e)
        {
            // ���б��м�����һ������������͵������ͣ�
            if (actionIndex < actionsListBox.Items.Count)
            {
                var action = actionsListBox.Items[actionIndex].ToString();
                PerformAction(action);
                actionIndex++;
            }
            else
            {
                if (loopCheckBox.Checked)
                {
                    actionIndex = 0; // ����������ѭ��
                }
                else
                {
                    actionTimer.Stop();
                    actionIndex = 0;
                    isRunning = false;
                }
            }
        }

        private void PerformAction(string action)
        {
            var parts = action.Split(' ');

            //��������ǡ���ʱ������ֻ�����ض�����ʱʱ�䣬�����أ���ִ���κε��������
            if (parts[0] == "��ʱ")
            {
                int delay = int.Parse(parts[1]);
                actionTimer.Interval = delay;
                return;
            }
            // Parse the action string to extract coordinates and click type
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            string clickType = parts[2];

            MouseHelper.SetCursorPos(x, y);

            switch (clickType)
            {

                case "�������":
                    MouseHelper.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
                    break;
                case "���˫��":
                    MouseHelper.mouse_event(MOUSEEVENTF_LEFTDBLCLK, (uint)x, (uint)y, 0, 0);
                    break;
                case "�Ҽ�����":
                    MouseHelper.mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)x, (uint)y, 0, 0);
                    break;
                case "�Ҽ�˫��":
                    MouseHelper.mouse_event(MOUSEEVENTF_RIGHTDBLCLK, (uint)x, (uint)y, 0, 0);
                    break;
            }

            // ����ʱ���ļ������Ϊ�û�ָ�����ӳ�ʱ��
            actionTimer.Interval = (int)delayNumericUpDown.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                actionTimer.Interval = (int)delayNumericUpDown.Value;
                actionTimer.Start();
                isRunning = true;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            actionTimer.Stop();
            isRunning = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            // ��� clickTypeComboBox �Ƿ���ѡ����
            if (clickTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("����ѡ�������ͣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ��Ӷ������б��
         
            int x = (int)xNumericUpDown.Value;
            int y = (int)yNumericUpDown.Value;
            string clickType = clickTypeComboBox.SelectedItem.ToString();
            actionsListBox.Items.Add($"{x} {y} {clickType}");
        }

        private void insertDelayButton_Click(object sender, EventArgs e)
        {
            int delay = (int)delayNumericUpDown.Value;
            actionsListBox.Items.Add($"��ʱ {delay}");
        }


        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    actionsListBox.Items.Clear();
                    foreach (string line in lines)
                    {
                        actionsListBox.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var item in actionsListBox.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing file: " + ex.Message);
                }
            }
        }
    }
}