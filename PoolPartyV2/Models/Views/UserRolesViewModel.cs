using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models.Views
{
    public class UserRolesViewModel
    {
        public string RoleId { get; set; }
        public string userId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
