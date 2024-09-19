using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rbac.CoreBusiness.Dtos;
using rbac.CoreBusiness.Qms;
using rbac.CoreBusiness.Services;
using rbac.CoreBusiness.Vms;
using rbac.Infra.Helper;
using rbac.Modals.Models;
using rbac.Repository.Base;
using SqlSugar;

namespace rbac.Controllers
{
    public class AuthController : BaseController
    {
        private readonly ISqlSugarClient _db;
        private readonly UserServices _userServices;
        private readonly ILogger<AuthController> _logger;

        public Repository<User> Repository { get; }

        public AuthController(ISqlSugarClient sqlSugar,Repository<User> repository,UserServices userServices,ILogger<AuthController> logger)
        {
            _db = sqlSugar;
            Repository = repository;
            _userServices = userServices;
            _logger = logger;
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
        
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(UserDto userDto)
        {
            string result = await _userServices.AddUserAsync(userDto);
            return Ok(result);
        }

        /// <summary>
        /// 获取全部用户，不确定是否会使用
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var result = await _userServices.GetAllUsersAsync();
            return Ok(result);            
        }

        /// <summary>
        /// 获取所有分页用户
        /// </summary>
        /// <param name="userQms"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("GetPagedUsers")]
        public async Task<ActionResult> GetPagedUsers(UserQms userQms)
        {
            var result =await _userServices.GetPagedUsersAsync(userQms);
            return Ok(result);           
        }
        /// <summary>
        /// 更新用户信息以及角色
        /// </summary>
        /// <param name="userVm"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserVm userVm)
        {
            var res = await _userServices.UpdateUserAsync(userVm);
            return Ok(res);
        } 
    }
}
