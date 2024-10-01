using Store.Data.Contexts;
using Store.Reposatrys;

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
                    var context = serveses.GetRequiredService<StoreDBcontext>();
                    await SeedingContext.SeedAsync(context, factory);
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
