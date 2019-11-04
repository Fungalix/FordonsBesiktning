using System;


namespace FordonsBesiktning.Models
{
    class Reservation
    {
        public int Id { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public DateTime Date { get; protected set; }
        public Reservation(string registrationNumber, DateTime date)
        {
            RegistrationNumber = registrationNumber;
            Date = date;
        }
        public Reservation(int id, string registrationNumber, DateTime date)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            Date = date;
        }
    }
}
