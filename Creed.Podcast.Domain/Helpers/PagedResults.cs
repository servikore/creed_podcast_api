namespace Creed.Podcast.Domain
{
    /// <summary>
    /// Facilitate paged results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResults<T> where T : class
    {
        public PagedResults(IEnumerable<T> results, 
            int total, 
            bool hasNext, 
            bool hasPrevious, 
            int pageNumber, 
            int previousPageNumber, 
            int nextPageNumber)
        {
            Results = results;
            Total = total;
            HasNext = hasNext;
            HasPrevious = hasPrevious;
            PageNumber = pageNumber;
            PreviousPageNumber = previousPageNumber;
            NextPageNumber = nextPageNumber;
        }

        public IEnumerable<T> Results { get; }
        public int Total { get; }
        public bool HasNext { get; }
        public bool HasPrevious { get; }
        public int PageNumber { get; }
        public int PreviousPageNumber { get; }
        public int NextPageNumber { get; }

        /// <summary>
        /// Checks if results has rows
        /// </summary>
        /// <returns>true is does not have results, else false</returns>
        public bool IsEmpty()
        {
            return Results == null || Results.Count() == 0;
        }

        /// <summary>
        /// Return an empty representation of PagedResults<T>
        /// </summary>
        /// <returns></returns>
        public static PagedResults<T> Empty()
        {            
            return new PagedResults<T>(new List<T>(), 0, false, false, 0, 0, 0);
        }
        public static PagedResults<T> Generate(IEnumerable<T> results,int total, int pageNumber, int pageZise)
        {
            if(results == null || results.Count() == 0 || total == 0 || pageNumber == 0 || pageZise == 0)
            {
                return Empty();
            }
            
            int previousPageNumber = pageNumber > 1? pageNumber - 1 : 1;
            bool hasPrevious = pageNumber > 1;
            int nextPageNumber = total > (pageZise * pageNumber)? pageNumber + 1 : pageNumber;
            bool hasNext = total > (pageZise * pageNumber);

            return new PagedResults<T>(results, total, hasNext, hasPrevious, pageNumber, previousPageNumber, nextPageNumber);
        }
    }
}
