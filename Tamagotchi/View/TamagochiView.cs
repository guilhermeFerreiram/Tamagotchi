using Tamagotchi.Models;
using Tamagotchi.Service;

namespace Tamagotchi.View
{
    internal class TamagochiView
    {
        private int ComprimentoCaracteres { get; set; } = 60;

        public void ExibirTituloMenu(string tituloMenu)
        {
            int comprimentoTitulo = tituloMenu.Length;

            int comprimentoLado = (ComprimentoCaracteres - comprimentoTitulo) / 2;

            string menuFormatado = new string('-', comprimentoLado) + " " + tituloMenu + " " + new string('-', comprimentoLado);

            Console.WriteLine(menuFormatado);
        }

        public int ObterEscolhaDoUsuario()
        {
            Console.Write("Escolha: ");
            int escolha = int.Parse(Console.ReadLine()!);
            return escolha;
        }

        public void ExibirBoasVindas()
        {
            Console.WriteLine(@"
        
████████╗░█████╗░███╗░░░███╗░█████╗░░██████╗░░█████╗░░█████╗░██╗░░██╗██╗
╚══██╔══╝██╔══██╗████╗░████║██╔══██╗██╔════╝░██╔══██╗██╔══██╗██║░░██║██║
░░░██║░░░███████║██╔████╔██║███████║██║░░██╗░██║░░██║██║░░╚═╝███████║██║
░░░██║░░░██╔══██║██║╚██╔╝██║██╔══██║██║░░╚██╗██║░░██║██║░░██╗██╔══██║██║
░░░██║░░░██║░░██║██║░╚═╝░██║██║░░██║╚██████╔╝╚█████╔╝╚█████╔╝██║░░██║██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚═╝
        ");
            string separador = new string('-', ComprimentoCaracteres);
            Console.WriteLine($"{separador}\n");
            Console.Write("Seja bem vindo(a)! Qual seu nome?: ");
            string nomeUsuario = Console.ReadLine()!;
            Console.WriteLine($"Olá, {nomeUsuario}! Pressione qualquer tecla para começar!\n");
            Console.ReadKey();
            Console.Clear();
        }

        public void ExibirMenuPrincipal()
        {
            Console.Clear();
            ExibirTituloMenu("MENU");
            Console.WriteLine("Você deseja:\n");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair\n");
        }

        public void ExibirEspecies()
        {
            Console.WriteLine("Estes são os mascotes disponíveis:\n");
            PokemonApiService pokemonApi = new PokemonApiService();
            var pokemonList = pokemonApi.ObterEspecies();

            for (int i = 0; i < pokemonList.Results.Count; i++)
            {
                Console.WriteLine($"--> [{i + 1}] {pokemonList.Results[i].Name}");
            }
        }

        public void ExibirMenuDeAdocao()
        {
            Console.Clear();
            ExibirTituloMenu("ADOTE UM MASCOTE");
            Console.WriteLine("");
            ExibirEspecies();
            Console.WriteLine("");

            Console.WriteLine("1 - Exibir Detalhes de uma espécie");
            Console.WriteLine("2 - Adotar um pokémon");
            Console.WriteLine("3 - Voltar\n");
        }

        public void ExibirDetalhesDeUmaEspecie()
        {
            Console.Write("Digite o número do Pokémon: ");
            int index = int.Parse(Console.ReadLine()!);

            Console.Clear();

            PokemonApiService pokemonApi = new PokemonApiService();
            var pokemonDetails = pokemonApi.ObterDestalhesDaEspecie(index);

            ExibirTituloMenu(pokemonDetails.Name.ToUpper());

            Console.WriteLine($"Altura: {pokemonDetails.Height}");
            Console.WriteLine($"Peso: {pokemonDetails.Weight}");
            Console.WriteLine("Habilidades:");

            foreach (var pokemonAbility in pokemonDetails.Abilities)
            {
                Console.Write($"{pokemonAbility.Ability.Name.ToUpper()} ");
            }

            Console.WriteLine("\n\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public PokemonDetails ExibirMenuAdotar()
        {
            Console.Write("Digite o número do Pokémon: ");
            int index = int.Parse(Console.ReadLine()!);

            Console.Clear();

            PokemonApiService pokemonApi = new PokemonApiService();
            var pokemonDetails = pokemonApi.ObterDestalhesDaEspecie(index);

            return pokemonDetails;
        }

        public void ExibirMascotesAdotados(List<PokemonDetails> pokemonList)
        {
            Console.Clear();

            foreach (var pokemon in pokemonList)
            {
                ExibirTituloMenu(pokemon.Name.ToUpper());

                Console.WriteLine($"Altura: {pokemon.Height}");
                Console.WriteLine($"Peso: {pokemon.Weight}");
                Console.WriteLine("Habilidades:");

                foreach (var pokemonAbility in pokemon.Abilities)
                {
                    Console.Write($"{pokemonAbility.Ability.Name.ToUpper()} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public void ExibirMenuSair()
        {
            Console.Clear();
            Console.WriteLine("Até a próxima!...");
        }
    }
}
