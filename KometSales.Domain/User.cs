namespace KometSales.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public UserRol UserRol { get; set; }
        public bool Active { get; set; }
    }
}
