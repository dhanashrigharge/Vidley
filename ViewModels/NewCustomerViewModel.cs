using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> Membershiptype { get; set; }
        public Customer Customer { get; set; }
    }
}