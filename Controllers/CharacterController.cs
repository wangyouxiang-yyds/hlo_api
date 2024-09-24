using HLO_API.Dtos;
using HLO_API.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Expr;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HLO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly hlo_dbContext _dbContext;
        public CharacterController(hlo_dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CharacterController>
        [HttpGet]
        //拿取所有玩家資料
        public IEnumerable<CharacterDtos> Get()
        {
            var get_all_character = from character in _dbContext.character
                                    join job in _dbContext.job on character.JobId equals job.JobId
                                    join race in _dbContext.race on character.RaceId equals race.RaceId
                                    select new CharacterDtos
                                    {
                                        PlayerID = character.PlayerID,
                                        PlayerName = character.PlayerName,
                                        Level = character.Level,
                                        HP  = character.HP,
                                        MP = character.MP,
                                        Exp = character.Exp,
                                        //JobId = character.JobId,
                                        JobName = job.JobName,
                                        RaceName = race.RaceName,
                                        RaceId = character.RaceId,
                                        Coin = character.Coin,
                                        BagCount = character.BagCount 
                                    };

            return get_all_character;
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}")]
        // 拿取指定玩家
        public CharacterDtos Get(int id)
        {
            var get_all_character = (from character in _dbContext.character
                                     join job in _dbContext.job on character.JobId equals job.JobId
                                     join race in _dbContext.race on character.RaceId equals race.RaceId
                                     where character.PlayerID == id
                                    select new CharacterDtos
                                    {
                                        PlayerID = character.PlayerID,
                                        PlayerName = character.PlayerName,
                                        Level = character.Level,
                                        HP = character.HP,
                                        MP = character.MP,
                                        Exp = character.Exp,
                                       // JobId=character.JobId,
                                        JobName = job.JobName,
                                        RaceName = race.RaceName,
                                        Coin = character.Coin,
                                        BagCount = character.BagCount

                                    }).SingleOrDefault();

            return get_all_character;
        }

        // POST api/<CharacterController>
        [HttpPost]

        // 新增角色(新增一筆資料)
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}

