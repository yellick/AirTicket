﻿#pragma checksum "..\..\pageAddFlight.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ED0ABCC33773BB715674976BD828B16F930997945964C6083DA1CCC830A73E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AirTicket;
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


namespace AirTicket {
    
    
    /// <summary>
    /// pageAddFlight
    /// </summary>
    public partial class pageAddFlight : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button goBackBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox placeDepCB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox placeArrCB;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker flightDateDP;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox flightTimeTB;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox airlineCB;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox planeCB;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addFlight;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\pageAddFlight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchPlanes;
        
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
            System.Uri resourceLocater = new System.Uri("/AirTicket;component/pageaddflight.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pageAddFlight.xaml"
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
            this.goBackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\pageAddFlight.xaml"
            this.goBackBtn.Click += new System.Windows.RoutedEventHandler(this.goBackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.placeDepCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.placeArrCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.flightDateDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.flightTimeTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.airlineCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.planeCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.addFlight = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\pageAddFlight.xaml"
            this.addFlight.Click += new System.Windows.RoutedEventHandler(this.addFlight_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.searchPlanes = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\pageAddFlight.xaml"
            this.searchPlanes.Click += new System.Windows.RoutedEventHandler(this.searchPlanes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
