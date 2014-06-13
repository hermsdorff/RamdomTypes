namespace MoodleWrapper
{
    public struct MoodleCurso
    {
        public int id { get; set; }
        public string shortname { get; set; }
        public int categoryid { get; set; }
        public int categorysortorder { get; set; }
        public string fullname { get; set; }
        public string idnumber { get; set; }
        public string summary { get; set; }
        public int summaryformat { get; set; }
        public string format { get; set; }
        public int showgrades { get; set; }
        public int newsitems { get; set; }
        public int startdate { get; set; }
        public int numsections { get; set; }
        public int maxbytes { get; set; }
        public int showreports { get; set; }
        public int visible { get; set; }
        public int hiddensections { get; set; }
        public int groupmode { get; set; }
        public int groupmodeforce { get; set; }
        public int defaultgroupingid { get; set; }
        public int timecreated { get; set; }
        public int timemodified { get; set; }
        public int enablecompletion { get; set; }
        public int completionstartonenrol { get; set; }
        public int completionnotify { get; set; }
        public string lang { get; set; }
        public string forcetheme { get; set; }
    }
}