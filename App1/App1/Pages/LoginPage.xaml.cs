using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Facebook;
using System.Dynamic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        private const string AppId = "";
        private Uri _loginUrl;
        private const string _ExtendedPermissions = "user_about_me,publish_stream,offline_access";
        FacebookClient fbClient = new FacebookClient();
        
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void login()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = AppId;
            parameters.redirect_uri = "https://facebook.com/connect/login_success.html";

            //The requested response: an access token (token), an authorization code (code), or both (code )
            parameters.response_type = "token";

            //list of additional display modes can be found at http://developers.facebook.com/docs/reference
            parameters.display = "popup";

            //add the 'scope' parameter only if we have extendedPermissions.
            if (!string.IsNullOrWhiteSpace(_ExtendedPermissions))
            {
                parameters.scope = _ExtendedPermissions;
            }
            //generate the login url.
            var fb = new FacebookClient();
            _loginUrl = fb.GetLoginUrl(parameters);
            //_logoutUrl = fb.GetLogOutUrl(parameters);

            //WebView wv = new WebView();
            //wv.Navigate(_loginUrl);
            //webbrowser navigate
        }
    }
}
