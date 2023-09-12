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
                // 获取目标目录
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                // 遍历所有子文件夹
                foreach (var subDirectory in directoryInfo.GetDirectories("*", SearchOption.AllDirectories))
                {
                    // 将繁体中文文件夹名转换为简体中文
                    string simplifiedFolderName = STConverter.GetSimplified(subDirectory.Name); //Strings.StrConv(subDirectory.Name, VbStrConv.SimplifiedChinese, 1028);
                    if (simplifiedFolderName != subDirectory.Name)
                    {
                        // 重命名文件夹
                        subDirectory.MoveTo(Path.Combine(subDirectory.Parent.FullName, simplifiedFolderName));
                    }
                }

                // 遍历所有文件
                foreach (var file in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    // 将繁体中文文件名转换为简体中文
                    string simplifiedFileName = STConverter.GetSimplified(file.Name); //Strings.StrConv(file.Name, VbStrConv.SimplifiedChinese, 1028);
                    if (simplifiedFileName != file.Name)
                    {
                        // 重命名文件
                        file.MoveTo(Path.Combine(file.Directory.FullName, simplifiedFileName));
                    }
                }
                UIMessageDialog.ShowMessageDialog("文件和文件夹名称已成功转换为简体中文", "转换完成", false, Style);
            }
            catch (Exception ex)
            {
                ShowErrorDialog($"发生错误：{ex.Message}");
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rootFolderTextBox.Text.Trim()))
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "选择根文件夹路径";
                    folderBrowserDialog.ShowNewFolderButton = false; // 可以选择现有文件夹
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string selectedFolder = folderBrowserDialog.SelectedPath;
                        rootFolderTextBox.Text = selectedFolder; // 将选择的文件夹路径显示在文本框中

                        if (string.IsNullOrWhiteSpace(selectedFolder))
                        {
                            UIMessageDialog.ShowMessageDialog("请输入根文件夹路径", UILocalize.InfoTitle, false, Style);
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
                folderBrowserDialog.Description = "选择根文件夹路径";
                folderBrowserDialog.ShowNewFolderButton = false; // 可以选择现有文件夹
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    rootFolderTextBox.Text = selectedFolder; // 将选择的文件夹路径显示在文本框中
                }
            }
        }
    }
}