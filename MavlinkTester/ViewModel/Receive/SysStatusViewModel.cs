using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class SysStatusViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private uint onboardControlSensorsPresent;
        private uint onboardControlSensorsEnabled;
        private uint onboardControlSensorsHealth;
        private ushort load;
        private ushort voltageBattery;
        private short currentBattery;
        private sbyte batteryRemaining;
        private ushort dropRateComm;
        private ushort errorsComm;
        private ushort errorsCount1;
        private ushort errorsCount2;
        private ushort errorsCount3;
        private ushort errorsCount4;

        public uint OnboardControlSensorsPresent { get { return onboardControlSensorsPresent; } set { onboardControlSensorsPresent = value; OnPropertyChanged("OnboardControlSensorsPresent"); } }
        public uint OnboardControlSensorsEnabled { get { return onboardControlSensorsEnabled; } set { onboardControlSensorsEnabled = value; OnPropertyChanged("OnboardControlSensorsEnabled"); } }
        public uint OnboardControlSensorsHealth { get { return onboardControlSensorsHealth; } set { onboardControlSensorsHealth = value; OnPropertyChanged("OnboardControlSensorsHealth"); } }
        public ushort Load { get { return load; } set { load = value; OnPropertyChanged("Load"); } }
        public ushort VoltageBattery { get { return voltageBattery; } set { voltageBattery = value; OnPropertyChanged("VoltageBattery"); } }
        public short CurrentBattery { get { return currentBattery; } set { currentBattery = value; OnPropertyChanged("CurrentBattery"); } }
        public sbyte BatteryRemaining { get { return batteryRemaining; } set { batteryRemaining = value; OnPropertyChanged("BatteryRemaining"); } }
        public ushort DropRateComm { get { return dropRateComm; } set { dropRateComm = value; OnPropertyChanged("DropRateComm"); } }
        public ushort ErrorsComm { get { return errorsComm; } set { errorsComm = value; OnPropertyChanged("ErrorsComm"); } }
        public ushort ErrorsCount1 { get { return errorsCount1; } set { errorsCount1 = value; OnPropertyChanged("ErrorsCount1"); } }
        public ushort ErrorsCount2 { get { return errorsCount2; } set { errorsCount2 = value; OnPropertyChanged("ErrorsCount2"); } }
        public ushort ErrorsCount3 { get { return errorsCount3; } set { errorsCount3 = value; OnPropertyChanged("ErrorsCount3"); } }
        public ushort ErrorsCount4 { get { return errorsCount4; } set { errorsCount4 = value; OnPropertyChanged("ErrorsCount4"); } }

        #endregion

        public SysStatusViewModel()
        {
            MavlinkManager.Instance.SysStatusEvent += GetSysStatus;
        }

        private void GetSysStatus(UasMessage msg)
        {
            var sysStatus = msg as UasSysStatus;

            OnboardControlSensorsPresent = Convert.ToUInt32(sysStatus.OnboardControlSensorsPresent);
            OnboardControlSensorsEnabled = Convert.ToUInt32(sysStatus.OnboardControlSensorsEnabled);
            OnboardControlSensorsHealth = Convert.ToUInt32(sysStatus.OnboardControlSensorsHealth);
            Load = sysStatus.Load;
            VoltageBattery = sysStatus.VoltageBattery;
            CurrentBattery = sysStatus.CurrentBattery;
            BatteryRemaining = sysStatus.BatteryRemaining;
            DropRateComm = sysStatus.DropRateComm;
            ErrorsComm = sysStatus.ErrorsComm;
            ErrorsCount1 = sysStatus.ErrorsCount1;
            ErrorsCount2 = sysStatus.ErrorsCount2;
            ErrorsCount3 = sysStatus.ErrorsCount3;
            ErrorsCount4 = sysStatus.ErrorsCount4;
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
