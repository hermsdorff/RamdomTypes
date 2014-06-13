namespace MoodleWrapper
{
    using System;

    public class MoodleSimpleParameterQuery:MoodleRequest
    {
        private readonly string _param;
        private readonly string _value;

        public MoodleSimpleParameterQuery(String paramName, string paramValue)
        {
            _param = paramName;
            _value = paramValue;
        }

        #region Overrides of MoodleRequest

        protected override void FormatMoodleRequest()
        {
            this.AdicionaParametro(_param, _value);
        }

        #endregion
    }
}