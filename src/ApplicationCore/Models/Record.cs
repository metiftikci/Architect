using System.ComponentModel.DataAnnotations;

namespace Architect.ApplicationCore.Models
{
    public class Record : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public Record()
        {
            Description = string.Empty;
        }
    }
}
