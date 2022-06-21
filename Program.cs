using MAS_Final_Music_Store.Models;
using MAS_Final_Music_Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace MAS_Final_Music_Store
{
    static class Program
    {
        public static Person GlobalCustomer;

        private static void InitializeGlobalCustomer()
        {
            IPersonRepository pr = new PersonRepository(new Context());
            GlobalCustomer = pr.GetCustomerById(1);
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeGlobalCustomer();
            /*AllocConsole();
            
            IInstrumentRepository ir = new InstrumentRepository(new Context());
            foreach (var i in ir.GetAllInstruments())
            {
                Console.WriteLine(i.GetType().Name);
            }
            ElectricGuitar instrument = new ElectricGuitar
            {
                Name = "Pacifica 20012",
                Description = "desc1",
                Photo = null,
                Quantity = 10,
                StringsNum = 6,
                Material = "wood",
                Voltage = 100,
                Input = "dwqdq",
                SinglesNum = 2,
                HumbuckersNum = 2,
                BrandId = 1
            };
            ir.UpdateInstrument(3, instrument);*/

            /* PersonRepository pr = new(new Context());
             var a = pr.CustomerBoughtInstrumentWithId(2, 1);
             var b = pr.CustomerBoughtInstrumentWithId(2, 2);
             var c = pr.CustomerBoughtInstrumentWithId(2, 3);*/


            /* OrderInstrument oi1 = new OrderInstrument { InstrumentId = 1, OrderId = 1, Quantity = 4 };
             OrderInstrument oi2 = new OrderInstrument { InstrumentId = 1, OrderId = 1, Quantity = 4 };
             OrderInstrument oi3 = new OrderInstrument { InstrumentId = 1, OrderId = 1, Quantity = 4 };*/

            //Person person = new Person { PersonId = 1, PersonTypes = new HashSet<PersonType> { PersonType.Customer}};
            /*PersonRepository pr = new(new Context());
            var person = pr.GetPersonById(1);
            Console.WriteLine(person.PersonId);
            Person dummy = new Person 
            { 
                Name = "Adrian", 
                Surname = "Chervinchuk", 
                Address = person.Address, 
                Email = person.Email, 
                PhoneNumber = person.PhoneNumber 
            };
            pr.UpdatePerson(person.PersonId, dummy);*/


            //byte[] image = System.IO.File.ReadAllBytes(@"C:\Users\adria\OneDrive\Pulpit\VOLKI-krasivye-i-ochen-umnye-zhivotnye.jpg");
            //Console.WriteLine(image.Length);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
