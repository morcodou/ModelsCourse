using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurisTempus.ViewModels
{
  public class ClientViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    //public Address Address { get; set; }
    public string Phone { get; set; }
    public string ContactName { get; set; }

    //public ICollection<Case> Cases { get; set; }
    //public ICollection<Invoice> Invoices { get; set; }
  }
}
