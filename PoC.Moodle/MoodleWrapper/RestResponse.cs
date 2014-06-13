namespace MoodleWrapper
{
    using System;
    using System.Web.Script.Serialization;

    internal class RestResponse<T>
    {
        public T Data { get; private set; }

        public String RawData { get; private set; }

        public RestResponse(string raw)
        {
            RawData = raw;
            var serializador = new JavaScriptSerializer();
            Data = serializador.Deserialize<T>(RawData);
        }
    }
}