using ServiceCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemService.Domain
{
    [Table("Resource")]
    public class Resource : BaseEntityWithNoTenant
    {
        [Required]
        public string ResourceCode { get; set; }
      
        [Required]
        public string ResourceName { get; set; }
        [Required]
        public EnumResourceType ResourceType { get; set; }

        [Required]
        public Guid ParentResourceID { get; set; }

        public virtual Resource ParentResource { get; set; }
        public virtual ICollection<Resource> ChildrenResources { get; set; }
        [Required]
        public int SortNO { get; set; }

        public string ResourceDesc { get; set; }
    }
  

    [Table("Tenant")]
    public class Tenant : BaseEntityWithNoTenant
    {
        [Required]
        public string TenantCode { get; set; }
        [Required]
        public string TenantName { get; set; }
        [Required]
        public string TenantUrl { get; set; }
        [Required]
        public string TenantLogo { get; set; }

        [Required]
        public int SortNO { get; set; }

        public string TenantDesc { get; set; }
    }

   
}
