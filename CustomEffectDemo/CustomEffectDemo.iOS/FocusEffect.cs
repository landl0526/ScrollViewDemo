using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomEffectDemo.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace CustomEffectDemo.iOS
{
    public class FocusEffect : PlatformEffect
    {

        UIScrollView nativeControl;
        private bool _isAttached;
        protected override void OnAttached()
        {
            nativeControl = Control as UIScrollView;
            if (nativeControl != null && !_isAttached)
            {
                nativeControl.Scrolled += NativeControl_Scrolled;
                _isAttached = true;
            }
        }

        private void NativeControl_Scrolled(object sender, EventArgs e)
        {
            //var command = ScrollingEffect.GetCommand(Element);
            //command?.Execute(null);
        }
        protected override void OnDetached()
        {
            if (_isAttached)
            {
                nativeControl.Scrolled -= NativeControl_Scrolled;
                _isAttached = false;
            }
        }
    }
}