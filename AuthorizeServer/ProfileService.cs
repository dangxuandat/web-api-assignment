using IdentityServer4.Models;
using IdentityServer4.Services;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizeServer
{
    public class ProfileService : IProfileService
    {
        private readonly RepositoryContext _repositoryContext;
        public ProfileService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public  Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //if (!string.IsNullOrEmpty(context.Subject.Claims.FirstOrDefault(x => x.Value.Equals("sub")).ToString()))
                //{
                //    var account = await _repositoryContext.Accounts.FindAsync(context.Subject.Identity.Name);
                //    if (account != null)
                //    {
                //        var claims = ResourceOwnerPasswordValidator.GetUserClaims(account);
                //        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                //    }
                //    else
                //    {
                //        var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");
                //        if (!string.IsNullOrEmpty(userId?.Value))
                //        {
                //            var user = await _repositoryContext.Accounts.FindAsync(userId);

                //            if (user != null)
                //            {
                //                var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);
                //                context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                //            }
                //        }
                //    }
                //}
                context.IssuedClaims = context.Subject.Claims.ToList();
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  Task IsActiveAsync(IsActiveContext context)
        {
            //try
            //{
            //    var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "account_id");
            //    if (!string.IsNullOrEmpty(userId?.Value))
            //    {
            //        var account = await _repositoryContext.Accounts.FindAsync(Guid.Parse(userId.Value));
            //        if(account != null)
            //        {
            //            context.IsActive = true;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}
            return Task.FromResult(0);
        }
    }
}
