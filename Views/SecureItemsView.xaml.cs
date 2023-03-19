using MRK_NoteBook.Data;
using MRK_NoteBook.DataServices;
using MRK_NoteBook.ViewModel;

namespace MRK_NoteBook.Views;

public partial class SecureItemsView : ContentPage
{
	public SecureItemsView()
	{
		InitializeComponent();
        this.BindingContext = new SecretItemsViewModel(this.Navigation);

        List<ToDo> contacts = SecretItemsViewModel.GetToDo();
        listContacts.ItemsSource = contacts;
   

    }
    void HomeToDoClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
    }

    async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        //await Shell.Current.GoToAsync($"{nameof(SecureItemsView)}?ID={((ToDo)listContacts.SelectedItem).ID}");
        var todoItem = (ToDo)listContacts.SelectedItem;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.SaveItemAsync(todoItem);
        await Navigation.PopAsync();
        await DisplayAlert("Item Added", "DONE", "ok");

        await Navigation.PushAsync(new MainPage());
        //await Shell.Current.GoToAsync("..");


    }
}