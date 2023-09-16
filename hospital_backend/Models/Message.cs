
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace hospital_backend.Models
{
    public class Message//传递消息的基类，各种消息可以继承这个类来构造
    {
        private readonly Dictionary<string, object> _data = new();//要返回的数据
        public int errorCode { get; set; } //错误码，用于判断本次操作是否成功
        public bool status { get; set; }   //操作是否成功
        //初始化
        public Message()
        {
            errorCode = 300;
            status = false;
        }
        public void Add(string key, object value)
        {
            _data.Add(key, value);
        }

        public string ReturnJson()
        {
            return JsonSerializer.Serialize(_data);
        }
    }

    //public class 
}


/*
namespace hospital_backend
{
    public class Message
    {
        public int errorCode { get; set; } //错误码，用于判断本次操作是否成功
        public bool status { get; set; }   //操作是否成功
        public Dictionary<string, dynamic> data { get; set; } = new Dictionary<string, dynamic>(); //返回数据

        //初始化
        public Message()
        {
            errorCode = 300;
            status = false;
        }
        //将类以json字符串的形式传递给前端
        public string ReturnJson()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All),
            };
            return JsonSerializer.Serialize(this, options);
        }
    }

    public class RegisterMessage : Message
    {
        public RegisterMessage()
        {
            data.Add("user_id", null);
            errorCode = 300;
            status = false;
        }
    }

    public class LoginMessage : Message
    {
        public LoginMessage()
        {
            errorCode = 300;
            status = false;
            //data.Add("user_id", 0);
            //data.Add("user_password", "none");
            //data.Add("user_email", "none");
            //data.Add("user_phone", "none");
            //data.Add("user_name", null);
            //data.Add("user_profile", null);
            //data.Add("user_createtime", null);
            //data.Add("user_birthday",null);
            //data.Add("user_gender", null);
            //data.Add("user_state", null);
            //data.Add("user_signature", null);
            //data.Add("user_follower", null);
            //data.Add("user_follows", null);
            //data.Add("user_level", null);
            //data.Add("user_coin", null);
        }
    }

    public class FollowMessage : Message
    {
        public FollowMessage()
        {
            errorCode = 300;
            status = false;
        }
    }

    public class UniversityMessage : Message
    {
        public UniversityMessage()
        {
            errorCode = 500;
            status = false;
            data.Add("university_id", 0);
            data.Add("university_email", null);
            data.Add("university_name", null);
            data.Add("university_region", null);
            data.Add("university_country", null);
            data.Add("university_location", null);
            data.Add("university_introduction", null);
            data.Add("university_student_num", null);
            data.Add("university_website", null);
            data.Add("university_college", null);
            data.Add("university_abbreviation", null);
        }
    }

    public class InstitutionMessage : Message
    {
        public InstitutionMessage()
        {
            errorCode = 300;
            status = false;
            //data.Add("institution_id", 0);
            //data.Add("institution_name", null);
            //data.Add("institution_phone", null);
            //data.Add("institution_qualify", null);
            //data.Add("institution_introducion", null);
            //data.Add("institution_profile", null);
            //data.Add("institution_city", null);
            //data.Add("institution_email", null);
            //data.Add("institution_characteristic", null);
            //data.Add("institution_lessons", null);
            //data.Add("institution_createtime", null);
        }
    }



}*/