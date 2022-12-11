using DTO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Service;

using System.Configuration;
using System.Net;

namespace BitirmeTezi
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			var handler = new HttpClientHandler();

			// If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
			handler.AutomaticDecompression = ~DecompressionMethods.None;


			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var host = CreateHostBuilder().Build();
			ServiceProvider = host.Services;
			Application.Run(ServiceProvider.GetRequiredService<Form1>());
		}
		public static IServiceProvider ServiceProvider { get; private set; }
		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddDbContext<DBContext>(options =>
					 options.UseSqlite("Data Source=database.db"));

					services.AddTransient<Form1>();
				});
		}
	}
}