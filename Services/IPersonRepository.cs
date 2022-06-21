using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IPersonRepository
    {
        List<Person> GetAllCustomers();
        Person GetCustomerById(int id);
        Person CreateCustomer(CustomerDto customer);
        Person UpdateCustomer(int id, CustomerDto customer);
        bool RemoveCustomer(int id);
        bool CustomerBoughtInstrumentWithId(int customerId, int instrumentId);

        List<Person> GetAllWorkers();
        Person GetWorkerById(int id);
        Person CreateWorker(WorkerDto worker);
        Person UpdateWorker(int id, WorkerDto worker);
        bool RemoveWorker(int id);

    }
}
