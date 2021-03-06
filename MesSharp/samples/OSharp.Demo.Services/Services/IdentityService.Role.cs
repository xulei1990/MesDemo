﻿

using System;
using System.Linq;
using System.Linq.Expressions;

using Mes.Demo.Dtos.Identity;
using Mes.Demo.Models.Identity;
using Mes.Utility;
using Mes.Utility.Data;
using Mes.Utility.Extensions;


namespace Mes.Demo.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 角色信息查询数据集
        /// </summary>
        public IQueryable<Role> Roles
        {
            get { return RoleRepository.Entities; }
        }

        /// <summary>
        /// 检查角色信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的角色信息编号</param>
        /// <returns>角色信息是否存在</returns>
        public bool CheckRoleExists(Expression<Func<Role, bool>> predicate, int id = 0)
        {
            return RoleRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加角色信息信息
        /// </summary>
        /// <param name="dtos">要添加的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddRoles(params RoleDto[] dtos)
        {
            return RoleRepository.Insert(dtos);
        }

        /// <summary>
        /// 更新角色信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditRoles(params RoleDto[] dtos)
        {
            return RoleRepository.Update(dtos);
        }

        /// <summary>
        /// 删除角色信息信息
        /// </summary>
        /// <param name="ids">要删除的角色信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteRoles(params int[] ids)
        {
            return RoleRepository.Delete(ids);
        }

        public OperationResult SetRoleUsers(int id, int[] select)
        {
            var role = RoleRepository.GetByKey(id);
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            int[] beforeSelect = role.Users.Select(r => r.Id).ToArray();
            try
            {
                select.CheckNotNullOrEmpty("select");
            }
            catch (Exception)
            {
                select = new int[0];
            }

            beforeSelect.Except(select).ToList().ForEach(n => role.Users.Remove(UserRepository.GetByKey(n)));
            select.Except(beforeSelect).ToList().ForEach(n => role.Users.Add(UserRepository.GetByKey(n)));
            operationResult.Message = "修改了：" + UserRepository.UnitOfWork.SaveChanges() + "条数据";
            return operationResult;
        }

        public OperationResult SetRolePrivages(int id, int[] select)
        {
            var role = RoleRepository.GetByKey(id);
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            int[] beforeSelect = role.Menus.Select(r => r.Id).ToArray();
            try
            {
                select.CheckNotNullOrEmpty("select");
            }
            catch (Exception)
            {
                select = new int[0];
            }

            beforeSelect.Except(select).ToList().ForEach(n => role.Menus.Remove(MenuRepository.GetByKey(n)));
            select.Except(beforeSelect).ToList().ForEach(n => role.Menus.Add(MenuRepository.GetByKey(n)));
            operationResult.Message = "修改了：" + MenuRepository.UnitOfWork.SaveChanges() + "条数据";
            return operationResult;
        }
        #endregion
    }
}