using System;

namespace Shared.FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract AreEquals(Guid val, Guid comparer, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val.ToString() != comparer.ToString())
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(Guid val, Guid comparer, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val.ToString() == comparer.ToString())
                AddNotification(property, message);

            return this;
        }

        public ValidationContract GuidIsEmptyOrNull(Guid val, string property, string message)
        {
            if (val == null || val == Guid.Empty)
                AddNotification(property, message);

            return this;
        }  
    }
}