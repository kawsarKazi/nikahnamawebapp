﻿namespace NikahMetromoniApp.Models
{
    public class ContactRequest
    {
        public long Id { get; set; }
        public string PersonalId { get; set; }  
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; } 
    }
}