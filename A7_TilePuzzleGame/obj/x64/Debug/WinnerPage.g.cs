﻿#pragma checksum "C:\Users\Jane\Desktop\A7_HEom_JSantos\A7_TilePuzzleGame_HEom_JSantos\A7_TilePuzzleGame\WinnerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B4CF907F053C61BEB93713EA7C0EBBB78FBD8686E04E0A2EBA40BD67FE437CFD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace A7_TilePuzzleGame
{
    partial class WinnerPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // WinnerPage.xaml line 39
                {
                    this.winnerImg = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // WinnerPage.xaml line 40
                {
                    this.EnterName_Box = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // WinnerPage.xaml line 41
                {
                    this.WinnerMsg_Box = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // WinnerPage.xaml line 49
                {
                    this.OK_Btn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.OK_Btn).Click += this.OK_Btn_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

