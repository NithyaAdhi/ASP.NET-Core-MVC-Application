using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //one to one
        public int? ItemId { get; set; }
       
        [ForeignKey("ItemId")]
        public Item? item { get; set; }
    }
}
