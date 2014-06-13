using System.Collections.Generic;

namespace MoodleWrapper
{
    using System.IO;
    using System.Net;
    using System.Text;

    public class Moodle
    {
        private string _token;
        private string _urlBase;

        public Moodle(string urlBase, string token)
        {
            _token = token;
            _urlBase = urlBase;
        }

        public List<MoodleUserInfo> GetUsers()
        {
            var response = ConsultaWebService<List<MoodleUserInfo>, MoodleNoParameter>("oktech_get_users", null);
            return response.Data;
        }

        public void DuplicateCourse(MoodleCurso curso, string fullname, string shortname)
        {
            var response = ConsultaWebService<MoodleDupCourseResult, MoodleDupCourseRequest>(
                "core_course_duplicate_course", new MoodleDupCourseRequest(curso, fullname, shortname));
        }

        public MoodleUserInfo GetUser(string username)
        {
            var response = ConsultaWebService<List<MoodleUserInfo>, MoodleSimpleParameterQuery>(
                "oktech_get_user_byusername", new MoodleSimpleParameterQuery("userinfo", username));

            return response.Data[0];
        }

        public List<MoodleCurso> GetCourses()
        {
            var response = ConsultaWebService<List<MoodleCurso>, MoodleNoParameter>("core_course_get_courses", null);
            return response.Data;
        }

        public void core_user_create_users(MoodleUserInfo usuario)
        {
            ConsultaWebService<MoodleUserAddResponse, MoodleUserInfo>(
                "core_user_create_users", usuario);
        }

        private RestResponse<T> ConsultaWebService<T, TU>(string funcao, TU parametro) where TU : MoodleRequest
        {
            var req = WebRequest.Create(MoodleUrl(funcao));
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = 0;
            if (parametro != null)
            {
                var dadosRequisicao = Encoding.UTF8.GetBytes(parametro.MoodleEncode());
                req.ContentLength = dadosRequisicao.Length;

                using (var writer = req.GetRequestStream())
                {
                    writer.Write(dadosRequisicao, 0, dadosRequisicao.Length);
                }
            }

            var response = req.GetResponse();
            using (var webStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(webStream))
                {
                    var resposta = reader.ReadToEnd();
                    return new RestResponse<T>(resposta);
                }
            }
        }

        private string MoodleUrl(string funcao)
        {
            return string.Format(
                "{0}/webservice/rest/server.php?wstoken={1}&wsfunction={2}&moodlewsrestformat=json",
                _urlBase,
                _token,
                funcao);
        }

        public List<MoodleCurso> GetCoursesByUser(MoodleUserInfo usuario)
        {
            var response = ConsultaWebService<List<MoodleCurso>, MoodleSimpleParameterQuery>(
                "core_enrol_get_users_courses", new MoodleSimpleParameterQuery("userid", usuario.id.ToString()));

            return response.Data;
        }

        public List<MoodleGrade> GetGrades(MoodleCurso curso)
        {
            var response = ConsultaWebService<List<MoodleGrade>, MoodleSimpleParameterQuery>(
                "oktech_get_course_grades", new MoodleSimpleParameterQuery("courseid", curso.idnumber));

            return response.Data;
        }

        public List<MoodleGrade> GetGrades(MoodleUserInfo usuario)
        {
            var response = ConsultaWebService<List<MoodleGrade>, MoodleSimpleParameterQuery>(
                "oktech_get_user_grades", new MoodleSimpleParameterQuery("userid", usuario.id.ToString()));

            return response.Data;
        }

        public List<MoodleGroup> GetCourseGroups(MoodleCurso curso)
        {
            var response =
                ConsultaWebService<List<MoodleGroup>, MoodleSimpleParameterQuery>(
                    "core_group_get_course_groups", new MoodleSimpleParameterQuery("courseid", curso.id.ToString()));

            return response.Data;
        }
    }

    public class MoodleDupCourseRequest : MoodleRequest
    {
        private int courseid;
        private string fullname;
        private string shortname;
        private int categoryid;


        public MoodleDupCourseRequest(MoodleCurso curso, string fullname, string shortname)
        {
            this.courseid = curso.id;
            this.categoryid = curso.categoryid;
            this.fullname = fullname;
            this.shortname = shortname;
        }

        #region Overrides of MoodleRequest

        protected override void FormatMoodleRequest()
        {
            this.AdicionaParametro("courseid", courseid.ToString());
            this.AdicionaParametro("fullname", fullname);
            this.AdicionaParametro("shortname", shortname);
            this.AdicionaParametro("categoryid", categoryid.ToString());
        }

        #endregion
    }

    public class MoodleDupCourseResult
    {
    }

    public class MoodleGroup
    {
        public int id { get; set; }
        public int courseid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int descriptionformat { get; set; }
        public string enrolmentkey { get; set; }
    }

    public class MoodleGrade
    {
    }
}