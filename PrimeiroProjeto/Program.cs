using System;
using System.Collections.Generic;

public class Produto {
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }

    public Produto(string nome, double preco, string autor, string genero) {
        Nome = nome;
        Preco = preco;
        Quantidade = 0; 
        Autor = autor;
        Genero = genero;
    }

    public override string ToString() {
        return $"{Nome} ({Preco:C}) – {Quantidade} no estoque";
    }
}

public class Estoque {
    private List<Produto> produtos;

    public Estoque() {
        produtos = new List<Produto>();
    }

    
    public void AdicionarProduto(string nome, double preco, string autor, string genero) {
        Produto produto = new Produto(nome, preco, autor, genero);
        produtos.Add(produto);
        Console.WriteLine("Livro adicionado!");
    }

    
    public void ListarProdutos() {
        if (produtos.Count == 0) {
            Console.WriteLine("Não há produtos no estoque.");
            return;
        }

        int i = 1;
        foreach (Produto produto in produtos) {
            Console.WriteLine($"{i++}. {produto}");
        }
    }

    // Método para remover um produto pelo índice
    public void RemoverProduto(int indice) {
        if (indice < 1 || indice > produtos.Count) {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        produtos.RemoveAt(indice - 1); 
        Console.WriteLine("Produto removido com sucesso.");
    }

    // Método para entrada de estoque (adicionar quantidade)
    public void EntradaEstoque(int indice, int quantidade) {
        if (indice < 1 || indice > produtos.Count) {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Produto produto = produtos[indice - 1];
        produto.Quantidade += quantidade;
        Console.WriteLine($"Entrada de {quantidade} unidades no livro {produto.Nome}.");
    }

    // Método para saída de estoque (remover quantidade)
    public void SaidaEstoque(int indice, int quantidade) {
        if (indice < 1 || indice > produtos.Count) {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Produto produto = produtos[indice - 1];
        if (produto.Quantidade >= quantidade) {
            produto.Quantidade -= quantidade;
            Console.WriteLine($"Saída de {quantidade} unidades do livro {produto.Nome}.");
        }
        else {
            Console.WriteLine("Quantidade em estoque insuficiente.");
        }
    }
}

class Program {
    static void Main(string[] args) {
        Estoque estoque = new Estoque();
        int opcao;

        do {
            
            Console.WriteLine("\nControle de Estoque - Livraria");
            Console.WriteLine("[1] Novo");
            Console.WriteLine("[2] Listar Produtos");
            Console.WriteLine("[3] Remover Produtos");
            Console.WriteLine("[4] Entrada Estoque");
            Console.WriteLine("[5] Saída Estoque");
            Console.WriteLine("[0] Sair");
            Console.Write("Escolha uma opção: ");

            
            if (!int.TryParse(Console.ReadLine(), out opcao)) {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao) {
                case 1:
                    // Adicionar novo produto
                    Console.Write("Informe o nome do livro: ");
                    string nome = Console.ReadLine();
                    Console.Write("Informe o preço: ");
                    double preco;
                    while (!double.TryParse(Console.ReadLine(), out preco) || preco <= 0) {
                        Console.Write("Preço inválido. Digite novamente: ");
                    }
                    Console.Write("Informe o autor(a): ");
                    string autor = Console.ReadLine();
                    Console.Write("Informe o gênero: ");
                    string genero = Console.ReadLine();

                    estoque.AdicionarProduto(nome, preco, autor, genero);
                    break;

                case 2:
                    // Listar produtos
                    estoque.ListarProdutos();
                    break;

                case 3:
                    // Remover produto
                    Console.Write("Informe a posição do livro a ser removido: ");
                    int posicaoRemover;
                    while (!int.TryParse(Console.ReadLine(), out posicaoRemover)) {
                        Console.Write("Posição inválida. Digite novamente: ");
                    }
                    estoque.RemoverProduto(posicaoRemover);
                    break;

                case 4:
                    // Entrada de estoque
                    Console.Write("Informe a posição do livro: ");
                    int posicaoEntrada;
                    while (!int.TryParse(Console.ReadLine(), out posicaoEntrada)) {
                        Console.Write("Posição inválida. Digite novamente: ");
                    }
                    Console.Write("Informe a quantidade de entrada: ");
                    int quantidadeEntrada;
                    while (!int.TryParse(Console.ReadLine(), out quantidadeEntrada) || quantidadeEntrada <= 0) {
                        Console.Write("Quantidade inválida. Digite novamente: ");
                    }
                    estoque.EntradaEstoque(posicaoEntrada, quantidadeEntrada);
                    break;

                case 5:
                    // Saída de estoque
                    Console.Write("Informe a posição do livro: ");
                    int posicaoSaida;
                    while (!int.TryParse(Console.ReadLine(), out posicaoSaida)) {
                        Console.Write("Posição inválida. Digite novamente: ");
                    }
                    Console.Write("Informe a quantidade de saída: ");
                    int quantidadeSaida;
                    while (!int.TryParse(Console.ReadLine(), out quantidadeSaida) || quantidadeSaida <= 0) {
                        Console.Write("Quantidade inválida. Digite novamente: ");
                    }
                    estoque.SaidaEstoque(posicaoSaida, quantidadeSaida);
                    break;

                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }
}
