namespace crm.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public Orders(){}
    }
}
