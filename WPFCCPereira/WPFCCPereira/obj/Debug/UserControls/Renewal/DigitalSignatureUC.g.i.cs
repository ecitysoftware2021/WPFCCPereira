﻿#pragma checksum "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66DB70C198BE556D13FECE5FAF62C8AAE4B1DF32194E3D1723CE57DB447FDE7A"
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
    /// DigitalSignatureUC
    /// </summary>
    public partial class DigitalSignatureUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_show_id;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 306 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnNext;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnReturn;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/digitalsignatureuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
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
            return;
            case 2:
            this.btn_show_id = ((System.Windows.Controls.Image)(target));
            
            #line 250 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.btn_show_id.TouchEnter += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_show_id_TouchEnter);
            
            #line default
            #line hidden
            
            #line 251 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.btn_show_id.TouchLeave += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_show_id_TouchLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 269 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.txtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtPassword_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 270 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.txtPassword.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtPassword_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNext = ((System.Windows.Controls.Image)(target));
            
            #line 313 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.btnNext.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnNext_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnReturn = ((System.Windows.Controls.Image)(target));
            
            #line 323 "..\..\..\..\UserControls\Renewal\DigitalSignatureUC.xaml"
            this.btnReturn.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnReturn_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

