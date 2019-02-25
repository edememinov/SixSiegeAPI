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
    public class MatchFactory
    {
        public Models.Match CreateMatch(dynamic jsonObject, User user)
        {
            if (CheckIfPlayersEmpty(jsonObject) == true)
            {
                MatchProvider matchProvider = new MatchProvider();
                var match = matchProvider.GetMatch(jsonObject, user);

                return match;
            }

            else
            {
                return null;
            }
        }

        private bool CheckIfPlayersEmpty(dynamic jsonObject)
        {
            var playersJson = jsonObject.GetValue("players");
            if (playersJson == null)
            {
                return false;
            }
            var stringPlayer = playersJson.ToString();
            var cleanStringPlayer = Regex.Replace(stringPlayer, @"\r\n?|\n", "");

            var playerJsonClean = JObject.Parse(cleanStringPlayer);

            var jsonPlayer0 = playerJsonClean.GetValue("roster_0");
            var jsonPlayer1 = playerJsonClean.GetValue("roster_1");
            var jsonPlayer2 = playerJsonClean.GetValue("roster_2");
            var jsonPlayer3 = playerJsonClean.GetValue("roster_3");
            var jsonPlayer4 = playerJsonClean.GetValue("roster_4");
            var jsonPlayer5 = playerJsonClean.GetValue("roster_5");
            var jsonPlayer6 = playerJsonClean.GetValue("roster_6");
            var jsonPlayer7 = playerJsonClean.GetValue("roster_7");
            var jsonPlayer8 = playerJsonClean.GetValue("roster_8");
            var jsonPlayer9 = playerJsonClean.GetValue("roster_9");
            var jsonPlayer10 = playerJsonClean.GetValue("roster_10");
            var jsonPlayer11 = playerJsonClean.GetValue("roster_11");




            if (jsonPlayer0 == null && jsonPlayer1 == null && jsonPlayer2 == null && jsonPlayer3 == null && jsonPlayer4 == null && jsonPlayer5 == null && jsonPlayer6 == null && jsonPlayer7 == null && jsonPlayer8 == null && jsonPlayer9 == null && jsonPlayer10 == null && jsonPlayer11 == null)
            {
                return false;
            }

            return true;
        }
    }
}
