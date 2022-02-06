using System.ComponentModel.DataAnnotations;

namespace Home.Models
{

     public class Cadastro
     {
          [Key]
          [Required]
          public int Id {get;set;}

          [Required]
          public string Nome {get;set;} 
          
          [Required] 
          public int Cpf {get;set;} 
     }
}