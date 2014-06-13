namespace MoodleWrapper
{
    using System.Web;

    public class MoodleUserInfo : MoodleRequest
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string auth { get; set; }
        //Auth plugins include manual, ldap, imap, etc
        public string idnumber { get; set; }
        //An arbitrary ID code number perhaps from the institution
        public string lang { get; set; }
        //Language code such as "en", must exist on server
        //public string theme { get; set; } //Theme name such as "standard", must exist on server
        //public string timezone { get; set; } //Timezone code such as Australia/Perth, or 99 for default
        //public int mailformat { get; set; } //Mail format code is 0 for plain text, 1 for HTML etc
        //public string description { get; set; } 
        //public string city { get; set; } 
        //public string country { get; set; } //Home country code of the user, such as AU or CZ

        protected override void FormatMoodleRequest()
        {
            _moodleArrayName = "users";
            AdicionaParametro("username", username);
            AdicionaParametro("password", password);
            AdicionaParametro("firstname", firstname);
            AdicionaParametro("lastname", lastname);
            AdicionaParametro("email", email);
            AdicionaParametro("idnumber", idnumber);
        }
    }
}