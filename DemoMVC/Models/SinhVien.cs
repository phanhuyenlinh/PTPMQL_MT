using System.ComponentModel.DataAnnotations;
namespace MVC.Models;
public class SinhVien
{
    [Key]
    public string SVID { get; set; }
    public string Name { get; set;}
    public string DC { get; set;}
}
