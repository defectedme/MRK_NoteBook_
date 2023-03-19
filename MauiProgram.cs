using Syncfusion.Maui.Core.Hosting;
using MRK_NoteBook.Views;


namespace MRK_NoteBook;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });



        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ManageToDoPage>();
        //builder.Services.AddTransient<LoginPage>();
        builder.ConfigureSyncfusionCore();




        return builder.Build();
    }
}
