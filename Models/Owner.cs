namespace DogGo.Models
{
    public class Owner
        // this is a model for the owners in our sql database
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NeighborhoodId { get; set; }
        public string Phone { get; set; }
    }
}
