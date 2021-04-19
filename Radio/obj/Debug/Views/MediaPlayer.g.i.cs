﻿#pragma checksum "..\..\..\Views\MediaPlayer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4F338E53E1B44E87BB8AECE68193049A73D5CF537CF2F5A0DBC1BDDCB07B067"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Radio.Views;
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


namespace Radio.Views {
    
    
    /// <summary>
    /// MediaPlayer
    /// </summary>
    public partial class MediaPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView m_listBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn TrackName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn TrackTime;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PosOfMusic;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimeOfMusic;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider m_Slider;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider m_Volume;
        
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
            System.Uri resourceLocater = new System.Uri("/Radio;component/views/mediaplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MediaPlayer.xaml"
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
            
            #line 22 "..\..\..\Views\MediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectTrack);
            
            #line default
            #line hidden
            return;
            case 2:
            this.m_listBox = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.TrackName = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 4:
            this.TrackTime = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 5:
            this.PosOfMusic = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TimeOfMusic = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.m_Slider = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.m_Volume = ((System.Windows.Controls.Slider)(target));
            
            #line 67 "..\..\..\Views\MediaPlayer.xaml"
            this.m_Volume.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.M_Volume_OnValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 71 "..\..\..\Views\MediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 73 "..\..\..\Views\MediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Suspend);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 75 "..\..\..\Views\MediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayerStop);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

