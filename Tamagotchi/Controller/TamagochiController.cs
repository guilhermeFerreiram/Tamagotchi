using Tamagotchi.View;
using Tamagotchi.Models;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    internal class TamagochiController
    {
        private TamagochiView Menu { get; set; }
        private List<PokemonDetails> MascotesAdotados { get; set; }
        public PokemonApiService PokemonApiService { get; set; }
        private PokemonList EspeciesDisponiveis { get; set; }

        public TamagochiController()
        {
            Menu = new TamagochiView();
            MascotesAdotados = new List<PokemonDetails>();
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
                                        MascotesAdotados.Add(pokemon);
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
                                    }
                                    break;
                                case 2:
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
                        Menu.ExibirMascotesAdotados(MascotesAdotados);
                        break;
                    case 3:
                        Menu.ExibirMenuSair();
                        break;
                    default:
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
