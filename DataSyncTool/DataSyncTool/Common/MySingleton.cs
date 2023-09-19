using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncTool.Common
{
    internal class MySingleton
    {
        private static MySingleton instance;
        private UIRichTextBox resultControl; // 假设 resultRichTextBox 是 UIRichTextBox 控件

        /// <summary>
        /// 构造函数设置为私有，以确保只能通过 Instance 属性访问它
        /// </summary>
        private MySingleton() // 私有构造函数
        {
        }

        public static MySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySingleton();
                }
                return instance;
            }
        }

        public event Action<string> SendMessage;

        public void Initialize(UIRichTextBox editControl)
        {
            resultControl = editControl;
        }


        public void OnSendMessage(string message)
        {
            //SendMessage?.Invoke(message);
            if (resultControl != null)
            {
                // 使用 Invoke 方法确保在 UI 线程上执行更新操作
                resultControl.Invoke(new Action(() =>
                {
                    resultControl.AppendText(message);
                    resultControl.ScrollToCaret();
                }));
            }
        }

    }
}
