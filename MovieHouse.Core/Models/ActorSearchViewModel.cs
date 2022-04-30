namespace MovieHouse.Core.Models
{
    public class ActorSearchViewModel
    {
        public ActorSearchViewModel()
        {
            Actors = new List<ActorViewModel>();
        }
        public bool Searched { get; set; }
        public int Page { get; set; }
        public string Keyword { get; set; }
        public bool LastPage { get; set; }

        public int TotalCount { get; set; }
        public List<ActorViewModel> Actors { get; set; }

        public int ActorsCount { get; set; }
    }
}
