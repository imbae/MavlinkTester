using System.ComponentModel;

namespace MavlinkTester.Model
{
    public class ControlItem : INotifyPropertyChanged
    {
        private string name;
        private object content;
        private bool isVisible;

        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public object Content { get { return content; } set { content = value; OnPropertyChanged("Content"); } }
        public bool IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged("IsVisible"); } }

        public ControlItem(string name, object content)
        {
            Name = name;
            Content = content;
        }

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!ReferenceEquals(PropertyChanged, null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
