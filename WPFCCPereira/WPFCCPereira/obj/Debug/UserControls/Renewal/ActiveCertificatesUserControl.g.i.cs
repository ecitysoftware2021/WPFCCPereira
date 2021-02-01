﻿#pragma checksum "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD71479732178E018DEE43CC564860E4C10BA41A0EE29E3B59E6383DE3F7BB45"
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
    /// ActiveCertificatesUserControl
    /// </summary>
    public partial class ActiveCertificatesUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 26 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grvEstablecimientos;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/activecertificatesusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
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
            
            #line 31 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 189 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NuevosActivos_TextChanged);
            
            #line default
            #line hidden
            
            #line 190 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.NuevosActivos_TouchDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 223 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumEmpleados_TextChanged);
            
            #line default
            #line hidden
            
            #line 224 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.NumEmpleados_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grvEstablecimientos = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.lv_data_list = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 281 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.Grid)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Grid_TouchDown);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 421 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NuevosActivos_TextChanged);
            
            #line default
            #line hidden
            
            #line 422 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.NuevosActivos_TouchDown);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 455 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumEmpleados_TextChanged);
            
            #line default
            #line hidden
            
            #line 456 "..\..\..\..\UserControls\Renewal\ActiveCertificatesUserControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.NumEmpleados_TouchDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

