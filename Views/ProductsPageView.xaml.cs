using MRK_NoteBook.DataServices;
using MRK_NoteBook.Models;
using MRK_NoteBook.Data;

namespace MRK_NoteBook.Views;

public partial class ProductsPageView : ContentPage
{

    public ProductsPageView()
    {
        InitializeComponent();

        List<ToDo> contacts = ProductsPageViewModel.GetToDo();
        listContacts.ItemsSource = contacts;

    }


    //async void OnSaveButtonClicked(object sender, EventArgs e)
    //{

    //    var todoItem = (ToDo)BindingContext;
    //    TodoItemDatabase database = await TodoItemDatabase.Instance;
    //    await database.SaveItemAsync(todoItem);
    //    await Navigation.PopAsync();

    //}

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
        await Navigation.PopAsync();

    }
    async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        await Shell.Current.GoToAsync($"{nameof(ProductsPageView)}?ID={((ToDo)listContacts.SelectedItem).ID}");
        var todoItem = (ToDo)listContacts.SelectedItem;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.SaveItemAsync(todoItem);
        //await Navigation.PopAsync();
        await DisplayAlert("Item Added", "DONE", "ok");

        await Navigation.PushAsync(new MainPage());

        //await Shell.Current.GoToAsync("..");


    }


}