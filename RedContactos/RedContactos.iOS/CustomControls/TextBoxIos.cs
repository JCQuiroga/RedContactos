using RedContactos.CustomControls;
using RedContactos.iOS.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(TextBox),typeof(TextBoxIos))]
namespace RedContactos.iOS.CustomControls
{
    public class TextBoxIos:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.BorderStyle=UITextBorderStyle.Bezel;
            Control.TextColor=UIColor.Cyan;
        }
    }
}