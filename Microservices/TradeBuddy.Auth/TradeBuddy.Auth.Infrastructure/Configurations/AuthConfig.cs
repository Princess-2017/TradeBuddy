using System.Collections.Generic;
using System.Net.Sockets;
using IdentityServer4.Models;

namespace TradeBuddy.Auth.Infrastructure.Configurations
{
    public static class AuthConfig
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "kasbiyar_web", // شناسه کلاینت جدید
                    ClientSecrets = { new Secret("web_secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code, // نوع Grant Type
                    AllowedScopes = { "openid", "profile", "api" }, // حوزه‌های دسترسی
                    RedirectUris = { "https://kasbiyar.com/callback" }, // آدرس بازگشت پس از احراز هویت
                    PostLogoutRedirectUris = { "https://kasbiyar.com/logout-callback" } // آدرس بازگشت پس از خروج
                }
            };
        }
    }
}
