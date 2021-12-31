using System;

namespace PokedexCRUD
{
    class PokedexCRUD
    {
        static PokemonsRepositorio repositorio = new PokemonsRepositorio();
        public static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarPokemons();
                        break;
                    case "2":
                        InserirPokemon();
                        break;
                    case "3":
                        AtualizarPokemon();
                        break;
                    case "4":
                        ExcluirPokemon();
                        break;
                    case "5":
                        VisualizarPokemon();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
            }
        }

        private static void VisualizarPokemon()
        {
            System.Console.WriteLine("Digite o ID do Pokemon: ");
            int indicePokemon = int.Parse(Console.ReadLine());

            var pokemon = repositorio.RetornaPorId(indicePokemon);

            System.Console.WriteLine(pokemon);
        }

        private static void ExcluirPokemon()
        {
            System.Console.WriteLine("Digite o ID do Pokemon: ");
            int indicePokemon = int.Parse(Console.ReadLine());

            repositorio.Excluir(indicePokemon);
        }

        private static void AtualizarPokemon()
        {
            System.Console.WriteLine("Digite o ID do Pokemon");
            int indicePokemon = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo), i));
            }

            System.Console.WriteLine("Digite o Tipo Entre as Opções Acima: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Novo Nome do Pokemon: ");
            string entradaNome = Console.ReadLine();

            System.Console.WriteLine("Digite o Novo Tamanho do Pokemon: ");
            string entradaTamanho = Console.ReadLine();

            System.Console.WriteLine("Digite a Nova Descrição do Pokemon: ");
            string entradaDescricao = Console.ReadLine();

            Pokemons updatePokemon = new Pokemons(id: indicePokemon,
                                                tipo: (Tipo)entradaTipo,
                                                nome: entradaNome,
                                                tamanho: entradaTamanho,
                                                descricao: entradaDescricao);
            
            repositorio.Atualizar(indicePokemon, updatePokemon);
        }

        private static void InserirPokemon()
        {
            System.Console.WriteLine("Inserir Novo Pokemon");

            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo), i));
            }

            System.Console.WriteLine("Digite o Tipo Entre as Opções Acima: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Nome do Pokemon: ");
            string entradaNome = Console.ReadLine();

            System.Console.WriteLine("Digite o Tamanho do Pokemon: ");
            string entradaTamanho = Console.ReadLine();

            System.Console.WriteLine("Digite a Descrição do Pokemon: ");
            string entradaDescricao = Console.ReadLine();

            Pokemons newPokemon = new Pokemons(id: repositorio.ProximoId(),
                                                tipo: (Tipo)entradaTipo,
                                                nome: entradaNome,
                                                tamanho: entradaTamanho,
                                                descricao: entradaDescricao);
            
            repositorio.Inserir(newPokemon);
        }

        private static void ListarPokemons()
        {
            System.Console.WriteLine("Listar Pokemons");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum Pokemon Cadastrado!");
            }
            
            foreach (var item in lista)
            {
                var excluido = item.RetornaExcluidoId();

                System.Console.WriteLine("#ID {0}: - {1} - {2}", item.RetornaId(),
                                         item.RetornaNome(),
                                        (excluido ? "*Excluido*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("PokedexCRUD a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine();

            System.Console.WriteLine("[1]- Listar Pokemons");
            System.Console.WriteLine("[2]- Inserir Novo Pokemon");
            System.Console.WriteLine("[3]- Atualizar Pokemon");
            System.Console.WriteLine("[4]- Excluir Pokemon");
            System.Console.WriteLine("[5]- Visualizar Pokemon");
            System.Console.WriteLine("[C]- Limpar Tela");
            System.Console.WriteLine("[X]- Sair");
            System.Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}