using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWebAPI.Models
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Customer_id")]
        public int CustomerId { get; set; }

        [Column("Customer_name")]
        public string CustomerName { get; set; }

        [Column("Customer_mobile_no")]
        public string MobileNumber   { get; set; }

        [Column("Customer_email")]
        public string EmailAddress { get; set; }
    }
}
