namespace PoC.Moodle
{
    using System;
    using System.Linq;

    using MoodleWrapper;

    class Program
    {
        static void Main(string[] args)
        {
            var moodle = new Moodle("http://ukko/moodle", "e5fde11886e0d3b30d90767c45378deb");
            var cursosOfertados = moodle.GetCourses();

            foreach (var curso in cursosOfertados)
            {
                Console.WriteLine(curso.fullname);
                if (curso.fullname.Equals("At.en.der"))
                {
                    moodle.DuplicateCourse(curso, "At.en.der.2", "At.en.der.2");
                }
            }

            var usuarios = moodle.GetUsers();

            if (!usuarios.Any(u => u.username == "110233333315"))
            {
                var novoUsuario = new MoodleUserInfo
                    {
                        username = "22046666615",
                        password = "Senh@Moodl3",
                        firstname = "Valmir",
                        lastname = "Sales",
                        lang = "pt_br",
                        auth = "manual",
                        email = "22046666615@cpf.br",
                        idnumber = "110233333345"
                    };

                Console.WriteLine(novoUsuario.MoodleEncode());
                moodle.core_user_create_users(novoUsuario);
            }

            var usuario = moodle.GetUser("kleber.sales");
            Console.WriteLine(usuario.firstname);

            var cursosDoUsuario = moodle.GetCoursesByUser(usuario);
            foreach (var curso in cursosDoUsuario)
            {
                var grupos = moodle.GetCourseGroups(curso);
                Console.WriteLine("------------------");
                foreach (var grupo in grupos)
                {
                    Console.WriteLine("grupo: " + grupo.name);
                    //var participantes = moodle.GetEnrolled(grupo);
                }
            }

            Console.ReadLine();
        }
    }
}
