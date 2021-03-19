namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        }
    }
}
