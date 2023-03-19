using MRK_NoteBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRK_NoteBook.ViewModel
{
    public class SecretItemsViewModel
    {
        public SecretItemsViewModel(INavigation navigation)
        {

       

        }

        public static List<ToDo> _contacts = new List<ToDo>()
        {
            new ToDo {Product="Beer", Info="  :) "},
            new ToDo {Product="Vodka", Info=" 40% "},
         };
        private object listContacts;

        public static List<ToDo> GetToDo() => _contacts;
        public static ToDo GetContactById(int id)
        {
            return _contacts.FirstOrDefault(x => x.ID == id);
        }



    }
}
