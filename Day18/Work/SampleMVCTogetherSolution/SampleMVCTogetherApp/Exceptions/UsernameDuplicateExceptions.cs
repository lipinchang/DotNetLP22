namespace SampleMVCTogetherApp.Exceptions
{
    public class UsernameDuplicateExceptions : Exception
    {
        string msg;
        public UsernameDuplicateExceptions()
        {
            msg = "Username already present";
        }
        public override string Message => msg;
    }
}
