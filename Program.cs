namespace Amoba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] game_states = new string[100];

            using (StreamReader sr = File.OpenText("gameStates.txt"))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    game_states[i] = sr.ReadLine();
                    i++;
                }
            }

            List<GameState> gameStatesList = new List<GameState>();

            foreach (string game_state in game_states)
            {
                if (File.Exists(game_state))
                {
                    StreamReader sr = File.OpenText(game_state);
                    string[] jatekosok = sr.ReadLine().Split(';');
                    string[][] jatekSorok = new string[4][];

                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        jatekSorok[i] = sr.ReadLine().Split(';');
                        i++;
                    }

                    GameState gameState = new(4, 4, jatekosok[0], jatekosok[1]);
                    
                    for (int j = 0; j< jatekSorok.Count(); j++)
                    {
                        for (int k = 0; k < jatekSorok[j].Length; k++)
                        {
                            gameState.Tabla[j,k] = jatekSorok[j][k];
                        }
                    }
                    gameState.CheckState = gameState.StepSigning(gameState.CheckState);

                    gameStatesList.Add(gameState);

                    //Console.WriteLine(gamestate.CheckState + ","+ gamestate.Jatekos1 +","+ gamestate.Tabla[0,0]);
                }
            }
            int[] checkStates = new int[4];

            foreach (GameState gameState in gameStatesList)
            {
                if (gameState.CheckState == -1)
                {
                    checkStates[3]++;
                } else
                {
                    checkStates[(int)gameState.CheckState]++;
                }
            }

            Console.WriteLine("6. feladat:");
            Console.WriteLine($"\tElső játékos {checkStates[1]} esetben nyert.");
            Console.WriteLine($"\tMásodik játékos {checkStates[2]} esetben nyert.");
            Console.WriteLine($"\t{checkStates[1]} esetben döntetlen eredmény született.");
            Console.WriteLine($"\t{checkStates[3]} esetben még nincs teljesen lejátszva.");
        }
    }
}
