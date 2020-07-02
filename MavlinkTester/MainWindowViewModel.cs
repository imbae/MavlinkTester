using MavLinkNet;
using MavlinkTester.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace MavlinkTester
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool isMavlinkConnected;
        private string mavlinkStatus;

        public bool IsMavlinkConnected { get { return isMavlinkConnected; } set { isMavlinkConnected = value; OnPropertyChanged("IsMavlinkConnected"); } }
        public string MavlinkStatus { get { return mavlinkStatus; } set { mavlinkStatus = value; OnPropertyChanged("MavlinkStatus"); } }


        public MainWindowViewModel()
        {
            ConnectMavlink_Command = new RelayCommand(item => ConnectMavlink(item));
            DisconnectMavlink_Command = new RelayCommand(item => DisconnectMavlink());
            RefreshComport_Command = new RelayCommand(item => RefreshComport(item));

            MavlinkManager.Instance.MavlinkReceivedEvent += MavlinkReceived;

            MavlinkStatus = "Wait ... ";
        }

        private void ConnectMavlink(object obj)
        {
            var item = obj as SerialConnectItem;
            MavlinkManager.Instance.ConnectMavlinkSerial(item.SelectedComPort, item.SelectedBaudrate);
        }

        private void DisconnectMavlink()
        {
            MavlinkManager.Instance.DisconnectMavlinkSerial();

            MavlinkStatus = "Wait ... ";
            IsMavlinkConnected = false;
        }

        private void RefreshComport(object obj)
        {
            var item = obj as SerialConnectItem;
            item.RefeshSerialPort();
        }

        private void MavlinkReceived(UasMessage msg)
        {
            MavlinkStatus = "Mavlink Connected";
            IsMavlinkConnected = true;
        }

        public ICommand ConnectMavlink_Command { get; private set; }
        public ICommand DisconnectMavlink_Command { get; private set; }
        public ICommand RefreshComport_Command { get; private set; }


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
