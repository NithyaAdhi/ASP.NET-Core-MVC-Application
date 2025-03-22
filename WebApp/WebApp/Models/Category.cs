namespace WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //one to many
        public List<Item>? Items { get; set;}


    }
}
