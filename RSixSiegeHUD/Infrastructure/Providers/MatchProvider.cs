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

            var stringscore = score.ToString();

            var cleanStringScore = Regex.Replace(stringscore, @"\r\n?|\n", "");

            var scoreJsonClean = JObject.Parse(cleanStringScore);



            var blue = scoreJsonClean.GetValue("blue");
            var orange = scoreJsonClean.GetValue("orange");

            Models.Match match = new Models.Match()
            {
                ScoreBlueTeam = blue,
                ScoreOrangeTeam = orange
            };

           
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            byte[] name = Encoding.ASCII.GetBytes(user.UserName);
            byte[] timestamp = Encoding.ASCII.GetBytes(unixTimestamp.ToString());
            var combinedBytes = name.Concat(timestamp).ToString();

            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedBytes);
            var hash = sha256.ComputeHash(bytes);

            match.MatchToken = hash;          

            return match;
        }
    }
}
