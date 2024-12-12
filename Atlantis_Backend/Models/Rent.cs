namespace Atlantis_Backend.Models
{
    public class Rent
    {
        public int Id { get; set; } 
        public string Name { get; set; }= string.Empty;
        public string DataNascimento { get; set; } = string.Empty;
        public int livroId { get; set; }   

        public DateTime emprestado_at {  get; set; }
        public DateTime? devolvido_em { get; set; }
    }
}
