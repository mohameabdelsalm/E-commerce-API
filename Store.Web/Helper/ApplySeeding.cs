using Microsoft.AspNetCore.Identity;
using Store.Data.Contexts;
using Store.Data.Entites.IdentityEntites;
using Store.Reposatrys;
using Store.Repository;

namespace Store.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serveses = scope.ServiceProvider;
                var factory = serveses.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = serveses.GetRequiredService<StoreDbcontext>();

					var UserManger = serveses.GetRequiredService<UserManager<AppUser>>();

					await SeedingContext.SeedAsync(context, factory);
					await SeedingIdentityUser.SeedUserAsync(UserManger);
				}
                catch (Exception ex)
                {
                    var loger = factory.CreateLogger<ApplySeeding>();
                    loger.LogError(ex.Message);
                }
            }
        }
    }
}
