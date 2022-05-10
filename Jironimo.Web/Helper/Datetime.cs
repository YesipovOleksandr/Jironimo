namespace Jironimo.Web.Helper
{
    public static class Datetime
    {
        public static string GetCreatedAt(DateTime time)
        {
            return time.ToString($"MMM d") + $"th, {time.Year}";
        }
    }
}
