using System;

namespace Blog.Command.Exceptions
{
    public class InvalidLoginException: ApplicationException { }
    public class InvalidPasswordException : ApplicationException { }
    public class UserNotActiveException : ApplicationException { }
}
