//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student
{
    using System;
    using System.Collections.Generic;
    
    public partial class Marks
    {
        public int Id { get; set; }
        public Nullable<int> Mark { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> TestId { get; set; }
    
        public virtual Tests Tests { get; set; }
        public virtual Users Users { get; set; }
    }
}
