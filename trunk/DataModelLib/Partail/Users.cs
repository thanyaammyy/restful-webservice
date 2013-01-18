namespace DataModelLib
{
    public partial class User
    {
        public string StatusLabel
        {
            get
            {
                if (Status == 1)
                {
                    return "Active";
                }
                return "Inactive";
            }
        }
    }
}
