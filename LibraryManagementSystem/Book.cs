using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {

        private int isbn;
        private String bookTitle;
        private String language;
        private String bindingName;
        private int numCopies;
        private int numCopiesCurrent;
        private String category;
        private String pubYear;

        public Book(int isbn, string bookTitle, string language, string category, string pubYear)
        {
            this.isbn = isbn;
            this.bookTitle = bookTitle;
            this.language = language;
            this.category = category;
            this.pubYear = pubYear;
        }

        public Book(int isbn, string bookTitle, string language, string bindingName, int numCopies, int numCopiesCurrent, string category, string pubYear)
        {
            this.isbn = isbn;
            this.bookTitle = bookTitle;
            this.language = language;
            this.bindingName = bindingName;
            this.numCopies = numCopies;
            this.numCopiesCurrent = numCopiesCurrent;
            this.category = category;
            this.pubYear = pubYear;
        }

        public int Isbn { get => isbn; set => isbn = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string Language { get => language; set => language = value; }
        public string BindingName { get => bindingName; set => bindingName = value; }
        public int NumCopies { get => numCopies; set => numCopies = value; }
        public int NumCopiesCurrent { get => numCopiesCurrent; set => numCopiesCurrent = value; }
        public string Category { get => category; set => category = value; }
        public string PubYear { get => pubYear; set => pubYear = value; }
    }
}
