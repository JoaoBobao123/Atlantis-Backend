using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Dom Casmurro", Author = "Machado de Assis", Year = 1899, Quantity = 2 },
            new Book { Id = 2, Title = "Memórias Póstumas de Brás Cubas", Author = "Machado de Assis", Year = 1881, Quantity = 3 },
            new Book { Id = 3, Title = "Grande Sertão: Veredas", Author = "João Guimarães Rosa", Year = 1956, Quantity = 4 },
            new Book { Id = 4, Title = "O Cortiço", Author = "Aluísio Azevedo", Year = 1890, Quantity = 4 },
            new Book { Id = 5, Title = "Iracema", Author = "José de Alencar", Year = 1865, Quantity = 1 },
            new Book { Id = 6, Title = "Macunaíma", Author = "Mário de Andrade", Year = 1928, Quantity = 11 },
            new Book { Id = 7, Title = "Capitães da Areia", Author = "Jorge Amado", Year = 1937, Quantity = 2 },
            new Book { Id = 8, Title = "Vidas Secas", Author = "Graciliano Ramos", Year = 1938, Quantity = 9 },
            new Book { Id = 9, Title = "A Moreninha", Author = "Joaquim Manuel de Macedo", Year = 1844, Quantity = 2 },
            new Book { Id = 10, Title = "O Tempo e o Vento", Author = "Erico Verissimo", Year = 1949, Quantity = 1 },
            new Book { Id = 11, Title = "A Hora da Estrela", Author = "Clarice Lispector", Year = 1977, Quantity = 1 },
            new Book { Id = 12, Title = "O Quinze", Author = "Rachel de Queiroz", Year = 1930, Quantity = 1 },
            new Book { Id = 13, Title = "Menino do Engenho", Author = "José Lins do Rego", Year = 1932, Quantity = 5 },
            new Book { Id = 14, Title = "Sagarana", Author = "João Guimarães Rosa", Year = 1946, Quantity = 3 },
            new Book { Id = 15, Title = "Fogo Morto", Author = "José Lins do Rego", Year = 1943, Quantity = 1 }
        };

        [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(books.Where(book => book.Quantity > 0));
        }
        [HttpGet("{id}")]
        public ActionResult GetBookById(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound(new{Message = "Livro não encontrado."});
            return Ok(book);
        }



        [HttpPost("{id}/rent")]
        public ActionResult RentBook(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound(new{ Message = "Livro não encontrado." });
                Console.WriteLine("Restam" + book);

            if (book.Quantity <= 0)
                return BadRequest(new{ Message = "Livro esgotado no momento." });

            book.Quantity--;
            return Ok(new{ Message = "Livro alugado com sucesso!" });
        }
    }
}

