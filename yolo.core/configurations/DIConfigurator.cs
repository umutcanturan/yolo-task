using System;
using Microsoft.Extensions.DependencyInjection;
using yolo.service.implementations;
using yolo.service.interfaces;
using MediatR;
using System.Reflection;
using yolo.common.commands;
using yolo.service.commands.commandHandlers;

namespace yolo.core.configurations
{
	public class DIConfigurator
	{
		public static void Inject(IServiceCollection services)
		{
            services.AddMediatR(typeof(FunctionBCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(FunctionBCommandHandler).GetTypeInfo().Assembly);

            services.AddSingleton<IStringService, StringService>();
			services.AddScoped<IFunctionService, FunctionService>();
		}
	}
}

