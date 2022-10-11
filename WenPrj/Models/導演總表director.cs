using System;
using System.Collections.Generic;

#nullable disable

namespace WenPrj.Models
{
    public partial class 導演總表director
    {
        public 導演總表director()
        {
            電影導演movieDirectors = new HashSet<電影導演movieDirector>();
        }

        public int 導演編號directorId { get; set; }
        public string 中文名字nameCht { get; set; }
        public string 英文名字nameEng { get; set; }
        public byte[] 導演照片image { get; set; }

        public virtual ICollection<電影導演movieDirector> 電影導演movieDirectors { get; set; }
    }
}
