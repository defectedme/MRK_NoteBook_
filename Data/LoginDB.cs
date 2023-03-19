using SQLite;

namespace MRK_NoteBook.Data
{
    public class LoginDB
    {
        [PrimaryKey]

        public string UserName { get; set; }
        public string Password { get; set; }    


    }
}
