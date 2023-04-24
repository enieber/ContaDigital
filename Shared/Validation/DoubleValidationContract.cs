namespace Shared.FluentValidator.Validation
{
    public partial class ValidationContract
    {
        #region AreNotEquals
        public ValidationContract AreNotEquals(double val, string property, string message)
        {
            if (val <= 0)
                AddNotification(property, message);

            return this;
        }
        #endregion

    }
}
