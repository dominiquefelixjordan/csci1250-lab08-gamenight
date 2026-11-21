using System.ComponentModel;

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
//const string HISTORY_FILE = "history.txt";
//const int MAX_POINTS = 20;

// look for the data files next to program.cs however the program is started
string projectFolder = Path.GetFullPath (
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

string pl = "PLAYERS";
string po = "POINTS";


string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);


Console.WriteLine($"{pl.PadRight(11)}{po.PadRight(11)} \n");

for (int i = 0; i < players.Length; i++)
{

Console.WriteLine(players[i].PadRight(11) + points[i]); 
}

int totals = TotalPoints(points);
int leader = LeaderIndex(points);

Console.WriteLine($"Leader: {players[leader]} with {points[leader]} points!");
Console.WriteLine($"Season total: {totals}");



//methods

static int LeaderIndex(string[] points)
{
    int index = 0;
    int topScore = 0;

for (int i = 0; i < points.Length; i++)
{
int score = Convert.ToInt32(points[i]);  
if (score > topScore)
{
    topScore = score; 
    index = i;
}
}
return index;
}


static int TotalPoints(string[] points)
 {int sum = 0;

     foreach (string score in points)
     {sum += Convert.ToInt32(score);

     }
     return sum;
 }

// static string HitoryEntry(int night, string winner, int points)
 
