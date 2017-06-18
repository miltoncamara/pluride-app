using Foundation;
using Social;
using UIKit;

namespace Pluride.App.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            var tint = UIColor.FromRGB(255, 31, 115);
            UINavigationBar.Appearance.BarTintColor = tint;
            UINavigationBar.Appearance.TintColor = tint;
            UIBarButtonItem.Appearance.TintColor = tint;
            UITabBar.Appearance.TintColor = tint;
            UISwitch.Appearance.OnTintColor = tint;
            UIAlertView.Appearance.TintColor = tint;
            
            UIView.AppearanceWhenContainedIn(typeof(UIAlertController)).TintColor = tint;
            UIView.AppearanceWhenContainedIn(typeof(UIActivityViewController)).TintColor = tint;
            UIView.AppearanceWhenContainedIn(typeof(SLComposeViewController)).TintColor = tint;

            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            global::Xamarin.Forms.Forms.Init();
            global::ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();
            global::CachedImageCircle.Forms.Plugin.iOS.CachedImageCircleRenderer.Init();

            LoadApplication(new Portable.App());

			return base.FinishedLaunching(app, options);
		}

        void DidBecomeActive(NSNotification notification)
        {
            ((Portable.App)Xamarin.Forms.Application.Current).SecondOnResume();

        }

        public override void WillEnterForeground(UIApplication uiApplication)
        {
            base.WillEnterForeground(uiApplication);
            ((Portable.App)Xamarin.Forms.Application.Current).SecondOnResume();
        }
    }
}
