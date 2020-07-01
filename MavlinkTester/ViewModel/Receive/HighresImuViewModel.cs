using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class HighresImuViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private ulong timeUsec;
        private float xacc;
        private float yacc;
        private float zacc;
        private float xgyro;
        private float ygyro;
        private float zgyro;
        private float xmag;
        private float ymag;
        private float zmag;
        private float absPressure;
        private float diffPressure;
        private float pressureAlt;
        private float temperature;
        private ushort fieldsUpdated;

        public ulong TimeUsec { get { return timeUsec; } set { timeUsec = value; OnPropertyChanged("TimeUsec"); } }
        public float Xacc { get { return xacc; } set { xacc = value; OnPropertyChanged("Xacc"); } }
        public float Yacc { get { return yacc; } set { yacc = value; OnPropertyChanged("Yacc"); } }
        public float Zacc { get { return zacc; } set { zacc = value; OnPropertyChanged("Zacc"); } }
        public float Xgyro { get { return xgyro; } set { xgyro = value; OnPropertyChanged("Xgyro"); } }
        public float Ygyro { get { return ygyro; } set { ygyro = value; OnPropertyChanged("Ygyro"); } }
        public float Zgyro { get { return zgyro; } set { zgyro = value; OnPropertyChanged("Zgyro"); } }
        public float Xmag { get { return xmag; } set { xmag = value; OnPropertyChanged("Xmag"); } }
        public float Ymag { get { return ymag; } set { ymag = value; OnPropertyChanged("Ymag"); } }
        public float Zmag { get { return zmag; } set { zmag = value; OnPropertyChanged("Zmag"); } }
        public float AbsPressure { get { return absPressure; } set { absPressure = value; OnPropertyChanged("AbsPressure"); } }
        public float DiffPressure { get { return diffPressure; } set { diffPressure = value; OnPropertyChanged("DiffPressure"); } }
        public float PressureAlt { get { return pressureAlt; } set { pressureAlt = value; OnPropertyChanged("PressureAlt"); } }
        public float Temperature { get { return temperature; } set { temperature = value; OnPropertyChanged("Temperature"); } }
        public ushort FieldsUpdated { get { return fieldsUpdated; } set { fieldsUpdated = value; OnPropertyChanged("FieldsUpdated"); } }

        #endregion

        public HighresImuViewModel()
        {
            MavlinkManager.Instance.HighresImuEvent += GetHighresImu;
        }

        private void GetHighresImu(UasMessage msg)
        {
            var highresImu = msg as UasHighresImu;

            TimeUsec = highresImu.TimeUsec;
            Xacc = highresImu.Xacc;
            Yacc = highresImu.Yacc;
            Zacc = highresImu.Zacc;
            Xgyro = highresImu.Xgyro;
            Ygyro = highresImu.Ygyro;
            Zgyro = highresImu.Zgyro;
            Xmag = highresImu.Xmag;
            Ymag = highresImu.Ymag;
            Zmag = highresImu.Zmag;
            AbsPressure = highresImu.AbsPressure;
            DiffPressure = highresImu.DiffPressure;
            PressureAlt = highresImu.PressureAlt;
            Temperature = highresImu.Temperature;
            FieldsUpdated = highresImu.FieldsUpdated;
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
