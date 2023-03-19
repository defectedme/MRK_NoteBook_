using MRK_NoteBook.DataServices;
using MRK_NoteBook.Data;

namespace MRK_NoteBook.Models
{
    public partial class ManageToDoViewModel : ContentPage
    {


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (ToDo)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (ToDo)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
            await Navigation.PopAsync();

        }
    }
}
