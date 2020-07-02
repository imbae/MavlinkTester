using MavLinkNet;
using MavlinkTester.Model;
using System.ComponentModel;
using System.Timers;
using System.Windows.Input;

namespace MavlinkTester.ViewModel
{
    class SetHeartbeatViewModel : INotifyPropertyChanged
    {
        private readonly Timer heartbeatTimer = new Timer();

        private readonly UasHeartbeat heartbeatCommand = new UasHeartbeat();

        #region Binding Field

        private bool isEnabledHeartbeat;
        private bool isTimerTick;
        public bool IsEnabledHeartbeat { get { return isEnabledHeartbeat; } set { isEnabledHeartbeat = value; OnPropertyChanged("IsEnabledHeartbeat"); } }
        public bool IsTimerTick { get { return isTimerTick; } set { isTimerTick = value; OnPropertyChanged("IsTimerTick"); } }


        private byte type;
        private byte autopilot;
        private byte baseMode;
        private byte systemStatus;
        private uint customMode;
        private byte mavlinkVersion;

        public byte Type { get { return type; } set { type = value; OnPropertyChanged("Type"); } }
        public byte Autopilot { get { return autopilot; } set { autopilot = value; OnPropertyChanged("Autopilot"); } }
        public byte BaseMode { get { return baseMode; } set { baseMode = value; OnPropertyChanged("BaseMode"); } }
        public byte SystemStatus { get { return systemStatus; } set { systemStatus = value; OnPropertyChanged("SystemStatus"); } }
        public uint CustomMode { get { return customMode; } set { customMode = value; OnPropertyChanged("CustomMode"); } }
        public byte MavlinkVersion { get { return mavlinkVersion; } set { mavlinkVersion = value; OnPropertyChanged("MavlinkVersion"); } }

        #endregion

        public SetHeartbeatViewModel()
        {
            SetHeartbeat_Command = new RelayCommand(item => SetHeartbeat());
            StartHeartbeat_Command = new RelayCommand(item => StartHeartbeat());
            StopHeartbeat_Command = new RelayCommand(item => StopHeartbeat());

            heartbeatTimer.Interval = 1000;
            heartbeatTimer.Elapsed += HeartbeatTimer_Elapsed;
        }


        public ICommand SetHeartbeat_Command { get; private set; }
        public ICommand StartHeartbeat_Command { get; private set; }
        public ICommand StopHeartbeat_Command { get; private set; }


        private void SetHeartbeat()
        {
            heartbeatCommand.Type = (MavType)Type;
            heartbeatCommand.Autopilot = (MavAutopilot)Autopilot;
            heartbeatCommand.BaseMode = (MavModeFlag)BaseMode;
            heartbeatCommand.SystemStatus = (MavState)SystemStatus;
            heartbeatCommand.CustomMode = CustomMode;
            heartbeatCommand.MavlinkVersion = MavlinkVersion;
        }

        private void StartHeartbeat()
        {
            heartbeatTimer.Start();

            IsEnabledHeartbeat = heartbeatTimer.Enabled;
        }

        private void StopHeartbeat()
        {
            if(heartbeatTimer.Enabled)
            {
                heartbeatTimer.Stop();

                IsEnabledHeartbeat = heartbeatTimer.Enabled;
                IsTimerTick = false;
            }
        }

        private void HeartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MavlinkManager.Instance.MavSerialTransport.SendMessage(heartbeatCommand);

            IsTimerTick = !IsTimerTick;
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
