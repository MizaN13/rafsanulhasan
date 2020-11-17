using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RH.Apps.Web.SPA
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(_
				=> new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
			);

			// Configure your authentication provider options here.
			// For more information, see https://aka.ms/blazor-standalone-auth
			builder.Services.AddOidcAuthentication(options =>
				builder.Configuration.Bind("Local", options.ProviderOptions)
			);

			await builder.Build().RunAsync().ConfigureAwait(true);
		}
	}
}
