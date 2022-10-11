using System;
using System.Collections.Generic;

#nullable disable

namespace WenPrj.Models
{
    public partial class 演員總表actor
    {
        public 演員總表actor()
        {
            電影主演casts = new HashSet<電影主演cast>();
        }

        public int 演員編號actorsId { get; set; }
        public string 中文名字nameCht { get; set; }
        public string 英文名字nameEng { get; set; }
        public byte[] 演員照片image { get; set; }

        public virtual ICollection<電影主演cast> 電影主演casts { get; set; }
    }
}
