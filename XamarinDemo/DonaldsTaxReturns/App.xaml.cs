using Xamarin.Forms;
using Microsoft.Identity.Client;
using DonaldsTaxReturns.Pages;
using DonaldsTaxReturns.Services;
using DonaldsTaxReturns.Views;
using System.Collections.Generic;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace DonaldsTaxReturns
{
    public partial class App : Application
    {
        public static PublicClientApplication AuthClient = null;
        public static UIParent UiParent = null;

        public static SecuredPage Secured;

        public App()
        {
            InitializeComponent();

            TabbedPage overallTab;
            overallTab = new TabbedPage();

            Secured = new SecuredPage();

            overallTab.Children.Add(new NavigationPage(new NoAuthPage()) { Title = "No Auth" });
            overallTab.Children.Add(new NavigationPage(Secured) { Title = "Secured" });

            MainPage = overallTab;
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            var userInfo = await AuthenticationService.GetCachedSignInToken();



            if (userInfo != null)
            {
                Secured.Title = "Logged In";
                var authView = new AuthRequiredView();
                //await authView.InitializeDisplay(userInfo);

                List<Models.TaxReturns> lstTaxReturns = await DonaldsTaxReturnsService.GetAllTaxReturns(userInfo.AccessToken, false).ConfigureAwait(false);
                
                await authView.InitializeDisplay(userInfo, lstTaxReturns);

                Secured.Content = authView;
            }
            else
            {
                Secured.Title = "Not Logged In";
                Secured.Content = new LoginView();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
