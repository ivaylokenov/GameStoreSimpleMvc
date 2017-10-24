namespace GameStore.App
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main()
            => MvcEngine.Run(
                new WebServer(1337, new ControllerRouter(), new ResourceRouter()));
    }
}
