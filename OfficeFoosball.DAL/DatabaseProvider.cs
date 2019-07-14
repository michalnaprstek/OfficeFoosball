namespace OfficeFoosball.DAL
{
    class DatabaseProvider : IDatabaseProvider
    {
        private readonly IFoosballDatabase _db;

        public DatabaseProvider(FoosballContext db)
        {
            _db = db;
        }

        public IFoosballDatabase Get() => _db;
    }
}
