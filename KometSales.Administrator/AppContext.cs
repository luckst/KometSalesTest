namespace KometSales.Administrator
{
    public class AppContext
    {
        private static string authToken;

        public static string AuthToken
        {
            get { return authToken; }
            set { authToken = value; }
        }
    }
}
