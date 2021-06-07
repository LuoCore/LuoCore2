﻿using DataTransferModels;
using DataTransferModels.BasePermission.Request;
using DataTransferModels.BasePermission.Response;
using EntitysModels;
using IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;

namespace Repository
{
    public class PermissionRepository : SqlSugarRepository<ISystemLogsRepository>, IPermissionRepository
    {
        public PermissionRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }
        /// <summary>
        /// 按父级ID查询
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public ResultDto<List<Base_Permission>> ReadPermissionByParentId(string parentId) 
        {
            ResultDto<List<Base_Permission>> res = new ResultDto<List<Base_Permission>>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res.Status = true;
                    res.Data = new List<Base_Permission>();
                    res.Data = db.Queryable<Base_Permission>()
                    .Where(x => x.PermissionParentId.Equals(parentId))
                    .ToList();
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }


        public ResultDto<ResponsePermissionListDto> ReadPermissionTableData(RequestPermissionDto req) 
        {
            ResultDto<ResponsePermissionListDto> res = new ResultDto<ResponsePermissionListDto>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res.Status = true;
                    var selectSql= db.Queryable<Base_Permission,Base_Permission>((p,p2)=>
                    new JoinQueryInfos(JoinType.Left, p.PermissionParentId.Equals(p2.PermissionId)&&p2.IsValid.Equals(true)));

                   var whereSql= selectSql.WhereIF(!string.IsNullOrEmpty(req.PermissionId), p => p.PermissionId.Equals(req.PermissionId))
                    .WhereIF(!string.IsNullOrEmpty(req.PermissionName), p => p.PermissionName.Equals(req.PermissionName))
                    .WhereIF(!string.IsNullOrEmpty(req.PermissionAction), p => p.PermissionAction.Equals(req.PermissionAction))
                    .WhereIF(!string.IsNullOrEmpty(req.PermissionParentId), p => p.PermissionParentId.Equals(req.PermissionParentId))
                    .WhereIF(!Equals(null, req.PermissionType), p => p.PermissionType.Equals(req.PermissionType))
                    .WhereIF(!Equals(null, req.StartTime)&&!Equals(null, req.EndTime), p => SqlFunc.Between(p.CreateTime,req.StartTime,req.EndTime))
                    .WhereIF(!string.IsNullOrEmpty(req.CreateName), p => p.CreateName.Equals(req.CreateName))
                    .WhereIF(!Equals(null, req.IsValid), p => p.IsValid.Equals(req.IsValid));

                    res.Data=new ResponsePermissionListDto() { TableData = new List<ResponsePermissionDto>() };
                    res.Data.TableData = whereSql.Select((p, p2) => new ResponsePermissionDto
                    {
                        PermissionId = p.PermissionId,
                        PermissionName = p.PermissionName,
                        PermissionAction = p.PermissionAction,
                        PermissionParentId = p.PermissionParentId,
                        PermissionParentName = p2.PermissionName,
                        CreateName = p.CreateName,
                        CreateTime = p.CreateTime,
                        PermissionType = p.PermissionType,
                        IsValid = p.IsValid
                    }).ToList();
                 
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }
    }
}
