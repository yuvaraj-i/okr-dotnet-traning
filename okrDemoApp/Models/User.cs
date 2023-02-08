using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace okrDemoApp.Models;

public class User
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }

}


