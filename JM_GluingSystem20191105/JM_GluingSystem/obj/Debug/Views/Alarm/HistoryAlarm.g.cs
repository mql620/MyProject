﻿#pragma checksum "..\..\..\..\Views\Alarm\HistoryAlarm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AC79C98AC297D6D87DB90F36931B7EEEC8C8ADA4"
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


namespace JM_GluingSystem.Views.Alarm {
    
    
    /// <summary>
    /// HistoryAlarm
    /// </summary>
    public partial class HistoryAlarm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 105 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker AlarmDatePicker1;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker AlarmDatePicker2;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SelKeyTxt;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchAlarmInfoBtn;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JM_GluingSystem.Common.Css.DataGridPage AlarmInfo_Page;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AlarmInfo_DgSource;
        
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
            System.Uri resourceLocater = new System.Uri("/JM_GluingSystem;component/views/alarm/historyalarm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
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
            this.AlarmDatePicker1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.AlarmDatePicker2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.SelKeyTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.searchAlarmInfoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
            this.searchAlarmInfoBtn.Click += new System.Windows.RoutedEventHandler(this.SearchAlarmInfoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AlarmInfo_Page = ((JM_GluingSystem.Common.Css.DataGridPage)(target));
            return;
            case 6:
            this.AlarmInfo_DgSource = ((System.Windows.Controls.DataGrid)(target));
            
            #line 119 "..\..\..\..\Views\Alarm\HistoryAlarm.xaml"
            this.AlarmInfo_DgSource.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dataGrid_LoadingRow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

