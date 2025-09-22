using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public DateTime ReleaseDate { get; }

        public Book(int id, string title, string author, DateTime releaseDate)
        {
            Id = id; Title = title; Author = author; ReleaseDate = releaseDate;
        }

        public override string ToString()
            => $"Cím: {Title}, Szerző: {Author}, Megj.: {ReleaseDate:yyyy-MM-dd}";
    }
}
