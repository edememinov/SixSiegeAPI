using Newtonsoft.Json.Linq;
using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class PlayerFactory
    {
        public List<Player> CreatePlayers(dynamic jsonObject, Round round, User user)
        {
            
            var playersJson = jsonObject.GetValue("players");
            if (playersJson == null)
            {
                return null;
            }
            var stringscore = playersJson.ToString();
            var cleanStringScore = Regex.Replace(stringscore, @"\r\n?|\n", "");

            var scoreJsonClean = JObject.Parse(cleanStringScore);

            List<Player> players = new List<Player>();
            
            for(var x = 0; x < 10; x++)
            {
                var roster = "roster_" + x;
                var jsonPlayer = scoreJsonClean.GetValue(roster);
                if (jsonPlayer != null)
                {
                    var stringjsonPlayer = jsonPlayer.ToString();
                    var cleanStringPlayer = Regex.Replace(stringjsonPlayer, @"\r\n?|\n", "");
                    var playerJsonClean = JObject.Parse(cleanStringPlayer);

                    if (jsonPlayer != null)
                    {
                        var stringBool = playerJsonClean.GetValue("is_local");

                        Player player = new Player()
                        {
                            Name = playerJsonClean.GetValue("name")
                        };
                        if (stringBool.ToString().ToLower().Equals("true"))
                        {
                            player.IsLocal = true;
                        }
                        else
                        {
                            player.IsLocal = false;
                        }

                        if (player.IsLocal == true)
                        {
                            player.UbisoftAccountToken = user.UbisoftId;
                        }

                        players.Add(player);

                    }
                }
               
            }
            return players;
        }
    }
}
