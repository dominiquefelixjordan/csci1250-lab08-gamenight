/*
*Name:        Felix Jordan
*Course:      CSCI 1250, Section 001
*Assignment:  Lab 08, Game Night 
*Date:        November 18, 2026
*Description: Keeps a game night leader board in three text files. Shows the
              season so far, records tonights points, saves the new totals, and adds tonights
              results to a history that grows every week. 
*/


const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;


// look for the data files next to program.cs however the program is started
string projectFolder = Path.GetFullPath (
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
string[] history = File.ReadAllLines(HISTORY_FILE);
 int nightsPlayed = history.Length;
 int tonightNumber = history.Length +1;

// only display this while no history has been recorded
if (history.Length == 0)
{
    Console.WriteLine($"No nights played yet.");

}

//otherwise, show how many lines stored
else
{

    Console.WriteLine($"Nights played: {nightsPlayed}");
}

// then show everything stored in history
foreach (string pastNight in history)
{
    Console.WriteLine(pastNight);
}

Console.WriteLine($"Tonight is night {tonightNumber}");

string pl = "PLAYERS";
string po = "POINTS";


string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);


Console.WriteLine($"{pl.PadRight(11)}{po.PadRight(11)} \n");

//writes every index before exiting
for (int i = 0; i < players.Length; i++)
{

Console.WriteLine(players[i].PadRight(11) + points[i]); 
}

int totals = TotalPoints(points);
int leader = LeaderIndex(points);

Console.WriteLine($"Leader: {players[leader]} with {points[leader]} points!");
Console.WriteLine($"Season total: {totals}");

//part 2 start, gets current nights scores and saves them

int[] tonight = new int[players.Length];
int bestScore = 0;
int bestScoreIndex = 0;

// need the index, loop through all of players 
for (int i = 0; i < players.Length; i++)
{
Console.Write($"Points tonight for {players[i]}: "); 
tonight[i] = Convert.ToInt32(Console.ReadLine());

//doesn't move on until parameters met
while (tonight[i] > MAX_POINTS || tonight[i] < 0)
{
Console.WriteLine("Points must be from 0 to 20");
Console.Write($"Points tonight for {players[i]}: "); 
tonight[i] = Convert.ToInt32(Console.ReadLine());
}

// only run this if current score better than bestScore
if (bestScore < tonight[i])
{
bestScore = tonight[i];
bestScoreIndex = i;
}

int season = Convert.ToInt32(points[i]) + tonight[i];
points[i] = season.ToString();
}

string winnerTonight = players[bestScoreIndex];
int bestTonight = tonight[bestScoreIndex];

Console.WriteLine($"Tonights winner: {winnerTonight} with {bestTonight} points");
File.WriteAllLines(POINTS_FILE, points);
Console.WriteLine($"Saved points.txt");

//part 3 start, need to create method 

string[] entry = { HistoryEntry(tonightNumber, winnerTonight, bestTonight) };
File.AppendAllLines(HISTORY_FILE, entry);
Console.WriteLine($"Added to history.txt: {HistoryEntry(tonightNumber, winnerTonight, bestTonight)}");;

//methods

static int LeaderIndex(string[] points)
{
    int index = 0;
    int topScore = 0;
//we need to run through the entire file and keep track of the index
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
 {
    int sum = 0;
//foreach because i want everything and dont care about the index
     foreach (string score in points)
     {sum += Convert.ToInt32(score);

     }
     return sum;
 }

static string HistoryEntry(int night, string winner, int points)
{
    
return $"Night {night}: {winner} won with {points} points.";
}
 
