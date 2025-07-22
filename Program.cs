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
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Id = Guid.NewGuid().ToString();
                Name = name;
                Age = age;
            }

            public virtual void DisplayInfo() // Method to display person information
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Age: " + Age);
            }
        }

    
    //create doctor class 
    class Doctors: Person
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
            class Patients : Person
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
                /*
                 *  Appointment class 
                 • AppointmentId (int) 
                 • Doctor (Doctor object) 
                 • Patient (Patient object) 
                 • AppointmentDate (DateTime)
                 
                 */
                class Appointment
                {
                    public string Id { get; set; } = string.Empty;
                    public Doctors Doctor { get; set; }
                    public Patients Patient { get; set; }
                    private DateTime AppointmentDate { get; set; }
                    public Appointment(Doctors doctor, Patients patient, DateTime appointmentDate)
                    {
                        Id = Id;
                        Doctor = doctor;
                        Patient = patient;
                        AppointmentDate = appointmentDate;
                    }
                }
                //Create a base class: Person 
                
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
} 
