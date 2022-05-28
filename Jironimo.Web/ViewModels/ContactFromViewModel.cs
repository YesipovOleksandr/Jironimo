namespace Jironimo.Web.ViewModels
{
    public class ContactFromViewModel
    {
        public string Name { set; get; }
        public string From { set; get; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public string Email { get; set; }
        public bool iSDisplay { get; set; } = true;
    }
}
