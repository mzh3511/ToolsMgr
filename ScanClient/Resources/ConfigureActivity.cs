using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using GoogleGson;
using Java.IO;
using Java.Net;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Impl.Client;
using Org.Apache.Http.Util;
using Org.Json;
using ToolsMgr.Parameters;

namespace ToolsMgr
{
    [Activity(Label = "ToolsMgr", MainLauncher = true, Icon = "@drawable/icon")]
    public class ConfigureActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Configure);

            var btnLogin = FindViewById<Button>(Resource.Id.btn_login);
            btnLogin.Click += btnLogin_Click;
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            var result = await Task.Factory.StartNew(DoGet);
            var txtUsername = FindViewById<EditText>(Resource.Id.txt_login_name);
            var gson = new Gson();
            //gson.FromJson(result, typeof(RespSyncAuthParam))
        }
        private string DoGet()
        {
            var txtUsername = FindViewById<EditText>(Resource.Id.txt_login_name);
            var username = txtUsername.Text;
            var password = FindViewById<EditText>(Resource.Id.txt_login_pwd).Text;

            var result = string.Empty;
            var url =new URL(@"http://192.168.1.115:49152");
            var urlConn = url.OpenConnection() as HttpURLConnection;
            if(urlConn == null)
                return result;
            try
            {
                var inStream = new InputStreamReader(urlConn.InputStream);
                var bufferReader = new BufferedReader(inStream);
                var readLine = string.Empty;
                while ((readLine = bufferReader.ReadLine())!= null)
                {
                    result += readLine;
                }
                inStream.Close();
                urlConn.Disconnect();
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }
    }
}