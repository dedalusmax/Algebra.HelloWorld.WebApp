﻿using System.ComponentModel.DataAnnotations;

namespace Algebra.HelloWorld.WebApp.Data.Entities;

public class Movie : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    public string Genre { get; set; }

    public short ReleaseYear { get; set; }
}
