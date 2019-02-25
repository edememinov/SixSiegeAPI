using Newtonsoft.Json.Linq;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchProvider
    {
        public object GetMatch(dynamic jsonObject, User user)
        {
            dynamic matchJson = jsonObject.GetValue("match");
            dynamic score = matchJson.GetValue("score");

            dynamic token = jsonObject.GetValue("info");
            
           
            if(token == null)
            {
                return null;
            }

            token = token.ToString();
            var stringscore = score.ToString();

            var cleanStringScore = Regex.Replace(stringscore, @"\r\n?|\n", "");

            var scoreJsonClean = JObject.Parse(cleanStringScore);



            var blue = scoreJsonClean.GetValue("blue");
            var orange = scoreJsonClean.GetValue("orange");

            Models.Match match = new Models.Match()
            {
                ScoreBlueTeam = blue,
                ScoreOrangeTeam = orange,
                MatchToken  = token
            };
   

            return match;
        }

   
    }
}
