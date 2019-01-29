//using Microsoft.AspNetCore.Mvc;
//using RSixSiegeHUD.Data;
//using RSixSiegeHUD.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RSixSiegeHUD.Infrastructure
//{
//    public class Persistor : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public Persistor(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> PersistObject(Object obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var objectType = obj.GetType();

//            if(objectType == typeof(Kill))
//            {
//                _context.Kills.Add(obj);
//            }
//            else if ()
//            {

//            }
//            db.Add(obj);
//            await _context.SaveChangesAsync();

//            return Ok(death);
//        }
//    }
//}
