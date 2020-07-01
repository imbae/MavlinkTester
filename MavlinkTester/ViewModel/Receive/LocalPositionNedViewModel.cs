using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class LocalPositionNedViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private uint timeBootMs;
        private float x;
        private float y;
        private float z;
        private float vx;
        private float vy;
        private float vz;

        public uint TimeBootMs { get { return timeBootMs; } set { timeBootMs = value; OnPropertyChanged("TimeBootMs"); } }
        public float X { get { return x; } set { x = value; OnPropertyChanged("X"); } }
        public float Y { get { return y; } set { y = value; OnPropertyChanged("Y"); } }
        public float Z { get { return z; } set { z = value; OnPropertyChanged("Z"); } }
        public float Vx { get { return vx; } set { vx = value; OnPropertyChanged("Vx"); } }
        public float Vy { get { return vy; } set { vy = value; OnPropertyChanged("Vy"); } }
        public float Vz { get { return vz; } set { vz = value; OnPropertyChanged("Vz"); } }

        #endregion

        public LocalPositionNedViewModel()
        {
            MavlinkManager.Instance.LocalPositionNedEvent += GetLocalPositionNed;
        }

        private void GetLocalPositionNed(UasMessage msg)
        {
            var localPositionNed = msg as UasLocalPositionNed;

            TimeBootMs = localPositionNed.TimeBootMs;
            X = localPositionNed.X;
            Y = localPositionNed.Y;
            Z = localPositionNed.Z;
            Vx = localPositionNed.Vx;
            Vy = localPositionNed.Vy;
            Vz = localPositionNed.Vz;
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
