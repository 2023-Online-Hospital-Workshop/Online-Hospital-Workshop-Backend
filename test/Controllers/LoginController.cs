using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ModelContext _context;

        public LoginController(ModelContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string login(string user_id)
        {
            Message message = new();
            try
            {
                var patient_info = _context.Patients
                    .Where(patient => patient.PatientId == user_id)
                    .Select(patient => new
                    {
                        patient.PatientId,
                        patient.Name,
                    }).First();
                message.Add("userid", patient_info.PatientId);
                message.Add("username", patient_info.Name);
                message.Add("errorCode", 200);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }

            return message.ReturnJson();
        }
    }

}



/*
namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ModelContext myContext; // 创建一个模型上下文对象

        // 构造函数，在每次调用该Controller中的api函数时，都会创建一个context对象用于操作数据库
        public LoginController(ModelContext modelContext)
        {
            myContext = modelContext;
        }

        // 在此处敲api函数
        [HttpPost]
        public string login(string user_phone, string password)
        {
            Message message = new();
            try
            {
                var user_info = myContext.Users
                .Where(user => user.UserPhone == user_phone && user.UserPassword == password)
                .Select(user => new
                {
                    user.UserId,
                    user.UserName,
                }).First();
                message.Add("userid", user_info.UserId);
                message.Add("username", user_info.UserName);
                message.Add("errorCode", 200);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }

            return message.ReturnJson();
        }
    }
}
*/