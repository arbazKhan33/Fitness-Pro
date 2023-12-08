using Microsoft.AspNetCore.Identity;

namespace FitnessPro.ViewModel
{
    public class MailSettings
    {
        //configure and use smtp server from google 

        public string? Mail { get; set; }
        public string? DisplayNmae { get; set; }
        public string? Password { get; set; }
        public string? Host {get;set;}
        public int Port { get; set; }
    }
}
