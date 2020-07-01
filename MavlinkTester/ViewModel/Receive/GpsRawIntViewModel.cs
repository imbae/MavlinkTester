using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class GpsRawIntViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private ulong timeUsec;
        private byte fixType;
        private int lat;
        private int lon;
        private int alt;
        private int eph;
        private int epv;
        private int vel;
        private int cog;

        public ulong TimeUsec { get { return timeUsec; } set { timeUsec = value; OnPropertyChanged("TimeUsec"); } }
        public byte FixType { get { return fixType; } set { fixType = value; OnPropertyChanged("FixType"); } }
        public int Lat { get { return lat; } set { lat = value; OnPropertyChanged("Lat"); } }
        public int Lon { get { return lon; } set { lon = value; OnPropertyChanged("Lon"); } }
        public int Alt { get { return alt; } set { alt = value; OnPropertyChanged("Alt"); } }
        public int Eph { get { return eph; } set { eph = value; OnPropertyChanged("Eph"); } }
        public int Epv { get { return epv; } set { epv = value; OnPropertyChanged("Epv"); } }
        public int Vel { get { return vel; } set { vel = value; OnPropertyChanged("Vel"); } }
        public int Cog { get { return cog; } set { cog = value; OnPropertyChanged("Cog"); } }

        #endregion

        public GpsRawIntViewModel()
        {
            MavlinkManager.Instance.GpsRawIntEvent += GetGpsRawInt;
        }

        private void GetGpsRawInt(UasMessage msg)
        {
            var gpsRawInt = msg as UasGpsRawInt;

            TimeUsec = gpsRawInt.TimeUsec;
            FixType = gpsRawInt.FixType;
            Lat = gpsRawInt.Lat;
            Lon = gpsRawInt.Lon;
            Alt = gpsRawInt.Alt;
            Eph = gpsRawInt.Eph;
            Epv = gpsRawInt.Epv;
            Vel = gpsRawInt.Vel;
            Cog = gpsRawInt.Cog;
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
