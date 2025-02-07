﻿using Microsoft.AspNetCore.Components.Authorization;

namespace HotelFinal.Client.Services
{
    public class UserService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public UserService(AuthenticationStateProvider authenticationStateProvider)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetUserId()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            try
            {
                return user.FindFirst("sub").Value;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> GetUserEmail()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/emailaddress").Value;
        }
    }
}
