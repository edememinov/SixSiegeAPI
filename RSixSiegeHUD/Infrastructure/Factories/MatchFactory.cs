﻿using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchFactory
    {
        public async void CreateMatchAsync(dynamic jsonObject)
        {
            MatchProvider matchProvider = new MatchProvider();
            var match = matchProvider.GetMatch(jsonObject);
            Persistor persistor = new Persistor();
            await persistor.PersistObject(match);

        }

    }
}