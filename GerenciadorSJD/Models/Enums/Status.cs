using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models.Enums
{
    public enum Status : int
    {
        [Display(Name = "Não Definido")]
        NaoDefinido = 0,

        Encarregado = 1,

        Presidente = 2,

        Investigado = 3,

        Sindicado = 4,

        Acusado = 5,

        Envolvido = 6,

        Testemunha = 7,

        Indiciado = 8
    }
}
