using System;
using System.Collections.Generic;
using System.Linq;
namespace Tamagotchi
{
    public class PokemonList
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResult> Results { get; set; }
    }
}
