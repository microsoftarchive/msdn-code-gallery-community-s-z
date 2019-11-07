namespace ClientWorkflow.Model
{
    public static class CountModelFactory
    {
        #region Public Methods

        public static ICountModel CreateModel(object extension = null)
        {
            return new CountModel(extension);
        }

        #endregion
    }
}