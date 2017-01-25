using Library.Models;
using System.Collections.Generic;

namespace Library.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Book Book { get; set; }

        public string Title
        {
            get
            {
                if (Book != null && Book.Id != 0)
                {
                    return "Edit Book";
                }
                else
                {
                    return "New Book";
                }
            }
        }
    }
}