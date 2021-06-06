using Newtonsoft.Json;
using SerializeObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudProduto
{
    public partial class Form1 : Form
    {
        private List<Produto> Produtos = new List<Produto>();
        private Produto Prod = null;
        private List<Marca> Marcas = new List<Marca>
        {
            new Marca(1, "Marca 01"),
            new Marca(2, "Marca 02"),
            new Marca(3, "Marca 03")
        };
        private List<Categoria> Categorias = new List<Categoria>
        {
            new Categoria(1, "Categoria 01"),
            new Categoria(2, "Categoria 02"),
            new Categoria(3, "Categoria 03")
        };

        public Form1()
        {
            InitializeComponent();
            cmbMarca.Items.AddRange(Marcas.ToArray());
            cmbCategoria.Items.AddRange(Categorias.ToArray());

            if (File.Exists("Produtos.json"))
                AtualizarLista();
        }

        private void Salvar()
        {
            bool Editando = false;
            if (Prod == null)
            {
                Prod = new Produto();
                Prod.Codigo = Convert.ToInt64(txtCodigo.Text);
            }
            else
                Editando = true;

            Prod.Descricao = txtDescricao.Text;
            Prod.Preco = Convert.ToDecimal(txtPreco.Text);
            Prod.Categoria = cmbCategoria.SelectedItem as Categoria;
            Prod.Marca = cmbMarca.SelectedItem as Marca;
            Prod.DataVencimento = txtDataVencimento.Value;
            Prod.DataFabricacao = txtDataFabricacao.Value;
            Prod.Lote = txtLote.Text;

            if (Editando)
                Produtos[Produtos.IndexOf(Prod)] = Prod;
            else
                Produtos.Add(Prod);

            File.WriteAllText("Produtos.json",
                JsonConvert.SerializeObject(Produtos, Formatting.Indented));

            LimparTela();
            AtualizarLista();
        }

        private void LimparTela()
        {
            Prod = null;

            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            cmbCategoria.SelectedItem = null;
            cmbMarca.SelectedItem = null;
            txtDataVencimento.Value = DateTime.Now;
            txtDataFabricacao.Value = DateTime.Now;
            txtLote.Text = "";
        }

        private void AtualizarLista()
        {
            Produtos = JsonConvert
                    .DeserializeObject<Produto[]>(File.ReadAllText("Produtos.json")).ToList();

            lbProdutos.Items.Clear();
            lbProdutos.Items.AddRange(Produtos.ToArray());
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Prod = lbProdutos.SelectedItem as Produto;
            txtCodigo.Text = Prod.Codigo.ToString();
            txtDescricao.Text = Prod.Descricao;
            txtPreco.Text = Prod.Preco.ToString();
            cmbCategoria.SelectedItem = Categorias
                .Where(o => o.Codigo == Prod.Categoria.Codigo)
                .FirstOrDefault();
            cmbMarca.SelectedItem = Marcas
                .Where(o => o.Codigo == Prod.Marca.Codigo)
                .FirstOrDefault();
            txtDataVencimento.Value = Prod.DataVencimento;
            txtDataFabricacao.Value = Prod.DataFabricacao;
            txtLote.Text = Prod.Lote;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Produtos.Remove(lbProdutos.SelectedItem as Produto);
            File.WriteAllText("Produtos.json",
                JsonConvert.SerializeObject(Produtos, Formatting.Indented));

            AtualizarLista();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
