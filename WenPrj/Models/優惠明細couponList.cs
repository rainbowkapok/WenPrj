using System;
using System.Collections.Generic;

#nullable disable

namespace WenPrj.Models
{
    public partial class 優惠明細couponList
    {
        public int 優惠明細編號couponListId { get; set; }
        public int 會員編號memberId { get; set; }
        public int 優惠編號couponId { get; set; }
        public bool 是否使用優惠oxCouponUsing { get; set; }
        public int 訂單編號orderId { get; set; }

        public virtual 優惠總表coupon 優惠編號coupon { get; set; }
        public virtual 會員member 會員編號member { get; set; }
        public virtual 訂單總表order 訂單編號order { get; set; }
    }
}
