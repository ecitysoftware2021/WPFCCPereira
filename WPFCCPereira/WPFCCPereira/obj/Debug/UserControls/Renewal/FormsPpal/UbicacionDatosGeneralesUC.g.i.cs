﻿#pragma checksum "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C4F27051B0A579CBD53E6AAFD53674F46843A861FEFB49A05CE3B6974B8F4820"
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
using WPFCCPereira.UserControls.Renewal.FormsPpal;


namespace WPFCCPereira.UserControls.Renewal.FormsPpal {
    
    
    /// <summary>
    /// UbicacionDatosGeneralesUC
    /// </summary>
    public partial class UbicacionDatosGeneralesUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UC;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UN;
        
        #line default
        #line hidden
        
        
        #line 372 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnNext;
        
        #line default
        #line hidden
        
        
        #line 382 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/renewal/formsppal/ubicaciondatosgeneralesuc." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
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
            this.UC = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.UN = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnNext = ((System.Windows.Controls.Image)(target));
            
            #line 379 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
            this.btnNext.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnNext_TouchDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnReturn = ((System.Windows.Controls.Image)(target));
            
            #line 389 "..\..\..\..\..\UserControls\Renewal\FormsPpal\UbicacionDatosGeneralesUC.xaml"
            this.btnReturn.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnReturn_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

