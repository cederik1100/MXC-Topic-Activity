﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B241F5BBBFCA05D46D8D3C0E642AD251CB41F635"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MCX_Topics;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MCX_Topics {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBSearch;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTSearch;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTUpload;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTCheck;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTDelete;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTClose;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DataCount;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxUploaded;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxTopics;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MCX Topics;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TBSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BTSearch = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\MainWindow.xaml"
            this.BTSearch.Click += new System.Windows.RoutedEventHandler(this.BTSearch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTUpload = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\MainWindow.xaml"
            this.BTUpload.Click += new System.Windows.RoutedEventHandler(this.BTUpload_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTCheck = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\MainWindow.xaml"
            this.BTCheck.Click += new System.Windows.RoutedEventHandler(this.BTCheck_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTDelete = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\MainWindow.xaml"
            this.BTDelete.Click += new System.Windows.RoutedEventHandler(this.BTDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BTClose = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\MainWindow.xaml"
            this.BTClose.Click += new System.Windows.RoutedEventHandler(this.BTClose_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ListBoxUploaded = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.ListBoxTopics = ((System.Windows.Controls.ListBox)(target));
            
            #line 105 "..\..\..\..\MainWindow.xaml"
            this.ListBoxTopics.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxTopics_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

