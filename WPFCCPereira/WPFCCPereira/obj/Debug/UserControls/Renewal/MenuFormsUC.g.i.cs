﻿#pragma checksum "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF94659C15B6219743B8928726BE8CC16D56EFD3E275B71DF36248F0C9AF6C5C"
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


namespace WPFCCPereira.UserControls.Renewal {
    
    
    /// <summary>
    /// MenuFormsUC
    /// </summary>
    public partial class MenuFormsUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_list;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ShowDetail;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnDigilenciar;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnFirma;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnPago;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/menuformsuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
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
            
            #line 43 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
            this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_list = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.ShowDetail = ((System.Windows.Controls.TextBlock)(target));
            
            #line 97 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
            this.ShowDetail.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.ShowDetail_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDigilenciar = ((System.Windows.Controls.Image)(target));
            
            #line 216 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
            this.btnDigilenciar.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnDigilenciar_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnFirma = ((System.Windows.Controls.Image)(target));
            
            #line 228 "..\..\..\..\UserControls\Renewal\MenuFormsUC.xaml"
            this.btnFirma.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnFirma_TouchDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPago = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

