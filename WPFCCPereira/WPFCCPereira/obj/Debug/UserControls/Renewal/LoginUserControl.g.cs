﻿#pragma checksum "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B415A499E5EE751FE88CE65CB7CBD7240EA3C0FB9115997AB5D22EF694BCE23B"
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
using WPFCCPereira.UserControls.Renewal;
using WpfAnimatedGif;


namespace WPFCCPereira.UserControls.Renewal {
    
    
    /// <summary>
    /// LoginUserControl
    /// </summary>
    public partial class LoginUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtError;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnLogin;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnCancell;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image load_gif;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/loginusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
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
            
            #line 31 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtId.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtId_TextChanged);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtId.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtId_TouchDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 105 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtEmail_TextChanged);
            
            #line default
            #line hidden
            
            #line 106 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtEmail.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtEmail_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 134 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtPassword_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 135 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.txtPassword.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.txtPassword_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btnLogin = ((System.Windows.Controls.Image)(target));
            
            #line 159 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.btnLogin.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnLogin_TouchDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancell = ((System.Windows.Controls.Image)(target));
            
            #line 169 "..\..\..\..\UserControls\Renewal\LoginUserControl.xaml"
            this.btnCancell.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnCancell_TouchDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.load_gif = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

