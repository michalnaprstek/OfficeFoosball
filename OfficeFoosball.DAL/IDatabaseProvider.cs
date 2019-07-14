namespace OfficeFoosball.DAL
{
    public interface IDatabaseProvider 
    {
        IFoosballDatabase Get();
    }
}
