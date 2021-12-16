using HouseDesignsEcommerce.Data.Entities;
using System.Collections.Generic;

namespace HouseDesignsEcommerce.Data
{
    public interface IApplicationRepository
    {

        IEnumerable<HouseDesign> GetAllHouseDesigns();
        IEnumerable<HouseDesign> GetHouseDesignsByProjectName(string projectName);
        bool SaveAll();
        IEnumerable<Category> GetAllCategories();
    }
}