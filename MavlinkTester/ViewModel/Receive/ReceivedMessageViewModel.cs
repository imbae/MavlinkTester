using MavlinkTester.Model;
using MavlinkTester.View;
using System.ComponentModel;

namespace MavlinkTester.ViewModel
{
    class ReceivedMessageViewModel : INotifyPropertyChanged
    {
        private enum ControlIndex
        {
            HeartBeat = 0,
            SysStatus,
            GpsRawInt,
            Attitude,
            LocalPositionNed,
            ServoOutputRaw,
            VfrHud,
            PositionTargetGlobalInt,
            HighresImu,
            Altitude,
            BatteryStatus
        }

        private ControlItem selectedControl;
        private int selectedListViewIndex;

        public ControlItem SelectedControl { get { return selectedControl; } set { selectedControl = value; OnPropertyChanged("SelectedControl"); } }
        public int SelectedListViewIndex { get { return selectedListViewIndex; } set { selectedListViewIndex = value; ChangedControl(value); OnPropertyChanged("SelectedListViewIndex"); } }
        public ControlItem[] ControlItems { get; set; }
       

        public ReceivedMessageViewModel()
        {
            InitializeControl();

            SelectedListViewIndex = 0;
        }

        private void InitializeControl()
        {
            ControlItems = new[]
            {
                new ControlItem (ControlIndex.HeartBeat.ToString(), new HeartbeatView { DataContext = new HeartbeatViewModel() } ),
                new ControlItem (ControlIndex.SysStatus.ToString(), new SysStatusView { DataContext = new SysStatusViewModel() } ),
                new ControlItem (ControlIndex.GpsRawInt.ToString(), new GpsRawIntView { DataContext = new GpsRawIntViewModel() } ),
                new ControlItem (ControlIndex.Attitude.ToString(), new AttitudeView { DataContext = new AttitudeViewModel() } ),
                new ControlItem (ControlIndex.LocalPositionNed.ToString(), new LocalPositionNedView { DataContext = new LocalPositionNedViewModel() } ),
                new ControlItem (ControlIndex.ServoOutputRaw.ToString(), new ServoOutputRawView { DataContext = new ServoOutputRawViewModel() } ),
                new ControlItem (ControlIndex.VfrHud.ToString(), new VfrHudView { DataContext = new VfrHudViewModel() } ),
                new ControlItem (ControlIndex.PositionTargetGlobalInt.ToString(), new PositionTargetGlobalIntView { DataContext = new PositionTargetGlobalIntViewModel() } ),
                new ControlItem (ControlIndex.HighresImu.ToString(), new HighresImuView { DataContext = new HighresImuViewModel() } ),
                new ControlItem (ControlIndex.Altitude.ToString(), new AltitudeView { DataContext = new AltitudeViewModel() } ),
                new ControlItem (ControlIndex.BatteryStatus.ToString(), new BatteryStatusView { DataContext = new BatteryStatusViewModel() } ),
            };

            SelectedControl = ControlItems[0];
        }

        private void ChangedControl(int index)
        {
            SelectedControl = ControlItems[index];
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
