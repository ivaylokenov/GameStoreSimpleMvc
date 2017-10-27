namespace GameStore.App.Services.Contracts
{
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public interface IGameService
    {
        void Create(
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        void Update(
            int id, 
            string title, 
            string description, 
            string thumbnailUrl, 
            decimal price, 
            double size, 
            string videoId, 
            DateTime releaseDate);

        void Delete(int id);

        Game GetById(int id);

        bool Exists(int id);

        IEnumerable<TModel> ByIds<TModel>(IEnumerable<int> ids);

        IEnumerable<TModel> All<TModel>(int? userId = null);
    }
}
