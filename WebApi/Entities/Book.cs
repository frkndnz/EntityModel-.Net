using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Title { get; set; } // kitap başlığı
        public int PageCount { get; set; } // sayfa sayısı
        public DateTime PublishDate { get; set; } // yayınlanma tarihi
        public Genre Genre {get;set;}
        public int GenreId { get; set; }   // tür ıd 'si tutuyoruz
        public Author Author{get;set;}
        public int AuthorId{get;set;}
        
    }
}