//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmoothDataBaseControl
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_order_detail
    {
        public int order_detail_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> popup_item_id { get; set; }
        public int order_id { get; set; }
        public Nullable<int> product_qty { get; set; }
        public Nullable<float> amount { get; set; }
        public string comment { get; set; }
        public Nullable<int> cook_status { get; set; }
        public Nullable<int> is_active { get; set; }
    
        public virtual tb_order tb_order { get; set; }
        public virtual tb_popup_item tb_popup_item { get; set; }
        public virtual tb_product tb_product { get; set; }
    }
}
