namespace SimpleMvc.Framework.Helpers
{
    public static class ControllerHelpers
    {
        public static string GetControllerName(object controller)
            => controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

        public static string GetViewFullQualifiedName(
            string controller,
            string action)
            => string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controller,
                action);
    }
}
