namespace SimpleMvc.Framework.Attributes.Validation
{
    using System;

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
