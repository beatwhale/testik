//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practic
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarTable()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Id_car { get; set; }
        public string Gos_number { get; set; }
        public string Car_brand { get; set; }
        public string Car_year { get; set; }
        public string Car_client_name { get; set; }
        public string Car_client_phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
