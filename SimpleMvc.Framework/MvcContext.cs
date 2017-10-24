namespace SimpleMvc.Framework
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext() { }

        public static MvcContext Get
            => instance == null ? (instance = new MvcContext()) : instance;

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; } = "Controllers";

        public string ControllerSuffix { get; set; } = "Controller";

        public string ViewsFolder { get; set; } = "Views";

        public string ModelsFolder { get; set; } = "Models";

        public string ResourcesFolder { get; set; } = "Resources";
    }
}
