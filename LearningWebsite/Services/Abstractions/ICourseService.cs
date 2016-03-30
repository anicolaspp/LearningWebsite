﻿using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseService
    {
        IEnumerable<Course> GetMatcherFor(string searchTerm);

        Course GetBy(int id);
    }
}