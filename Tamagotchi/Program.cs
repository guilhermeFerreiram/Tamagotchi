using RestSharp;
using Newtonsoft.Json;
using Tamagotchi;

class Program
{
    static void Main()
    {
        string apiUrl = "https://pokeapi.co/api/v2/pokemon/";
        var client = new RestClient(apiUrl);
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            PokemonList pokemonList = JsonConvert.DeserializeObject<PokemonList>(response.Content);

            Console.WriteLine("=== Escolha seu Tamagochi! ===\n");

            for (int i = 0; i < pokemonList.Results.Count; i++)
            {
                Console.WriteLine($"--> [{i + 1}] {pokemonList.Results[i].Name}");
            }

            Console.WriteLine("");
            Console.Write("Escolha: ");
            int escolha = int.Parse(Console.ReadLine()!);

            Console.Clear();

            client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
            request = new RestRequest("", Method.Get);
            response = client.Execute(request);

            PokemonDetails pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(response.Content);

            Console.WriteLine($"=== {pokemonDetails.Name} ===\n");

            Console.WriteLine($"--> Altura: {pokemonDetails.Height}");
            Console.WriteLine($"--> Peso: {pokemonDetails.Weight}");
            Console.WriteLine("--> Habilidades:");

            foreach (var pokemonAbility in pokemonDetails.Abilities)
            {
                Console.WriteLine($"- {pokemonAbility.Ability.Name}");
            }
        }
        else
        {
            Console.WriteLine($"Erro na requisição. Código de status: {response.StatusCode};");
        }


    }
}
