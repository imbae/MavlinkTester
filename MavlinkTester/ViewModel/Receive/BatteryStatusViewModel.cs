using MavLinkNet;
using MavlinkTester.Model;
using System;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class BatteryStatusViewModel : INotifyPropertyChanged
    {
        #region Binding Field

        private byte id;
        private byte batteryFunction;
        private byte type;
        private short temperature;
        private ushort[] voltages = new ushort[10];
        private short currentBattery;
        private int currentConsumed;
        private int energyConsumed;
        private sbyte batteryRemaining;

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public byte BatteryFunction { get { return batteryFunction; } set { batteryFunction = value; OnPropertyChanged("BatteryFunction"); } }
        public byte Type { get { return type; } set { type = value; OnPropertyChanged("Type"); } }
        public short Temperature { get { return temperature; } set { temperature = value; OnPropertyChanged("Temperature"); } }
        public ushort[] Voltages { get { return voltages; } set { voltages = value; OnPropertyChanged("Voltages"); } }
        public short CurrentBattery { get { return currentBattery; } set { currentBattery = value; OnPropertyChanged("CurrentBattery"); } }
        public int CurrentConsumed { get { return currentConsumed; } set { currentConsumed = value; OnPropertyChanged("CurrentConsumed"); } }
        public int EnergyConsumed { get { return energyConsumed; } set { energyConsumed = value; OnPropertyChanged("EnergyConsumed"); } }
        public sbyte BatteryRemaining { get { return batteryRemaining; } set { batteryRemaining = value; OnPropertyChanged("BatteryRemaining"); } }

        #endregion

        public BatteryStatusViewModel()
        {
            MavlinkManager.Instance.BatteryStatusEvent += GetBatteryStatus;
        }

        private void GetBatteryStatus(UasMessage msg)
        {
            var batteryStatus = msg as UasBatteryStatus;

            Id = batteryStatus.Id;
            BatteryFunction = batteryStatus.BatteryFunction;
            Type = batteryStatus.Type;
            Temperature = batteryStatus.Temperature;

            for(int i = 0; i < batteryStatus.Voltages.Length; i++)
            {
                Voltages[i] = batteryStatus.Voltages[i];
            }

            CurrentBattery = batteryStatus.CurrentBattery;
            CurrentConsumed = batteryStatus.CurrentConsumed;
            EnergyConsumed = batteryStatus.EnergyConsumed;
            BatteryRemaining = batteryStatus.BatteryRemaining;
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
