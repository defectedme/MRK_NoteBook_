using MRK_NoteBook.Data;
using MRK_NoteBook.DataServices;
using MRK_NoteBook.Views;

namespace MRK_NoteBook;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        //MainPage = new AppShell();
        //MainPage = new LoginPage();
        //MainPage = new NavigationPage(new SecureItemsView());
        MainPage = new NavigationPage(new LoginPage());

    }
    static LoginDatabase loginDatabase;

    public static LoginDatabase LoginDatabase
    {
        get
        {
            if(loginDatabase == null)
            {
                loginDatabase = new LoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
            }
            return loginDatabase;
        }
    }

    static SecureFolderLoginDatabase secureFolderLoginDatabase;

    public static SecureFolderLoginDatabase secureLoginDatabase
    {
        get
        {
            if (secureFolderLoginDatabase == null)
            {
                secureFolderLoginDatabase = new SecureFolderLoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
            }
            return secureFolderLoginDatabase;
        }
    }
}
