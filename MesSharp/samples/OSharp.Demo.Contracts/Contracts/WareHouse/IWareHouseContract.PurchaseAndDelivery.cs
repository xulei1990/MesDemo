﻿using System;
using System.Linq;
using System.Linq.Expressions;

using Mes.Core;
using Mes.Demo.Dtos.WareHouse;
using Mes.Demo.Models.WareHouse;
using Mes.Utility.Data;


namespace Mes.Demo.Contracts.WareHouse
{
    public partial interface IWareHouseContract : IDependency
    {
        /// <summary>
        /// 获取产线 信息查询数据集
        /// </summary>
        IQueryable<PurchaseAndDelivery> PurchaseAndDeliverys { get; }

        /// <summary>
        /// 检查产线信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的产线信息编号</param>
        /// <returns>产线信息是否存在</returns>
        bool CheckPurchaseAndDeliveryExists(Expression<Func<PurchaseAndDelivery, bool>> predicate, int id = 0);

        /// <summary>
        /// 添加产线信息
        /// </summary>
        /// <param name="dtos">要添加的产线信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddPurchaseAndDeliverys(params PurchaseAndDeliveryDto[] dtos);

        /// <summary>
        /// 更新产线信息
        /// </summary>
        /// <param name="dtos">包含更新信息的产线DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditPurchaseAndDeliverys(params PurchaseAndDeliveryDto[] dtos);

        /// <summary>
        /// 删除产线信息
        /// </summary>
        /// <param name="ids">要删除的产线信息编号</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeletePurchaseAndDeliverys(params int[] ids);

        OperationResult OutWareHouse(string sn);

        OperationResult InWareHouse(string model, string sn);

    }
}
