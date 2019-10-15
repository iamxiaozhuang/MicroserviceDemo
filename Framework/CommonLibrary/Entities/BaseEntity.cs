using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLibrary
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTimeOffset CreateIn { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdateIn { get; set; }
        public string UpdatedBy { get; set; }

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

    }

    public class BaseEntityWithScope : BaseEntity
    {
        public string ScopeCode { get; set; }
    }

    [Table("Recycle")]
    public class Recycle : BaseEntity
    {

        [Required]
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        [Required]
        /// <summary>
        /// 记录的主键
        /// </summary>
        public Guid RowKey { get; set; }

        [Required]
        /// <summary>
        /// 删除的记录
        /// </summary>
        public string RowData { get; set; }

        [Required]
        /// <summary>
        /// 删除批次
        /// </summary>
        public Guid DeleteBatchID { get; set; }

    }

    [ComplexType]
    public class Attachment
    {
        [Key]
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }
        [Required]
        /// <summary>
        /// 附件Name
        /// </summary>
        public string AttachmentName { get; set; }

        [Required]
        /// <summary>
        /// 附件地址
        /// </summary>
        public string AttachmentUrl { get; set; }

        [Required]
        /// <summary>
        /// 附件排序
        /// </summary>
        public int AttachmentSort { get; set; }

    }
}
