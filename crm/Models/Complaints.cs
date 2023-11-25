using Microsoft.Build.Evaluation;

namespace crm.Models
{
    public class Complaints
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Complaints()
        {}
    }
}
