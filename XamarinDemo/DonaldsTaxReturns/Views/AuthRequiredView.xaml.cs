using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DonaldsTaxReturns.Models;
using DonaldsTaxReturns.Services;
using Xamarin.Forms;

namespace DonaldsTaxReturns.Views
{
    public partial class AuthRequiredView : ContentView
    {
        private List<TaxReturns> lstTaxReturns = new List<TaxReturns>();
        private UserInfo userInfo;

        public AuthRequiredView()
        {
            InitializeComponent();
        }

        public AuthRequiredView(UserInfo userInfo, List<TaxReturns> lstTaxReturns)
        {
            this.userInfo = userInfo;
            this.lstTaxReturns = lstTaxReturns;
            InitializeComponent();


            Device.BeginInvokeOnMainThread(() => {
                BindingContext = userInfo;

                // lstTaxReturns= await DonaldsTaxReturnsService.GetAllTaxReturns(info.AccessToken).ConfigureAwait(false);

                //lstTaxReturns = lst;
                taxReturnsList.ItemsSource = lstTaxReturns;
            });


        }

        public async Task InitializeDisplay(UserInfo info,List<TaxReturns> lst )
        {
            
            BindingContext = info;

            // lstTaxReturns= await DonaldsTaxReturnsService.GetAllTaxReturns(info.AccessToken).ConfigureAwait(false);

            lstTaxReturns = lst;
            taxReturnsList.ItemsSource = lstTaxReturns;

         


        }
       

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            AuthenticationService.Logout();

            var login = new LoginView();
            App.Secured.Content = login;
            App.Secured.Title = "Not Logged In";
        }

    }
}
