using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRK_NoteBook.Models;
using MRK_NoteBook.Data;

namespace MRK_NoteBook.Helpers
{
    public  class DeleteAllFromDb
    {

        readonly SQLiteAsyncConnection _database;

        public DeleteAllFromDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ToDo>();
        }  
     
       public Task<int> DeleteAllItems<T>()
        {
            return _database.DeleteAllAsync<ToDo>();
        }
    }
}
