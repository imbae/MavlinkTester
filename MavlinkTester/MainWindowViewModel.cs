using MavLinkNet;
using MavlinkTester.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace MavlinkTester
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string mavlinkStatus;
        public string MavlinkStatus { get { return mavlinkStatus; } set { mavlinkStatus = value; OnPropertyChanged("MavlinkStatus"); } }


        public MainWindowViewModel()
        {
            ConnectMavlink_Command = new RelayCommand(item => ConnectMavlink(item));

            MavlinkManager.Instance.HeartbeatEvent += GetHeartbeat;

            MavlinkStatus = "Wait ... ";
        }

        private void ConnectMavlink(object obj)
        {
            var item = obj as SerialConnectItem;
            MavlinkManager.Instance.ConnectMavlinkSerial(item.SelectedComPort, item.SelectedBaudrate);
        }

        private void GetHeartbeat(UasMessage msg)
        {
            MavlinkStatus = "Mavlink Connected";
        }

        public ICommand ConnectMavlink_Command { get; private set; }


        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!ReferenceEquals(PropertyChanged,null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
