﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Mes.Utility.Extensions;


namespace Mes.Web.Security
{
    /// <summary>
    /// 在线用户存储基类
    /// </summary>
    public abstract class OnlineUserStoreBase
    {
        /// <summary>
        /// 获取网站在线用户
        /// </summary>
        public OnlineUser GetCurrentSiteUser(IPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            string name = user.Identity.Name;
            return Get(name, OnlineType.Site);
        }

        /// <summary>
        /// 获取客户端在线用户
        /// </summary>
        public OnlineUser GetCurrentApiUser(IPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            string name = user.Identity.Name;
            return Get(name, OnlineType.Client);
        }

        /// <summary>
        /// 获取指定类型的在线用户信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="onlineType">在线类型</param>
        /// <returns></returns>
        public abstract OnlineUser Get(string name, OnlineType onlineType);

        /// <summary>
        /// 设置或更新在线用户信息
        /// </summary>
        /// <param name="user">在线用户信息</param>
        public abstract void Set(OnlineUser user);

        /// <summary>
        /// 移除在线用户信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="onlineType">在线类型</param>
        public abstract void Remove(string name, OnlineType onlineType);
    }
}