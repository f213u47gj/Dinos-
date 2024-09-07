namespace DinoGame.Repositories
{
    public interface IScoreRepository
    {
        Task AddScoreAsync(Score score);
        Task<IEnumerable<Score>> GetScoreAsync();
    }
}
