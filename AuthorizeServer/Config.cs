using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthorizeServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> GetApiScopes => new List<ApiScope>
        {
            new ApiScope("Cinema"),
        };
        public static IEnumerable<ApiResource> GetApiResources => new List<ApiResource>
        {
            new ApiResource
            {
                Name = "Cinema",
                Scopes = new List<string>{ "Cinema"},
            }
        };

        public static IEnumerable<Client> GetClients => new List<Client>
        {
            new Client
            {
                AccessTokenLifetime = 20*60,
                ClientId = "ClientCinema",
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "Cinema" },
            },
        };
    }
}
