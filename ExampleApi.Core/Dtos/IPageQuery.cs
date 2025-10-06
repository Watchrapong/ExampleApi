using AssetManagement.Core.Entities;

namespace AssetManagement.Core.Dtos;

/// <summary>
/// ประเภทการจัดเรียงในการค้นหาข้อมูล
/// </summary>
public enum SortTypes
{
    /// <summary>
    /// การจัดเรียงจากน้อยไปมาก (Ascending)
    /// </summary>
    Asc,

    /// <summary>
    /// การจัดเรียงจากมากไปน้อย (Descending)
    /// </summary>
    Desc,
}

/// <summary>
/// คำขอสำหรับการค้นหาข้อมูลแบบแบ่งหน้า
/// </summary>
public abstract class IPageQuery<T> where T : IEntity
{
    private int _page = 1;
    public int Page
    {
        get { return _page; }
        set
        {
            _page = value < 0 ? 1 : value;
        }
    }

    private int _pageSize = 10;
    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            _pageSize = value < 0 || value > 100 ? 10 : value;
        }
    }
    public string? SortKey { get; set; }
    public SortTypes? SortType { get; set; }

    /// <summary>
    /// ใช้สำหรับปรับแต่งคำขอค้นหาข้อมูล
    /// </summary>
    public virtual IQueryable<T> ApplyToQuery(IQueryable<T> query)
    {
        return query;
    }
}

