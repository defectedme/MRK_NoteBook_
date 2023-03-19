
namespace MRK_NoteBook.Views;

public partial class OnAbouToClicked : ContentPage
{
    public OnAbouToClicked()
    {
        InitializeComponent();

    }

    void HomeToDoClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

 

}