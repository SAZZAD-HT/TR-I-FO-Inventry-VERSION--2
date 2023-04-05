using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TR_I_FO___Inventry_VERSION__2.Models.Databases
{
    [Table("ImportItems")]
    public class ImportList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Import { get; set; }

        public string sProduct_name { get; set; }

        public string country { get; set; }




        public String sDescription { get; set; }




        public string d_Quantity { get; set; }
        public string cust_quantity { get; set; }
       
    }
}
