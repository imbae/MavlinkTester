using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class PositionTargetGlobalIntViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private uint timeBootMs;
        private byte coordinateFrame;
        private ushort typeMask;
        private int latInt;
        private int lonInt;
        private float alt;
        private float vx;
        private float vy;
        private float vz;
        private float afx;
        private float afy;
        private float afz;
        private float yaw;
        private float yawRate;

        public uint TimeBootMs { get { return timeBootMs; } set { timeBootMs = value; OnPropertyChanged("TimeBootMs"); } }
        public byte CoordinateFrame { get { return coordinateFrame; } set { coordinateFrame = value; OnPropertyChanged("CoordinateFrame"); } }
        public ushort TypeMask { get { return typeMask; } set { typeMask = value; OnPropertyChanged("TypeMask"); } }
        public int LatInt { get { return latInt; } set { latInt = value; OnPropertyChanged("LatInt"); } }
        public int LonInt { get { return lonInt; } set { lonInt = value; OnPropertyChanged("LonInt"); } }
        public float Alt { get { return alt; } set { alt = value; OnPropertyChanged("Alt"); } }
        public float Vx { get { return vx; } set { vx = value; OnPropertyChanged("Vx"); } }
        public float Vy { get { return vy; } set { vy = value; OnPropertyChanged("Vy"); } }
        public float Vz { get { return vz; } set { vz = value; OnPropertyChanged("Vz"); } }
        public float Afx { get { return afx; } set { afx = value; OnPropertyChanged("Afx"); } }
        public float Afy { get { return afy; } set { afy = value; OnPropertyChanged("Afy"); } }
        public float Afz { get { return afz; } set { afz = value; OnPropertyChanged("Afz"); } }
        public float Yaw { get { return yaw; } set { yaw = value; OnPropertyChanged("Yaw"); } }
        public float YawRate { get { return yawRate; } set { yawRate = value; OnPropertyChanged("YawRate"); } }

        #endregion

        public PositionTargetGlobalIntViewModel()
        {
            MavlinkManager.Instance.PositionTargetGlobalIntEvent += GetPositionTargetGlobalInt;
        }

        private void GetPositionTargetGlobalInt(UasMessage msg)
        {
            var positionTargetGlobalInt = msg as UasPositionTargetGlobalInt;

            TimeBootMs = positionTargetGlobalInt.TimeBootMs;
            CoordinateFrame = Convert.ToByte(positionTargetGlobalInt.CoordinateFrame);
            TypeMask = positionTargetGlobalInt.TypeMask;
            LatInt = positionTargetGlobalInt.LatInt;
            LonInt = positionTargetGlobalInt.LonInt;
            Alt = positionTargetGlobalInt.Alt;
            Vx = positionTargetGlobalInt.Vx;
            Vy = positionTargetGlobalInt.Vy;
            Vz = positionTargetGlobalInt.Vz;
            Afx = positionTargetGlobalInt.Afx;
            Afy = positionTargetGlobalInt.Afy;
            Afz = positionTargetGlobalInt.Afz;
            Yaw = positionTargetGlobalInt.Yaw;
            YawRate = positionTargetGlobalInt.YawRate;
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
