using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Employee
{
    public interface INewEmployee
    {
        string employee_id { get; }
        string Nametext { get; set; }
        string Emailtext { get; set; }
        string Citizen_idtext { get; set; }
        string Addresstext { get; set; }
        string Positiontext { get; set; }
        string PhoneNumtext { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string message { get; set; }
    }
}
