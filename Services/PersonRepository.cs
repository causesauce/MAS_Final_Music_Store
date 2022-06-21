using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class PersonRepository : IPersonRepository
    {

        private readonly Context _context;
        public PersonRepository(Context context)
        {
            _context = context;
        }

        private List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.Where(p => p.PersonId == id).FirstOrDefault();
        }
        public bool UpdatePerson(int id, Person person)
        {
            var modifiedPerson = GetPersonById(id);

            if (modifiedPerson is null)
            {
                return false;
            }

            modifiedPerson.ChangePersonlData(person);
            _context.SaveChanges();
            return true;
        }
        bool RemovePerson(int id)
        {
            var removedPerson = GetPersonById(id);
            if (removedPerson is null)
            {
                return false;
            }

            _context.Remove(removedPerson);
            _context.SaveChanges();
            return true;
        }

        public List<Person> GetAllCustomers()
        {
            return _context.Persons.Where(p => p.PersonTypes.Contains(PersonType.Customer)).ToList();
        }

        public List<Person> GetAllWorkers()
        {
            return _context.Persons.Where(p => p.PersonTypes.Contains(PersonType.Worker)).ToList();
        }

        public Person GetCustomerById(int id)
        {
            var person = _context.Persons.Where(p => p.PersonId == id).FirstOrDefault();
            if (!person.PersonTypes.Contains(PersonType.Customer))
            {
                return null; 
            }
            return person;
        }

        public Person GetWorkerById(int id)
        {
            var person = _context.Persons.Where(p => p.PersonId == id).FirstOrDefault();
            if (!person.PersonTypes.Contains(PersonType.Worker))
            {
                return null;
            }
            return person;
        }

        public bool RemoveCustomer(int id)
        {
            var cust = GetCustomerById(id);
            if (cust is null)
            {
                return false;
            }

            _context.Remove(cust);
            _context.SaveChanges();
            return true;

        }

        public bool RemoveWorker(int id)
        {
            var worker = GetWorkerById(id);
            if (worker is null)
            {
                return false;
            }

            _context.Remove(worker);
            _context.SaveChanges();
            return true;
        }

        public Person UpdateCustomer(int id, CustomerDto customer)
        {
            var modifiedCust = GetCustomerById(id);
            if(modifiedCust is null)
            {
                return null;
            }

            if (customer.ChangePersonalData)
            {
                modifiedCust.ChangePersonlData(customer);
            }
            modifiedCust.Balance = customer.Balance;
            modifiedCust.BonusPoints = customer.BonusPoints;

            _context.SaveChanges();
            return modifiedCust;

        }

        public Person UpdateWorker(int id, WorkerDto worker)
        {
            var modifiedWorker = GetWorkerById(id);
            if (modifiedWorker is null)
            {
                return null;
            }

            if (worker.ChangePersonalData)
            {
                modifiedWorker.ChangePersonlData(worker);
            }
            modifiedWorker.Salary = worker.Salary;
            modifiedWorker.WorkerType = worker.WorkerType;

            modifiedWorker.MemberTeamId = worker.MemberTeamId;

            if(worker.ManagerTeamId is not null)
            {
                if(worker.ManagerTeamId != modifiedWorker.MemberTeamId)
                    throw new ArgumentException("Subset constraint was violated, the worker doesn't belong to the team");

                if (modifiedWorker.WorkerType is not WorkerType.Manager)
                    throw new ArgumentException(
                        "Custom constraint violation, Worker of type different from Manager is tried to be set as a manager of a team"
                        );
            }

            modifiedWorker.ManagerTeamId = worker.ManagerTeamId;

            _context.SaveChanges();
            return modifiedWorker;
        }

        public Person CreateCustomer(CustomerDto customer)
        {
            var newCustomer = new Person();
            newCustomer.ChangePersonlData(customer);
            newCustomer.Balance = customer.Balance;
            newCustomer.BonusPoints = customer.BonusPoints;
            newCustomer.PersonTypes = new() { PersonType.Customer };

            _context.Persons.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public Person CreateWorker(WorkerDto worker)
        {
            var newWorker = new Person();
            newWorker.ChangePersonlData(worker);
            newWorker.PersonTypes = new() { PersonType.Worker};
            newWorker.Salary = worker.Salary;
            newWorker.WorkerType = worker.WorkerType;

            newWorker.MemberTeamId = worker.MemberTeamId;

            if (worker.ManagerTeamId is not null)
            {
                if (worker.ManagerTeamId != newWorker.MemberTeamId)
                    throw new ArgumentException("Subset constraint was violated, the worker doesn't belong to the team");

                if (newWorker.WorkerType is not WorkerType.Manager)
                    throw new ArgumentException(
                        "Custom constraint violation, Worker of type different from Manager is tried to be set as a manager of a team"
                        );
            }

            newWorker.ManagerTeamId = worker.ManagerTeamId;

            _context.Persons.Add(newWorker);
            _context.SaveChanges();
            return newWorker;
        }

        // returns true if customer with specified customerId bought an instrument with specidied instrumentId
        // otherwise returns false
        public bool CustomerBoughtInstrumentWithId(int customerId, int instrumentId)
        {
            return _context.Orders.AsNoTracking()
                 .Where(o => o.CustomerId == customerId)
                 .Include(o => o.OrderInstruments)
                     .ThenInclude(oi => oi.InstrumentIdNavigation)
                 .Any(o => o.OrderInstruments.Select(oi => oi.InstrumentId == instrumentId).FirstOrDefault());
        }
    }
}
