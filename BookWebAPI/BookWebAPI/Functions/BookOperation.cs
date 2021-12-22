using BookWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookWebAPI.Fn
{
    public class BookOperation
    {
        public static bool  Handle(int id, List<Book> list)
        {
            //Control the id 
            if (id == 0)
                return false;

            //Is book exist?
            var book = list.FirstOrDefault(x => x.ID == id);
            if (book is null)
                return false;

            return true;
        }
    }
}
