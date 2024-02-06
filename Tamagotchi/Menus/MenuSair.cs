namespace Tamagotchi.Menus
{
    internal class MenuSair : Menu
    {
        public override void Executar(string nomeUsuario)
        {
            base.Executar(nomeUsuario);
            Console.WriteLine("Até a próxima!...");
        }
    }
}
