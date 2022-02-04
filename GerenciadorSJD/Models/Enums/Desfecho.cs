using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models.Enums
{
    public enum Desfecho : int
    {
        [Display(Name = "Aguardando Desfecho")]
        Aguardo = 0,

        [Display(Name = "Encaminhado ao TJM")]
        Tjm = 1,

        [Display(Name = "Encaminhado à PGE")]
        Pge = 2,

        [Display(Name = "Encaminhado ao CPI-4")]
        Cpi = 3,

        [Display(Name = "Encaminhado ao MP")]
        Mp = 4,

        [Display(Name = "Encaminhado a outra OPM")]
        OPMDiversa = 5,

        [Display(Name = "Manifestação Preliminar")]
        Manisfestacao = 6,

        [Display(Name = "Instaurado PD")]
        Pd = 7,

        [Display(Name = "Instaurado Processo Regular")]
        ProcRegular = 8,
        
        [Display(Name = "Arquivado")]
        Arquivo = 9
    }
}
