using JurisTempus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices.WindowsRuntime;

namespace JurisTempus
{
  public class ContactModel : PageModel
  {
    public void OnGet()
    {

    }

    [BindProperty]
    public ContactViewModel ViewModel { get; set; }

    public void OnPost()
    {
      if (ModelState.IsValid)
      {
        return;
      }
    }
  }
}
