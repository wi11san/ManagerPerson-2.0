namespace ManagerPersonAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Office { get; set; }
        public double Salary { get; set; }
        public bool Active { get; set; }
    }
}
