namespace GameStore.App.Models.Games
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class GameListingAdminModel : IMapFrom<Game>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public void Configure(IMapperConfigurationExpression config)
        {
            config
                .CreateMap<Game, GameListingAdminModel>()
                .ForMember(gla => gla.Name, cfg => cfg.MapFrom(g => g.Title));
        }
    }
}
