﻿#pragma checksum "..\..\AddMedicamento.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD43D5EB05BEB14157357A814709B19B48BBA683D25F326E3843F65EC1655DEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_Miguel_Ballesteros_2023;
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


namespace Proyecto_Miguel_Ballesteros_2023 {
    
    
    /// <summary>
    /// AddMedicamento
    /// </summary>
    public partial class AddMedicamento : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNombre;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtDescripción;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtStock;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPrecio;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTGuardar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTCancelar;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblArriba;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\AddMedicamento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblEmail;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto Miguel Ballesteros 2023;component/addmedicamento.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddMedicamento.xaml"
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
            this.TxtNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtDescripción = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtStock = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\AddMedicamento.xaml"
            this.TxtStock.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtStock_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtPrecio = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\AddMedicamento.xaml"
            this.TxtPrecio.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtPrecio_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\AddMedicamento.xaml"
            this.BTGuardar.Click += new System.Windows.RoutedEventHandler(this.BTGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BTCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AddMedicamento.xaml"
            this.BTCancelar.Click += new System.Windows.RoutedEventHandler(this.BTCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LblArriba = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.LblEmail = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

