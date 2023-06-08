﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace WriteSeparateFromEfCore.Models;

public partial class UserLogin
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string EmailAddress { get; set; }

    [Required]
    [StringLength(5)]
    public string Pin { get; set; }

    public override string ToString() => $"{Id,-4}{EmailAddress}";

}