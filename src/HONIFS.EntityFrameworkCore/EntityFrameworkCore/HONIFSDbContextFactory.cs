﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HONIFS.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class HONIFSDbContextFactory : IDesignTimeDbContextFactory<HONIFSDbContext>
{
    public HONIFSDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        HONIFSEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<HONIFSDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new HONIFSDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HONIFS.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
