﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoJun.Shadow.Api.ContractModel.External.Test.v1;
using PoJun.Shadow.Api.IService.Test;
using PoJun.Shadow.ContractModel;

namespace PoJun.Shadow.WebApi.Controllers.Test.v1
{
    //[Route("api/[controller]")]
    [Route("api/Test/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region 初始化

        private IUserInfoService userInfoService;
        private IComponentContext componentContext;//Autofac上下文

        public TestController(IComponentContext _componentContext, IUserInfoService _userInfoService)
        {
            //默认
            userInfoService = _userInfoService;
            ////指定V1
            //_v1userInfoService = _componentContext.ResolveNamed<IUserInfoService>(typeof(MyAutofac.Api.Service.v1.UserInfoService).Name);
            ////指定V2
            //_v2userInfoService = _componentContext.ResolveNamed<IUserInfoService>(typeof(MyAutofac.Api.Service.v2.UserInfoService).Name);
            ////指定V0
            //_v0userInfoService = _componentContext.ResolveNamed<IUserInfoService>(typeof(MyAutofac.Api.Service.V0UserInfoService).Name);
            ////指定V3
            //_v3userInfoService = _componentContext.ResolveNamed<IUserInfoService>(typeof(MyAutofac.Api.Service.v3.UserInfoService).Name);
        }

        #endregion

        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            return $"[破军测试接口v1.0]-{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public Task<BaseResponse> Add(AddUserParam param)
        {
            /**
             * MongoDB底层驱动会自动创建库和表
             * 我们只需要编写好实体类即可（实体类的字段与数据库一一对应）【PoJun.Shadow.Entity】
             */
            return userInfoService.Add(param);
        }
    }
}