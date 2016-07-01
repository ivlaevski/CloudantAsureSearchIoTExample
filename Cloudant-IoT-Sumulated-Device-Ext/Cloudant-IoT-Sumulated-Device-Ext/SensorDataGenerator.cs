using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloudant_IoT_Sumulated_Device_Ext
{
    public class SensorDataGenerator
    {
        static Random R = new Random();
        static string[] sensorNames = new[] { "sensorA", "sensorB", "sensorC", "sensorD", "sensorE" };

        static string[] deviceIds = new[] {
            "{B0D4243B-C27D-4D89-94AB-4328D202506D}",
            "{F98FC94F-3F6B-41D9-B32E-D3F7F5A68555}",
            "{152AAF23-A37B-4767-AD1D-C021F80E668F}",
            "{997AD563-33F5-497A-B8AE-CFEE7944C93F}",
            "{2817F691-089F-4B7E-9749-2DE9B6E31955}" };


        static string[] cityes = new[] {
            "Coral Hills",
            "Redmond",
            "Layton",
            "Santa Maria",
            "Homestead"};

        static double[] lats = new[] {
            38.878333,
            39.009013,
            41.072834,
            34.960212,
            25.462703};

        static double[] lons = new[] {
            -76.922701,
            -111.862000,
            -111.979355,
            -120.441797,
            -80.446846};

        static string[] errorMessages = new[] {
            "",
            "ERROR-001: Simple error",
            "ERROR-002: Complicated error with more thext",
            "ERROR-003: More Complicated error message with \n new lines. And long text descriptions. \n Amd more..."};
        static int[] errorMessagesWight = new[] { 20, 5, 3, 2 };
        static int totalErrorMessagesWight = 30;

        static string[] userMessages = new[] {
            "",
            "Today I have issues with my sensor",
            "Hi, technical revision is needed",
            "I don not see any issues with the device"};
        static int[] userMessagesWight = new[] { 20, 2, 3, 5 };
        static int totalUserMessagesWight = 30;

        public static Sensor Generate()
        {
            var sensorname = sensorNames[R.Next(sensorNames.Length)];
            var deviceID = R.Next(deviceIds.Length);
            var errorRnd = R.Next(totalErrorMessagesWight);
            var userRnd = R.Next(totalUserMessagesWight);
            string error = "";
            int i = 0;
            while (errorRnd >0 )
            {
                error = errorMessages[i];                
                errorRnd = errorRnd - errorMessagesWight[i];
                i++;
            }
            string user = "";
            i = 0;
            while (userRnd > 0)
            {
                user = userMessages[i];
                userRnd = userRnd - userMessagesWight[i];
                i++;
            }
            var id = DateTime.Now.ToJavaScriptMilliseconds().ToString();
            return new Sensor
            {
                origtime = DateTime.UtcNow.ToString(),
                displacement = R.Next(30, 70),
                temp = R.Next(70, 150),
                hmdt = R.Next(30, 70),
                modified = DateTime.Now.ToJavaScriptMilliseconds(),
                recordtitle = sensorname,
                record = sensorname + " record",
                _id = id,
                tags = "Generated",
                deviceId = deviceIds[deviceID],
                city = cityes[deviceID],
                lat = lats[deviceID],
                lon = lons[deviceID],
                errorMessage = error,
                userMessage = user
            };
        }
    }
}
