﻿#pragma checksum "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B7854F59F5D33B2E893FD3B3748C33293FF1F9B88E0A99D22F9D63782BFEEFC7"
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
using WPFCCPereira.UserControls.Administrator;


namespace WPFCCPereira.UserControls.Administrator {
    
    
    /// <summary>
    /// AdministratorUserControl
    /// </summary>
    public partial class AdministratorUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTittle;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDescription;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_denominations;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtValor;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnNext;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnCancell;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/usercontrols/administrator/administratorusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
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
            this.txtTittle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.lv_denominations = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.txtValor = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btnNext = ((System.Windows.Controls.Image)(target));
            
            #line 180 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
            this.btnNext.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnNext_TouchDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancell = ((System.Windows.Controls.Image)(target));
            
            #line 190 "..\..\..\..\UserControls\Administrator\AdministratorUserControl.xaml"
            this.btnCancell.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.BtnCancell_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

