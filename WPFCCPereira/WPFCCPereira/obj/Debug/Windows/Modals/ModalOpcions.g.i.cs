﻿#pragma checksum "..\..\..\..\Windows\Modals\ModalOpcions.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "760727419A6EF1D30307FD72C0B29034B4A49D84827AB7CBC3184DA84A5A1AF7"
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
using WPFCCPereira.Windows.Modals;
using WpfAnimatedGif;


namespace WPFCCPereira.Windows.Modals {
    
    
    /// <summary>
    /// ModalOpcions
    /// </summary>
    public partial class ModalOpcions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridOperaciones;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOpcion;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridTeclado;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtultimosDigitos;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ShowHide;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock botonAceptar;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GifLoad2;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/windows/modals/modalopcions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
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
            
            #line 19 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((WPFCCPereira.Windows.Modals.ModalOpcions)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridOperaciones = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtOpcion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.gridTeclado = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.txtultimosDigitos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ShowHide = ((System.Windows.Controls.Image)(target));
            
            #line 92 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            this.ShowHide.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.ShowHide_TouchDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 103 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 113 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 123 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 132 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 141 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 150 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 160 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 170 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 180 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 16:
            this.botonAceptar = ((System.Windows.Controls.TextBlock)(target));
            
            #line 193 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            this.botonAceptar.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BotonAceptar_TouchDown);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 204 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 214 "..\..\..\..\Windows\Modals\ModalOpcions.xaml"
            ((System.Windows.Controls.TextBlock)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TextBlock_TouchDown);
            
            #line default
            #line hidden
            return;
            case 19:
            this.GifLoad2 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

