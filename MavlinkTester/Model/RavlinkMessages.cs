using MavlinkTester.Function;

namespace MavlinkTester.Model
{
    public class RavGoNLoiter
    {
        /******************************************************
         * 
         * Packet Structure
         * 
         * ---Type --------------- Name ------------- Length -----
         *    int           Lat                         4
         *    int           Lng                         8
         *    int           Approach_alt                12
         *    int           Loiter_alt                  16
         *    short         Approach_speed              18
         *    short         Loiter_speed                20
         *    int           Loiter_radius               24
         *    int           BitOffset                   28
         *    
         *    BitOffset     Altitude_type               :8
         *    BitOffset     Altitude0                   :24
        ******************************************************/

        #region Payload

        /// <summary>
        /// latitude(2e-9rad)
        /// </summary>
        public int Lat { get; set; }

        /// <summary>
        /// longitude(2e-9rad)
        /// </summary>
        public int Lng { get; set; }

        /// <summary>
        /// approach altitude(cm)
        /// </summary>
        public int Approach_alt { get; set; }

        /// <summary>
        /// loitering altitude(cm)
        /// </summary>
        public int Loiter_alt { get; set; }

        /// <summary>
        /// approach speed(cm/s)
        /// </summary>
        public short Approach_speed { get; set; }

        /// <summary>
        /// loitering speed(cm/s)
        /// </summary>
        public short Loiter_speed { get; set; }

        /// <summary>
        /// radius(cm) of turn : CW turn for positive radius, CCW for negative ratius
        /// </summary>
        public int Loiter_radius { get; set; }

        /// <summary>
        /// [0:7] Altitude_type
        /// [8:31] Altitude0
        /// </summary>
        public int BitOffset { get; set; }

        #endregion

        #region Bitoffset

        /// <summary>
        /// altitude type(0: baro alt, 1:wgs-84 absolute, 2:wgs-84 from ground)
        /// </summary>
        public sbyte Altitude_type
        {
            get { return ConvertBitField.GetBitField<sbyte>(BitOffset, 0, 8); }
            set { BitOffset = ConvertBitField.SetBitField(value, BitOffset, 0, 8); }
        }

        /// <summary>
        /// reference altitude for altitude type-2(cm)
        /// </summary>
        public int Altitude0
        {
            get { return ConvertBitField.GetBitField<int>(BitOffset, 8, 24); }
            set { BitOffset = ConvertBitField.SetBitField(value, BitOffset, 8, 24); }
        }

        #endregion
    }
}
