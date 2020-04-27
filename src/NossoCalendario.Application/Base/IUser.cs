using System;
using System.Collections.Generic;
using System.Text;

namespace NossoCalendario.Application.Base
{
    public interface IUser
    {
        Guid GetUserId();
        string GetUserEmail();
        string GetUserName();
        bool IsAuthenticated();
    }
}
