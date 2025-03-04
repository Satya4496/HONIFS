namespace HONIFS.Leads
{
    public static class LeadConsts
    {
        private const string DefaultSorting = "{0}FirstName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Lead." : string.Empty);
        }

    }
}