﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EF_Core1.Models;

public partial class Countries
{
    public int CountryIdentifier { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Customers> Customers { get; } = new List<Customers>();
}