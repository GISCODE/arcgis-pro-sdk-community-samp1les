//Copyright 2015 Esri

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace DockPaneBookmarkAdvanced
{
    /// <summary>
    /// This sample shows how to:  
    /// * Handle project item collection changes
    /// * Add and delete a bookmark
    /// * Leverage existing ArcGIS Pro commands
    /// * Add styling to buttons to follow ArcGIS Pro styling guidelines
    /// </summary>
    /// <remarks>
    /// 1. In Visual Studio click the Build menu. Then select Build Solution.
    /// 1. Click Start button to open ArcGIS Pro.
    /// 1. ArcGIS Pro will open. 
    /// 1. Open a project with a map that has bookmarks and click on the 'Add-in' tab.
    /// 1. Click the 'Show bookmarks' button to show the bookmark dockpane
    /// 1. On the 'bookmark dockpane' click the 'Get Maps' button to fill the 'Available Maps' dropdown.
    /// 1. Select a map on the 'Available Maps' dropdown.
    /// 1. Click on any of the 'Bookmark' thumbnails to zoom to a given bookmark.
    /// 1. Clock the 'New Bookmark' button.
    /// ![UI](Screenshots/Screen.png)
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
                return _this ?? (_this = (Module1)FrameworkApplication.FindModule("DockPaneBookmarkAdvanced_Module"));
            }
        }
    }
}
