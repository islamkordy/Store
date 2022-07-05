namespace Store.Application.Exceptions
{
    public  class InternalServiceError : Exception
    {
        public InternalServiceError(string messege) : base(messege)
        {
        }
    }
}
