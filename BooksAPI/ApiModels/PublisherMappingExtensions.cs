using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.ApiModels
{
    public static class PublisherMappingExtensions
    {
        public static PublisherModel ToApiModel(this Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                FoundedYear = publisher.FoundedYear,
                CountryOfOrigin = publisher.CountryOfOrigin,
                HeadQuartersLocation = publisher.HeadQuartersLocation,
            };
        }

        public static Publisher ToDomainModel(this PublisherModel publisherModel)
        {
            return new Publisher
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,
                FoundedYear = publisherModel.FoundedYear,
                CountryOfOrigin = publisherModel.CountryOfOrigin,
                HeadQuartersLocation = publisherModel.HeadQuartersLocation,
            };
        }

        public static IEnumerable<PublisherModel> ToApiModels(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(p => p.ToApiModel());
        }

        public static IEnumerable<Publisher> ToDomainModels(this IEnumerable<PublisherModel> publisherModels)
        {
            return publisherModels.Select(p => p.ToDomainModel());
        }
    }
}
