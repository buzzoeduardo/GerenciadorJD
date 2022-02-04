using System.ComponentModel.DataAnnotations;

namespace GerenciadorSJD.Models.Enums
{
    public enum PostGrad : int
    {
        [Display(Name = "Cel PM")]
        Cel = 0,

        [Display(Name = "Ten Cel PM")]
        Ten_Cel = 1,

        [Display(Name = "Maj PM")]
        Maj = 2,

        [Display(Name = "Cap PM")]
        Cap = 3,

        [Display(Name = "1º Ten PM")]
        PrimTen = 4,

        [Display(Name = "2º Ten PM")]
        SegTen = 5,

        [Display(Name = "Subtem PM")]
        Subten = 6,

        [Display(Name = "1º Sgt PM")]
        PrimSgt = 7,

        [Display(Name = "2º Sgt PM")]
        SegSgt = 8,

        [Display(Name = "3º Sgt PM")]
        TercSgt = 9,

        [Display(Name = "Cb PM")]
        Cb = 10,

        [Display(Name = "Sd 1ª Cl PM")]
        Sd = 11,

        [Display(Name = "Sd 2ª Cl PM")]
        Sd_Seg_Cl = 12
    }
}
