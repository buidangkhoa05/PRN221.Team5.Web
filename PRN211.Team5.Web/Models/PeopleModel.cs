namespace PRN211.Team5.Web.Models
{
    public class PeopleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = "John Doe";
        public int Age { get; set; } = 18;
    }
}
