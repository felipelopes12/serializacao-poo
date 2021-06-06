using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto Prod = new Produto
            {
                Codigo = 1,
                Descricao = "BOLACHA RECHEADA",
                DataFabricacao = DateTime.Now.AddDays(-5),
                DataVencimento = DateTime.Now.AddDays(30),
                Lote = "FAT1011",
                Preco = 2,
                Categoria = new Categoria
                {
                    Codigo = 1,
                    Descricao = "BOLACHA"
                },
                Marca = new Marca
                {
                    Codigo = 1,
                    Descricao = "NESTLE"
                }
            };

            Salvar(Prod);
            LoadProduto();
        }

        private static void LoadProduto()
        {
            Produto Prod = JsonConvert
                    .DeserializeObject<Produto>(File.ReadAllText("Produto.json"));

            Prod.Codigo = 2;
            Prod.Descricao = "WAFER RECHEADO";

            Stream st = new FileStream("Produto.bin", 
                FileMode.Open, FileAccess.Read, FileShare.Read);
            Prod = new BinaryFormatter().Deserialize(st) as Produto;
            st.Close();

            Prod.Descricao = "Arquivo binário alterado";
            Prod.Marca.Descricao = "Marca Binária";

            Salvar(Prod);
        }

        private static void Salvar(Produto Prod)
        {
            string JsonProduto = JsonConvert
                .SerializeObject(Prod, Formatting.Indented);

            // Serialicação de um objeto json (string)
            File.WriteAllText("Produto.json", JsonProduto);

            // Serialização de um objeto em array de byte[]
            Stream st = new FileStream("Produto.bin",
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);
            new BinaryFormatter().Serialize(st, Prod);
            st.Close();
        }
    }
}
