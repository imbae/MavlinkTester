using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class ServoOutputRawViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private uint timeUsec;
        private byte port;
        private ushort servo1Raw;
        private ushort servo2Raw;
        private ushort servo3Raw;
        private ushort servo4Raw;
        private ushort servo5Raw;
        private ushort servo6Raw;
        private ushort servo7Raw;
        private ushort servo8Raw;

        public uint TimeUsec { get { return timeUsec; } set { timeUsec = value; OnPropertyChanged("TimeUsec"); } }
        public byte Port { get { return port; } set { port = value; OnPropertyChanged("Port"); } }
        public ushort Servo1Raw { get { return servo1Raw; } set { servo1Raw = value; OnPropertyChanged("Servo1Raw"); } }
        public ushort Servo2Raw { get { return servo2Raw; } set { servo2Raw = value; OnPropertyChanged("Servo2Raw"); } }
        public ushort Servo3Raw { get { return servo3Raw; } set { servo3Raw = value; OnPropertyChanged("Servo3Raw"); } }
        public ushort Servo4Raw { get { return servo4Raw; } set { servo4Raw = value; OnPropertyChanged("Servo4Raw"); } }
        public ushort Servo5Raw { get { return servo5Raw; } set { servo5Raw = value; OnPropertyChanged("Servo5Raw"); } }
        public ushort Servo6Raw { get { return servo6Raw; } set { servo6Raw = value; OnPropertyChanged("Servo6Raw"); } }
        public ushort Servo7Raw { get { return servo7Raw; } set { servo7Raw = value; OnPropertyChanged("Servo7Raw"); } }
        public ushort Servo8Raw { get { return servo8Raw; } set { servo8Raw = value; OnPropertyChanged("Servo8Raw"); } }

        #endregion

        public ServoOutputRawViewModel()
        {
            MavlinkManager.Instance.ServoOutputRawEvent += GetServoOutputRaw;
        }

        private void GetServoOutputRaw(UasMessage msg)
        {
            var servoOutputRaw = msg as UasServoOutputRaw;

            TimeUsec = servoOutputRaw.TimeUsec;
            Port = servoOutputRaw.Port;
            Servo1Raw = servoOutputRaw.Servo1Raw;
            Servo2Raw = servoOutputRaw.Servo2Raw;
            Servo3Raw = servoOutputRaw.Servo3Raw;
            Servo4Raw = servoOutputRaw.Servo4Raw;
            Servo5Raw = servoOutputRaw.Servo5Raw;
            Servo6Raw = servoOutputRaw.Servo6Raw;
            Servo7Raw = servoOutputRaw.Servo7Raw;
            Servo8Raw = servoOutputRaw.Servo8Raw;
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
