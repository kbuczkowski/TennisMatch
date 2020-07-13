using Android.Content;
using Sharpnado.MaterialFrame;
using Sharpnado.MaterialFrame.Droid;
using System;
using TennisMatchApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MaterialFrame), typeof(CustomMaterialFrameRenderer))]
namespace TennisMatchApp.Droid.CustomRenderers
{
    public class CustomMaterialFrameRenderer : AndroidMaterialFrameRenderer
    {
        public CustomMaterialFrameRenderer(Context context) : base(context)
        {
            //ThrowStopExceptionOnDraw = true;
        }
    }
}