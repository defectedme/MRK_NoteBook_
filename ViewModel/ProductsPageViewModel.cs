using MRK_NoteBook.DataServices;
using MRK_NoteBook.Views;
using MRK_NoteBook.Data;

namespace MRK_NoteBook.Models
{
    public class ProductsPageViewModel : ProductsPageView
    {

        public ProductsPageViewModel()
        {



        }
        List<ToDo> contacts = ProductsPageViewModel.GetToDo();

        public static List<ToDo> _contacts = new List<ToDo>()
        {
            new ToDo {Product="Milk", Info="0,5% Fat"},
            new ToDo {Product="Chocolate", Info="Dark"},
            new ToDo {Product="Bread", Info="Fresh"},
            new ToDo {Product="Cola", Info="Suger FREE"},
            new ToDo {Product="Sousage", Info="Low Fat"},
            new ToDo {Product="Coffee", Info=""},
            new ToDo {Product="Soap", Info="dish"},
            new ToDo {Product="Toothpaste", Info="Fresh"},
            new ToDo {Product="Toilet paper", Info="MUST"},
            new ToDo {Product="Beer", Info="  :) "},
            new ToDo {Product="Vodka", Info=" 40% "},


         };

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var todoItem = (ToDo)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();

        }




        public static List<ToDo> GetToDo() => _contacts;
        public static ToDo GetContactById(string id)
        {
            return _contacts.FirstOrDefault(x => x.UserName == id);
        }



    }
}
