﻿#pragma checksum "..\..\..\UserControls\MenuUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "325A62FBFBFE063DAC0A5E7077247D1E45774807AA343101D4362A0DEED32344"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WPFCCPereira.UserControls;


namespace WPFCCPereira.UserControls {
    
    
    /// <summary>
    /// MenuUserControl
    /// </summary>
    public partial class MenuUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_pay_certificate;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_search_name;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_search_consecutive;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_search_renovacion;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/menuusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\MenuUserControl.xaml"
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
            
            #line 26 "..\..\..\UserControls\MenuUserControl.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_pay_certificate = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\UserControls\MenuUserControl.xaml"
            this.btn_pay_certificate.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_search_TouchDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_search_name = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\UserControls\MenuUserControl.xaml"
            this.btn_search_name.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_search_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_search_consecutive = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\UserControls\MenuUserControl.xaml"
            this.btn_search_consecutive.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_search_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_search_renovacion = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\UserControls\MenuUserControl.xaml"
            this.btn_search_renovacion.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_search_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

