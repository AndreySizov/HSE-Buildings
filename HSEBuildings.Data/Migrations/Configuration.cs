namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HSEBuildings.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HSEBuildings.Data.Context context)
        {
            //Repository repo = new Repository();
            //repo.GetData();
            //foreach (var item in repo.Campuses)
            //{
            //    context.Campus.AddOrUpdate(camp => camp.Name, item);
            //}
            //foreach (var item in repo.Flors)
            //{
            //    context.Flor.AddOrUpdate(flor => flor.Number, item);
            //}
            //foreach (var item in repo.Rooms)
            //{
            //    context.Room.AddOrUpdate(room => room.Name, item);
            //}
            //foreach (var item in repo.Photos)
            //{
            //    context.Photo.AddOrUpdate(photo => photo.Link, item);
            //}
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
