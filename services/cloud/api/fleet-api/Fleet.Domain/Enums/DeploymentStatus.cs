namespace Fleet.Domain.Enums;

public enum DeploymentStatus
{
    Planned,
    Approved,
    Provisioning,
    Active,
    Maintenance,
    Offline,
    Retired
}
