using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationUsingRazorPages.Entity
{
    public class Customer
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public string Property_ID { get; set; }

        [Required]
        public string Property_Name { get; set; }

        [Required]
        public string GM_Name { get; set; }

        [Required]
        public string Street_Address { get; set; }

        [Required]
        public string City_Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Zipcode { get; set; }
    }
}
