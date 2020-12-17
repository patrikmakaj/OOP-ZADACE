using System;
using System.Runtime.Serialization;

namespace DZ4
{
    [Serializable]
    public class TvException : SystemException
    {
        public string Title { get; private set; }
        public TvException() { }
        public TvException(string message, string Title) : base(message)
        {
            this.Title = Title;
        }
        public TvException(string message, Exception innerException) : base(message,innerException)
        { }
        protected TvException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
