using System;
using System.Collections.Generic;

namespace SerializeObjects
{
    [Serializable]
    public class Produto
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Lote { get; set; }

        public Produto() { }

        public override string ToString()
        {
            return $"{Codigo} - {Descricao}";
        }
    }
}