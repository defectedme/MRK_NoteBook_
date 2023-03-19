using MRK_NoteBook.ViewModel;
namespace MRK_NoteBook.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginViewModel(this.Navigation);

	}
}