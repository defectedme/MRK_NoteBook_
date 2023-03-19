using MRK_NoteBook.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRK_NoteBook.DataServices
{
    public class LoginDatabase
    {

        readonly SQLiteAsyncConnection loginDatabase;

        public LoginDatabase(string dbPath)
        {
            loginDatabase = new SQLiteAsyncConnection(dbPath);
            loginDatabase.CreateTableAsync<ToDo>().Wait();
        }

        public Task<ToDo> GetLoginDataAsync(string userName)
        {
            return loginDatabase.Table<ToDo>()
                .Where(i => i.UserName == userName)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginDataAsync(ToDo loginData)
        {
            return loginDatabase.InsertAsync(loginData);
        }
    }
}
