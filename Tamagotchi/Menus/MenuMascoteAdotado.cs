namespace Tamagotchi.Menus
{
    internal class MenuMascoteAdotado : Menu
    {
        public override void Executar(string nomeUsuario)
        {
            base.Executar(nomeUsuario);

            Console.WriteLine($"{nomeUsuario.ToUpper()}, MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO...");
        }
    }
}
