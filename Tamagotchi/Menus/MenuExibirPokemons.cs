using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Modelos;

namespace Tamagotchi.Menus
{
    internal class MenuExibirPokemons : Menu
    {
        public override void Executar(string nomeUsuario)
        {
            string apiUrl = "https://pokeapi.co/api/v2/pokemon/";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                base.Executar(nomeUsuario);
                ExibirTituloMenu("ADOTE UM MASCOTE");

                PokemonList pokemonList = JsonConvert.DeserializeObject<PokemonList>(response.Content);

                for (int i = 0; i < pokemonList.Results.Count; i++)
                {
                    Console.WriteLine($"--> [{i + 1}] {pokemonList.Results[i].Name}");
                }

                Console.WriteLine("");
                Console.Write("Escolha: ");
                int escolha = int.Parse(Console.ReadLine()!);

                Console.Clear();

                string separador = new string('-', base.ComprimentoCaracteres);
                Console.WriteLine(separador);
                Console.WriteLine($"{nomeUsuario}, você deseja:");
                Console.WriteLine($"1 - Saber mais sobre o {pokemonList.Results[escolha - 1].Name}");
                Console.WriteLine($"2 - Adotar {pokemonList.Results[escolha - 1].Name}");
                Console.WriteLine("3 - Voltar");

                int opcaoEscolhida = int.Parse(Console.ReadLine()!);

                Dictionary<int, Menu> opcoes = new();
                opcoes.Add(1, new MenuExibirPokemonDetails(escolha));
                opcoes.Add(2, new MenuMascoteAdotado());
                opcoes.Add(3, new MenuExibirPokemons());

                if (opcoes.ContainsKey(opcaoEscolhida))
                {
                    Menu menuASerExibido = opcoes[opcaoEscolhida];
                    menuASerExibido.Executar(nomeUsuario);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }
            else
            {
                Console.WriteLine($"Erro na requisição. Código de status: {response.StatusCode};");
            }
        }
    }
}
