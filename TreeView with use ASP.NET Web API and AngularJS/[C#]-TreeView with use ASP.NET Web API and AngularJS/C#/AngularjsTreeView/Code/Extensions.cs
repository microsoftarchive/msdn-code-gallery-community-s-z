namespace AngularjsTreeView.DomainModel
{
    public static class Extensions
    {
        public static int? TryParseToInt(this object value)
        {
            int result;
            if (value != null && int.TryParse(value.ToString(), out result))
            {
                return result;
            }

            return null;
        }
    }
}