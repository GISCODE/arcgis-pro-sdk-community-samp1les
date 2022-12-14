//   Copyright 2015 Esri
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace ArcGISOnlineConnect
{
    /// <summary>
    /// ArcGISOnlineConnect exercises a collection of programmatic interactions with ArcGIS Online using EsriHttpClient
    /// </summary>
    /// <remarks>
    /// 1. In Visual Studio click the Build menu. Then select Build Solution.
    /// 2. Click Start button to open ArcGIS Pro.
    /// 3. ArcGIS Pro will open. 
    /// 4. Open any project file. Click on the Add-in tab on the ribbon and then on the Show "AgolDockpane" button.
    /// ![UI](Screenshot/AgolInterface.png)  
    /// 5. On top the AgolDockpane (pane) you find the ArcGIS Online Uri used for the interaction with ArcGIS Online (your portal).
    /// 6. Select from the 'AGOL operation' listbox by starting with 'GetRest' (go through the list top to bottom doing the following steps):
    /// 7. Verify the Parameter(s) required for the query you just selected (note: default values are filled in by using return values from previous query results so sequence is important)
    /// 8. Click on the "Run ... ArcGIS Online Query" button to execute the query.
    /// 9. View the results in text box on the bottom of the AgolDockpane.  
    /// 10. Please not that ArcGIS Online queries return json and various content returned in json is deserialized into the respective c# class.
    /// 11. Also note that permissions and content are required for various queries (i.e. content or folder queries)
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
                return _this ?? (_this = (Module1)FrameworkApplication.FindModule("ArcGISOnlineConnect_Module"));
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
