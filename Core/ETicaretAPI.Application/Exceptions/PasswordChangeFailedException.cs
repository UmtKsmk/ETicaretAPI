namespace ETicaretAPI.Application.Exceptions
{
    public class PasswordChangeFailedException : Exception
    {
        public PasswordChangeFailedException() : base("An unexpected error has occurred while updating password.")
        {
        }

        public PasswordChangeFailedException(string? message) : base(message)
        {
        }

        public PasswordChangeFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
