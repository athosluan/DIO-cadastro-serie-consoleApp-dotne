using System.Threading;
using System.Runtime.CompilerServices;
using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirAtualizarSerie("inserir");
                        break;
                    case "3":
                        InserirAtualizarSerie("atualizar");
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarPorGenero();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Digite uma das opções acima.");
                        Console.ReadKey();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Até breve. Obrigado.");
            Thread.Sleep(1000);
        }

        private static void ListarPorGenero()
        {
            Console.WriteLine("Listar por Gêneros.");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            int idGenero = int.Parse(Console.ReadLine());

            var lista = repositorio.Lista();
            foreach (var item in lista)
            {
                if(Enum.GetName(item.retornaGenero()) == Enum.GetName(typeof(Genero),idGenero))
                {
                    Console.WriteLine($"# {item.retornaId()} - {item.retornTitulo()} - {item.retornaGenero().ToString()}");
                }
            }
            Console.ReadKey();

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite a ID da série que deseja excluir: ");
            int _id = int.Parse(Console.ReadLine());
            var s = repositorio.RetornaPorId(_id);
            repositorio.Exclui(_id);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.ReadKey();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries.");
            var serie = repositorio.Lista();
            if (serie.Count == 0)
            {
                Console.WriteLine("Não há séries cadastradas.");
                Console.ReadKey();
                return;
            }

            foreach (var s in serie)
            {
                Console.WriteLine($"# {s.Id} - {s.retornTitulo()}");
            }
            Console.ReadKey();
        }

        private static void InserirAtualizarSerie(string Opcao)
        {
            int _id = -1;

            if (Opcao.ToUpper() == "INSERIR")
            {
                Console.WriteLine("Inserir nova Série.");
            }
            else
            {
                Console.WriteLine("Atualizar uma série.");
                Console.WriteLine();
                Console.Write("Qual a ID da série? ");
                _id = int.Parse(Console.ReadLine());
            }

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Com base nos Gêneros acima digite o número da opção:");
            int entGenero = int.Parse(Console.ReadLine());

            Console.Write("Titulo da Série:");
            string entTitulo = Console.ReadLine();

            Console.Write("O Ano da Série: ");
            int entAno = int.Parse(Console.ReadLine());

            Console.Write("Uma Descrição da Série: ");
            string entDesc = Console.ReadLine();

            if (Opcao.ToUpper() == "INSERIR")
            {
                repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)entGenero, entTitulo, entDesc, entAno));
                Console.WriteLine();
                Console.WriteLine("Série inserida com sucesso!");
            }
            else
            {
                repositorio.Atualiza(_id, new Serie(_id, (Genero)entGenero, entTitulo, entDesc, entAno));
                Console.WriteLine();
                Console.WriteLine("Atualizada com sucesso!");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Listar séries por Gênero");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            Console.Write("Opção: ");
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            opcao = string.IsNullOrEmpty(opcao) ? "0" : opcao;
            return opcao;
        }
    }


}
