using System;
using Microsoft.Extensions.DependencyInjection;
using yolo.service.implementations;
using yolo.service.interfaces;

namespace yolo.core.configurations
{
	public class DIConfigurator
	{
		public static void Inject(IServiceCollection services)
		{
			services.AddSingleton<IStringService, StringService>();
		}
	}
}

