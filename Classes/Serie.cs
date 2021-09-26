using System;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero _genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.genero = _genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {this.genero}{Environment.NewLine}";
            retorno += $"Titulo: {this.Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao}{Environment.NewLine}";
            retorno += $"Ano de Inicio: {this.Ano}";
            return retorno;
        }

        public string retornTitulo(){
            return this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public Genero retornaGenero()
        {
           return genero;
        }

        public string retornaDescricao()
        {
            return this.Descricao;
        }

        public int retornaAno()
        {
            return this.Ano;
        }
        
    }


}