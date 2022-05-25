namespace Mc2.CrudTest.Dtos
{
    public class PaginateInput
    {
        public string SearchText { get; set; }
        public string SortOrder { get; set; }
        public int PageCount { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;
    }
}
