namespace MoodleWrapper
{
    using System;

    public class MoodleNoParameter : MoodleRequest
    {
        #region Implementation of IMoodleRequest

        public string MoodleEncode()
        {
            throw new NotImplementedException();
        }

        protected override void FormatMoodleRequest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}