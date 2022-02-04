using GerenciadorSJD.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models
{
    public class Processo
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "O {0} deve ter conter no mínimo {2} dígitos.")]
        [Required(ErrorMessage = "Nome da OPM Obrigatória.")]
        [Display(Name = "OPM")]
        public string Opm { get; set; }

        [Required(ErrorMessage = "Número Obrigatório")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Cídigo da OPM Obrigatório")]
        [Display(Name = "Código da OPM")]
        public string Prefixo { get; set; }

        [Display(Name = "Data da Instauração")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        public Origem Origem { get; set; }

        public string Historico { get; set; }

        public ICollection<Policia> Policia { get; set; } = new List<Policia>();

        public int PoliciaId { get; set; }
        
        public Desfecho Desfecho { get; set; }

        public string Obs { get; set; }

        //Construtor sem argumentos
        public Processo()
        {
        }

        //Construtor com argumentos
        public Processo(int id, string opm, int numero, string prefixo, DateTime data, Origem origem, string historico, Desfecho desfecho, string obs)
        {
            Id = id;
            Opm = opm;
            Numero = numero;
            Prefixo = prefixo;
            Data = data;
            Origem = origem;
            Historico = historico;            
            Desfecho = desfecho;
            Obs = obs;
        }
    }
}
