//   Copyright 2014 Esri
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
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Core.CIM;

namespace ExportWeb3DObjectResource
{
    /// <summary>
    /// Implements the logic to export 3D marker symbol layers to web 3D object resource
    /// </summary>
    public static class Exporter
    {
        //Downscale factor
        //Value should be between 0 and 1
        //If downscale factor is 0 THEN textures are dropped
        private static double _downscaleFactor = 1;
        public static double DownscaleFactor
        {
            get { return _downscaleFactor; }

            set { _downscaleFactor = value; }
        }

        //Max texture dimension
        //Should be between 0 and 4096
        //If max texture dimension is 0 THEN textures are dropped
        private static int _maxTextureDimension = 512;
        public static int MaxTextureDimension
        {
            get { return _maxTextureDimension; }

            set { _maxTextureDimension = value; }
        }

        //Exporting logic
        public static async Task Export3DMarkerSymbols()
        {
            var activeMapView = ArcGIS.Desktop.Mapping.MapView.Active;
            if (activeMapView == null)
                return;

            CIMMarker3D mrkr3D = null;
            var selectedLayers = activeMapView.GetSelectedLayers();
            if (selectedLayers.Count == 0)
            {
                ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Select at least one point feature layer in the Contents pane.");
                return;
            }

            string outputFolder = SetOutputFolder();
            if (outputFolder == "")
                return;

            await QueuedTask.Run(() =>
            {
                foreach (FeatureLayer ftrLayer in selectedLayers)
                {
                    CIMRenderer currentRenderer = ftrLayer.GetRenderer();

                    if (currentRenderer is CIMSimpleRenderer)
                    {
                        //Get simple renderer from feature layer
                        CIMSimpleRenderer simpleRenderer = currentRenderer as CIMSimpleRenderer;
                        CIMPointSymbol ptSymbol = simpleRenderer.Symbol.Symbol as CIMPointSymbol;
                        if (ptSymbol != null)
                        {
                            var symbolLayers = ptSymbol.SymbolLayers;
                            int count = 0;
                            foreach (CIMSymbolLayer s in symbolLayers)
                            {
                                mrkr3D = s as CIMMarker3D;
                                if (mrkr3D != null)
                                {
                                    string output = outputFolder + "\\" + ftrLayer.Name + "_" + count.ToString() + ".json";
                                    if (File.Exists(output))
                                    {
                                        ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Following file already exists: " + output);
                                    }
                                    else
                                    {
                                        bool success = mrkr3D.ExportWeb3DObjectResource(output, DownscaleFactor, MaxTextureDimension);
                                        if (!success)
                                            //Export will fail if the 3D marker symbol being exported is a restricted symbol
                                            ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Export failed for: " + output);
                                    }
                                    count++;
                                }
                            }
                        }
                    }

                    else if (currentRenderer is CIMUniqueValueRenderer)
                    {
                        //Get unique value renderer from feature layer
                        CIMUniqueValueRenderer uniqueRenderer = currentRenderer as CIMUniqueValueRenderer;
                        CIMUniqueValueGroup[] uv_group = uniqueRenderer.Groups;
                        foreach (CIMUniqueValueGroup v in uv_group)
                        {
                            CIMUniqueValueClass[] uv_classes = v.Classes;
                            foreach (CIMUniqueValueClass uv_class in uv_classes)
                            {
                                CIMPointSymbol ptSymbol = uv_class.Symbol.Symbol as CIMPointSymbol;
                                if (ptSymbol != null)
                                {
                                    var symbolLayers = ptSymbol.SymbolLayers;
                                    int count = 0;
                                    foreach (CIMSymbolLayer s in symbolLayers)
                                    {
                                        mrkr3D = s as CIMMarker3D;
                                        if (mrkr3D != null)
                                        {
                                            string output = outputFolder + "\\" + ftrLayer.Name + "_" + uv_class.Label + "_" + count.ToString() + ".json";
                                            if (File.Exists(output))
                                            {
                                                ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Following file already exists: " + output);
                                            }
                                            else
                                            {
                                                bool success = mrkr3D.ExportWeb3DObjectResource(output, DownscaleFactor, MaxTextureDimension);
                                                if (!success)
                                                    //Export will fail if the 3D marker symbol being exported is a restricted symbol
                                                    ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Export failed for: " + output);
                                            }
                                            count++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        public static string SetOutputFolder()
        {
            FolderBrowserDialog browseDialog = new FolderBrowserDialog();
            browseDialog.Description = "Select output folder for files";
            browseDialog.ShowDialog();
            return browseDialog.SelectedPath;
        }
    }
}
