using MRK_NoteBook.ViewModel;

namespace MRK_NoteBook.Views;

public partial class EmailView : ContentPage
{
    public EmailView()
    {
        InitializeComponent();
        this.BindingContext = new EmailViewModel(this.Navigation);
    }

}