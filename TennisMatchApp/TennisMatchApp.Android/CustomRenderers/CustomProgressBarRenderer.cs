using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using TennisMatchApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace TennisMatchApp.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {
            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.SetProgressDrawableTiled(Resources.GetDrawable(Resource.Drawable.custom_progressbar_style, (this.Context).Theme));
        }
    }
}