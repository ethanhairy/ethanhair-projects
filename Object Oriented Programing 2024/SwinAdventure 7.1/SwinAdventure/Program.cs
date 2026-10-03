using System;
namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Swin-Adventure!");

            Console.Write("What is your Name: ");
            string name = Console.ReadLine();
            Console.Write("Please give a Description: ");
            string description = Console.ReadLine();

            Player _player = new Player(name, description);

            Bag _bag = new Bag(new string[] { "bag" }, $"{_player.Name}'s Bag", "this is the player's bag");
            Item _shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "this is a shovel");
            Item _sword = new Item(new string[] { "sword" }, "a sword", "this is a sword");
            Item _gem = new Item(new string[] { "gem" }, "a gem", "A bright red Gem");

            _player.Inventory.Put(_shovel);
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_gem);

            Command _look = new LookCommand();
            int quit = 0;
            do
            {
                Console.WriteLine("Command -> ");
                string cmd = Console.ReadLine().ToLower();
                if (cmd == "quit")
                {
                    quit = 1;
                }
                else
                {
                    Console.WriteLine(_look.Execute(_player, cmd.Split(' ')));
                }
            } while (quit != 1);
        }
    }
}
