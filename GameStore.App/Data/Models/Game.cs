namespace GameStore.App.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        // In GB
        [Range(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string VideoId { get; set; }
        
        public string ThumbnailUrl { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
