##CIMExamples

<!-- TODO: Write a brief abstract explaining this sample -->
Shows the following CIM capabilities:  
  
1. Provide sample to create CIMUniqueValueRenderer from scratch  
1. Same as above but using the UniqueValueRendererDefinition class and the layer to configure the underlying Renderer  
1. How to create the equivalent of symbol levels in Pro.  
1. How to change out the Data Connection (equivalent to changing "DataSource" in ArcObjects)  
1. Change the selection color for the given feature layer  
  


<a href="http://pro.arcgis.com/en/pro-app/sdk/" target="_blank">View it live</a>

<!-- TODO: Fill this section below with metadata about this sample-->
```
Language:      C#
Subject:       Map Authoring
Contributor:   ArcGIS Pro SDK Team <arcgisprosdk@esri.com>
Organization:  Esri, http://www.esri.com
Date:          4/1/2016
ArcGIS Pro:    1.2
Visual Studio: 2013, 2015
```

##Resources

* [API Reference online](http://pro.arcgis.com/en/pro-app/sdk/api-reference)
* <a href="http://pro.arcgis.com/en/pro-app/sdk/" target="_blank">ArcGIS Pro SDK for .NET (pro.arcgis.com)</a>
* [arcgis-pro-sdk-community-samples](http://github.com/Esri/arcgis-pro-sdk-community-samples)
* [ArcGIS Pro DAML ID Reference](http://github.com/Esri/arcgis-pro-sdk/wiki/ArcGIS Pro DAML ID Reference)
* [FAQ](http://github.com/Esri/arcgis-pro-sdk/wiki/FAQ)
* [ArcGIS Pro SDK icons](https://github.com/Esri/arcgis-pro-sdk/releases/tag/1.2.0.5023)
* [ProConcepts: ArcGIS Pro Add in Samples](https://github.com/Esri/arcgis-pro-sdk-community-samples/wiki/ProConcepts-ArcGIS-Pro-Add-in-Samples)
* [Sample data for ArcGIS Pro SDK Community Samples](https://github.com/Esri/arcgis-pro-sdk-community-samples/releases)

![ArcGIS Pro SDK for .NET Icons](http://esri.github.io/arcgis-pro-sdk/images/Home/Image-of-icons.png "ArcGIS Pro SDK Icons")

##How to use the sample
<!-- TODO: Explain how this sample can be used. To use images in this section, create the image file in your sample project's screenshots folder. Use relative url to link to this image using this syntax: ![My sample Image](FacePage/SampleImage.png) -->
1. Download the Community Sample data (see under the 'Resources' section for downloading sample data). The sample data contains an ArcGIS Pro project and data to be used for this sample. Make sure that the Sample data is unzipped in c:\data and c:\data\Admin is available.  
1. In Visual Studio click the Build menu. Then select Build Solution.  
1. Click Start button to open ArcGIS Pro.  
1. ArcGIS Pro will open.  
1. Open the project 'C:\Data\Admin\AdminSample.aprx'.  Please note that layer names and other specific data is required for this sample, hence this specific project is required.  
1. Click on the 'CIM Examples' TAB.  
![CIMExamples](Screenshots/Screenshot1.png)  
  
1. Click the 'Renderer From Scratch' button to create a new render for the States layer:  
![CIMExamples](Screenshots/Screenshot2.png)  
  
1. Click the 'Renderer via Definition' button to create a new UniqueValueRendererDefinition for States using the 'TOTPOP2010' field:  
![CIMExamples](Screenshots/Screenshot3.png)   
  
1. Click the 'Create Symbol Levels' button to create the equivalent of symbol levels in Pro:  
![CIMExamples](Screenshots/Screenshot4.png)  
  
1. Click the 'Layer DataSource' button to change out the Data Connection to 'C:\Data\Admin\AdminSample.gdb':  
![CIMExamples](Screenshots/Screenshot5.png)  
  
1. Click the 'Layer Selection Color' button to change the selection color for the given feature layer:  
![CIMExamples](Screenshots/Screenshot6.png)  
  


[](Esri Tags: ArcGIS-Pro-SDK)
[](Esri Language: C-Sharp)???

<p align = center><img src="http://esri.github.io/arcgis-pro-sdk/images/ArcGISPro.png"  alt="pre-req" align = "top" height = "20" width = "20" >
<b> ArcGIS Pro 1.2 SDK for Microsoft .NET Framework</b>
</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Home](https://github.com/Esri/arcgis-pro-sdk/wiki) | <a href="http://pro.arcgis.com/en/pro-app/sdk" target="_blank">ArcGIS Pro SDK</a> | <a href="http://pro.arcgis.com/en/pro-app/sdk/api-reference/index.html" target="_blank">API Reference</a> | [Requirements](#requirements) | [Download](#installing-arcgis-pro-sdk-for-net) |  <a href="http://github.com/esri/arcgis-pro-sdk-community-samples" target="_blank">Samples</a>
