using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleWrapper
{
    using System.Web;

    public abstract class MoodleRequest
    {
        private Dictionary<string, string> _parametros = new Dictionary<string, string>();

        protected string _moodleArrayName = string.Empty;

        public string MoodleSingleObjectEncode()
        {
            LimpaParametros();
            FormatMoodleRequest();
            var resultado = ConcatenaParametros();
            return resultado;
        }

        public string MoodleEncode(int index = 0)
        {
            if (_moodleArrayName == string.Empty) return this.MoodleSingleObjectEncode();

            LimpaParametros();
            FormatMoodleRequest();
            var resultado = ConcatenaParametrosEmArray(index);
            return resultado;
        }

        private string ConcatenaParametros()
        {
            var resultado = new List<string>();

            foreach (var parametro in _parametros)
            {
                resultado.Add(String.Format("{0}={1}", parametro.Key, parametro.Value));
            }

            return String.Join("&", resultado);
        }

        private string ConcatenaParametrosEmArray(int index)
        {
            var resultado = new List<string>();

            foreach (var parametro in _parametros)
            {
                resultado.Add(
                    String.Format("{0}[{1}][{2}]={3}", _moodleArrayName, index, parametro.Key, parametro.Value));
            }

            return string.Join("&", resultado);
        }

        protected abstract void FormatMoodleRequest();

        protected void LimpaParametros()
        {
            _parametros.Clear();
        }

        protected void AdicionaParametro(string nome, string valor)
        {
            _parametros.Add(nome, HttpUtility.UrlEncode(valor));
        }
    }
}
