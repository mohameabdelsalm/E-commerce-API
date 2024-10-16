
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Data.Contexts;
using Store.Repository.Basket;
using Store.Repository.Basket.Model;
using Store.Repository.Interface;
using Store.Repository.Repository;
using Store.Service.Basket;
using Store.Service.Basket.AutoMapper;
using Store.Service.Caching;
using Store.Service.Interface;
using Store.Service.Mapping;
using Store.Service.TokenService;
using Store.Web.Extensions;
using Store.Web.Helper;

namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			

			// Add services to the container.
			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<StoreDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("localConnection"));
            });

			builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
			});

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService,ProductService>();
			builder.Services.AddScoped<IBasketRepostory, BasketRepostory>();
			builder.Services.AddScoped<IBasketService, BasketService>();
			builder.Services.AddScoped<IcacheService,cacheService>();
			builder.Services.AddScoped<ITokenService,TokenService>();
			builder.Services.AddAutoMapper(typeof(MappingProfile));
			builder.Services.AddAutoMapper(typeof(BasketProfile));


			builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));

				return ConnectionMultiplexer.Connect(configuration);
            });

            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await ApplySeeding.ApplySeedingAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
