public static class StringUtility
{
    public static void ThorwIfNull(this string value, bool space = true)
    {
        if (space)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(value.GetType().Name);
        }
        else
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(value.GetType().Name);
        }
    }
}