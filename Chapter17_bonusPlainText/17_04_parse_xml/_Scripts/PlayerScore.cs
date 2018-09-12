public class PlayerScoreDate
{
    private string playerName;
    private int score;
    private string date;

    public void SetPlayerName(string playerName) { this.playerName = playerName; }
    public void SetScore(int score) { this.score = score; }
    public void SetDate(string date) { this.date = date; }

    override public string ToString()
    {
        return "Player = " + this.playerName + ", score = " + this.score + ", date = " + this.date;
    }
}
