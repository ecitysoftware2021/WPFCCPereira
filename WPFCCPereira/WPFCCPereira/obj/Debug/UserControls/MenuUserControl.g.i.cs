#pragma checksum "..\..\..\UserControls\MenuUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4FCD1159184570D4868299E344DADF3942E11A4E"
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


namespace WPFCCPereira.UserControls
{


    /// <summary>
    /// MenuUserControl
    /// </summary>
    public partial class MenuUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 22 "..\..\..\UserControls\MenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_exit;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btn_exit = ((System.Windows.Controls.Image)(target));

#line 27 "..\..\..\UserControls\MenuUserControl.xaml"
                    this.btn_exit.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_exit_TouchDown);

#line default
#line hidden
                    return;
                case 2:
                    this.cc_details = ((System.Windows.Controls.ContentControl)(target));
                    return;
                case 3:
                    this.cc_certificates = ((System.Windows.Controls.ContentControl)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Image btn_pay_certificate;
        internal System.Windows.Controls.Image btn_search_name;
        internal System.Windows.Controls.Image btn_search_;
    }
}

