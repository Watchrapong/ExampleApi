namespace AssetManagement.Core.Entities;

/// <summary>
/// เอนทิตีสำหรับติดต่อกับฐานข้อมูล
/// </summary>
public interface IEntity
{
}

/// <summary>
/// เอนทิตีที่ต้องบันทึกการตรวจสอบ
/// </summary>
public interface IAuditLogEntity : IEntity { }

/// <summary>
/// เอนทิตีที่มี ID
/// </summary>
public interface IIdEntity : IEntity
{
    Guid Id { get; set; }
}

/// <summary>
/// เอนทิตีที่มีการสร้างและปรับปรุงเวลา
/// </summary>
public interface ITimeEntity : IEntity
{
    /// <summary>
    /// วันที่และเวลาที่เอนทิตีถูกสร้างขึ้น
    /// </summary>
    /// <example>2025-01-01T12:00:00Z</example>
    DateTime Created { get; set; }

    /// <summary>
    /// วันที่และเวลาที่เอนทิตีถูกปรับปรุงล่าสุด
    /// </summary>
    /// <example>2025-05-01T15:30:00Z</example>
    DateTime? Updated { get; set; }
}

/// <summary>
/// เอนทิตีที่สนับสนุนการลบแบบซอฟต์
/// </summary>
public interface ISoftDeleteEntity : IEntity
{
    /// <summary>
    /// วันที่และเวลาที่เอนทิตีถูกทำเครื่องหมายว่าถูกลบ
    /// </summary>
    /// <example>2025-06-01T10:00:00Z</example>
    DateTime? Deleted { get; set; }
}
