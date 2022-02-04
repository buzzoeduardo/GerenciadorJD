namespace GerenciadorSJD.Models.ViewModel
{
    public class ModeloPolicial
    {
        public Policia Policiais { get; set; }
        public ICollection<Processo> Processos { get; set; }
    }
}
