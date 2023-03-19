using SQLite;

namespace MRK_NoteBook.Data
{
    public class ToDo
    {


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ToDoName { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }


        public string Product { get; set; }
        public string Info { get; set; }

        //[PrimaryKey]

        public string UserName { get; set; }
        public string Password { get; set; }


        //[PrimaryKey]
        public string SecureUserName { get; set; }
        public string SecurePassword { get; set; }


    }

}
