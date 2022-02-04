namespace GerenciadorSJD.Models
{
    public class Numerador
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set;}

        //Construtor sem argumentos
        public Numerador()
        {
        }

        //Construtor com argumentos
        public Numerador(int id, int numero, string descricao)
        {
            Id = id;
            Numero = numero;
            Descricao = descricao;
        }
    }
}
