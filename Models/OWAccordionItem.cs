public class OWAccordionItem
{
    public string Header { get; set; } = "Placeholder";
    public string IconCss { get; set; } = "e-dashboard e-icons";
    public bool Expanded { get; set; }
    public List<AccordionItemContent> Content { get; set; } = new List<AccordionItemContent>();
}

public class AccordionItemContent
{
    public string IconCss { get; set; } = "e-icons e-content-icon";
    public string Text { get; set; } = "Placeholder";
}

// public class SidebarItem
// {
//     public string IconCss { get; set; }
// }
