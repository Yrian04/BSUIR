using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor.Exceptions
{
    internal class EdgeIncidentNullException : Exception
    {
        public EdgeIncidentNullException()
        {
        }

        public EdgeIncidentNullException(string? message) : base(message)
        {
        }

        public EdgeIncidentNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EdgeIncidentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
