namespace KometSales.Domain
{
    public class UserRol: BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
