using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSixSiegeHUD.Data;
using RSixSiegeHUD.Infrastructure;
using RSixSiegeHUD.Models;
using RSixSiegeHUD.ViewModel;

namespace RSixSiegeHUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Object
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Object/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Object
        [HttpPost(Name = "Match")]
        //[EnableCors("AllowAnyOrigin")]
        public OkResult Post([FromBody] dynamic jsonObject)
        {
            GeneralObjectCreator generalObjectCreator = new GeneralObjectCreator();
            SiegeViewModel viewmodel = generalObjectCreator.SeperateObjects(jsonObject);

            if (_context.Users.Where(x => x.OverWolfId.Equals(viewmodel.CurrentUser.OverWolfId)).FirstOrDefault() == null)
            {
                _context.Add(viewmodel.CurrentUser);
                _context.SaveChanges();
            }

            if (_context.Matches.Where(x => x.MatchToken == viewmodel.CurrentMatch.MatchToken).FirstOrDefault() == null)
            {
                _context.Add(viewmodel.CurrentMatch);
                _context.SaveChanges();
            }

            var currentUser = _context.Users.Where(x => x.OverWolfId.Equals(viewmodel.CurrentUser.OverWolfId)).FirstOrDefault();
            var matchId = _context.Matches.Where(x => x.MatchToken.Equals(viewmodel.CurrentMatch.MatchToken)).FirstOrDefault().MatchId;
            

            if(_context.Rounds.Where(x => x.MatchId == matchId && x.RoundNumber == viewmodel.CurrentRound.RoundNumber).FirstOrDefault() == null)
            {
                viewmodel.CurrentRound.MatchId = matchId;
                viewmodel.CurrentRound.UserId = currentUser.UserId;
                _context.Add(viewmodel.CurrentRound);
                _context.SaveChanges();
            }
            
            var roundId = _context.Rounds.Where(x => x.MatchId == matchId && x.RoundNumber == viewmodel.CurrentRound.RoundNumber).FirstOrDefault().RoundId;
            foreach (var player in viewmodel.CurrentPlayers)
            {
                if (player.IsLocal)
                {
                    player.UserId = currentUser.UserId;
                    LocalPlayer localPlayer = new LocalPlayer()
                    {
                        Deaths = viewmodel.CurrentLocalPlayer.Deaths,
                        Health = viewmodel.CurrentLocalPlayer.Health,
                        Kills = viewmodel.CurrentLocalPlayer.Kills,
                        RoundId = roundId,
                        IsLocal = true,
                        Name = player.Name,
                        MatchId = matchId,
                        Score = viewmodel.CurrentLocalPlayer.Score,
                        UserId = currentUser.UserId,
                        UbisoftAccountToken = viewmodel.CurrentUser.UbisoftId
                    };
                    if(_context.Players.Where(x => x.MatchId == matchId && x.RoundId == roundId && x.Name.Equals(localPlayer.Name)).FirstOrDefault() == null)
                    {
                        _context.Add(localPlayer);
                    }
                    
                }
                else
                {
                    player.MatchId = matchId;
                    player.RoundId = roundId;

                    if (_context.Players.Where(x => x.MatchId == matchId && x.RoundId == roundId && x.Name.Equals(player.Name)).FirstOrDefault() == null)
                    {
                        _context.Add(player);
                    }
                }
                _context.SaveChanges();

            }

            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/Object/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
