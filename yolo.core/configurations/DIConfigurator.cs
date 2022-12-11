using System;
using Microsoft.Extensions.DependencyInjection;
using yolo.service.implementations;
using yolo.service.interfaces;
using MediatR;
using System.Reflection;
using yolo.common.commands;
using yolo.service.commands.commandHandlers;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.Extensions.Configuration;

namespace yolo.core.configurations
{
	public class DIConfigurator
	{
		public static void Inject(IServiceCollection services, ConfigurationManager configuration)
		{
            services.AddMediatR(typeof(FunctionBCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(FunctionBCommandHandler).GetTypeInfo().Assembly);

            services.AddSingleton<IStringService, StringService>();
			services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<IAssetService, AssetService>();

            services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(configuration["GraphQLURI"] ?? "", new NewtonsoftJsonSerializer()));
        }
	}
}

