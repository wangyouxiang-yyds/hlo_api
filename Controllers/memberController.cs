using HLO_API.Dtos;
using HLO_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HLO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class memberController : ControllerBase
    {

        private readonly hlo_dbContext _dbContext;
        public memberController(hlo_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<memberController>
        [HttpGet]
        // 拿取所有會員的資料(暫定)
        public IEnumerable<memberDto> Get()
        {

            var get_all_member = from member in _dbContext.memberdata
                                 select new memberDto
                                 {
                                     GUID = member.GUID,
                                     Account = member.Account,
                                     password = member.password,
                                     username = member.username,
                                     createtime = member.createtime,
                                     
                                 };
            return get_all_member;
        }

        // GET api/<memberController>/5
        [HttpGet("{guid}")]
        public memberDto Get(string guid)
        {
            var get_guid = (from member in _dbContext.memberdata
                            where member.GUID == guid
                            select new memberDto
                            {
                                GUID = member.GUID,
                                Account = member.Account,
                                username = member.username,
                                createtime = member.createtime,
                                Character = (from b in _dbContext.character
                                             where member.ID == b.memberID
                                             select new CharacterDtos
                                             {
                                                 PlayerID = b.PlayerID,
                                                 PlayerName = b.PlayerName,
                                                 Level = b.Level,
                                                 HP = b.HP,
                                                 MP = b.MP,
                                                 Coin = b.Coin
                                               
                                             }).ToList()


                            }).SingleOrDefault();
            return get_guid;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginData)
        {
            var member = _dbContext.memberdata.SingleOrDefault(m => m.GUID == loginData.GUID);
            if (member == null)
            {
                return NotFound(new { message = "Member not found." });
            }

            if (member.password != loginData.password)
            {
                return Unauthorized(new { message = "Incorrect password." });
            }

            return Ok(new { message = "Login successful!" });
        }



        // 新增會員資料
        // POST api/<memberController>  
        [HttpPost]
        public IActionResult Post([FromBody] MemberPOSTDtos value)
        {

            var existMember = _dbContext.memberdata
                .Any(m => m.Account == value.Account || m.username == value.username);

            if (existMember)
            {
                // 如果 account 或 username 重複，回傳包含 errorCode 的 JSON 物件
                return Conflict(new { errorCode = 409, message = "Account or Username already exists." });
            }
            memberdata insert = new memberdata
            {
                Account = value.Account,
                password = value.password,
                username = value.username,  
                createtime = DateTime.Now,
                GUID = Guid.NewGuid().ToString() // 隨機生成 GUID
            };
            _dbContext.memberdata.Add(insert);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = insert.GUID }, new { message = "Member created successfully." });
        }

        // PUT api/<memberController>/5
        [HttpPut("{guid}")]
        // 更新會員資料
        public void Put(string guid, [FromBody] memberdata value)
        {
            var update = (from a in _dbContext.memberdata
                         where a.GUID == guid
                         select a).Single();

            if (update != null)
            {
                
                update.password = value.password;
                update.username = value.username;
               
                _dbContext.SaveChanges();
            }
        }

        // DELETE api/<memberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
