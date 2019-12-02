using OfficeFoosball.DAL.Entities;
using System;
using System.Linq;

namespace OfficeFoosball.DAL
{
    public class DataStoreInitializer : IDataStoreInitializer
    {
        private readonly FoosballContext _dbContext;

        public DataStoreInitializer(FoosballContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            _dbContext.Database.EnsureCreated();
        }
    }
}
