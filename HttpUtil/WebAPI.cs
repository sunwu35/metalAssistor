using metalAssistor.entity;
using metalAssistor.HttpUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.HttpUtil
{
    class WebAPI
    {
        public static string url = "http://192.168.1.227:8080";
        public const string urlUpload = "/metal-detection/uploadMetalTaskDetail";
        public const string urlTask = "/metal-detection/queryMetalTaskList";
        public const string login = "/auth/login";

        static WebAPI()
        {
            url = InfoBean.Create().URL;
            if (string.IsNullOrWhiteSpace(url)) 
                url = "http://192.168.1.227:8080";
        }
        public static ResultMode UploadData(Dictionary<string, object> data)
        {
            var setting = new JsonSerializerSettings() { 
                ContractResolver=new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() 
            };

            ResultMode r = HttpClient.HttpPostJson(url + urlUpload, JsonConvert.SerializeObject(data,Formatting.None,setting));
            
            return r;
        }
        
        public static List<TaskBean> GetTask()
        {       
            ResultMode r = HttpClient.HttpPostJson(url + urlTask, "");
            if(r.Code == "200")
            {
                return JsonConvert.DeserializeObject<List<TaskBean>>(r.Data.ToString());
            }
            return new List<TaskBean>();
        }


        public static ResultMode Login(string name,string password)
        {
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("username",name);
            info.Add("password",password);
            ResultMode r = HttpClient.HttpPostJson(url + login, JsonConvert.SerializeObject(info));
            if (r.Code == "200")
            {
                LoginMode lm = JsonConvert.DeserializeObject<LoginMode>(r.Data.ToString());
                Constant.Authorization = lm.Access_token;
                Constant.UserName = name;
                Constant.Password = password;
            }
            return r;
        }
    }
}
