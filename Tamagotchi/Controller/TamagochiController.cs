using Tamagotchi.View;
using Tamagotchi.Models;

namespace Tamagotchi.Controller
{
    internal class TamagochiController
    {
        private TamagochiView Menu { get; set; } = new TamagochiView();
        private List<PokemonDetails> MascotesAdotados { get; set; } = new List<PokemonDetails>();
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
                            Menu.ExibirMenuDeAdocao();
                            escolha = Menu.ObterEscolhaDoUsuario();

                            switch (escolha)
                            {
                                case 1:
                                    Menu.ExibirDetalhesDeUmaEspecie();
                                    break;
                                case 2:
                                    var pokemonAdotado = Menu.ExibirMenuAdotar();
                                    MascotesAdotados.Add(pokemonAdotado);
                                    Console.WriteLine("Parabéns! Você adotou seu mascote com sucesso!");
                                    Console.WriteLine("──────────────");
                                    Console.WriteLine("────▄████▄────");
                                    Console.WriteLine("──▄████████▄──");
                                    Console.WriteLine("──██████████──");
                                    Console.WriteLine("──▀████████▀──");
                                    Console.WriteLine("─────▀██▀─────");
                                    Console.WriteLine("──────────────");
                                    Console.WriteLine("\nPressione qualquer tecla para voltar...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    break;
                            }
                            if (escolha == 3)
                            {
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
