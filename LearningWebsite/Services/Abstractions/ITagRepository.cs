using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetMatchesTo(string nameToMatch);
    }
}