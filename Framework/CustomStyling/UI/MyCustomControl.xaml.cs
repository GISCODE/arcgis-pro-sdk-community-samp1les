/*

   Copyright 2019 Esri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       https://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

   See the License for the specific language governing permissions and
   limitations under the License.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArcGIS.Desktop.Framework;

namespace CustomStyling.UI {
    /// <summary>
    /// Interaction logic for MyCustomControl.xaml
    /// </summary>
    public partial class MyCustomControl : UserControl {
        public MyCustomControl() {
            InitializeComponent();

            if (!IsInDesignMode)
                InitResources();
        }

        private void InitResources() {
            var resources = this.Resources;
            resources.BeginInit();

            if (FrameworkApplication.ApplicationTheme == ApplicationTheme.Dark ||
                FrameworkApplication.ApplicationTheme == ApplicationTheme.HighContrast) {
                resources.MergedDictionaries.Add(
                   new ResourceDictionary() {
                    Source = new Uri("pack://application:,,,/CustomStyling;component/Themes/DarkTheme.xaml")
           });
            }
            else {
                resources.MergedDictionaries.Add(
                    new ResourceDictionary() {
                        Source = new Uri("pack://application:,,,/CustomStyling;component/Themes/LightTheme.xaml")
                    });
            }
            resources.EndInit();
        }

        internal bool IsInDesignMode
        {
            get
            {
                return (bool) DependencyPropertyDescriptor.FromProperty(
                    DesignerProperties.IsInDesignModeProperty, typeof (DependencyObject)).Metadata.DefaultValue;
            }
        }
    }
}
