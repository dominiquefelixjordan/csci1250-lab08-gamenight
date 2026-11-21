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

//                                                      part 2 start

int[] tonight = new int[players.Length];
int bestScore = 0;
int bestScoreIndex = 0;

for (int i = 0; i < players.Length; i++)
{
Console.WriteLine($"Points tonight for {players[i]}: "); 
tonight[i] = Convert.ToInt32(Console.ReadLine());

while (tonight[i] > 20 || tonight[i] < 0)
{
Console.WriteLine("Points must be from 0 to 20");
Console.WriteLine($"Points tonight for {players[i]}: "); 
tonight[i] = Convert.ToInt32(Console.ReadLine());
}

if (bestScore < tonight[i])
{
bestScore = tonight[i];
bestScoreIndex = i;
}

int season = Convert.ToInt32(points[i]) + tonight[i];
points[i] = season.ToString();
}

Console.WriteLine($"Tonights winner: {players[bestScoreIndex]} with {tonight[bestScoreIndex]} points");
File.WriteAllLines(POINTS_FILE, points);
Console.WriteLine($"Saved points.txt");





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
 
