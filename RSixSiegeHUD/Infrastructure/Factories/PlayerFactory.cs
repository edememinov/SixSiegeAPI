using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class PlayerFactory
    {
        public async void CreateLocalPlayerAsync(dynamic jsonObject, Round round, User user)
        {
            var playersJson = jsonObject.GetValue("players");
            
            for(var x = 0; x < 10; x++)
            {
                var roster = "roster" + x;
                var jsonPlayer = jsonObject.GetValue(roster);
                if(jsonPlayer != null)
                {
                    Player player = new Player()
                    {
                        IsLocal = jsonPlayer.GetValue("is_local"),
                        Name = jsonPlayer.GetValue("name")
                    };
                    if (player.IsLocal == true)
                    {
                        player.UbisoftAccountToken = user.UbisoftId;
                    }

                    Persistor persistor = new Persistor();
                    await persistor.PersistObject(player);
                }
                



            }



           
        }
    }
}
