﻿#pragma checksum "..\..\..\..\Views\BasicInfo\EditInfo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B3DCB983C8D326B5D75658EECC5F7D3E88D2BBA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using JM_GluingSystem.Views.BasicInfo;
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
    /// EditInfo
    /// </summary>
    public partial class EditInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_AccountNo;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_UserName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Password;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Position;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmBtn;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/JM_GluingSystem;component/views/basicinfo/editinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 8 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
            ((JM_GluingSystem.Views.BasicInfo.EditInfo)(target)).Closed += new System.EventHandler(this.WindowClose);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_AccountNo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_UserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Position = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ConfirmBtn = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
            this.ConfirmBtn.Click += new System.Windows.RoutedEventHandler(this.ConfirmBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\Views\BasicInfo\EditInfo.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

