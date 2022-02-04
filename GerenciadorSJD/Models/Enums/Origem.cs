using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models.Enums
{
    public enum Origem : int
    {
        [Display(Name = "CORREG PM")]
        Corregedoria = 0,
        [Display(Name = "CPI-4")]
        Cpi = 1,
        [Display(Name = "FÓRUM")]
        Forum = 2,
        [Display(Name = "RECLAMAÇÃO - BTL")]
        Btl = 3,
        [Display(Name = "COMANDANTE OPM")]
        Cmt = 4,
        [Display(Name = "PPJM")]
        Ppjm = 5,        
        [Display(Name = "COMANDANTE CIA")]
        CmtCia = 6
    }
}
