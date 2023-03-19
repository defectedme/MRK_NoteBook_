
using SQLite;
using MRK_NoteBook.Data;
using MRK_NoteBook.Models;

namespace MRK_NoteBook.DataServices
{
    public class TodoItemDatabase
    {
        static SQLiteAsyncConnection Database;


        public static readonly AsyncLazy<TodoItemDatabase> Instance =
            new AsyncLazy<TodoItemDatabase>(async () =>
            {
                var instance = new TodoItemDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<ToDo>();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return instance;
            });


        public TodoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ToDo>> GetItemsAsync()
        {
            return Database.Table<ToDo>().ToListAsync();
        }

        public Task<List<ToDo>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<ToDo>("SELECT * FROM [ToDo] WHERE [Done] = 0");
        }

        public Task<ToDo> GetItemAsync(int id)
        {
            return Database.Table<ToDo>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDo item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ToDo item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteAllItems<T>()
        {
            return Database.DeleteAllAsync<ToDo>();
        }
    }
}
