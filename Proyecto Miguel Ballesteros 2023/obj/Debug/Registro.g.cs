﻿#pragma checksum "..\..\Registro.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C952A59EE2002A356C6210317075876BC74E841C854E50A75DFE6F9043438A6"
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
    /// Registro
    /// </summary>
    public partial class Registro : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNombre;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtEmail;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtDireccion;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtTelefono;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPassword;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTRegistrar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Registro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto Miguel Ballesteros 2023;component/registro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registro.xaml"
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
            this.TxtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtDireccion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtTelefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.BTRegistrar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Registro.xaml"
            this.BTRegistrar.Click += new System.Windows.RoutedEventHandler(this.BTRegistrar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BTCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Registro.xaml"
            this.BTCancelar.Click += new System.Windows.RoutedEventHandler(this.BTCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

