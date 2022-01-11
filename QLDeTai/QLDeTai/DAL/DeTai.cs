namespace QLDeTai.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeTai")]
    public partial class DeTai
    {
        public long ID { get; set; }

        [StringLength(200)]
        public string TenDeTai { get; set; }

        public long? IDMonHoc { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
