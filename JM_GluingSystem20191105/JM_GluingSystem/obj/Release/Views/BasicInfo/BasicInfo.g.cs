﻿#pragma checksum "..\..\..\..\Views\BasicInfo\BasicInfo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1490406286C3324D6B7574C71CB680D739200739"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using JM_GluingSystem.Common.Css;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace JM_GluingSystem.Views.BasicInfo {
    
    
    /// <summary>
    /// BasicInfo
    /// </summary>
    public partial class BasicInfo : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 104 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelKeyChooseComb;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SelKeyTxt;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button search_UserInfoBtn;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshBtn;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JM_GluingSystem.Common.Css.DataGridPage UserInfo_Page;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UserInfo_DgSource;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderBody;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JM_GluingSystem;component/views/basicinfo/basicinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SelKeyChooseComb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.SelKeyTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.search_UserInfoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            this.search_UserInfoBtn.Click += new System.Windows.RoutedEventHandler(this.Search_UserInfoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RefreshBtn = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            this.RefreshBtn.Click += new System.Windows.RoutedEventHandler(this.RefreshBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\..\Views\BasicInfo\BasicInfo.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UserInfo_Page = ((JM_GluingSystem.Common.Css.DataGridPage)(target));
            return;
            case 9:
            this.UserInfo_DgSource = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.borderBody = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

