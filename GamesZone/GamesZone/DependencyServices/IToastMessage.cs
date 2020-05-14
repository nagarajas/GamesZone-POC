using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.DependencyServices
{
    public interface IToastMessageService
    {
        void Show(string message);
    }
}
