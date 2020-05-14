using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.PageModels
{
    public class CommonSearchPageModel : FreshBasePageModel
    {
        public bool IsGamesSearch
        {
            get;set;
        }

        public bool IsPlayerSearch
        {
            get; set;
        }
    }
}
