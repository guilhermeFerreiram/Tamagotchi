using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Modelos;

namespace Tamagotchi.Menus
{
    internal class MenuExibirPokemonDetails : Menu
    {
        public int Index { get; set; }

        public MenuExibirPokemonDetails(int index)
        {
            this.Index = index;
        }

        public override void Executar(string nomeUsuario)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{this.Index}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                PokemonDetails pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(response.Content);

                base.Executar(nomeUsuario);
                ExibirTituloMenu(pokemonDetails.Name.ToUpper());

                Console.WriteLine($"Altura: {pokemonDetails.Height}");
                Console.WriteLine($"Peso: {pokemonDetails.Weight}");
                Console.WriteLine("Habilidades:");

                foreach (var pokemonAbility in pokemonDetails.Abilities)
                {
                    Console.Write($"{pokemonAbility.Ability.Name.ToUpper()} ");
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                Menu menuExibirPokemons = new MenuExibirPokemons();
                menuExibirPokemons.Executar(nomeUsuario);
            }
            else
            {
                Console.WriteLine($"Erro na requisição. Código de status: {response.StatusCode};");
            }
        }
    }
}
