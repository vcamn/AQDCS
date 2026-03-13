using System;
using Fleet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Infrastructure.Persistence.Configurations.Metadata;

public class SensorIntegrationConfiguration : IEntityTypeConfiguration<SensorIntegration>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SensorIntegration> builder)
    {
        builder.ToTable("sensor_integrations");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.ConfigJson)
               .IsRequired()
               .HasColumnType("jsonb");

        builder.Property(e => e.CreatedAtUtc)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(e => e.Sensor)
               .WithMany(s => s.SensorIntegrations)
               .HasForeignKey(e => e.SensorId)
               .OnDelete(DeleteBehavior.NoAction);

       builder.HasOne(e => e.IntegrationTemplate)
               .WithMany(t => t.SensorIntegrations)
               .HasForeignKey(e => e.IntegrationTemplateId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
