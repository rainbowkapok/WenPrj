using System;
using System.Collections.Generic;

#nullable disable

namespace WenPrj.Models
{
    public partial class 電影圖片總表movieImage
    {
        public 電影圖片總表movieImage()
        {
            電影圖片movieIimagesLists = new HashSet<電影圖片movieIimagesList>();
        }

        public int 圖片編號imageId { get; set; }
        public byte[] 圖片image { get; set; }
        public int 屏蔽invisible { get; set; }

        public virtual ICollection<電影圖片movieIimagesList> 電影圖片movieIimagesLists { get; set; }
    }
}
