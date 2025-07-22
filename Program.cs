using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem
{
    class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
        }
    }

    class Doctor : Person
    {
        public string Specialization { get; set; }
        public List<DateTime> AvailableAppointments { get; set; }

        public Doctor(string name, string specialization, List<DateTime> availableAppointments)
            : base(name)
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

        public Patient(string name, int age, string phoneNumber)
            : base(name)
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

    class Hospital
    {
        private List<Doctor> doctors = new List<Doctor>();
        private List<Patient> patients = new List<Patient>();
        private List<Appointment> appointments = new List<Appointment>();

        public void AddDoctor()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine();

            var availableAppointments = new List<DateTime>();
            Console.Write("How many available appointments? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter appointment date {i + 1} (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                availableAppointments.Add(date);
            }

            var doctor = new Doctor(name, specialization, availableAppointments);
            doctors.Add(doctor);
            Console.WriteLine("Doctor added successfully.\n");
        }

        public void AddPatient()
        {
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            var patient = new Patient(name, age, phone);
            patients.Add(patient);
            Console.WriteLine("Patient added successfully.\n");
        }

        public void BookAppointment()
        {
            if (doctors.Count == 0 || patients.Count == 0)
            {
                Console.WriteLine("Please add doctors and patients first.\n");
                return;
            }

            Console.WriteLine("Available Doctors:");
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {doctors[i].Name} - {doctors[i].Specialization}");
            }

            Console.Write("Select Doctor (number): ");
            int doctorIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Available Patients:");
            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {patients[i].Name}");
            }

            Console.Write("Select Patient (number): ");
            int patientIndex = int.Parse(Console.ReadLine()) - 1;

            var selectedDoctor = doctors[doctorIndex];
            var selectedPatient = patients[patientIndex];

            if (selectedDoctor.AvailableAppointments.Count == 0)
            {
                Console.WriteLine("No available appointments for this doctor.\n");
                return;
            }

            Console.WriteLine("Available Appointment Dates:");
            for (int i = 0; i < selectedDoctor.AvailableAppointments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedDoctor.AvailableAppointments[i]:dd/MM/yyyy}");
            }

            Console.Write("Select Appointment Date (number): ");
            int dateIndex = int.Parse(Console.ReadLine()) - 1;

            DateTime appointmentDate = selectedDoctor.AvailableAppointments[dateIndex];

            // Prevent double-booking a doctor
            bool isBooked = appointments.Any(a =>
                a.Doctor == selectedDoctor && a.AppointmentDate.Date == appointmentDate.Date);

            if (isBooked)
            {
                Console.WriteLine("This appointment slot is already booked.\n");
                return;
            }

            selectedDoctor.AvailableAppointments.RemoveAt(dateIndex);
            var appointment = new Appointment(selectedDoctor, selectedPatient, appointmentDate);
            appointments.Add(appointment);
            Console.WriteLine("Appointment booked successfully.\n");
        }

        public void DisplayAllAppointments()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.\n");
                return;
            }

            foreach (var app in appointments)
            {
                app.DisplayAppointmentInfo();
                Console.WriteLine();
            }
        }

        public void ShowDoctorsBySpecialization()
        {
            Console.Write("Enter specialization to search: ");
            string spec = Console.ReadLine();

            var filtered = doctors.FindAll(d => d.Specialization.Equals(spec, StringComparison.OrdinalIgnoreCase));

            if (filtered.Count == 0)
            {
                Console.WriteLine("No doctors found with that specialization.\n");
                return;
            }

            foreach (var doc in filtered)
            {
                doc.DisplayInfo();
                Console.WriteLine();
            }
        }
        /// Search appointments by patient name or date
        public void SearchAppointmentsByPatientName()
        {
            Console.Write("Enter patient name to search: ");
            string name = Console.ReadLine();

            var results = appointments.Where(a => a.Patient.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No appointments found for that patient.\n");
                return;
            }

            foreach (var app in results)
            {
                app.DisplayAppointmentInfo();
                Console.WriteLine();
            }
        }
        
        public void SearchAppointmentsByDate()
        {
            Console.Write("Enter date to search (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            var results = appointments.Where(a => a.AppointmentDate.Date == date.Date).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No appointments found on that date.\n");
                return;
            }

            foreach (var app in results)
            {
                app.DisplayAppointmentInfo();
                Console.WriteLine();
            }


        }

        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            while (true)
            {
                Console.WriteLine("\nHospital System Menu:");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Add Patient");
                Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. Display All Appointments");
                Console.WriteLine("5. Show Doctors by Specialization");
                Console.WriteLine("6. Search Appointments by Patient Name");
                Console.WriteLine("7. Search Appointments by Date");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": hospital.AddDoctor(); break;
                    case "2": hospital.AddPatient(); break;
                    case "3": hospital.BookAppointment(); break;
                    case "4": hospital.DisplayAllAppointments(); break;
                    case "5": hospital.ShowDoctorsBySpecialization(); break;
                    case "6": hospital.SearchAppointmentsByPatientName(); break;
                    case "7": hospital.SearchAppointmentsByDate(); break;
                    case "8": return;
                    default: Console.WriteLine("Invalid choice.\n"); break;
                }
            }
        }
    }
}
