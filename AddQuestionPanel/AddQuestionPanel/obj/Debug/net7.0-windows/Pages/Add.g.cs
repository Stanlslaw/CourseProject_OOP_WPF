﻿#pragma checksum "..\..\..\..\Pages\Add.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80048DAB5D53312595AC94E0CDC45D88F685AED3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AddQuestionPanel.Pages;
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


namespace AddQuestionPanel.Pages {
    
    
    /// <summary>
    /// Add
    /// </summary>
    public partial class Add : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TopicsBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuestionText;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image QuestionImage;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid AnswersBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescHeader;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescText;
        
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
            System.Uri resourceLocater = new System.Uri("/AddQuestionPanel;component/pages/add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Add.xaml"
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
            this.TopicsBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.QuestionText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 37 "..\..\..\..\Pages\Add.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onGetImagePath);
            
            #line default
            #line hidden
            return;
            case 4:
            this.QuestionImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.AnswersBox = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 6:
            this.DescHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DescText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 73 "..\..\..\..\Pages\Add.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onAddQuestion);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

