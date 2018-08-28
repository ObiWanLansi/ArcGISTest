using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Rasters;

namespace ArcGISTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private bool bSceneViewMaster = false;

        //private readonly Random random = new Random();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            //-----------------------------------------------------------------

            if( true )
            {
                IWebProxy webProxy = WebRequest.DefaultWebProxy;
                webProxy.Credentials = CredentialCache.DefaultCredentials;
                WebRequest.DefaultWebProxy = webProxy;

                ServicePointManager.ServerCertificateValidationCallback += ( sender , certificate , chain , sslPolicyErrors ) => true;
            }

            //-----------------------------------------------------------------

            //SceneView.SetViewpointCamera(new Camera(49.761471, 06.650053, 1289, 295, 71, 0));

            //-----------------------------------------------------------------

            //SceneView.SetViewpointAsync(new Viewpoint(new MapPoint(06.650053, 49.761471, SpatialReferences.Wgs84), 100000));
            //SceneView.ViewpointChanged += SceneView_ViewpointChanged;
            //-----------------------------------------------------------------

            //LoadRasterFile();
            //CreateSphereSymbol();

            //LoadOfflineWorld();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        private void LoadOfflineWorld()
        {
            RasterLayer rl = new RasterLayer( new Raster( @"C:\Lanser\Entwicklung\GitRepositories\ArcGISTest\OfflineWorldRasterMap.tif" ) );
            SceneView.Scene.Basemap.BaseLayers.Add( rl );
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //private readonly List<RasterLayer> lrl = new List<RasterLayer>();

        ///// <summary>
        ///// 
        ///// </summary>
        //private void LoadRasterFile()
        //{
        //    foreach( string file in Directory.EnumerateFiles( @"C:\Lanser\Viewshed" , "*.tif" ) )
        //    {
        //        RasterLayer rl = new RasterLayer( new Raster( file ) );

        //        //rl.Renderer = new ColormapRenderer( new [] { Colors.White , Colors.Red } );

        //        Color c = Color.FromRgb( ( byte ) random.Next( 256 ) , ( byte ) random.Next( 256 ) , ( byte ) random.Next( 256 ) );
        //        rl.Renderer = new ColormapRenderer( new [] { Colors.White , c } );

        //        SceneView.Scene.Basemap.BaseLayers.Add( rl );

        //        lrl.Add( rl );
        //    }

        //    //var pos = new MapPoint( 35.425224999999998 , 29.243605555555558 , SpatialReferences.Wgs84 );
        //    //SceneView.SetViewpointAsync( new Viewpoint( pos , 400000 ) );

        //    //Viewpoint vp = Viewpoint.FromJson( "{\"rotation\":356.654,\"targetGeometry\":{\"xmin\":34.852290478845788,\"ymin\":28.884536061570579,\"xmax\":36.089164761015653,\"ymax\":29.731651136591623,\"spatialReference\":{\"wkid\":4326}}}" );
        //    //SceneView.SetViewpointAsync( vp );
        //}



        ///// <summary>
        ///// Creates the sphere symbol.
        ///// </summary>
        //private void CreateSphereSymbol()
        //{

        //    //-----------------------------------------------------------------

        //    MapPoint modelCenter = new MapPoint( 06.650053 , 49.761471 , 200 , SpatialReferences.Wgs84 );

        //    var mss = ModelSceneSymbol.CreateAsync( new Uri( "GlobalHawk.3ds" , UriKind.RelativeOrAbsolute ) , 0.1 );
        //    mss.Wait();

        //    GraphicsOverlay modelOverlay = new GraphicsOverlay();
        //    modelOverlay.Opacity = 1.0;
        //    modelOverlay.SceneProperties.SurfacePlacement = SurfacePlacement.Absolute;
        //    modelOverlay.Graphics.Add( new Graphic( modelCenter , mss.Result ) );

        //    SceneView.GraphicsOverlays.Add( modelOverlay );

        //    //-----------------------------------------------------------------

        //    MapPoint bombCenter = new MapPoint( 06.650053 , 49.761471 , 0 , SpatialReferences.Wgs84 );

        //    SimpleMarkerSceneSymbol bomb = new SimpleMarkerSceneSymbol
        //    {
        //        Style = SimpleMarkerSceneSymbolStyle.Sphere ,
        //        Color = Colors.Orange ,
        //        Height = 10 ,
        //        Width = 10 ,
        //        Depth = 10 ,
        //        AnchorPosition = SceneSymbolAnchorPosition.Center
        //    };

        //    SimpleMarkerSceneSymbol sphereSymbol = new SimpleMarkerSceneSymbol
        //    {
        //        Style = SimpleMarkerSceneSymbolStyle.Sphere ,
        //        Color = Colors.Red ,
        //        Height = 3000 ,
        //        Width = 3000 ,
        //        Depth = 3000 ,
        //        AnchorPosition = SceneSymbolAnchorPosition.Center
        //    };

        //    //-----------------------------------------------------------------


        //    GraphicsOverlay symbolsOverlay = new GraphicsOverlay();
        //    symbolsOverlay.Opacity = 0.5;
        //    symbolsOverlay.SceneProperties.SurfacePlacement = SurfacePlacement.Draped;
        //    symbolsOverlay.Graphics.Add( new Graphic( bombCenter , bomb ) );
        //    symbolsOverlay.Graphics.Add( new Graphic( bombCenter , sphereSymbol ) );

        //    SceneView.GraphicsOverlays.Add( symbolsOverlay );

        //    //-----------------------------------------------------------------

        //    SceneView.SetViewpointAsync( new Viewpoint( bombCenter , 100000 ) );
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Handles the MouseWheel event of the TopoOpacity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseWheelEventArgs"/> instance containing the event data.</param>
        private void Slider_MouseWheel( object sender , MouseWheelEventArgs e )
        {
            if( e.Delta > 0 )
            {
                ( sender as Slider ).Value += 10;
            }
            else
            {
                ( sender as Slider ).Value -= 10;
            }
        }


        ///// <summary>
        ///// Handles the ViewpointChanged event of the SceneView control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //private void SceneView_ViewpointChanged(object sender, EventArgs e)
        //{
        //    Camera c = SceneView.Camera;

        //    bSceneViewMaster = true;

        //    sRoll.Value = c.Roll;
        //    sPitch.Value = c.Pitch;
        //    sHeading.Value = c.Heading;

        //    bSceneViewMaster = false;
        //}


        /// <summary>
        /// Handles the ValueChanged event of the TopographieOpacity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        private void TopographieOpacity_ValueChanged( object sender , RoutedPropertyChangedEventArgs<double> e )
        {
            WorldTopoMap.Opacity = sTopoOpacity.Value / 100;
            e.Handled = true;
        }


        /// <summary>
        /// Handles the ValueChanged event of the OpenStreetMapOpacity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        private void OpenStreetMapOpacity_ValueChanged( object sender , RoutedPropertyChangedEventArgs<double> e )
        {
            OpenStreetMap.Opacity = sOpenStreetMap.Value / 100;
            e.Handled = true;
        }


        /// <summary>
        /// Handles the ValueChanged event of the NatGeoWorldMapOpacity control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        private void NatGeoWorldMapOpacity_ValueChanged( object sender , RoutedPropertyChangedEventArgs<double> e )
        {
            NatGeoWorldMap.Opacity = sNatGeoWorldMap.Value / 100;
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the ResetLOC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetLOC_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 0 , 0 , SpatialReferences.Wgs84 ) , 50000000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the ResetRPY control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetRPY_Click( object sender , RoutedEventArgs e )
        {
            Camera c = SceneView.Camera;

            SceneView.SetViewpointCamera( new Camera( c.Location.Y , c.Location.X , c.Location.Z , 0 , 0 , 0 ) );

            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the ResetLAYER control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetLAYER_Click( object sender , RoutedEventArgs e )
        {
            sTopoOpacity.Value = 0;
            sOpenStreetMap.Value = 0;
            sNatGeoWorldMap.Value = 0;

            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoTR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoTR_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 6.650053 , 49.761471 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoKN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoKN_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 9.1636708 , 47.6750345 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoFN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoFN_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 9.3856279 , 47.6673831 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoParis control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoParis_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 2.2944703 , 48.8577159 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoHimalaya control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoHimalaya_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( 83.9283193 , 28.6364527 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the GotoNewYork control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GotoNewYork_Click( object sender , RoutedEventArgs e )
        {
            SceneView.SetViewpoint( new Viewpoint( new MapPoint( -74.0092898 , 40.7089826 , SpatialReferences.Wgs84 ) , 10000 ) );
            e.Handled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElevationExaggerating_ValueChanged( object sender , RoutedPropertyChangedEventArgs<double> e )
        {
            SceneView.Scene.BaseSurface.ElevationExaggeration = sElevationExaggerating.Value;
            e.Handled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyViewpoint_Click( object sender , RoutedEventArgs e )
        {
            Clipboard.SetText( SceneView.GetCurrentViewpoint( ViewpointType.BoundingGeometry ).ToJson() );
            e.Handled = true;
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ResetRasterLayer_Click( object sender , RoutedEventArgs e )
        //{
        //    lrl.ForEach( rl =>
        //    {
        //        SceneView.Scene.Basemap.BaseLayers.Remove( rl );
        //        rl = null;

        //    } );
        //    lrl.Clear();

        //    e.Handled = true;
        //}


        ///// <summary>
        ///// Cameras the changed.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        //private void CameraChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (bSceneViewMaster == true)
        //    {
        //        return;
        //    }

        //    Camera c = SceneView.Camera;

        //    SceneView.SetViewpointCamera(new Camera(c.Location.Y, c.Location.X, c.Location.Z, sHeading.Value, sPitch.Value, sRoll.Value));
        //}

    } // end public partial class MainWindow 
}
