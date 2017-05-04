namespace PropertyAgency.Models.Interfaces
{
    public interface IPaginationable
    {
         int TotalItems { get;  set; }
         int CurrentPage { get;  set; }
         int PageSize { get;  set; }
         int TotalPages { get;  set; }
         int StartPage { get;  set; }
         int EndPage { get;  set; }
    }
}
