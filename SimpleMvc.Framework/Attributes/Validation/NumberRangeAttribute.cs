namespace SimpleMvc.Framework.Attributes.Validation
{
    public class NumberRangeAttribute : PropertyValidationAttribute
    {
        private readonly double minimum;
        private readonly double maximum;

        public NumberRangeAttribute(double minimum, double maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }

        public override bool IsValid(object value)
        {
            var valueAsDouble = value as double?;
            if (valueAsDouble == null)
            {
                return true;
            }

            return minimum <= valueAsDouble && valueAsDouble <= maximum;
        }
    }
}
