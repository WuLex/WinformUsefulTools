using ChineseConversionApp.Common;
using Sunny.UI;

namespace ChineseConversionApp
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ConvertToSimplifiedChinese(string path)
        {
            try
            {
                // ��ȡĿ��Ŀ¼
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                // �����������ļ���
                foreach (var subDirectory in directoryInfo.GetDirectories("*", SearchOption.AllDirectories))
                {
                    // �����������ļ�����ת��Ϊ��������
                    string simplifiedFolderName = STConverter.GetSimplified(subDirectory.Name); //Strings.StrConv(subDirectory.Name, VbStrConv.SimplifiedChinese, 1028);
                    if (simplifiedFolderName != subDirectory.Name)
                    {
                        // �������ļ���
                        subDirectory.MoveTo(Path.Combine(subDirectory.Parent.FullName, simplifiedFolderName));
                    }
                }

                // ���������ļ�
                foreach (var file in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    // �����������ļ���ת��Ϊ��������
                    string simplifiedFileName = STConverter.GetSimplified(file.Name); //Strings.StrConv(file.Name, VbStrConv.SimplifiedChinese, 1028);
                    if (simplifiedFileName != file.Name)
                    {
                        // �������ļ�
                        file.MoveTo(Path.Combine(file.Directory.FullName, simplifiedFileName));
                    }
                }
                UIMessageDialog.ShowMessageDialog("�ļ����ļ��������ѳɹ�ת��Ϊ��������", "ת�����", false, Style);
            }
            catch (Exception ex)
            {
                ShowErrorDialog($"��������{ex.Message}");
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rootFolderTextBox.Text.Trim()))
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "ѡ����ļ���·��";
                    folderBrowserDialog.ShowNewFolderButton = false; // ����ѡ�������ļ���
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string selectedFolder = folderBrowserDialog.SelectedPath;
                        rootFolderTextBox.Text = selectedFolder; // ��ѡ����ļ���·����ʾ���ı�����

                        if (string.IsNullOrWhiteSpace(selectedFolder))
                        {
                            UIMessageDialog.ShowMessageDialog("��������ļ���·��", UILocalize.InfoTitle, false, Style);
                            return;
                        }

                        ConvertToSimplifiedChinese(selectedFolder);
                    }
                }
            }
            else
            {
                ConvertToSimplifiedChinese(rootFolderTextBox.Text.Trim());
            }

            //string rootFolderPath = rootFolderTextBox.Text;
            //ConvertToSimplifiedChinese(rootFolderPath);
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "ѡ����ļ���·��";
                folderBrowserDialog.ShowNewFolderButton = false; // ����ѡ�������ļ���
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    rootFolderTextBox.Text = selectedFolder; // ��ѡ����ļ���·����ʾ���ı�����
                }
            }
        }
    }
}