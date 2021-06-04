using System;
using System.Linq;
using System.Text;

namespace EntitysModels
{
    ///<summary>
    ///
    ///</summary>
    public partial class Base_RolePermission
    {
          
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RolePermissionId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RoleId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PermissionId {get;set;}

    }
}
