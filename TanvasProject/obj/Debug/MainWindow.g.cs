﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "113EE863D9EA09ADAC7F352EABB733C032B7D74A260621D27E54171E228976E1"
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
using TanvasProject;


namespace TanvasProject {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button screenshotbutton;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button spritebutton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deletSprite;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image volume;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button slider_control;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_control;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button volume_control;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vup;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vdown;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image volume_b;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox check;
        
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
            System.Uri resourceLocater = new System.Uri("/TanvasProject;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 9 "..\..\MainWindow.xaml"
            ((TanvasProject.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.screenshotbutton = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\MainWindow.xaml"
            this.screenshotbutton.Click += new System.Windows.RoutedEventHandler(this.takeScreenshot);
            
            #line default
            #line hidden
            return;
            case 4:
            this.spritebutton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.spritebutton.Click += new System.Windows.RoutedEventHandler(this.createHapticImage);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deletSprite = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\MainWindow.xaml"
            this.deletSprite.Click += new System.Windows.RoutedEventHandler(this.deleteAllSprites);
            
            #line default
            #line hidden
            return;
            case 6:
            this.slider = ((System.Windows.Controls.Slider)(target));
            return;
            case 7:
            this.volume = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.slider_control = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\MainWindow.xaml"
            this.slider_control.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Slider);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button_control = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\MainWindow.xaml"
            this.button_control.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Button);
            
            #line default
            #line hidden
            return;
            case 10:
            this.volume_control = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\MainWindow.xaml"
            this.volume_control.Click += new System.Windows.RoutedEventHandler(this.volume_control_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.vup = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.vdown = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.volume_b = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            this.check = ((System.Windows.Controls.CheckBox)(target));
            
            #line 119 "..\..\MainWindow.xaml"
            this.check.Checked += new System.Windows.RoutedEventHandler(this.check_Checked);
            
            #line default
            #line hidden
            
            #line 119 "..\..\MainWindow.xaml"
            this.check.Unchecked += new System.Windows.RoutedEventHandler(this.check_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

