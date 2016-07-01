namespace Cloudant_IoT_Sumulated_Device_Ext
{
    #region Sensor
    /// <summary>
    /// Sensor class 
    /// this class is used to manage data from sensors
    /// </summary>
    public class Sensor
    {
        public string _id;

        public string recordtitle;
        public string record;
        public string origtime;

        public int displacement;
        public int temp;
        public int hmdt;
        public long modified;
        public string tags;

        public string city;
        public double lat;
        public double lon;

        public string deviceId;
        public string userMessage;
        public string errorMessage;        
    }
    #endregion Sensor

}
