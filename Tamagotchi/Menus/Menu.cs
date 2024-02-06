namespace Tamagotchi.Menus
{
    internal class Menu
    {
        public int ComprimentoCaracteres { get; set; } = 60;
        public void ExibirTituloMenu(string tituloMenu)
        {
            int comprimentoTitulo = tituloMenu.Length;

            int comprimentoLado = (ComprimentoCaracteres - comprimentoTitulo) / 2;

            string menuFormatado = new string('-', comprimentoLado) + " " + tituloMenu + " " + new string('-', comprimentoLado);

            Console.WriteLine(menuFormatado);
        }

        public virtual void Executar(string nomeUsuario)
        {
            Console.Clear();
        }
    }
}
