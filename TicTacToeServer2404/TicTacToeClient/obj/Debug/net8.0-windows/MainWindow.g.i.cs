// Updated by XamlIntelliSenseFileGenerator 15.03.2025 14:17:27
#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EC8FA7166C11DC0483396F095BF9A52A87029689"
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
using System.Windows.Controls.Ribbon;
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


namespace TicTacToeClient
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TicTacToeClient;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btn00 = ((System.Windows.Controls.Button)(target));

#line 6 "..\..\..\MainWindow.xaml"
                    this.btn00.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btn01 = ((System.Windows.Controls.Button)(target));

#line 7 "..\..\..\MainWindow.xaml"
                    this.btn01.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btn02 = ((System.Windows.Controls.Button)(target));

#line 8 "..\..\..\MainWindow.xaml"
                    this.btn02.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btn10 = ((System.Windows.Controls.Button)(target));

#line 9 "..\..\..\MainWindow.xaml"
                    this.btn10.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btn11 = ((System.Windows.Controls.Button)(target));

#line 10 "..\..\..\MainWindow.xaml"
                    this.btn11.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btn12 = ((System.Windows.Controls.Button)(target));

#line 11 "..\..\..\MainWindow.xaml"
                    this.btn12.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.btn20 = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\..\MainWindow.xaml"
                    this.btn20.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btn21 = ((System.Windows.Controls.Button)(target));

#line 13 "..\..\..\MainWindow.xaml"
                    this.btn21.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.btn22 = ((System.Windows.Controls.Button)(target));

#line 14 "..\..\..\MainWindow.xaml"
                    this.btn22.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock gameStatus;
        internal System.Windows.Controls.Button button0;
        internal System.Windows.Controls.Button button1;
        internal System.Windows.Controls.Button button2;
        internal System.Windows.Controls.Button button3;
        internal System.Windows.Controls.Button button4;
        internal System.Windows.Controls.Button button5;
        internal System.Windows.Controls.Button button6;
        internal System.Windows.Controls.Button button7;
        internal System.Windows.Controls.Button button8;
        internal System.Windows.Controls.Button exitButton;
    }
}

