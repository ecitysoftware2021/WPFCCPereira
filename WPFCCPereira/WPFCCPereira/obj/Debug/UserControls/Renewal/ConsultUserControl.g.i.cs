﻿#pragma checksum "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B1D6A5636B9D2E338339EE8D16465C5F6C45EA73E1B204B682D4C6684C6B62B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using WPFCCPereira.UserControls.Renewal;


namespace WPFCCPereira.UserControls.Renewal {
    
    
    /// <summary>
    /// ConsultUC
    /// </summary>
    public partial class ConsultUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReferencia;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_error;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_consult;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/consultusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
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
            this.btn_exit = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 63 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            ((System.Windows.Controls.Button)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Select_TouchDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 75 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            ((System.Windows.Controls.Button)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Select_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtReferencia = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            this.txtReferencia.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            
            #line 99 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            this.txtReferencia.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Text_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_error = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btn_consult = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\UserControls\Renewal\ConsultUserControl.xaml"
            this.btn_consult.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnConsult_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

