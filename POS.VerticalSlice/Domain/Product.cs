using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.VerticalSlice.Domain;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public string? Code { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public int Stock { get; set; }

    public string? Image { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SellPrice { get; set; }

    public int CategoryId { get; set; }

    public int ProviderId { get; set; }

    public int State { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;
}
