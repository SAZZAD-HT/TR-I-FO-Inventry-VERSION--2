using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TR_I_FO___Inventry_VERSION__2.Models.Databases
{
    [Table("User")]
    public class USER
    {
        [Key]
        public int User_id { get; set; }    
        public string User_name { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Approval { get; set; }        
        
    }
}
