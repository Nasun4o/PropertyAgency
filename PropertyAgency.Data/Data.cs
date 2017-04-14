namespace PropertyAgency.Data
{
    public class Data
    {
        private static PropertyAgencyContext context;

        public static PropertyAgencyContext Context => context ?? (context = new PropertyAgencyContext());
    }
}
