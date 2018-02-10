using System;

namespace Blog.Command.Exceptions
{
    public class UsernameTakenException: ApplicationException{}
    public class PasswordsDontMatchException: ApplicationException { }
}
