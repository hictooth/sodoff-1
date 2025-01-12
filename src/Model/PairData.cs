﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sodoff.Model;

[Index(nameof(UserId))]
[Index(nameof(VikingId))]
public class PairData {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PairId { get; set; }

    public string? UserId { get; set; }

    public string? VikingId { get; set; }

    public virtual ICollection<Pair> Pairs { get; set; }
}
