namespace SimpleMvc.Framework.Attributes.Methods
{
    using System;

    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
