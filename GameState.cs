using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    public class GameState
    {
        private string jatekos1;
        private string jatekos2;
        private string[,]? tabla;
        private int checkState;
        private List<GameState> gameStates;

        public GameState(int n, int m, string jatekos1 = "", string jatekos2 = "")
        {
            this.jatekos1 = jatekos1;
            this.jatekos2 = jatekos2;
            this.tabla = new string[n, m];
        }

        public string Jatekos1 { get => jatekos1; set => jatekos1 = value; }
        public string Jatekos2 { get => jatekos2; set => jatekos2 = value; }
        public string[,] Tabla { get => tabla; private set => tabla = value; }
        public int CheckState { 
            get => checkState; 
            set => checkState = value; }
        public List<GameState> GameStates { get => gameStates; set => gameStates = value; }

        public int StepSigning(int checkState)
        {
            if (CheckGameOver("X")) {
                checkState = 1; 
            } else if (CheckGameOver("O")) {
                checkState = 2;
            } else if (CheckDraw()) { 
                checkState = 0; } else
            {  checkState = -1; }
            return checkState;
        }
        private bool CheckDraw()
        {
            foreach (var field in Tabla)
            {
                if (field == "_" || field == "") { return false; }
            }
            return true;
        }
        public bool CheckGameOver(string sign)
        {
            int i = 0;
            int j = 0;
            int n = Tabla.GetLength(0);
            while (i < n && Tabla[i, i] == sign) { i++; }
            if (i == n) return true;
            i = 0;
            while (i < n && Tabla[i, n - 1 - i] == sign) { i++; }
            if (i == n) return true;
            i = 0;
            while (i < n)
            {
                j = 0;
                while (j < n && Tabla[i, j] == sign) { j++; }
                if (j == n) return true;
                j = 0;
                while (j < n && Tabla[j, i] == sign) { j++; }
                if (j == n) return true;
                i++;
            }
            return false;
        }
        public string CreateGameState()
        {
            if (!File.Exists("gameStates.txt"))
            {
                File.Create("gameStates.txt");
            }

            StreamReader sr = new StreamReader("gameStates.txt");

            int ordNum = 1;
            while (!sr.EndOfStream && sr.ReadLine() == $"minta{ordNum}.txt") { ordNum++; }
            sr.Close();

            using (StreamWriter sw = File.AppendText("gameStates.txt"))
            {
                sw.WriteLine($"minta{ordNum}.txt");
            }

            string file = "";

            using (sr = File.OpenText("gameStates.txt"))
            {
                while (!sr.EndOfStream)
                {
                    file = sr.ReadLine();
                }
            }

            return file;
        }

        public void SaveGameState(GameState gamestate, string fajl)
        {
            string items = gamestate.Jatekos1 + ";" + gamestate.Jatekos2;
            StreamWriter sw = new StreamWriter(fajl);
            sw.WriteLine(items);

            for (int k = 0; k < gamestate.Tabla.GetLength(0); k++)
            {
                items = "";
                int m = gamestate.Tabla.GetLength(1);
                for (int i = 0; i < m; i++)
                {
                    string item = (gamestate.Tabla[k, i] == "") ? "_" : gamestate.Tabla[k, i];
                    items += (i < m - 1) ? item + ";" : item;
                }
                sw.WriteLine(items);
            }
            sw.Close();
        }
    }
}
