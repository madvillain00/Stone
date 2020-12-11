//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Product_Order = new HashSet<Product_Order>();
        }
    
        public int ProductID { get; set; }
        public Nullable<int> DeliveryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Price { get; set; }
        public string ShelfLife { get; set; }
        public string CountInStore { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Order> Product_Order { get; set; }
    }
}