using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblCrew
    {
        public int CrewId { get; set; }
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public string Cdcnumber { get; set; }
        public bool? IsOtherCdc { get; set; }
        public string OtherCdcnumber { get; set; }
        public string CrewFirstName { get; set; }
        public string CrewLastName { get; set; }
        public string CareerObjective { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string CurrentDesgination { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaritalStatus { get; set; }
        public string EmergencyContact { get; set; }
        public string EmrgCntName { get; set; }
        public string Relation { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string SkypeId { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
    }
}
