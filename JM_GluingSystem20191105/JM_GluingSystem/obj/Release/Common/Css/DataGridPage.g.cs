﻿#pragma checksum "..\..\..\..\Common\Css\DataGridPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9E6819C2AA90B8F22E89EF407635FB59F24146E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace JM_GluingSystem.Common.Css {
    
    
    /// <summary>
    /// DataGridPage
    /// </summary>
    public partial class DataGridPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkRecords;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnFirst;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnPrev;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox page;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock countPage;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGO;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnNext;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Common\Css\DataGridPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnLast;
        
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
            System.Uri resourceLocater = new System.Uri("/JM_GluingSystem;component/common/css/datagridpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Common\Css\DataGridPage.xaml"
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
            this.tbkRecords = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnFirst = ((System.Windows.Controls.TextBlock)(target));
            
            #line 53 "..\..\..\..\Common\Css\DataGridPage.xaml"
            this.btnFirst.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnFirst_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPrev = ((System.Windows.Controls.TextBlock)(target));
            
            #line 54 "..\..\..\..\Common\Css\DataGridPage.xaml"
            this.btnPrev.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnPrev_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.page = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.countPage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnGO = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Common\Css\DataGridPage.xaml"
            this.btnGO.Click += new System.Windows.RoutedEventHandler(this.btnGO_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnNext = ((System.Windows.Controls.TextBlock)(target));
            
            #line 62 "..\..\..\..\Common\Css\DataGridPage.xaml"
            this.btnNext.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnNext_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnLast = ((System.Windows.Controls.TextBlock)(target));
            
            #line 63 "..\..\..\..\Common\Css\DataGridPage.xaml"
            this.btnLast.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnLast_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

