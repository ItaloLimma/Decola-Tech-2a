namespace PokedexCRUD
{
    public class Pokemons : EntidadeBase
    {
        //Atributos
        private Tipo Tipo { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private string Tamanho { get; set; }

        private bool Excluido { get; set; }

        //Metodos
        public Pokemons(int id, Tipo tipo, string nome, string descricao, string tamanho)
        {
            this.Tipo = tipo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Tamanho = tamanho;
            this.Excluido = false;
        }

        //Sobrescrevendo o ToString para retornar uma saída formatada
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Tamanho: "  + this.Tamanho + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public string RetornaNome()
        {
            return this.Nome;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool RetornaExcluidoId()
        {
            return this.Excluido;
        }
    }
}