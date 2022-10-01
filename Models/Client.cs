﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Fitlance.Models
{
    [Table("Clients")]
    public class Client
    {
        public int? Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string? FirstName { get; set; }
        public int? LastName { get; set; }
        public EmailAddressAttribute? EmailAddress { get; set; }
        public string? City { get; set; }
        public int? ZipCode { get; set; }
        public Blob ProfileImage { get; set; }
        public string? Bio { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
