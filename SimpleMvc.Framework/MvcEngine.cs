namespace SimpleMvc.Framework
{
    using System;
    using System.Reflection;
    using WebServer;

    public static class MvcEngine
    {
        public static void Run(WebServer server)
        {
            RegisterAssemblyName();
            
            try
            {
                server.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly
                .GetEntryAssembly()
                .GetName()
                .Name;
        }
    }
}
