using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JM_GluingSystem.Views.BasicInfo
{
    /// <summary>
    /// Authorization.xaml 的交互逻辑
    /// </summary>
    public partial class Authorization : Window
    {
        public delegate void BackgroundChange();
        public event BackgroundChange bkChange;
        public delegate void ChangeTextHandler();
        public event ChangeTextHandler ChangeTextEvent;
        public Authorization()
        {
            InitializeComponent();
        }
        private void WindowClose(object sender, EventArgs e)
        {
            if (bkChange != null)
                bkChange();
            Close();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bkChange != null)
                bkChange();
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (txt_AccountNo.Text.Length == 0 || txt_UserName.Text.Length == 0 || txt_Password.Text.Length == 0 || Position.Text.Length == 0)
            {
                MessageBox.Show("信息不能为空！");
            }
            else
            {
                string level = "";
                switch (Position.Text)
                {
                    case "管理员":
                        level = "1";
                        break;
                    case "高级操作员":
                        level = "2";
                        break;
                    case "初级操作员":
                        level = "3";
                        break;
                    case "投屏专用":
                        level = "4";
                        break;
                }
                if (DB_Account.insertUserInfo(txt_AccountNo.Text, txt_UserName.Text, txt_Password.Text, level, Login.userInfo.AccountID, Login.userInfo.UserName))
                {
                    MessageBox.Show("用户添加成功！");
                    if (bkChange != null)
                        bkChange();
                    Close();
                    if (ChangeTextEvent != null)
                    {
                        ChangeTextEvent();
                    }
                }
                else
                {
                    MessageBox.Show("用户添加失败！");
                }
            }
        }
    }
}
