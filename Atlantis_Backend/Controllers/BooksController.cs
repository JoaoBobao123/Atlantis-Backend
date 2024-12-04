using Atlantis_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atlantis_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> Books = new List<Book>
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

        // Retorna todos os livros disponíveis
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllAvailableBooks()
        {
            var availableBooks = Books.Where(b => b.Quantity > 0).ToList();
            return Ok(availableBooks);
        }

        // Retorna um livro específico pelo ID
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null || book.Quantity == 0)
            {
                return NotFound(new { Message = "Livro não disponível no momento!" });
            }
            return Ok(book);
        }

        // Aluga um livro (reduz a quantidade disponível)
        [HttpPut("{id}/rent")]
        public ActionResult RentBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { Message = "Livro não encontrado!" });
            }

            if (book.Quantity == 0)
            {
                return BadRequest(new { Message = $"O livro '{book.Title}' está esgotado no momento!" });
            }

            // Reduz a quantidade disponível
            book.Quantity--;
            return Ok(new { Message = $"Você alugou o livro '{book.Title}'.", RemainingQuantity = book.Quantity });
        }

        // Desaluga um livro (aumenta a quantidade disponível)
        [HttpPut("{id}/return")]
        public ActionResult ReturnBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { Message = "Livro não encontrado!" });
            }

            // Aumenta a quantidade disponível
            book.Quantity++;
            return Ok(new { Message = $"Você devolveu o livro '{book.Title}'.", UpdatedQuantity = book.Quantity });
        }
    }
}
