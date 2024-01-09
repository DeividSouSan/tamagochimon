
using Pokemon;
using Tamagotchi;

namespace Tamagotchi
{
    public class TamagotchiMenu
    {
        private static string userName = "";

        public void Menu()
        {
            Console.Write("Por favor, digite seu nome: ");
            userName = Console.ReadLine()!;
        }

        public async Task ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("""
            ··················································
            : _____ _   __  __   _   ___  ___   ___ _  _ ___ :
            :|_   _/_\ |  \/  | /_\ / __|/ _ \ / __| || |_ _|:
            :  | |/ _ \| |\/| |/ _ \ (_ | (_) | (__| __ || | :
            :  |_/_/ \_\_|  |_/_/ \_\___|\___/ \___|_||_|___|:
            ··················································
            """);
                Console.WriteLine($"Olá {userName}, escolha uma opção:");
                Console.WriteLine("1. Adotar");
                Console.WriteLine("2. Opção 2");
                Console.WriteLine("3.  Sair");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        await AdotarMascote();
                        break;
                    case "2":
                        VerMascote();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Seleção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public static async Task AdotarMascote()
        {
            Console.WriteLine("Você pode adotar qualquer Pokemons.");
            string pokemon = PokemonControl.GetPokemonName();

            try
            {
                await PokemonControl.SearchPokemon(pokemon);
                Console.WriteLine($"Pokemon {PokemonControl.mascote?.Name} adotado com sucesso!");

            }
            catch
            {
                Console.WriteLine("Erro ao adotar o Pokemon!");
            }
        }

        public static void VerMascote()
        {
            Console.WriteLine("Você pode ver todos os Pokemons adotados.");
            PokemonControl.ShowPokemon();
        }
    }
}