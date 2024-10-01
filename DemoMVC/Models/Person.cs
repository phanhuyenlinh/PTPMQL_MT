using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Person
    {
        [Key]
        public string cancuoccongdan { get; set; }
        public string hoten { get; set; }
        public string quequan { get; set; }

    }

}