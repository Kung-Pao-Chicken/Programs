//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlog.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class mix_categorycontent
    {
        public mix_categorycontent()
        {
            this.mix_acticle = new HashSet<mix_acticle>();
        }
    
        public int CatContentID { get; set; }
        public int CatID { get; set; }
        public string CatContentName { get; set; }
        public byte[] CatcontentLogo { get; set; }
    
        public virtual ICollection<mix_acticle> mix_acticle { get; set; }
        public virtual mix_category mix_category { get; set; }
    }
}