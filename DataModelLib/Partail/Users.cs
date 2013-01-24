namespace DataModelLib
{
    public partial class UserService
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
