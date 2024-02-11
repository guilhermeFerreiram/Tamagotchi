using Tamagotchi.View;
using Tamagotchi.Models;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    internal class TamagochiController
    {
        private TamagochiView Menu { get; set; }
        private PokemonDetails MascoteAdotado { get; set; }
        public PokemonApiService PokemonApiService { get; set; }
        private PokemonList EspeciesDisponiveis { get; set; }

        public TamagochiController()
        {
            Menu = new TamagochiView();
            MascoteAdotado = new PokemonDetails();
            PokemonApiService = new PokemonApiService();
            EspeciesDisponiveis = PokemonApiService.ObterEspecies();
            
        }
        
        public void Jogar()
        {
            Menu.ExibirBoasVindas();

            while (true)
            {
                Menu.ExibirMenuPrincipal();
                int escolha = Menu.ObterEscolhaDoUsuario();

                switch (escolha)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Menu.ExibirEspecies(EspeciesDisponiveis);
                            Menu.ExibirMenuDeAdocao();
                            escolha = Menu.ObterEscolhaDoUsuario();

                            switch (escolha)
                            {
                                case 1:
                                    Console.Write("Digite o número do Pokémon: ");
                                    int indice = int.Parse(Console.ReadLine());
                                    PokemonDetails pokemon = PokemonApiService.ObterDestalhesDaEspecie(indice);
                                    Menu.ExibirDetalhesDeUmaEspecie(pokemon);
                                    if (Menu.ConfirmarAdocao())
                                    {
                                        MascoteAdotado = pokemon;
                                        Console.WriteLine($"Parabéns! Você adotou o mascote {pokemon.Name.ToUpper()} com sucesso!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("\nPressione qualquer tecla para voltar...");
                                        Console.ReadKey();

                                        Random random = new Random();
                                        int numeroAleatorioFome = random.Next(0, 11);
                                        int numeroAleatorioHumor = random.Next(0, 11);
                                        int numeroAleatorioSono = random.Next(0, 11);

                                        pokemon.Fome = numeroAleatorioFome;
                                        pokemon.Humor = numeroAleatorioHumor;
                                        pokemon.Sono = numeroAleatorioSono;
                                    }
                                    break;
                                case 2:
                                    break;
                                default:
                                    Menu.ExibirMensagemOpcaoInvalida();
                                    break;
                            }
                            if (escolha == 2)
                            {
                                escolha = 0;
                                break;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Menu.ExibirMascoteAdotado(MascoteAdotado);
                            Menu.MenuCuidarDoMeuMascote(MascoteAdotado);
                            escolha = Menu.ObterEscolhaDoUsuario();

                            switch (escolha)
                            {
                                case 1:
                                    MascoteAdotado.Alimentar();
                                    Console.WriteLine($"{MascoteAdotado.Name.ToUpper()} teve uma ótima refeição!");
                                    Console.WriteLine("Fome + 1");
                                    Console.WriteLine("\nPressione qualquer tecla...");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    MascoteAdotado.Brincar();
                                    Console.WriteLine($"{MascoteAdotado.Name.ToUpper()} brincou até dizer chega!");
                                    Console.WriteLine("Humor + 1");
                                    Console.WriteLine("\nPressione qualquer tecla...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    MascoteAdotado.Dormir();
                                    Console.WriteLine($"{MascoteAdotado.Name.ToUpper()} tirou uma soneca!");
                                    Console.WriteLine("Sono + 1");
                                    Console.WriteLine("\nPressione qualquer tecla...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    break;
                                default:
                                    Menu.ExibirMensagemOpcaoInvalida();
                                    break;
                            }
                            if (escolha == 4)
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        Menu.ExibirMenuSair();
                        break;
                    default:
                        Menu.ExibirMensagemOpcaoInvalida();
                        break;
                }
                if (escolha == 3)
                {
                    break;
                }
            }
        }
    }
}
