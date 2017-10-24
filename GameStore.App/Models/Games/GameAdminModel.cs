namespace GameStore.App.Models.Games
{
    using Infrastructure.Validation;
    using Infrastructure.Validation.Games;
    using SimpleMvc.Framework.Attributes.Validation;
    using System;

    public class GameAdminModel
    {
        [Required]
        [Title]
        public string Title { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }
        
        [ThumbnailUrl]
        public string ThumbnailUrl { get; set; }

        [NumberRange(0, double.MaxValue)]
        public decimal Price { get; set; }

        [NumberRange(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [VideoId]
        public string VideoId { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
