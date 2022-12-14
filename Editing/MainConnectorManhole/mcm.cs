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
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Editing.Attributes;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Internal.Editing;
using ArcGIS.Desktop.Mapping;

namespace MainConnectorManhole
{
  internal class mcm : MapTool
  {
    public mcm()
    {
      IsSketchTool = true;
      SketchType = SketchGeometryType.Line;
      SketchOutputMode = ArcGIS.Desktop.Mapping.SketchOutputMode.Map;
      UseSnapping = true;
    }

    protected override Task<bool> OnSketchCompleteAsync(Geometry geometry)
    {
      //Run on MCT
      return QueuedTask.Run(() =>
      {
        var op = new EditOperation();
        op.Name = "Create main-connector-manhole";
        op.SelectModifiedFeatures = false;
        op.SelectNewFeatures = false;

        //get the templates
        var map = MapView.Active.Map;
        var mainTemplate = map.FindLayers("main").First().GetTemplate("main");
        var mhTemplate = map.FindLayers("Manhole").First().GetTemplate("Manhole");
        var conTemplate = map.FindLayers("Connector").First().GetTemplate("Connector");

        //create the main geom
        var mainGeom = GeometryEngine.Move(geometry, 0, 0, -20);
        op.Create(mainTemplate, mainGeom);

        //create manhole points and connector
        foreach (var pnt in ((Polyline)geometry).Points)
        {
          //manhole point at sketch vertex
          op.Create(mhTemplate, pnt);

          //vertical connector between mahole and main
          var conPoints = new List<MapPoint>();
          conPoints.Add(pnt); //top of vertical connector
          conPoints.Add(GeometryEngine.Move(pnt, 0, 0, -20)); //bottom of vertical connector
          var conPolyLine = PolylineBuilder.CreatePolyline(conPoints);
          op.Create(conTemplate, conPolyLine);
        }
        return op.Execute();
      });
    }
  }
}
