namespace HospitalSystem
{
    internal class Program
    {
        //create doctor class 
        class Doctors
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Specialization { get; set; }
            public DateTime AvailabileAppointment { get; set; }
            public Doctors(string name, string specialization, int experience)
            {
                Id = Id;
                Name = name;
                Specialization = specialization;
                AvailabileAppointment = DateTime.Now.AddDays(7); // Example: next available appointment in 7 days

            }
            public void DisplayInfo()
            {
                Console.WriteLine("Doctor ID: " + Id);
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Specialization: " + Specialization);
                Console.WriteLine("Available Appointment: " + AvailabileAppointment.ToString("dd/MM/yyyy"));

            }
            // create patient class
            class Patients
            {
                public string Id { get; set; }
                public string Name { get; set; }
                public int Age { get; set; }
                public string Phone { get; set; }

                public Patients(string name, int age, string phone)
                {
                    Id = Id;
                    Name = name;
                    Age = age;
                    Phone = phone;

                }
                public void DisplayInfo()
                {
                    Console.WriteLine("Patient ID: " + Id);
                    Console.WriteLine("Name: " + Name);
                    Console.WriteLine("Age: " + Age);
                    Console.WriteLine("Phone: " + Phone);
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
} 
