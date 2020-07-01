using MavLinkNet;
using MavlinkTester.Model;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class AltitudeViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private ulong timeUsec;
        private float altitudeMonotonic;
        private float altitudeAmsl;
        private float altitudeLocal;
        private float altitudeRelative;
        private float altitudeTerrain;
        private float bottomClearance;

        public ulong TimeUsec { get { return timeUsec; } set { timeUsec = value; OnPropertyChanged("TimeUsec"); } }
        public float AltitudeMonotonic { get { return altitudeMonotonic; } set { altitudeMonotonic = value; OnPropertyChanged("AltitudeMonotonic"); } }
        public float AltitudeAmsl { get { return altitudeAmsl; } set { altitudeAmsl = value; OnPropertyChanged("AltitudeAmsl"); } }
        public float AltitudeLocal { get { return altitudeLocal; } set { altitudeLocal = value; OnPropertyChanged("AltitudeLocal"); } }
        public float AltitudeRelative { get { return altitudeRelative; } set { altitudeRelative = value; OnPropertyChanged("AltitudeRelative"); } }
        public float AltitudeTerrain { get { return altitudeTerrain; } set { altitudeTerrain = value; OnPropertyChanged("AltitudeTerrain"); } }
        public float BottomClearance { get { return bottomClearance; } set { bottomClearance = value; OnPropertyChanged("BottomClearance"); } }

        #endregion


        public AltitudeViewModel()
        {
            MavlinkManager.Instance.AltitudeEvent += GetAltitude;

        }

        private void GetAltitude(UasMessage msg)
        {
            var altitude = msg as UasAltitude;

            TimeUsec = altitude.TimeUsec;
            AltitudeMonotonic = altitude.AltitudeMonotonic;
            AltitudeAmsl = altitude.AltitudeAmsl;
            AltitudeLocal = altitude.AltitudeLocal;
            AltitudeRelative = altitude.AltitudeRelative;
            AltitudeTerrain = altitude.AltitudeTerrain;
            BottomClearance = altitude.BottomClearance;
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
