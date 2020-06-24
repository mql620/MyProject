using JM_GluingSystem.DB;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JM_GluingSystem.Views.BasicInfo
{
    /// <summary>
    /// BasicInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }
        private void changeBk()
        {
            this.borderBody.Visibility = Visibility.Hidden;
        }
        private void Search_UserInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            string selKeyChooseTxt = SelKeyChooseComb.Text;
            string selKeyTxt = SelKeyTxt.Text;
            DataTable dt = DB_Account.searchBasicUserInfo(selKeyChooseTxt, selKeyTxt);
            if (dt != null)
            {
                UserInfo_DgSource.ItemsSource = dt.DefaultView;
                UserInfo_Page.ShowPages(UserInfo_DgSource, dt, 20);
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserInfo_DgSource.ItemsSource != null)
            {
                UserInfo_DgSource.ItemsSource = null;
                string selKeyChooseTxt = SelKeyChooseComb.Text;
                string selKeyTxt = SelKeyTxt.Text;
                DataTable dt = DB_Account.searchBasicUserInfo(selKeyChooseTxt, selKeyTxt);
                if (dt != null)
                {
                    UserInfo_DgSource.ItemsSource = dt.DefaultView;
                    UserInfo_Page.ShowPages(UserInfo_DgSource, dt, 20);
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.borderBody.Visibility = Visibility.Visible;
            Authorization authorization = new Authorization();
            authorization.Owner = this.Parent as Window;
            authorization.bkChange += new Authorization.BackgroundChange(changeBk);
            authorization.ShowDialog();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView myselect = (DataRowView)UserInfo_DgSource.SelectedItem;
            if (myselect != null)
            {
                this.borderBody.Visibility = Visibility.Visible;
                EditInfo editInfo = new EditInfo();
                editInfo.Owner = this.Parent as Window;
                editInfo.txt_AccountNo.Text = myselect.Row[0].ToString();
                editInfo.txt_UserName.Text = myselect.Row[1].ToString();
                editInfo.txt_Password.Text = myselect.Row[2].ToString();
                editInfo.Position.Text = myselect.Row[3].ToString();
                editInfo.bkChange += new EditInfo.BackgroundChange(changeBk);
                editInfo.ChangeTextEvent += new EditInfo.ChangeTextHandler(editInfo_ChangeTextEvent);
                editInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("未选中数据！");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView myselect = (DataRowView)UserInfo_DgSource.SelectedItem;
            if (myselect != null)
            {
                string accountID = myselect.Row[0].ToString();
                if (accountID.Equals(Login.userInfo.AccountID))
                {
                    MessageBox.Show("不允许删除自己，请周知！");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("确定删除用户？", "提示", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            if (DB_Account.updateUserStatus(accountID, Login.userInfo.AccountID, "1"))
                            {
                                MessageBox.Show("删除成功！");
                                myselect.Delete();
                            }
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("未选中数据！");
            }
        }
        private void editInfo_ChangeTextEvent()
        {
            string selKeyChooseTxt = SelKeyChooseComb.Text;
            string selKeyTxt = SelKeyTxt.Text;
            DataTable dt = DB_Account.searchBasicUserInfo(selKeyChooseTxt, selKeyTxt);
            if (dt != null)
            {
                UserInfo_DgSource.ItemsSource = dt.DefaultView;
                UserInfo_Page.ShowPages(UserInfo_DgSource, dt, 20);
            }
        }
        /// <summary>
        /// 表结构
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("AccountNo",typeof(string)),
                new DataColumn("UserName",typeof(string)),
                new DataColumn("Password",typeof(string)),
                new DataColumn("UserLevel",typeof(string)),
                new DataColumn("CreateTime",typeof(string))
            });
            return dt;
        }
    }
}
