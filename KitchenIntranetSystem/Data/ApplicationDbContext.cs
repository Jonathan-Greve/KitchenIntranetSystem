﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KitchenIntranetSystem.Models;

namespace KitchenIntranetSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<KitchenIntranetSystem.Models.Expenses> Expenses { get; set; }
        public DbSet<KitchenIntranetSystem.Models.Beers> Beers { get; set; }
        public DbSet<KitchenIntranetSystem.Models.BeerCategories> BeerCategories { get; set; }
        public DbSet<KitchenIntranetSystem.Models.Shopping> Shopping { get; set; }
        public DbSet<KitchenIntranetSystem.Models.KitchenDinners> KitchenDinners { get; set; }
        public DbSet<KitchenIntranetSystem.Models.Participants> Participants { get; set; }
        public DbSet<KitchenIntranetSystem.Models.KitchenBankAccounts> KitchenBankAccounts { get; set; }
        public DbSet<KitchenIntranetSystem.Models.BankAccountDatas> BankAccountDatas { get; set; }

    }
}
