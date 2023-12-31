﻿#pragma checksum "..\..\..\ActivationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DE176599B01CCB0E5CD44997727A8624FE8C0885"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using PDDTestBelarus;
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


namespace PDDTestBelarus {
    
    
    /// <summary>
    /// ActivationWindow
    /// </summary>
    public partial class ActivationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\ActivationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Placeholder;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ActivationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KeyBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ActivationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ActivationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PDDTestBelarus;component/activationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ActivationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Placeholder = ((System.Windows.Controls.Label)(target));
            
            #line 27 "..\..\..\ActivationWindow.xaml"
            this.Placeholder.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.KeyBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\ActivationWindow.xaml"
            this.KeyBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnInputChanges);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SendButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\ActivationWindow.xaml"
            this.SendButton.Click += new System.Windows.RoutedEventHandler(this.SendKey);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

