using System.Collections.ObjectModel;
using System.IO.Ports;

namespace MavlinkTester.Model
{
    public class SerialConnectItem
    {
        public ObservableCollection<string> ComPort { get; set; }
        public ObservableCollection<int> Baudrate { get; set; }

        public string SelectedComPort { get; set; }
        public int SelectedBaudrate { get; set; }


        public SerialConnectItem()
        {
            ComPort = new ObservableCollection<string>();
            Baudrate = new ObservableCollection<int>();

            Baudrate.Add(57600);
            Baudrate.Add(115200);

            RefeshSerialPort();
        }

        public void RefeshSerialPort()
        {
            ComPort.Clear();

            foreach (string searchPort in SerialPort.GetPortNames())
            {
                ComPort.Add(searchPort);
            }
        }
    }
}
