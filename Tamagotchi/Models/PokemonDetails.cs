namespace Tamagotchi.Models
{
    public class PokemonDetails
    {
        public string Name { get; set; }
        public List<PokemonAbility> Abilities { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Fome { get; set; }
        public int Humor { get; set; }
        public int Sono { get; set; }

        public void Alimentar()
        {
            Fome++;
        }

        public void Brincar()
        {
            Humor++;
        }

        public void Dormir()
        {
            Sono++;
        }
    }
}
