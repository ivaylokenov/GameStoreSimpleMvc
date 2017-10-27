namespace GameStore.App.Models.Orders
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class GameListingOrdersModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string VideoId { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Description { get; set; }
    }
}
