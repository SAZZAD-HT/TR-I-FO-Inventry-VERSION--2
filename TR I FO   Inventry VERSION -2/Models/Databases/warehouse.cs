using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TR_I_FO___Inventry_VERSION__2.Models.Databases
{
    [Table("WareHouse")]
    public class warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Ware_prd_id { get; set; }

        public string Product_name { get; set; }

        public string country { get; set; }




        public String Description { get; set; }
        public Double Buy_Price { get; set; }
        

        public string Picture { get; set; }
        public DateTime Buy_date { get; set; }
        public string Quantity { get; set; }

        public string stock { get; set; }
    }
}
