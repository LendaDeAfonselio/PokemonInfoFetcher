using System;
using System.Runtime.Serialization;

namespace PokemonInfoFetcher.Domain
{
    [Serializable]
    internal class NoSmogonDataException : Exception
    {
        public NoSmogonDataException()
        {
        }

        public NoSmogonDataException(string message) : base(message)
        {
        }

        public NoSmogonDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSmogonDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}