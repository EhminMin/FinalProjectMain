using FinalProject.GUI.Models;

namespace FinalProject.GUI.Interfaces
{
    public interface ISaveLoad
    {
        void Save(string filePath, List<FurnitureSet> data);
        List<FurnitureSet> Load(string filePath);
    }
}
