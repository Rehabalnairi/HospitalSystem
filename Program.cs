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
        }//
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
