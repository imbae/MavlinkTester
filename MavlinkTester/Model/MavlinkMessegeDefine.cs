
namespace MavlinkTester.Model
{
    public enum MavlinkMessageID
    {
        HEARTBEAT = 0,
        SYS_STATUS = 1,
        SYSTEM_TIME = 2,
        GPS_RAW_INT = 24,
        ATTITUDE = 30,
        ATTITUDE_QUATERNION = 31,
        LOCAL_POSITION_NED = 32,
        GLOBAL_POSITION_INT = 33,
        SERVO_OUTPUT_RAW = 36,
        MISSION_ITEM = 39,
        MISSION_REQUEST = 40,
        MISSION_CURRENT = 42,
        MISSION_COUNT = 44,
        MISSION_ITEM_REACHED = 46,
        MISSION_ACK = 47,
        NAV_CONTROLLER_OUTPUT = 62,
        VFR_HUD = 74,
        ATTITUDE_TARGET = 83,
        POSITION_TARGET_GLOBAL_INT = 87,
        HIGHRES_IMU = 105,
        TIMESYNC = 111,
        ACTUATOR_CONTROL_TARGET = 140,
        ALTITUDE = 141,
        BATTERY_STATUS = 147,
        ESTIMATOR_STATUS = 230,
        WIND_COV = 231,
        VIBRATION = 241,
        HOME_POSITION = 242,
        EXTENDED_SYS_STATE = 245,
        STATUS_TEXT = 253
    }
}
