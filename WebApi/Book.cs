using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Title { get; set; } // kitap başlığı
        public int GenreId { get; set; }   // tür ıd 'si tutuyoruz
        public int PageCount { get; set; } // sayfa sayısı
        public DateTime PublishDate { get; set; } // yayınlanma tarihi

    }
}