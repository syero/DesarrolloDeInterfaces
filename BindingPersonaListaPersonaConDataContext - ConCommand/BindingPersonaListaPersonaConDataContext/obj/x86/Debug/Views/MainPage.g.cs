﻿#pragma checksum "C:\Users\syero\source\repos\DesarrolloDeInterfaces\BindingPersonaListaPersonaConDataContext - ConCommand\BindingPersonaListaPersonaConDataContext\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3B0DCFC8476FC949966D8776201FEFF6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BindingPersonaListaPersonaConDataContext
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ScrollListaPersonas = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 2:
                {
                    this.grid_Formulario = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.btn_guardar = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 94 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btn_guardar).Click += this.btn_guardar_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.btn_agregar = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 5:
                {
                    this.btn_eliminar = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 6:
                {
                    this.txtBlck_Nombre = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.txtBx_Nombre = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.txtBlck_Apellidos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.txtBx_Apellidos = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.txtBlck_FNacimiento = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.txtBx_FNacimiento = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12:
                {
                    this.txtBlck_Telefono = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.txtBx_Telefono = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14:
                {
                    this.txtBlck_Direccion = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.txtBx_Direccion = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16:
                {
                    this.listaPersonas = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

