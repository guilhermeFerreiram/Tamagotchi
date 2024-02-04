using RestSharp;
using Newtonsoft.Json;
public class PokemonList
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<PokemonResult> Results { get; set; }
}

public class PokemonResult
{
    public string Name { get; set; }
    public string Url { get; set; }
}

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

            foreach (var pokemonResult in pokemonList.Results)
            {
                Console.WriteLine($"Nome: {pokemonResult.Name}");
            }
        }
        else
        {
            Console.WriteLine($"Erro na requisição. Código de status: {response.StatusCode}");
        }
    }
}
