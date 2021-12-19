﻿using HouseDesignsEcommerce.Data.Entities;
using System.Collections.Generic;

namespace HouseDesignsEcommerce.Data
{
    public interface IApplicationRepository
    {

        IEnumerable<HouseDesign> GetAllHouseDesigns();
        IEnumerable<HouseDesign> GetHouseDesignsByProjectName(string projectName);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        bool SaveAll();
    }
}