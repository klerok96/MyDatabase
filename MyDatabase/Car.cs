//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public decimal Cost { get; set; }
        public int Power { get; set; }
        public int Consumption { get; set; }
        public Nullable<int> ColorID { get; set; }
        public Nullable<int> DiskCarID { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual DiskCar DiskCar { get; set; }
    }
}