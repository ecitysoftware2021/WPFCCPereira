﻿#pragma checksum "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ECEB32A67698CD08BF29D6BF38AAA4D8C109A7696957AC1B026589DD8BBDA00D"
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


namespace WPFCCPereira.Windows.Modals {
    
    
    /// <summary>
    /// ModalDetailInformationW
    /// </summary>
    public partial class ModalDetailInformationW : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btn_list;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ShowDetail;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WPFCCPereira;component/windows/modals/modaldetailinformationw.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml"
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
            this.btn_list = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.ShowDetail = ((System.Windows.Controls.TextBlock)(target));
            
            #line 74 "..\..\..\..\Windows\Modals\ModalDetailInformationW.xaml"
            this.ShowDetail.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.CloseDetail_TouchDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lv_data_list = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

