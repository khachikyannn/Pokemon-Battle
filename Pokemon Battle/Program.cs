namespace Pokemon_Battle
{
    internal class Program
    { 
        static void Main()
        {
            //////https://sharplab.io/#v2:C4LgTgrgdgNAJiA1AHwAICYCMBYAUHjAAgEEoBLAWwEMAbQ+wvAb3rwcNQGZCA3MsYBFodMABhLlqNACoBPAA4BTNgyYr2DAOaLgjXBvZr9Bg6gDshAETQA1lAD2AdyiWA3A3UGAvp5/H6XIRkULrE2q6egahihAByVBSKEf567IGklLQAFMG6VNowIuJQCYoAlJ5GJiTahAC8hPlJnuzxifWEJYnJ7H7snpHcfAJCdKgALIQACmC5WRUpVSbRAJxZACSWTBlSckpenaVwhExtil6FYYrH29pelmU9DH5+BOiEAMJUuiASmTTMfopQIfexQADO9hoilBNHsYEIADEIGBYfDkoNCPYeIowLM4Ioin9dgpCZUWlodBT6EtqhwLJsmMjUVD4QcvsA3NTCH1npiOTkQo0CkSuopCqCIVCYayEQAzFFosALaq/ABGVHBhKyTUKYpVqm5zKVHQVLLhYCe9FeKQA9LbAtjcfjCRNprMQvNPPbaRp7asNpYOYdEjczhcatcTlcI44yMAABYnY2yg5mh5Wwj2m02t6fZiRdDoSp0gzcnbCNX2NUdKCKRyfb5ZMSFSyIuH2OXBTTAMGEACSg8sErBkOhSoAdABxMBUWSPblZLIcspVtVlCcpi0dSVjmUWicATUUNDhjgxKXYa4nMzmC8vHgfARiVA614rMlJmaB1V83LwXhAA=

            string playAgain = "";

            while (playAgain == "yes")
            {
                Console.WriteLine("Pick Your First Pokemon");
                // display pokemon
                string firstPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Second Pokemon");
                // display pokemon w/o first choice
                string secondPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Type Of Attack For First Pokemon");
                // display attack choices 
                string attackPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Type Of Attack For Second Pokemon");
                // display all attack choices
                attackPokemonChoice = Console.ReadLine();

                Console.WriteLine("Play Again?");
                playAgain = Console.ReadLine();
            }
        }
    }
}