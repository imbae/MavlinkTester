using MavLinkNet;
using MavlinkTester.Function;
using MavlinkTester.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MavlinkTester.ViewModel
{
    class SetCustomLoiterViewModel : INotifyPropertyChanged
    {
        private readonly UasCustomLoiter customLoiter = new UasCustomLoiter();

        #region Binding Field

        private double lat;
        private double lon;
        private int approachAlt;
        private int loiterAlt;
        private short approachSpeed;
        private short loiterSpeed;
        private int loiterRadius;
        private byte altitudeType;
        private int referenceAltitude;

        public double Lat { get { return lat; } set { lat = value; OnPropertyChanged("Lat"); } }
        public double Lon { get { return lon; } set { lon = value; OnPropertyChanged("Lon"); } }
        public int ApproachAlt { get { return approachAlt; } set { approachAlt = value; OnPropertyChanged("ApproachAlt"); } }
        public int LoiterAlt { get { return loiterAlt; } set { loiterAlt = value; OnPropertyChanged("LoiterAlt"); } }
        public short ApproachSpeed { get { return approachSpeed; } set { approachSpeed = value; OnPropertyChanged("ApproachSpeed"); } }
        public short LoiterSpeed { get { return loiterSpeed; } set { loiterSpeed = value; OnPropertyChanged("LoiterSpeed"); } }
        public int LoiterRadius { get { return loiterRadius; } set { loiterRadius = value; OnPropertyChanged("LoiterRadius"); } }
        public byte AltitudeType { get { return altitudeType; } set { altitudeType = value; OnPropertyChanged("AltitudeType"); } }
        public int ReferenceAltitude { get { return referenceAltitude; } set { referenceAltitude = value; OnPropertyChanged("ReferenceAltitude"); } }


        public ObservableCollection<ComboBoxItem> AltitudeTypeCollection { get; set; } = new ObservableCollection<ComboBoxItem>();



        #endregion


        public SetCustomLoiterViewModel()
        {
            InitializeControl();
            InitializeData();

            SendCustomLoiter_Command = new RelayCommand(item => SendCustomLoiter());
        }

        private void InitializeControl()
        {
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "Baro & GPS" });
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "WGS84" });
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "Baro" });
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "WGS84 Ground" });
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "SAS" });
            AltitudeTypeCollection.Add(new ComboBoxItem() { Content = "Sealevel" });
        }

        private void InitializeData()
        {
            Lat = 35.164615;
            Lon = 128.127188;
            ApproachAlt = 100;
            LoiterAlt = 100;
            ApproachSpeed = 23;
            LoiterSpeed = 23;
            LoiterRadius = 150;
            AltitudeType = 0;
            ReferenceAltitude = 0;
        }

        public ICommand SendCustomLoiter_Command { get; private set; }


        private void SendCustomLoiter()
        {
            ConvertMessage();

            MavlinkManager.Instance.MavSerialTransport.SendMessage(customLoiter);
        }

        private void ConvertMessage()
        {
            customLoiter.Lat = (int)(Lat * Formula.DegreeToRadianE9);
            customLoiter.Lon = (int)(Lon * Formula.DegreeToRadianE9);
            customLoiter.ApproachAlt = ApproachAlt * 100;
            customLoiter.LoiterAlt = LoiterAlt * 100;
            customLoiter.ApproachSpeed = (short)(ApproachSpeed * 100);
            customLoiter.LoiterSpeed = (short)(LoiterSpeed * 100);
            customLoiter.LoiterRadius = (short)(LoiterRadius * 100);

            customLoiter.Bitfield = ConvertBitField.SetBitField((sbyte)AltitudeType, customLoiter.Bitfield, 0, 8);
            customLoiter.Bitfield = ConvertBitField.SetBitField((ReferenceAltitude * 100), customLoiter.Bitfield, 8, 24);
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
