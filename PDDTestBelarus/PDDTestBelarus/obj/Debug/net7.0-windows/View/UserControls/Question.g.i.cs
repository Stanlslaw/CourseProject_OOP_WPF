﻿#pragma checksum "..\..\..\..\..\View\UserControls\Question.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57B0F0F3623AF59AD9F758E3582FF6968B5EBA62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using PDDTestBelarus.View.UserControls;
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


namespace PDDTestBelarus.View.UserControls {
    
    
    /// <summary>
    /// Question
    /// </summary>
    public partial class Question : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\View\UserControls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionText;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\View\UserControls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image QuestionImage;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\View\UserControls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid AnswersContainer;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\View\UserControls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid AnswerInput;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\View\UserControls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run AnswerNumTB;
        
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
            System.Uri resourceLocater = new System.Uri("/PDDTestBelarus;V1.0.0.0;component/view/usercontrols/question.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\UserControls\Question.xaml"
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
            this.QuestionText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.QuestionImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.AnswersContainer = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 4:
            this.AnswerInput = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 5:
            this.AnswerNumTB = ((System.Windows.Documents.Run)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

