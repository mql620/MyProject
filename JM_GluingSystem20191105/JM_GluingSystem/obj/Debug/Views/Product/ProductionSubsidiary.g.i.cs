﻿#pragma checksum "..\..\..\..\Views\Product\ProductionSubsidiary.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4C307D35E56B2649817F9E911F463427AC8A156C"
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
using JM_GluingSystem.Views.Product;
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


namespace JM_GluingSystem.Views.Product {
    
    
    /// <summary>
    /// ProductionSubsidiary
    /// </summary>
    public partial class ProductionSubsidiary : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 91 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker1;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker2;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchSubsidiaryInfoBtn;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button subsidiaryDetailsInfo;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JM_GluingSystem.Common.Css.DataGridPage SubsidiaryInfo_Page;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SubsidiaryInfo_DgSource;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
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
            System.Uri resourceLocater = new System.Uri("/JM_GluingSystem;component/views/product/productionsubsidiary.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
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
            this.DatePicker1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.DatePicker2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.searchSubsidiaryInfoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
            this.searchSubsidiaryInfoBtn.Click += new System.Windows.RoutedEventHandler(this.SearchSubsidiaryInfoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.subsidiaryDetailsInfo = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
            this.subsidiaryDetailsInfo.Click += new System.Windows.RoutedEventHandler(this.SubsidiaryDetailsInfoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SubsidiaryInfo_Page = ((JM_GluingSystem.Common.Css.DataGridPage)(target));
            return;
            case 6:
            this.SubsidiaryInfo_DgSource = ((System.Windows.Controls.DataGrid)(target));
            
            #line 104 "..\..\..\..\Views\Product\ProductionSubsidiary.xaml"
            this.SubsidiaryInfo_DgSource.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.SubsidiaryInfo_DgSource_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 7:
            this.borderBody = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
