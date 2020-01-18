﻿#pragma checksum "..\..\..\UserControls\PayerUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "450E702E4C748230C4700DFC0863E374A120992939D6DBC91052F49880D64657"
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
using WPFCCPereira.Keyboard;
using WPFCCPereira.UserControls;


namespace WPFCCPereira.UserControls {
    
    
    /// <summary>
    /// PayerUserControl
    /// </summary>
    public partial class PayerUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gd_payer;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_type_id;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxIdentification;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbData1;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxData1;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbData2;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxData2;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_payment;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\UserControls\PayerUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_back;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/payerusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\PayerUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.gd_payer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.cmb_type_id = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\UserControls\PayerUserControl.xaml"
            this.cmb_type_id.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cmb_type_id_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TbxIdentification = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxbData1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TbxData1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxbData2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.TbxData2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_payment = ((System.Windows.Controls.Image)(target));
            
            #line 157 "..\..\..\UserControls\PayerUserControl.xaml"
            this.btn_payment.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_payment_TouchDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_back = ((System.Windows.Controls.Image)(target));
            
            #line 165 "..\..\..\UserControls\PayerUserControl.xaml"
            this.btn_back.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Btn_back_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

