﻿using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) :base (options){ }

    public DbSet<Category> Categories { get; set; }
    public DbSet <Product> Products { get; set; }
}
