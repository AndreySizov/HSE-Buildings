using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSEBuildings.UI
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            gMapControl1.Bearing = 0;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Zoom = 12;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            
            GMapOverlay markersOverlay = new GMapOverlay("marker");
            markersOverlay.Markers.Add(CreateNewMarker(new PointLatLng(55.778651, 37.733001), "ул. Кирпичная, 33", "Кирпичная"));
            markersOverlay.Markers.Add(CreateNewMarker(new PointLatLng(55.761389, 37.633100), "ул. Мясницкая, 20", "Мясницкая20"));
            markersOverlay.Markers.Add(CreateNewMarker(new PointLatLng(55.761389, 37.632200), "ул. Мясницкая, 11", "Мясницкая11"));
            markersOverlay.Markers.Add(CreateNewMarker(new PointLatLng(55.720181, 37.608234), "ул. Шаболовка, 26", "Мясницкая26"));
            markersOverlay.Markers.Add(CreateNewMarker(new PointLatLng(55.803296, 37.409504), "ул. Таллинская, 34", "МИЭМ"));
            


            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Position = new PointLatLng(55.75393, 37.620795);
        }
        public GMapMarker CreateNewMarker(PointLatLng coordinates,string text,string tag)
        {
            GMarkerGoogle marker = new GMarkerGoogle(coordinates, GMarkerGoogleType.red);
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = text;
            marker.Tag = tag;
            return marker;
        }
    }
}
