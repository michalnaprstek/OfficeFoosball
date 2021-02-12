namespace OfficeFoosball.Models.Statistics
{
    public class PlayerSuccessRate
    {
        public Player Player { get; set; }
        public double SuccessPercentage { get; set; }
        public int TotalMatchCount { get; set; }
        public bool HasRanking { get; set; }
        public int MatchCountInRanking { get; set; }
    }
}
