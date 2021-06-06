using System;

namespace SerializeObjects
{
    [Serializable]
    public class Marca
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }

        public Marca() { }

        public Marca(long Codigo, string Descricao)
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
