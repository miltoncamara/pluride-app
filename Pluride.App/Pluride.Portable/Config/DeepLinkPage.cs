namespace Pluride.App.Portable.Config
{
    public class DeepLinkPage
    {
        public AppPage Page { get; set; }
        public string Id { get; set; }
    }

    public enum AppPage
    {
        Home,
        Rides,
        Settings
    }
}
