using System;
namespace DonaldsTaxReturns.Constants
{
    public class B2CConstants
    {public static readonly string Tenant = "xamarin007occ.onmicrosoft.com";
        public static readonly string ClientId = "30819db1-84cd-40af-ad08-407ed126fb4c";

        public static readonly string SignInUpPolicy = "B2C_1_b2c_occdemo_signupsignin";
        public static readonly string PasswordResetPolicy = "-- YOU PASSWORD RESET POLICY NAME HERE --";
        public static readonly string EditProfilePolicy = "YOUR EDIT PROFILE POLICY NAME HERE --";

        public static readonly string AuthorityBase = $"https://login.microsoftonline.com/tfp/{Tenant}/";
        public static readonly string SignUpInAuthority = $"{AuthorityBase}{SignInUpPolicy}";
        public static readonly string PasswordResetAuthority = $"{AuthorityBase}{PasswordResetPolicy}";
        public static readonly string EditProfileAuthority = $"{AuthorityBase}{EditProfilePolicy}";

        public static string[] ApplicationScopes = new string[] { "https://xamarin007occ.onmicrosoft.com/backend/read.only" };

        public static string MSALRedirectUri = $"msal{ClientId}://auth";
        public static string DonaldsTaxReturnsUrl = "https://occdemoazb2capi.azurewebsites.net/api/taxreturns";
    }
}
