using MRK_NoteBook.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRK_NoteBook.DataServices
{
    public class SecureFolderLoginDatabase
    {


        readonly SQLiteAsyncConnection secureloginDatabase;

        public SecureFolderLoginDatabase(string dbPath)
        {
            secureloginDatabase = new SQLiteAsyncConnection(dbPath);
            secureloginDatabase.CreateTableAsync<ToDo>().Wait();
        }

        public Task<ToDo> GetLoginDataAsync(string secureuserName)
        {

            return secureloginDatabase.Table<ToDo>()
                .Where(i => i.SecureUserName == secureuserName)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginDataAsync(ToDo loginData)
        {
            return secureloginDatabase.InsertAsync(loginData);
        }


    }
}
