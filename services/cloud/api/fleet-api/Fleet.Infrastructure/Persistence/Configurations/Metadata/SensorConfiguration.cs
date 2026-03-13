using System;
using Fleet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fleet.Infrastructure.Persistence.Configurations.Metadata;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
       builder.ToTable("sensors");

       builder.HasKey(e => e.Id);

       builder.Property(e => e.SensorIdentifier)
              .IsRequired()
              .HasMaxLength(48);
              
       builder.Property(e => e.SensorStatus)
              .IsRequired()
              .HasMaxLength(24);

       builder.Property(e => e.UnitOfMeasure)
              .IsRequired()
              .HasMaxLength(16);

       builder.HasOne(e => e.SensorType)
              .WithMany(st => st.Sensors)
              .HasForeignKey(e => e.SensorTypeId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);

       builder.HasOne(e => e.Station)
              .WithMany(s => s.Sensors)
              .HasForeignKey(e => e.StationId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);

       builder.HasOne(e => e.Device)
              .WithMany(d => d.Sensors)
              .HasForeignKey(e => e.DeviceId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.NoAction);
    }
}
