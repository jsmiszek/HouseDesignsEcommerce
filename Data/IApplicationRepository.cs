using HouseDesignsEcommerce.Data.Entities;
using System.Collections.Generic;

namespace HouseDesignsEcommerce.Data
{
    public interface IApplicationRepository
    {

        IEnumerable<HouseDesign> GetAllHouseDesigns();
        IEnumerable<HouseDesign> GetHouseDesignsByProjectName(string projectName);
        HouseDesign GetHouseDesignById(int id);
        IEnumerable<HouseDesign> GetHouseDesignsByUseableArea(double min, double max);
        IEnumerable<HouseDesign> GetHouseDesignsByPlotDimensions(double width, double length);
        IEnumerable<HouseDesign> GetHouseDesignsByRoofAngle(double min, double max);
        IEnumerable<HouseDesign> GetHouseDesignsByPrice(double min, double max);
        IEnumerable<HouseDesign> GetHouseDesignsByNumberOfRooms(int min, int max);
        IEnumerable<HouseDesign> GetHouseDesignsByNumberOfBathrooms(int min, int max);
        IEnumerable<HouseDesign> GetHouseDesignsByNumberOfGaragePositions(int min, int max);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string catName);
        
        bool SaveAll();
        void AddEntity(object model);
        
    }
}