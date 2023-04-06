using GenericFrameworkComponent.UIFrameworkUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class JSONUtil
    {
        public static JObject LoadJson(string fileName)
        {

            JObject? JsonObject = null;
            try
            {
                using (StreamReader file = File.OpenText(FileFolderUtil.JSONFilePath(fileName)))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonObject = (JObject)JToken.ReadFrom(reader);
                }
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to read JSON file: " + fileName + " due to reason: ");
            }
            return JsonObject;
        }

        public static string getJSONData(JObject jo)
        {
            string jsonString = null;

            try
            {
                jsonString = jo.ToString();
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to read JSON data from JSON object due to reason: ");
            }
            return jsonString;
        }

        public static string readJSONObject(string jsonString, string parentKeyNAme, string childKeyName)
        {
            JObject jsonObjectParent = null;
            JObject jsonObjectChild = null;
            string valueOfChildKey = null;

            try
            {
                jsonObjectParent = JObject.Parse(jsonString);
                jsonObjectChild = JObject.Parse(jsonObjectParent.GetValue(parentKeyNAme).ToString());
                valueOfChildKey = jsonObjectChild.GetValue(childKeyName).ToString();
                LogUtil.infoLog("Parent key: " + parentKeyNAme + " and Child key: " + childKeyName + " and child key value is: " + valueOfChildKey);
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to read JSON data of parent key: " + parentKeyNAme + " and child key " + childKeyName + " due to reason: ");
            }

            return valueOfChildKey;
        }

        public static string readJSONArray(string jsonString, string parentKeyNAme, string value)
        {
            JObject? jsonObjectParent = null;
            JArray? jsonArrayChild = null;
            string? valueOfChildKey = null;

            try
            {
                jsonObjectParent = JObject.Parse(jsonString);
                jsonArrayChild = JArray.Parse(jsonObjectParent.GetValue(parentKeyNAme).ToString());
                for (int i = 0; i < jsonArrayChild.Count(); i++)
                {
                    if (jsonArrayChild[i].ToString().Equals(value))
                    {
                        valueOfChildKey = jsonArrayChild[i].ToString();
                        break;
                    }
                }
                LogUtil.infoLog("Parent key: " + parentKeyNAme + " and child key value is: " + valueOfChildKey);
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to read JSON data of parent key: " + parentKeyNAme + " does not have value " + value + " due to reason: ");
            }

            return valueOfChildKey;
        }

        public static void createJson(string fileName, string JSONData)
        {
            try
            {
                File.WriteAllText(FileFolderUtil.JSONFilePath(fileName), JSONData);
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to create JSON file: " + fileName + " due to reason: ");
            }
        }
    }
}
