using Learn2MVC.Models;

namespace Learn2MVC.Entity
{
    public class FolderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Folder> Children { get; set; } = new List<Folder>();
    }
}
