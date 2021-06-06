using System;

namespace SerializeObjects
{
    [Serializable]
    public class Categoria
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }

        public Categoria() { }

        public Categoria(long Codigo, string Descricao)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
