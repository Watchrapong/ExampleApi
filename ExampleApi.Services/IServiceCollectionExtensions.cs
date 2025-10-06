using AssetManagement.Core.Services;

using Microsoft.Extensions.DependencyInjection;

namespace AssetManagement.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddEnServices(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IDepreciationYearService, DepreciationYearService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IDeviceGroupService, DeviceGroupService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDeviceAssetService, DeviceAssetService>();
        services.AddScoped<IGeneralLedgerService, GeneralLedgerService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IAccountingCloseService, AccountingCloseService>();
        services.AddScoped<IDepreciationService, DepreciationService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<IAuditService, AuditService>();

        return services;
    }
}