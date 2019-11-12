using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCreCaptchaDemo.Models
{
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Comment { get; set; }
}

}