﻿using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.Domain.Repositories;

public class UserDataContext : DbContext
{
    public UserDataContext(DbContextOptions<UserDataContext> options) : base(options) { }

    public DbSet<UserModel> Users { get; set; }
}
