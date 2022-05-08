namespace Jironimo.Common.Models.Aplications
{
    public class Application
    {
        public Application(string title, string description, string imagePath, bool positionRight)
        {
            Title = title;
            Description = description;
            ImagePath = imagePath;
            PositionRight = positionRight;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
    }
}

