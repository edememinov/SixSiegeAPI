using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchProvider
    {
        public object GetMatch(dynamic jsonObject, User user)
        {
            var matchJson = jsonObject.GetValue("match");
            var score = matchJson.GetValue("score");
            Match match = new Match()
            {
                ScoreBlueTeam = score.GetValue("blue"),
                ScoreOrangeTeam = score.GetValue("orange")
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
