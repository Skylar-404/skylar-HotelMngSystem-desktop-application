using hotelmngsystem.Models;

namespace hotelmngsystem.Helpers
{
    /// <summary>
    /// Holds the currently signed-in user for the lifetime of the application.
    /// </summary>
    internal static class SessionHelper
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsAdmin => CurrentUser != null && CurrentUser.IsAdmin;

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
