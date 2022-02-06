using System.ComponentModel.DataAnnotations;

namespace Home.Models
{
    public class Passagem
    {
    
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public float Preco { get; set; }
        
        [Required]
        public int CadastroId {get; set;}
        public Cadastro Cadastro {get; set;}

        [Required]
        public int DestinoId {get;set;}
        public Destino Destino {get; set;}
    }
}