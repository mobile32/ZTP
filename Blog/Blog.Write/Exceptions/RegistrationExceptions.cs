using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Exceptions
{
    public class UsernameTakenException: ApplicationException{}
    public class PasswordsDontMatchException: ApplicationException { }
}
