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
using System.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace Renderer
{
    
  internal class ApplyRenderer : Button
  {
    protected async override void OnClick()
    {
      //TODO: Modify this line below to experiment with the different renderers  
      //await DotDensityRenderer.DotDensityRendererAsync();
      //Charts
      //await ChartRenderers.BarChartRendererAsync();
      //await ChartRenderers.PieChartRendererAsync();
      await ChartRenderers.StackedBarChartRendererAsync();
      //ClassBreak
      //await ClassBreakRenderers.CBGraduatedColorsManualBreaks();
      //await ClassBreakRenderers.CBRendererGraduatedColors();
      //await ClassBreakRenderers.CBRendererGraduatedColorsOutlineAsync();
      //await ClassBreakRenderers.CBRendererGraduatedSymbols();
      //await ClassBreakRenderers.UnclassedRenderer();
      //await ClassBreakRenderers.CBGraduatedColorsManualBreaks();
      //Dot Density
      //await DotDensityRenderer.DotDensityRendererAsync();
      //HeatMap      
      //await HeatMapRenderers.HeatMapRenderersAsync();
      //Proportional
      //await ProportionalRenderers.ProportionalRendererAsync();
      //Unique Value
      //await UniqueValueRenderers.UniqueValueRendererAsync();
      //Simple renderers
      //await SimpleRenderers.SimpleRendererPolygon();
      //await SimpleRenderers.SimpleRendererLine();
      //await SimpleRenderers.SimpleRendererPoint();
      //await SimpleRenderers.SimpleRendererLineFromStyeItem();
    }
  }
}
