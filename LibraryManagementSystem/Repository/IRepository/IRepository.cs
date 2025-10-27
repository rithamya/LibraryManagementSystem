using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        //void Add(string title, int? authorId=null, int? year = null, string? phno =null , string? address =null );
        void ListItems();
        //void Update(int Id, string newTitle);
        //void Delete(int Id);
    }
}
