﻿#pragma checksum "..\..\..\UserControls\ConsultUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6236E2C9BD75ACE13C071CF840061B4B83DABD9612406DFF72DB4AC4F07598D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WPFCCPereira.UserControls;


namespace WPFCCPereira.UserControls {
    
    
    /// <summary>
    /// ConsultUserControl
    /// </summary>
    public partial class ConsultUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image check_option;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button check_identification;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button check_name;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_name;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_id;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_error;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_consult;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_tittle;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\UserControls\ConsultUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_data_list;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/consultusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\ConsultUserControl.xaml"
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
            
            #line 30 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.check_option = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.check_identification = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.check_identification.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Select_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.check_name = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.check_name.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Select_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.text_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 84 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.text_name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.text_name.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Text_name_TouchDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.text_id = ((System.Windows.Controls.TextBox)(target));
            
            #line 108 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.text_id.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            
            #line 109 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.text_id.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Text_id_TouchDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_error = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btn_consult = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.btn_consult.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnConsult_TouchDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbl_tittle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.lv_data_list = ((System.Windows.Controls.ListView)(target));
            
            #line 160 "..\..\..\UserControls\ConsultUserControl.xaml"
            this.lv_data_list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Lv_data_list_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

