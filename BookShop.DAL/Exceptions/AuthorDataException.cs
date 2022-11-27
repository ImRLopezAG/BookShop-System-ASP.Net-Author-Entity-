using System;
using System.Runtime.Serialization;

namespace Exceptions {
  [Serializable]
  public class AuthorDataException : Exception {
    public AuthorDataException() {
    }

    public AuthorDataException(string message) : base(message) {
    }

    public AuthorDataException(string message, Exception innerException) : base(message, innerException) {
    }

    protected AuthorDataException(SerializationInfo info, StreamingContext context) : base(info, context) {
    }
  }
}