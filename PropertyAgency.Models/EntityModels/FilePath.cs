using System.ComponentModel.DataAnnotations;

namespace PropertyAgency.Models.EntityModels
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        //public FileType FileType { get; set; }
        //public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
