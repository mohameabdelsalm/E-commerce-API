using Microsoft.OpenApi.Models;

namespace Store.Web.Extensions
{
	public static class SwaggerServiceExtension
	{
		public static IServiceCollection AddSwaggarDocumation(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc
				(
					"v1",
					new OpenApiInfo 
					{
						Title="ECommerce API",
						Version = "v1",
						Contact=new OpenApiContact 
						{
							Name="3BS ACademy",
							Email="abdelsalamm89@gamil.com",
							Url=new Uri("https://api.whatsapp.com/send/?phone=201068381215&text&type=phone_number&app_absent=0")
						}
					});

				var SecurityScheme = new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header Using The Bearer Scheme.Example :\"Authorization:Bearer{Token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme="bearer",
					Reference = new OpenApiReference
					{
						Id = "bearer",
						Type = ReferenceType.SecurityScheme

					}

				};
				options.AddSecurityDefinition("bearer",SecurityScheme);

				var SecurityRequirment = new OpenApiSecurityRequirement
				{
					{ SecurityScheme,new[]{ "bearer"} }
				};
				options.AddSecurityRequirement(SecurityRequirment);
			});

			return services;
		}

       

	}
	
}
