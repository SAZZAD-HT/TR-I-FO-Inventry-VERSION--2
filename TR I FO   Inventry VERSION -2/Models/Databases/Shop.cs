using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TR_I_FO___Inventry_VERSION__2.Models.Databases
{
    [Table("Shop")]
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Shop_prd_id { get; set; }

        public string sProduct_name { get; set; }

        public string country { get; set; }




        public String sDescription { get; set; }
        public Double Buy_Price { get; set; }
        public Double Sell_Price { get; set; }
        public double profit { get; set; }  

        public string sPicture { get; set; }
        public DateTime sell_date { get; set; }
        public string Quantity { get; set; }
        public String Customer_name { get; set; }
        public string CustomerEmail { get; set; }
        public string Customer_mobiler { get; set; }
        public string stock { get; set; }
    }
}
