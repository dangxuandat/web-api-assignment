using Entity;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly RepositoryContext _repositoryContext;

        public ResourceOwnerPasswordValidator(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                Account account = await _repositoryContext.Accounts.Include(x=> x.Role).FirstOrDefaultAsync(x => x.Email == context.UserName);
                if (account != null)
                {
                    context.Password = HashPassword(context.Password);
                    if(account.Password.Equals(context.Password))
                    {
                        context.Result = new GrantValidationResult(
                            subject: account.Id.ToString(),
                            authenticationMethod: "password",
                            claims: GetUserClaims(account)
                            );
                        
                    }
                    else
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                    }
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User dose not exist");
                }
                
            }
            catch (Exception)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or passwrod");
            }
        }

        public static Claim[] GetUserClaims(Account account)
        {
            return new Claim[]
            {
                new Claim(JwtClaimTypes.Email, account.Email),
                new Claim(JwtClaimTypes.Role, account.Role.Name),
            };
        }

        public static string HashPassword(string rawPassword)
        {
            //Create a SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                //ComputeHash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

                //convert byte array to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
