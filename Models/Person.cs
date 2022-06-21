using MAS_Final_Music_Store.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{

    public class Person
    {
        public int PersonId { get; set; }
        [MinLength(2, ErrorMessage = "Person Name cannot be less than 2")]

        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "Person Surname cannot be less than 2")]

        public string Surname { get; set; }
        [MinLength(5, ErrorMessage = "Person Email cannot be less than 5")]

        public string Email { get; set; }
        [MinLength(2, ErrorMessage = "Person PhoneNumber cannot be less than 2")]

        public string PhoneNumber { get; set; }
        [MinLength(2, ErrorMessage = "Person Address cannot be less than 2")]

        public string Address { get; set; }
        private HashSet<PersonType> _personTypes;
        public HashSet<PersonType> PersonTypes 
        {
            get { return _personTypes; } 
            set 
            { 
                if(value.Count < 1)
                {
                    throw new ArgumentException("PersonTypes set cannot have length less than 1");
                }
                _personTypes = value;    
            } 
        }

        public void ChangePersonlData(Person person)
        {
            if (person is null)
            {
                return;
            }
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            PhoneNumber = person.PhoneNumber;
            Address = person.Address;
        }

        public void ChangePersonlData(PersonDto person)
        {
            if (person is null)
            {
                return;
            }
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            PhoneNumber = person.PhoneNumber;
            Address = person.Address;
        }

        public void AddRole(PersonType type, Person person)
        {
            if (PersonTypes.Contains(type))
            {
                throw new ArgumentException("The type is already set!");
            }

            PersonTypes.Add(type);
            if (person is null)
            {
                return;
            }
            if (type is PersonType.Customer)
            {
                Balance = person.Balance;
                BonusPoints = person.BonusPoints;
            }
            else if (type is PersonType.Worker)
            {
                Salary = person.Salary;
                WorkerType = person.WorkerType;
            }
        }

        public void RemoveRole(PersonType type)
        {
            /*if (!PersonTypes.Contains(type))
            {
                return;
            }*/
            if (PersonTypes.Count == 1)
            {
                throw new ArgumentException("A type cannot be removed. Person has to have at least one type");
            }

            PersonTypes.Remove(type);
        }

        private bool IsWorker()
        {
            return PersonTypes.Contains(PersonType.Worker);
        }

        private void ThrowIfNotWorker()
        {
            if (!IsWorker())
            {
                throw new TypeAccessException("You are trying to acccess Worker's fields being not a Worker");
            }
        }

        private void ThrowIfNotManager()
        {
            if (WorkerType is not WorkerType.Manager)
            {
                throw new TypeAccessException("Worker is not for type Manager");
            }
        }

        private bool IsCustomer()
        {
            return PersonTypes.Contains(PersonType.Customer);
        }

        private void ThrowIfNotCustomer()
        {
            if (!IsCustomer())
            {
                throw new TypeAccessException("You are trying to acccess Customer's fields being not a Customer");
            }
        }


        // for Customer only


        [Range(0, double.MaxValue)]
        public double Balance { get; set; }

        [Range(0, double.MaxValue)]
        public double BonusPoints { get; set; }


        public HashSet<Review> Reviews { get; set; } = new();


        public HashSet<Order> Orders { get; set; } = new();


        public bool PayForOrder(Order order)
        {
            //ThrowIfNotCustomer();
            return false;
        }

        // for Worker only
        private double _salary;

        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException("Salary cannot be less than minimal slary");
                }
                _salary = value;
            }
        }

        public static double MinSalary { get; set; } = 2000;

        public WorkerType WorkerType { get; set; }

        public int? MemberTeamId { get; set; }
        public Team MemberTeamIdNavigation { get; set; }

        /* */
        public int? ManagerTeamId { get; set; }

        public Team ManagerTeamIdNavigation { get; set; }
       


    }
}
