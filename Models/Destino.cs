using System.ComponentModel.DataAnnotations;

namespace Home.Models
{
    public class Destino
    {
        [Key]
        [Required]
        public int Id {get;set;}
     
        [Required]
        public string Local {get;set;}
    }
}