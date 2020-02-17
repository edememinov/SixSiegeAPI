using Newtonsoft.Json.Linq;
using RSixSiegeHUD.Data.Entities;
using System.Text.RegularExpressions;
using Match = RSixSiegeHUD.Data.Entities.Match;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchProvider
    {
        public object GetMatch(dynamic jsonObject, User user)
        {
            dynamic matchJson = jsonObject.GetValue("match");

            if (matchJson == null)
            {
                return null;
            }

           
            dynamic score = matchJson.GetValue("score");

            if (score == null)
            {
                return null;
            }

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

            Match match = new Match()
            {
                ScoreBlueTeam = blue,
                ScoreOrangeTeam = orange,
                MatchToken  = token
            };
   

            return match;
        }

   
    }
}
