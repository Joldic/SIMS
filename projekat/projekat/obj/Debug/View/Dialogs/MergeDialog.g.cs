﻿#pragma checksum "..\..\..\..\View\Dialogs\MergeDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B25DA853AD8B093A40618A1E9940A969A168D913C98CE4AC26A4FF5EA7FC432"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using projekat.View.Dialogs;


namespace projekat.View.Dialogs {
    
    
    /// <summary>
    /// MergeDialog
    /// </summary>
    public partial class MergeDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Rooms_1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Rooms_2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Room_name;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Client;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DP1_Copy;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboTP1;
        
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
            System.Uri resourceLocater = new System.Uri("/projekat;component/view/dialogs/mergedialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
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
            this.Rooms_1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Rooms_2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Room_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Client = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.DP1_Copy = ((System.Windows.Controls.DatePicker)(target));
            
            #line 29 "..\..\..\..\View\Dialogs\MergeDialog.xaml"
            this.DP1_Copy.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DP1_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cboTP1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

