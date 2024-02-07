using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Models;

namespace Tamagotchi.Service
{
    internal class PokemonApiService
    {
        public PokemonList ObterEspecies()
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            PokemonList pokemonList = JsonConvert.DeserializeObject<PokemonList>(response.Content);

            return pokemonList;
        }

        public PokemonDetails ObterDestalhesDaEspecie(int index)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{index}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            PokemonDetails pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(response.Content);

            return pokemonDetails;
        }
    }
}
