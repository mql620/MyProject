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
using System.Windows.Forms;
using JM_GluingSystem.DB;
using JM_GluingSystem.Common;

namespace JM_GluingSystem.Views
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public static UserInformation_Kp userInfo;
        public Login()
        {
            InitializeComponent();
            //DB_CommonConect.CreatConnection();
        }
        private void Login_Load(object sender, RoutedEventArgs e)
        {
            // 全屏显示
            //this.WindowState = WindowState.Normal;
            //this.WindowStyle = WindowStyle.None;
            //this.ResizeMode = ResizeMode.NoResize;
            //this.Topmost = true;

            //this.Left = 0.0;
            //this.Top = 0.0;
            //this.Width = SystemParameters.PrimaryScreenWidth;
            //this.Height = SystemParameters.PrimaryScreenHeight;

            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Convert.ToInt32(DeskWidth * 0.5);
            this.Height = Convert.ToInt32(DeskHeight * 0.6);

        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (login_UserId.Text.Length == 0 || login_UserPwd.Password.Length == 0)
            {
                System.Windows.MessageBox.Show("用户名或密码不可以为空！");
            }
            else
            {
                userInfo = DB_Account.SearchUserInfo(login_UserId.Text);
                if (userInfo != null)
                {
                    if (userInfo.AccountID.Equals(login_UserId.Text.Trim()) && userInfo.Password.Equals(login_UserPwd.Password.Trim()))
                    {
                        MainWindow mainWindow = new MainWindow();
                        if (userInfo.UserLevel == "1")
                        {
                            mainWindow.UserInFoModule.Visibility = Visibility;
                        }
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("密码错误！");
                    }
                }
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
