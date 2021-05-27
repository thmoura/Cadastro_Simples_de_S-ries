using System;

namespace Dio.Series
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
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                         throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        
        }

        

        private static void ListarSeries()
        {
            Console.WriteLine("LIstar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }
            foreach (var serie in lista)
            { 
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void InserirSeries()
        {
            Console.WriteLine("Inserir Séries");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Género Entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);                            

        }

         private static void AtualizarSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gémero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao );

            repositorio.Atualisa(indiceSerie, atualizaSerie);                                 
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Séries");
            Console.WriteLine("Informe a opção desejada:");
           
            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Séries");
            Console.WriteLine("3- Atualizar Séries");
            Console.WriteLine("4- Excluir Séries");
            Console.WriteLine("5- Visualizar Séries");
            Console.WriteLine("C- Limpar");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
