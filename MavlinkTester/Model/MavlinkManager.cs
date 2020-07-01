using MavLinkNet;
using System;
using System.Diagnostics;

namespace MavlinkTester.Model
{
    public class MavlinkManager
    {
        public MavLinkSerialPortTransport MavSerialTransport { get; set; } = new MavLinkSerialPortTransport();

        public void ConnectMavlinkSerial(string port, int baudrate)
        {
            MavSerialTransport.MavlinkSystemId = 1;
            MavSerialTransport.MavlinkComponentId = 12;
            MavSerialTransport.SerialPortName = port;
            MavSerialTransport.BaudRate = baudrate;
            MavSerialTransport.Initialize();
            MavSerialTransport.OnPacketReceived += OnMavLinkPacketReceived;

        }

        public void DisconnectMavlinkSerial()
        {
            MavSerialTransport.OnPacketReceived -= OnMavLinkPacketReceived;
            MavSerialTransport.Dispose();
        }

        private void OnMavLinkPacketReceived(object sender, MavLinkPacket packet)
        {
            switch (packet.MessageId)
            {
                case (byte)MavlinkMessageID.HEARTBEAT:
                    {
                        HeartbeatEvent?.Invoke(packet.Message as UasHeartbeat);
                        break;
                    }
                case (byte)MavlinkMessageID.SYS_STATUS:
                    {
                        SysStatusEvent?.Invoke(packet.Message as UasSysStatus);
                        break;
                    }
                case (byte)MavlinkMessageID.GPS_RAW_INT:
                    {
                        GpsRawIntEvent?.Invoke(packet.Message as UasGpsRawInt);
                        break;
                    }
                case (byte)MavlinkMessageID.ATTITUDE:
                    {
                        AttitudeEvent?.Invoke(packet.Message as UasAttitude);
                        break;
                    }
                case (byte)MavlinkMessageID.LOCAL_POSITION_NED:
                    {
                        LocalPositionNedEvent?.Invoke(packet.Message as UasLocalPositionNed);
                        break;
                    }
                case (byte)MavlinkMessageID.SERVO_OUTPUT_RAW:
                    {
                        ServoOutputRawEvent?.Invoke(packet.Message as UasServoOutputRaw);
                        break;
                    }
                case (byte)MavlinkMessageID.VFR_HUD:
                    {
                        VfrHudEvent?.Invoke(packet.Message as UasVfrHud);
                        break;
                    }
                case (byte)MavlinkMessageID.POSITION_TARGET_GLOBAL_INT:
                    {
                        PositionTargetGlobalIntEvent?.Invoke(packet.Message as UasPositionTargetGlobalInt);
                        break;
                    }
                case (byte)MavlinkMessageID.HIGHRES_IMU:
                    {
                        HighresImuEvent?.Invoke(packet.Message as UasHighresImu);
                        break;
                    }
                case (byte)MavlinkMessageID.ALTITUDE:
                    {
                        AltitudeEvent?.Invoke(packet.Message as UasAltitude);
                        break;
                    }
                case (byte)MavlinkMessageID.BATTERY_STATUS:
                    {
                        BatteryStatusEvent?.Invoke(packet.Message as UasBatteryStatus);
                        break;
                    }
                default:
                    Debug.WriteLine(packet.MessageId);
                    break;
            }
        }


        #region Delegate & Event

        public delegate void MessageDelegate(UasMessage msg);

        public event MessageDelegate HeartbeatEvent;
        public event MessageDelegate SysStatusEvent;
        public event MessageDelegate GpsRawIntEvent;
        public event MessageDelegate AttitudeEvent;
        public event MessageDelegate LocalPositionNedEvent;
        public event MessageDelegate ServoOutputRawEvent;
        public event MessageDelegate VfrHudEvent;
        public event MessageDelegate PositionTargetGlobalIntEvent;
        public event MessageDelegate HighresImuEvent;
        public event MessageDelegate AltitudeEvent;
        public event MessageDelegate BatteryStatusEvent;

        #endregion

        #region SingleTon

        private static readonly Lazy<MavlinkManager> lazy = new Lazy<MavlinkManager>(() => new MavlinkManager());

        public static MavlinkManager Instance { get { return lazy.Value; } }

        private MavlinkManager()
        {

        }

        #endregion
    }
}
