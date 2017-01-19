namespace YasService.Models
{
    public class PaginationParams
    {
        public PaginationParams()
        {
            this.Page = 1;
            this.PerPage = 25;
        }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public int TotalRecords { get; set; }

        public int? TopCount { get; set; }

        public int PaginationOffset { get; set; }

        public int PaginationLimit { get; set; }

        public void SetPaging(PaginationParams paging)
        {
            this.Page = paging.Page;
            this.PerPage = paging.PerPage;
            this.PaginationLimit = paging.PaginationLimit;
            this.PaginationOffset = paging.PaginationOffset;
            this.Next = paging.Next;
            this.Previous = paging.Previous;
            this.TotalRecords = paging.TotalRecords;
            this.TopCount = paging.TopCount;
        }
    }
}