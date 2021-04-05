using System;
using System.Runtime.Serialization;

#nullable enable

namespace FrameworkCore.Helpers
{
    /// <summary>
    ///     The Exception That Is Thrown When The Criteria Specified For Accessing An Element In A Collection Does Not Match
    ///     Any Item In The Collection
    /// </summary>
    public class ItemNotFoundException : SystemException
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string? message) : base(message)
        {
        }

        public ItemNotFoundException(string? message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}