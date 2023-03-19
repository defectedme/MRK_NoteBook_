using MRK_NoteBook.Views;

namespace MRK_NoteBook;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI1MzgzM0AzMjMwMmUzNDJlMzBEMWI1R0FqMUxUQlJnNG5KWTRLT0ZaUlFaanhyRHJqZUJXeUJBM0YxZHNBPQ==");
        Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
        Routing.RegisterRoute(nameof(ProductsPageView), typeof(ProductsPageView));
        //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

    }
}
