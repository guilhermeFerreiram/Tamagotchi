namespace Tamagotchi.Modelos
{
    public class PokemonDetails
    {
        public string Name { get; set; }
        public List<PokemonAbility> Abilities { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
