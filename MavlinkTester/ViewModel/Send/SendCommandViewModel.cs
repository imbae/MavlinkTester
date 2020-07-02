using MavlinkTester.Model;
using MavlinkTester.View;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class SendCommandViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private ControlItem selectedControl;
        private int selectedListViewIndex;

        public ControlItem SelectedControl { get { return selectedControl; } set { selectedControl = value; OnPropertyChanged("SelectedControl"); } }
        public int SelectedListViewIndex { get { return selectedListViewIndex; } set { selectedListViewIndex = value; ChangedControl(value); OnPropertyChanged("SelectedListViewIndex"); } }
        public ControlItem[] ControlItems { get; set; }

        #endregion

        private enum ControlIndex
        {
            Heartbeat = 0,
            CustomLoiter
        }

        public SendCommandViewModel()
        {
            InitializeControl();
            SelectedListViewIndex = 0;
        }

        private void InitializeControl()
        {
            ControlItems = new[]
            {
                new ControlItem (ControlIndex.Heartbeat.ToString(), new SetHeartbeatView { DataContext = new SetHeartbeatViewModel() } ),
                new ControlItem (ControlIndex.CustomLoiter.ToString(), new SetCustomLoiterView { DataContext = new SetCustomLoiterViewModel() } ),
            };

            SelectedControl = ControlItems[0];
        }

        private void ChangedControl(int index)
        {
            SelectedControl = ControlItems[index];
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
