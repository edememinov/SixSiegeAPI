using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSixSiegeHUD.Data.Concrete;
using RSixSiegeHUD.Data.Entities;
using RSixSiegeHUD.Data.ViewModel;
using RSixSiegeHUD.Infrastructure;

namespace RSixSiegeHUD.API.Controllers
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
        public IEnumerable<Match> Get()
        {
            return _context.Matches;
        }

        // GET: api/Object/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Object
        [HttpPost(Name = "Match")]
        [EnableCors]
        public void Post([FromBody] dynamic jsonObject)
        {
            GeneralObjectCreator generalObjectCreator = new GeneralObjectCreator();
            SiegeViewModel viewmodel = generalObjectCreator.SeperateObjects(jsonObject);

            if(viewmodel.CurrentMatch == null)
            {
                throw new Exception("No match");
            }

            if (_context.Users.Where(x => x.OverWolfId.Equals(viewmodel.CurrentUser.OverWolfId)).FirstOrDefault() == null)
            {
                if(viewmodel.CurrentUser != null)
                {
                    _context.Add(viewmodel.CurrentUser);
                    _context.SaveChanges();
                }
                
            }

            if (_context.Matches.Where(x => x.MatchToken.Equals(viewmodel.CurrentMatch.MatchToken)).FirstOrDefault() == null)
            {
                if(viewmodel.CurrentMatch != null)
                {
                    if (!viewmodel.CurrentMatch.MatchToken.Equals(""))
                    {
                        _context.Add(viewmodel.CurrentMatch);
                        _context.SaveChanges();
                    }
                    
                }
                
            }
            else
            {
                var thisMatch = _context.Matches.Where(x => x.MatchToken.Equals(viewmodel.CurrentMatch.MatchToken)).FirstOrDefault();
                if (thisMatch.ScoreBlueTeam < viewmodel.CurrentMatch.ScoreBlueTeam || thisMatch.ScoreOrangeTeam < viewmodel.CurrentMatch.ScoreOrangeTeam)
                {
                    thisMatch.ScoreBlueTeam = viewmodel.CurrentMatch.ScoreBlueTeam;
                    thisMatch.ScoreOrangeTeam = viewmodel.CurrentMatch.ScoreOrangeTeam;
                    _context.Entry(thisMatch).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                
            }

            var currentUser = _context.Users.Where(x => x.OverWolfId.Equals(viewmodel.CurrentUser.OverWolfId)).FirstOrDefault();
            var matchId = _context.Matches.Where(x => x.MatchToken.Equals(viewmodel.CurrentMatch.MatchToken)).FirstOrDefault().MatchId;
            

            if(_context.Rounds.Where(x => x.MatchId == matchId && x.RoundNumber == viewmodel.CurrentRound.RoundNumber).FirstOrDefault() == null)
            {
                if(viewmodel.CurrentRound != null)
                {
                    viewmodel.CurrentRound.MatchId = matchId;
                    viewmodel.CurrentRound.UserId = currentUser.UserId;
                    _context.Add(viewmodel.CurrentRound);
                    _context.SaveChanges();
                }
                
            }
            
            var roundId = _context.Rounds.Where(x => x.MatchId == matchId && x.RoundNumber == viewmodel.CurrentRound.RoundNumber).FirstOrDefault().RoundId;
            if(viewmodel.CurrentPlayers != null)
            {
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
                        if (_context.Players.Where(x => x.MatchId == matchId && x.RoundId == roundId && x.Name.Equals(localPlayer.Name)).FirstOrDefault() == null)
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
            }

            if(viewmodel.CurrentRoundOutcome != null)
            {
                viewmodel.CurrentRoundOutcome.RoundId = roundId;
                viewmodel.CurrentRoundOutcome.UserId = currentUser.UserId;
                _context.Add(viewmodel.CurrentRoundOutcome);
                _context.SaveChanges();
            }

            if (viewmodel.CurrentMatchOutcome != null)
            {
                viewmodel.CurrentMatchOutcome.MatchId = matchId;
                viewmodel.CurrentMatchOutcome.UserId = currentUser.UserId;
                _context.Add(viewmodel.CurrentMatchOutcome);
                _context.SaveChanges();
            }

            if(viewmodel.PlayerDeath != null)
            {
                viewmodel.PlayerDeath.RoundId = roundId;
                viewmodel.PlayerDeath.UserId = currentUser.UserId;
                _context.Add(viewmodel.PlayerDeath);
                _context.SaveChanges();
            }

            if (viewmodel.PlayerKill != null)
            {
                viewmodel.PlayerKill.RoundId = roundId;
                viewmodel.PlayerKill.UserId = currentUser.UserId;
                _context.Add(viewmodel.PlayerKill);
                _context.SaveChanges();
            }


            _context.SaveChanges();

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
