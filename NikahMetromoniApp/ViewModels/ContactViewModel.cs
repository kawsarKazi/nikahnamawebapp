using System.Collections.Generic;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            ContactRequests= new List<ContactRequest>();
        }
        public List<ContactRequest> ContactRequests { get; set; }   
    }
}