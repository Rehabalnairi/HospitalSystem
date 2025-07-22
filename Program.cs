namespace HospitalSystem
{
    internal class Program
    {
        // Create a base class: Person


        // Base class: Person
        class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
          

            public Person(string name, int age)
            {
                Id = Guid.NewGuid().ToString();
                Name = name;
              
            }

            public virtual void DisplayInfo() // Method to display person information
            {

                Console.WriteLine($"ID: {Id}");
                Console.WriteLine($"Name: {Name}");

            }
        }


        //create doctor class 

        class Doctor : Person
        {
            public string Specialization { get; set; }
            public List<DateTime> AvailableAppointments { get; set; }

            public Doctor(int id, string name, string specialization, List<DateTime> availableAppointments)
                : base(name,id)
            {
                Specialization = specialization;
                AvailableAppointments = availableAppointments;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Specialization: {Specialization}");
                Console.WriteLine("Available Appointments:");
                foreach (var date in AvailableAppointments)
                {
                    Console.WriteLine($" - {date:dd/MM/yyyy}");
                }
            }
        }
        class Patient : Person
        {


            public int Age { get; set; }
            public string PhoneNumber { get; set; }

            public Patient(int id, string name, int age, string phoneNumber)
                : base(name,id)
            {
                Age = age;
                PhoneNumber = phoneNumber;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Phone Number: {PhoneNumber}");
            }
        }
        // Create a class: Appointment
        class Appointment
        {
            public string Id { get; set; }
            public Doctor Doctor { get; set; }
            public Patient Patient { get; set; }
            public DateTime AppointmentDate { get; set; }
            public Appointment(Doctor doctor, Patient patient, DateTime appointmentDate)
            {
                Id = Guid.NewGuid().ToString();
                Doctor = doctor;
                Patient = patient;
                AppointmentDate = appointmentDate;
            }
            public void DisplayAppointmentInfo()
            {
                Console.WriteLine($"Appointment ID: {Id}");
                Console.WriteLine($"Doctor: {Doctor.Name} ({Doctor.Specialization})");
                Console.WriteLine($"Patient: {Patient.Name} (Age: {Patient.Age})");
                Console.WriteLine($"Appointment Date: {AppointmentDate:dd/MM/yyyy}");
            }


        }
        static void Main(string[] args)
        {
            // Create instances of Doctor and Patient
            var doctor = new Doctor("Dr. Smith", "Cardiology", new List<DateTime> { DateTime.Now.AddDays(1), DateTime.Now.AddDays(2) });
            var patient = new Patient("John Doe", 30, "123-456-7890");
            // Display information
            doctor.DisplayInfo();
            Console.WriteLine();
            patient.DisplayInfo();
            Console.WriteLine();
            // Create an appointment
            var appointment = new Appointment(doctor, patient, DateTime.Now.AddDays(1));
            appointment.DisplayAppointmentInfo();
            Console.ReadLine();
        }
    }
} 
