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

            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver meu mascote");
            Console.WriteLine("3 - Sair\n");
        }
        
        public void ExibirEspecies(PokemonList especies)
        {
            Console.WriteLine("Estes são os mascotes disponíveis:\n");

            for (int i = 0; i < especies.Results.Count; i++)
            {
                Console.WriteLine($"--> [{i + 1}] {especies.Results[i].Name}");
            }
            Console.WriteLine("");
        }

        public void ExibirMenuDeAdocao()
        {
            ExibirTituloMenu("ADOTE UM MASCOTE");

            Console.WriteLine("1 - Adotar um Pokémon");
            Console.WriteLine("2 - Sair");
            Console.WriteLine("");
        }

        public void ExibirDetalhesDeUmaEspecie(PokemonDetails pokemon)
        {
            Console.Clear();

            ExibirTituloMenu(pokemon.Name.ToUpper());

            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine("Habilidades:");

            foreach (var pokemonAbility in pokemon.Abilities)
            {
                Console.Write($"{pokemonAbility.Ability.Name.ToUpper()} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public bool ConfirmarAdocao()
        {
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void ExibirMascoteAdotado(PokemonDetails pokemon)
        {
            Console.Clear();

            ExibirTituloMenu(pokemon.Name.ToUpper());

            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine("Habilidades:");

            foreach (var pokemonAbility in pokemon.Abilities)
            {
                Console.Write($"{pokemonAbility.Ability.Name.ToUpper()} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"Fome: {pokemon.Fome}");
            if (pokemon.Fome <= 5)
            {
                Console.WriteLine($"{pokemon.Name} está com muita fome!");
            }
            else if (pokemon.Fome > 5 && pokemon.Fome <= 8)
            {
                Console.WriteLine($"{pokemon.Name} está ficando com fome!");
            }
            else
            {
                Console.WriteLine($"{pokemon.Name} está sem fome!");
            }

            Console.WriteLine($"Humor: {pokemon.Humor}");
            if (pokemon.Humor <= 5)
            {
                Console.WriteLine($"{pokemon.Name} está muito triste!");
            }
            else if (pokemon.Fome > 5 && pokemon.Humor <= 8)
            {
                Console.WriteLine($"{pokemon.Name} está pouco feliz!");
            }
            else
            {
                Console.WriteLine($"{pokemon.Name} está muito feliz!");
            }

            Console.WriteLine($"Sono: {pokemon.Sono}");
            if (pokemon.Sono <= 5)
            {
                Console.WriteLine($"{pokemon.Name} está com muito sono!");
            }
            else if (pokemon.Fome > 5 && pokemon.Sono <= 8)
            {
                Console.WriteLine($"{pokemon.Name} está ficando com sono!");
            }
            else
            {
                Console.WriteLine($"{pokemon.Name} está bem disposto!");
            }
            Console.WriteLine("");
        }

        public void MenuCuidarDoMeuMascote(PokemonDetails pokemon)
        {
            Console.WriteLine($"1 - Alimentar {pokemon.Name.ToUpper()}");
            Console.WriteLine($"2 - Brincar com {pokemon.Name.ToUpper()}");
            Console.WriteLine($"3 - Colocar {pokemon.Name.ToUpper()} para dormir");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine("");
        }

        public void ExibirMenuSair()
        {
            Console.Clear();
            Console.WriteLine("Até a próxima!...");
        }
    }
}
