using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace ToolsMgr
{
    [Activity(Label = "ToolsMgr", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var btnConfigure = FindViewById<Button>(Resource.Id.btn_configure);
            btnConfigure.Click += btnConfigure_Click;
        }

        private void btnConfigure_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this,typeof(ConfigureActivity));
            StartActivity(intent);
        }
    }
}

