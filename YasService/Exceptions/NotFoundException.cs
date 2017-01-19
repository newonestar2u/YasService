namespace YasService.Exceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException(string exceptionMessage) : base(exceptionMessage)
        { }
    }
}