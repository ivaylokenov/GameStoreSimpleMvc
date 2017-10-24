namespace GameStore.App.Infrastructure.Validation.Games
{
    using SimpleMvc.Framework.Attributes.Validation;

    public class ThumbnailUrlAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var thumbnailUrl = value as string;
            if (thumbnailUrl == null)
            {
                return true;
            }

            return thumbnailUrl.StartsWith("http://")
                || thumbnailUrl.StartsWith("https://");
        }
    }
}
