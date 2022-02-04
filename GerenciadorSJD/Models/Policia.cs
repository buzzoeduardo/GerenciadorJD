using GerenciadorSJD.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models
{
    public class Policia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione uma opção válida")]
        [Display(Name = "POST/GRAD")]
        public PostGrad PostGrad { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Somente números são permitidos.")]
        [Required(ErrorMessage = "RE Obrigatório.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O {0} deve ter conter {1} dígitos.")]
        [Display(Name = "RE")]
        public string Re { get; set; }

        [Required(ErrorMessage = "Dígito Obrigatório.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Dígito Obrigatório")]
        [Display(Name = "DIG")]
        public string Digito { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve conter no mínimo {2} dígitos.")]
        [Required(ErrorMessage = "Nome Obrigatório.")]
        [Display(Name = "NOME")]
        public string Nome { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "O Nome de Guerra deve conter no mínimo {2} dígitos.")]
        [Required(ErrorMessage = "Nome de Guerra Obrigatório.")]
        [Display(Name = "NOME DE GUERRA")]
        public string NomeGuerra { get; set; }

        [EmailAddress(ErrorMessage = "Deve ser um e-mail válido.")]
        [Required(ErrorMessage = "E-mail Obrigatório.")]
        [Display(Name = "E-MAIL")]
        public string Email { get; set; }

        public ICollection<Processo> Processo { get; set; }   = new List<Processo>();    
        public int ProcessoId { get; set; }

        [Required(ErrorMessage = "Selecione uma opção válida")]
        [Display(Name = "STATUS")]
        public Status Status { get; set; }
        
        //Construtor sem argumentos
        public Policia() 
        {
        }

        //Construtor com argumentos
        public Policia(int id, PostGrad postGrad, string re, string digito, string nome, string nomeGuerra, string email, Status status)
        {
            Id = id;
            PostGrad = postGrad;
            Re = re;
            Digito = digito;
            Nome = nome;
            NomeGuerra = nomeGuerra;
            Email = email;            
            Status = status;
        }
    }
}
