using System;

namespace DIO_Series
{   
    class Program
    {
         static SerieRepositorio repositorio = new SerieRepositorio();
         static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        private static string opcaoUsuario;
        private static string opcaoUsuarioFilmeOuSerie;

        static void Main(string[] args)
        {
            do
            {   
                opcaoUsuarioFilmeOuSerie = ObterOpcaoFilmeOuSerie();               

                do
                {
                    if (opcaoUsuarioFilmeOuSerie == "1")
                    {
                        opcaoUsuario = ObterOpcaoUsuario();         
                                     
                        switch (opcaoUsuario)
                        {
                            case "1":
                                ListarFilmes();
                                break;
                            case "2":
                                InserirFilme();
                                break;
                            case "3":
                                AtualizarFilme();
                                break;
                            case "4":
                                ExcluirFilme();
                                break;
                            case "5":
                                VisualizarFilme();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            case "X":
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }               
                    }
                    else if(opcaoUsuarioFilmeOuSerie == "2")
                    {
                        opcaoUsuario = ObterOpcaoUsuario();
                        
                        switch (opcaoUsuario)
                        {
                            case "1":
                                ListarSeries();
                                break;
                            case "2":
                                InserirSerie();
                                break;
                            case "3":
                                AtualizarSerie();
                                break;
                            case "4":
                                ExcluirSerie();
                                break;
                            case "5":
                                VisualizarSerie();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            case "X":
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }    

                }while(opcaoUsuario != "X");         

            }while(opcaoUsuarioFilmeOuSerie != "X");

            System.Console.WriteLine("Obrigado por utilizar nossos serviços !");
            System.Console.WriteLine("Até a próxima ! :D");
            Console.ReadLine();
        }
        public static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }
        }
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Seja muito bem vindo !! DIO ao seu dispor!");
            System.Console.WriteLine("Informe a opção desejada");
            System.Console.WriteLine("1- Listar conteúdo");
            System.Console.WriteLine("2- Inserir novo conteúdo");
            System.Console.WriteLine("3- Atualizar conteúdo");
            System.Console.WriteLine("4- Excluir conteúdo");
            System.Console.WriteLine("5- Visualizar conteúdo");
            System.Console.WriteLine("C- Limpar tela");
            System.Console.WriteLine("X- Voltar ao menu anterior");

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
        private static string ObterOpcaoFilmeOuSerie()
        {
            System.Console.WriteLine("Olá !! Que prazer ter você aqui !!");
            System.Console.WriteLine("Sobre o que você deseja cadastrar?");
            System.Console.WriteLine("1- Filmes");
            System.Console.WriteLine("2- Séries");
            System.Console.WriteLine("X- Sair");
            

            string opcaoUsuarioFilmeOuSerie = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuarioFilmeOuSerie;
        }
        public static void ListarFilmes()
        {
            System.Console.WriteLine("Listar filmes");

            var lista = filmeRepositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum filme cadastrada");
                return;
            }

            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }
        }
        private static void InserirFilme()
        {
            System.Console.WriteLine("Inserir novo filme");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            filmeRepositorio.Insere(novoFilme);
        }
         private static void AtualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void ExcluirFilme()
        {
            System.Console.WriteLine("Digite o id do filme:");
            int indiceFilme = int.Parse(Console.ReadLine());

            filmeRepositorio.Exclui(indiceFilme);
        }
         private static void VisualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = filmeRepositorio.RetornaPorId(indiceFilme);

            System.Console.WriteLine(filme);
        }
    }
}
