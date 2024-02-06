namespace Tamagotchi.Menus
{
    internal class MenuInicial : Menu
    {
        public override void Executar(string nomeUsuario)
        {
            base.Executar(nomeUsuario);
            ExibirTituloMenu("MENU");
            Console.WriteLine($"{nomeUsuario}, você deseja:");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");

            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            Dictionary<int, Menu> opcoes = new();
            opcoes.Add(1, new MenuExibirPokemons());
            opcoes.Add(3, new MenuSair());

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
    }
}
