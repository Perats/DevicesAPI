namespace Domain.Models
{
    public class UserDomain
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DeviceDomain Device { get; set; }
    }
}
