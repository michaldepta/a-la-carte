namespace ALaCarte.IisAdministration.Models
{
    public class WebSite
    {
        public WebSite(long id, string name, string state)
        {
            Id = id;
            Name = name;
            State = state;
        }

        public long Id { get; }
        public string Name { get; }
        public string State { get; }
    }
}