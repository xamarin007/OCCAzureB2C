using System;
using System.Collections.Generic;
using DonaldsTaxReturns.Models;
using DonaldsTaxReturns.Pages;
using DonaldsTaxReturns.Services;
using Xamarin.Forms;

namespace DonaldsTaxReturns.Views
{
    public partial class LoginView : ContentView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            UserInfo userInfo = null;
            userInfo = await AuthenticationService.GetSignInUpToken();

            if (userInfo != null)
            {
                
                var lstTaxReturns = await DonaldsTaxReturnsService.GetAllTaxReturns(userInfo.AccessToken, true).ConfigureAwait(false);
                var authReqView = new AuthRequiredView(userInfo, lstTaxReturns);
                //await authReqView.InitializeDisplay(userInfo, lstTaxReturns).ConfigureAwait(false);

                Device.BeginInvokeOnMainThread(() => {
                    App.Secured.Content = authReqView;
                    App.Secured.Title = "Logged In";
              });

                return;
            }
            else
            {

                await Application.Current.MainPage
                                 .DisplayAlert("Login Error", "An error occurred while logging in", "OK");
            }
        }
    }
}
