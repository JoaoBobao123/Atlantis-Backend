﻿namespace Atlantis_Backend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsRented { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
    }
}
