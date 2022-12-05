using GuessingGameCollection.UserData;

namespace GuessingGameCollection.Data;
public class ScoreDAO : IScoreDAO
{
    public void PostScore(string name, int numberOfGuesses)
    {
        StreamWriter output = new StreamWriter("result.txt", append: true);
        output.WriteLine(name + "#&#" + numberOfGuesses);
        output.Close();
    }

    public List<PlayerData> GetHighScores()
    {
        StreamReader input = new StreamReader("result.txt");
        List<PlayerData> results = new List<PlayerData>();
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(name, guesses);
            int pos = results.IndexOf(pd);
            if (pos < 0)
            {
                results.Add(pd);
            }
            else
            {
                results[pos].Update(guesses);
            }


        }
        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        input.Close();

        return results;
    }
}