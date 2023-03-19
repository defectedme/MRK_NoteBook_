using MRK_NoteBook.Data;
using MRK_NoteBook.DataServices;
using MRK_NoteBook.ViewModel;
using System.Globalization;

namespace MRK_NoteBook.Views;

public partial class SecureFolderView : ContentPage
{
	public SecureFolderView()
	{
		InitializeComponent();
        this.BindingContext = new SecureFolderViewModel(this.Navigation);
    }

}