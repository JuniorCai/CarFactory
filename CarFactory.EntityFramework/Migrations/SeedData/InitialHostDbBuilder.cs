using CarFactory.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CarFactory.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly CarFactoryDbContext _context;

        public InitialHostDbBuilder(CarFactoryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
