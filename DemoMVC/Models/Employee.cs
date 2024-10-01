using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Employee : Person
    {
        public string Mamon {get; set; }
        public string Monhoc {get; set; }
    }
}