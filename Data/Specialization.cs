﻿namespace DoAn_API.Data
{
    public class Specialization
    {
        public string specialization { get; set; }
        public int specializationId { get; set; }
        public ICollection<Doctor> doctors { get; set; }
        public Specialization()
        {
            doctors = new List<Doctor>();
        }
    }
}