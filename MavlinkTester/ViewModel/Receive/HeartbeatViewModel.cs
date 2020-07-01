using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class HeartbeatViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private byte type;
        private byte autopilot;
        private byte baseMode;
        private byte systemStatus;
        private uint cusutomMode;
        private byte mavlinkVersion;

        public byte Type { get { return type; } set { type = value; OnPropertyChanged("Type"); } }
        public byte Autopilot { get { return autopilot; } set { autopilot = value; OnPropertyChanged("Autopilot"); } }
        public byte BaseMode { get { return baseMode; } set { baseMode = value; OnPropertyChanged("BaseMode"); } }
        public byte SystemStatus { get { return systemStatus; } set { systemStatus = value; OnPropertyChanged("SystemStatus"); } }
        public uint CusutomMode { get { return cusutomMode; } set { cusutomMode = value; OnPropertyChanged("CusutomMode"); } }
        public byte MavlinkVersion { get { return mavlinkVersion; } set { mavlinkVersion = value; OnPropertyChanged("MavlinkVersion"); } }

        #endregion

        public HeartbeatViewModel()
        {
            MavlinkManager.Instance.HeartbeatEvent += GetHeartbeat;
        }

        private void GetHeartbeat(UasMessage msg)
        {
            var heartbeat = msg as UasHeartbeat;

            Type = Convert.ToByte(heartbeat.Type);
            Autopilot = Convert.ToByte(heartbeat.Autopilot);
            BaseMode = Convert.ToByte(heartbeat.BaseMode);
            SystemStatus = Convert.ToByte(heartbeat.SystemStatus);
            CusutomMode = heartbeat.CustomMode;
            MavlinkVersion = heartbeat.MavlinkVersion;
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
