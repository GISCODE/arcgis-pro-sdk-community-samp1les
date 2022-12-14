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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArcGIS.Core.Data;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Editing.Attributes;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace UpdateAttributesWithSketch
{
  internal class AttributeWithSketch : MapTool
  {
    public AttributeWithSketch()
    {
      IsSketchTool = true;
      SketchType = SketchGeometryType.Line;
      SketchOutputMode = ArcGIS.Desktop.Mapping.SketchOutputMode.Map;
      UseSnapping = true;
    }

    protected override Task<bool> OnSketchCompleteAsync(ArcGIS.Core.Geometry.Geometry geometry)
    {
      //Simple check for selected layer
      if (MapView.Active.GetSelectedLayers().Count == 0)
      {
        MessageBox.Show("Please select a layer in the toc","Update attributes with sketch");
        return Task.FromResult(true);
      }

      //Run on MCT
      return QueuedTask.Run(() =>
      {
        //Get the selected layer in toc
        var featLayer = MapView.Active.GetSelectedLayers().First() as FeatureLayer;

        //find feature oids under the sketch for the selected layer
        var features = MapView.Active.GetFeatures(geometry);
        var featOids = features[featLayer];

        //update the attributes of those features
        var insp = new Inspector();
        insp.Load(featLayer, featOids);
        insp["PARCEL_ID"] = 42;

        //create and execute the edit operation
        var op = new EditOperation();
        op.Name = "Update parcel";
        op.SelectModifiedFeatures = true;
        op.SelectNewFeatures = false;
        op.Modify(insp);
        return op.Execute();
      });
    }
  }
}
