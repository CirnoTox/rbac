using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rbac.CoreBusiness.Services;
using rbac.Modals.Dto;
using rbac.Modals.Models;
using rbac.Repository.Base;
using SqlSugar;

namespace rbac.Controllers
{
    public class AuthController : BaseController
    {
        private readonly ISqlSugarClient _db;
        private readonly UserServices _userServices;

        public Repository<User> Repository { get; }

        public AuthController(ISqlSugarClient sqlSugar,Repository<User> repository,UserServices userServices)
        {
            _db = sqlSugar;
            Repository = repository;
            _userServices = userServices;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            string token = await _userServices.LoginAsync(login);
            return Ok(token);                    
        }
        
    }
}
