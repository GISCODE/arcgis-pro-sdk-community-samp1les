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
using System.Linq;
using System.Text;
using System.Windows.Input;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using System.Threading.Tasks;

namespace ListGeodataContent
{
    /// <summary>
    /// This sample illustrates how to list the feature classes and tables of a geodatabase.
    /// </summary>
    /// <remarks>
    /// 1. Download the Community Sample data (see under the 'Resources' section for downloading sample data).  The sample data contains a geodatabase called 'ReviewerWorkspace.gdb' with both tables and feature classes.  Make sure that the Sample data is unzipped in c:\data and "C:\Data\DataReviewer\ReviewerWorkspace.gdb" is available.
    /// 1. Open this solution in Visual Studio.  
    /// 1. Click the build menu and select Build Solution.
    /// 1. Click the Start button to open ArCGIS Pro.  ArcGIS Pro will open.
    /// 1. Open any project.
    /// 1. Click on the Add-in tab and see that a 'Show List Content Dockpane' button was added.
    /// 1. The 'Show List Content Dockpane' button opens the 'Show GDB Content' pane. 
    /// 1. Click the 'Open GDB' button, navigate to C:\Data\DataReviewer, and click on ReviewerWorkspace.gdb.
    /// ![UI](Screenshots/Screen1.png)
    /// </remarks>
    internal class Module1 : Module
    {
        private static Module1 _this = null;

        /// <summary>
        /// Retrieve the singleton instance to this module here
        /// </summary>
        public static Module1 Current
        {
            get
            {
                return _this ?? (_this = (Module1)FrameworkApplication.FindModule("ListGeodataContent_Module"));
            }
        }

        #region Overrides
        /// <summary>
        /// Called by Framework when ArcGIS Pro is closing
        /// </summary>
        /// <returns>False to prevent Pro from closing, otherwise True</returns>
        protected override bool CanUnload()
        {
            //TODO - add your business logic
            //return false to ~cancel~ Application close
            return true;
        }

        #endregion Overrides

    }
}
