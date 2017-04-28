using Android.Gms.Maps;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;

namespace Xamarin.Forms.GoogleMaps.Android.Extensions
{
    internal static class MapViewExtensions
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Task<GoogleMap> GetGoogleMapAsync(this MapView self)
        {
            return self.GetGoogleMapAsync();
        }

        static GoogleMap GetMap(MapView mapView)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return mapView.GetGoogleMapAsync().GetAwaiter().GetResult();
#pragma warning restore CS0618 // Type or member is obsolete
        }
   }

    class OnMapReadyCallback : Java.Lang.Object, IOnMapReadyCallback
    {
        readonly Action<GoogleMap> handler;

        public OnMapReadyCallback(Action<GoogleMap> handler)
        {
            this.handler = handler;
        }

        void IOnMapReadyCallback.OnMapReady(GoogleMap googleMap)
        {
            handler?.Invoke(googleMap);
        }
    }
}

