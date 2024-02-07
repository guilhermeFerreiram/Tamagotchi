using Tamagotchi.Controller;
using Tamagotchi.View;

class Program
{
    static void Main()
    {
        TamagochiController tamagochiController = new();
        tamagochiController.Jogar();
    }
}
