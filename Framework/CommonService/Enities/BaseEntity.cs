using System;
using System.Collections.Generic;
using System.Text;

namespace CommonService.Enities
{
    public class BaseEntity
    {
        private string tenantCode;
        public string TenantCode
        {
            get
            {
                return tenantCode == null ? "" : tenantCode;
            }
            set
            {
                tenantCode = value;
            }
        }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
