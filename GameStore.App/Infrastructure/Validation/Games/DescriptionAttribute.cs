namespace GameStore.App.Infrastructure.Validation.Games
{
    using SimpleMvc.Framework.Attributes.Validation;

    public class DescriptionAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var description = value as string;
            if (description == null)
            {
                return true;
            }

            return description.Length >= 20;
        }
    }
}
