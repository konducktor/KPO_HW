public readonly record struct NoviceScore
{
    public const int MIN = 1;
    public const int MAX = 10;
    public const int NOVICE_THRESHHOLD = 6;

    public int Score { get; }

    public NoviceScore(int score)
    {
        if (score < MIN || score > MAX)
        {
            throw new ArgumentOutOfRangeException(nameof(score), score, $"Повреждения: от {MIN} до {MAX}");
        }

        Score = score;
    }

    public bool IsSuitableForNovice()
    {
        return Score >= NOVICE_THRESHHOLD;
    }
}