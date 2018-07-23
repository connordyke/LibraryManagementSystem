using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {

        private int isbn;
        private String bookTitle;
        private String language;
        private String bindingName;
        private int numCopies;
        private int numCopiesCurrent;
        private String category;
        private String pubYear;
        private String outOfStock;
        private int shelfNum;
        private int floorNum;

        public Book(int isbn, string bookTitle, string language, string bindingName, int numCopies, int numCopiesCurrent, string category, string pubYear, string outOfStock, int shelfNum, int floorNum)
        {
            this.Isbn = isbn;
            this.BookTitle = bookTitle;
            this.Language = language;
            this.BindingName = bindingName;
            this.NumCopies = numCopies;
            this.NumCopiesCurrent = numCopiesCurrent;
            this.Category = category;
            this.PubYear = pubYear;
            this.OutOfStock = outOfStock;
            this.ShelfNum = shelfNum;
            this.FloorNum = floorNum;
        }

        public Book(int isbn)
        {
            this.Isbn = isbn;
        }

        public int Isbn { get => isbn; set => isbn = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string Language { get => language; set => language = value; }
        public string BindingName { get => bindingName; set => bindingName = value; }
        public int NumCopies { get => numCopies; set => numCopies = value; }
        public int NumCopiesCurrent { get => numCopiesCurrent; set => numCopiesCurrent = value; }
        public string Category { get => category; set => category = value; }
        public string PubYear { get => pubYear; set => pubYear = value; }
        public string OutOfStock { get => outOfStock; set => outOfStock = value; }
        public int ShelfNum { get => shelfNum; set => shelfNum = value; }
        public int FloorNum { get => floorNum; set => floorNum = value; }
    }

}
