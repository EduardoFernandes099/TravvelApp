using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using System;
using ViajeiD_.View;

namespace ViajeiD_
{
    public static class MauiProgram
    {
        public static MauiAppBuilder CreateMauiAppBuilder()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit();

            builder.Logging.AddDebug();

            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto");
                fonts.AddFont("DarkerGrotesque-SemiBold.ttf", "Grotesque");
            });

            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
            builder.Services.AddTransient<NovaPostagemForm>();
            builder.Services.AddTransient<FeedView>();
            builder.Services.AddSingleton<NovaPostagemForm>();

            return builder;
        }

        public static MauiApp CreateMauiApp()
        {
            return CreateMauiAppBuilder().Build();

        }


    }
}






