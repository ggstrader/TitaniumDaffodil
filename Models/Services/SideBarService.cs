public class SidebarService
{
    private bool _sidebarToggle;

    public bool SidebarToggle
    {
        get => _sidebarToggle;
        set
        {
            _sidebarToggle = value;
            StateChanged?.Invoke();
        }
    }

    public event Action StateChanged;

    public void ToggleSidebar()
    {
        Console.WriteLine("ToggleSidebar", _sidebarToggle);
        SidebarToggle = !SidebarToggle;
    }
}
