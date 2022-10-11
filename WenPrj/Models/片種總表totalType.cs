using System;
using System.Collections.Generic;

#nullable disable

namespace WenPrj.Models
{
    public partial class 片種總表totalType
    {
        public 片種總表totalType()
        {
            次片種總表types = new HashSet<次片種總表type>();
        }

        public int 片種編號totalTypeId { get; set; }
        public string 片種名稱totalTypeName { get; set; }

        public virtual ICollection<次片種總表type> 次片種總表types { get; set; }
    }
}
