using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class VfrHudViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private float airspeed;
        private float groundspeed;
        private short heading;
        private ushort throttle;
        private float alt;
        private float climb;

        public float Airspeed { get { return airspeed; } set { airspeed = value; OnPropertyChanged("Airspeed"); } }
        public float Groundspeed { get { return groundspeed; } set { groundspeed = value; OnPropertyChanged("Groundspeed"); } }
        public short Heading { get { return heading; } set { heading = value; OnPropertyChanged("Heading"); } }
        public ushort Throttle { get { return throttle; } set { throttle = value; OnPropertyChanged("Throttle"); } }
        public float Alt { get { return alt; } set { alt = value; OnPropertyChanged("Alt"); } }
        public float Climb { get { return climb; } set { climb = value; OnPropertyChanged("Climb"); } }

        #endregion

        public VfrHudViewModel()
        {
            MavlinkManager.Instance.VfrHudEvent += GetVfrHud;
        }

        private void GetVfrHud(UasMessage msg)
        {
            var vfrHud = msg as UasVfrHud;

            Airspeed = vfrHud.Airspeed;
            Groundspeed = vfrHud.Groundspeed;
            Heading = vfrHud.Heading;
            Throttle = vfrHud.Throttle;
            Alt = vfrHud.Alt;
            Climb = vfrHud.Climb;
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
