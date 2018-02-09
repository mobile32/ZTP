using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Exceptions
{
    public class InvalidLoginException: ApplicationException { }
    public class InvalidPasswordException : ApplicationException { }
    public class UserNotActiveException : ApplicationException { }
}
