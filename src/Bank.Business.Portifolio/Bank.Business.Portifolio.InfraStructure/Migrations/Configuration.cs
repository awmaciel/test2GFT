namespace Bank.Business.Portifolio.InfraStructure.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Bank.Business.Portifolio.InfraStructure.Context.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;            
        }

        protected override void Seed(Bank.Business.Portifolio.InfraStructure.Context.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
