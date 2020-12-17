using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XamarinCRUD
{
     public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Person>().Wait();
        }
        //Read All Items
        public Task<List<Person>> GetItemsAsync()
        {
            return db.Table<Person>().ToListAsync();
        }
        //Insert and Update new record
        public Task<int> SaveItemAsync(Person person)
        {
            if (person.PersonID != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }
        //Read Item
        public Task<Person> GetItemAsync(int personId)
        {
            return db.Table<Person>().Where(i => i.PersonID == personId).FirstOrDefaultAsync();
        }
        //Delete
        public Task<int> DeleteItemAsync(Person person)
        {
            return db.DeleteAsync(person);
        }
    }
    
}
