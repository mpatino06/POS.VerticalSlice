using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.VerticalSlice.Domain;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
