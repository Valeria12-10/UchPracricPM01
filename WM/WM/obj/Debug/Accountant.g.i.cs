﻿#pragma checksum "..\..\Accountant.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD6915D9F12BB9C43E726ADA9FF97EEFA8DB6192363159C0CFAB6F861A696CD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WM;


namespace WM {
    
    
    /// <summary>
    /// Accountant
    /// </summary>
    public partial class Accountant : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid WarehouseReportDataGrid;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TurnoverReportDataGrid;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RemainingReportDataGrid;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid InventoryDataGrid;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserInfoLabel;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\Accountant.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UserPhoto;
        
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
            System.Uri resourceLocater = new System.Uri("/WM;component/accountant.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Accountant.xaml"
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
            this.WarehouseReportDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 22 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveWarehouseReportToExcel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TurnoverReportDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 38 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveWarehouseReportToExcel);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RemainingReportDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 54 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveWarehouseReportToExcel);
            
            #line default
            #line hidden
            return;
            case 7:
            this.InventoryDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            
            #line 70 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveWarehouseReportToExcel);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UserInfoLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.UserNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 13:
            this.UserPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            
            #line 110 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UploadPhoto_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 122 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveProfile_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 132 "..\..\Accountant.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

