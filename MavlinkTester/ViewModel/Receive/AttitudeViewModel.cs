using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class AttitudeViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private uint timeBootMs;
        private float roll;
        private float pitch;
        private float yaw;
        private float rollspeed;
        private float pitchspeed;
        private float yawspeed;

        public uint TimeBootMs { get { return timeBootMs; } set { timeBootMs = value; OnPropertyChanged("TimeBootMs"); } }
        public float Roll { get { return roll; } set { roll = value; OnPropertyChanged("Roll"); } }
        public float Pitch { get { return pitch; } set { pitch = value; OnPropertyChanged("Pitch"); } }
        public float Yaw { get { return yaw; } set { yaw = value; OnPropertyChanged("Yaw"); } }
        public float Rollspeed { get { return rollspeed; } set { rollspeed = value; OnPropertyChanged("Rollspeed"); } }
        public float Pitchspeed { get { return pitchspeed; } set { pitchspeed = value; OnPropertyChanged("Pitchspeed"); } }
        public float Yawspeed { get { return yawspeed; } set { yawspeed = value; OnPropertyChanged("Yawspeed"); } }

        #endregion

        public AttitudeViewModel()
        {
            MavlinkManager.Instance.AttitudeEvent += GetAttitude;
        }

        private void GetAttitude(UasMessage msg)
        {
            var attitude = msg as UasAttitude;

            TimeBootMs = attitude.TimeBootMs;
            Roll = attitude.Roll;
            Pitch = attitude.Pitch;
            Yaw = attitude.Yaw;
            Rollspeed = attitude.Rollspeed;
            Pitchspeed = attitude.Pitchspeed;
            Yawspeed = attitude.Yawspeed;
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
