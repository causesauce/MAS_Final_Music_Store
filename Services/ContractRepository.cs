using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class ContractRepository : IContractRepository
    {
        private readonly Context _context;
        public ContractRepository(Context context)
        {
            _context = context;
        }

        public Contract CreateContract(Contract contract)
        {
            var newContract = new Contract
            {
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                Content = contract.Content,
                BrandId = contract.BrandId
            };

            _context.Contracts.Add(newContract);
            _context.SaveChanges();
            return newContract;
        }

        public List<Contract> GetAllContracts()
        {
            return _context.Contracts.ToList();
        }

        public Contract GetContractById(int id)
        {
            return _context.Contracts.Where(c => c.ContractId == id).FirstOrDefault();
        }

        public bool RemoveContract(int id)
        {
            var contract = GetContractById(id);
            if (contract is null)
            {
                return false;
            }

            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return true;

        }

        public Contract UpdateContract(int id, Contract contract)
        {
            var editedContract = GetContractById(id);
            if(editedContract is null)
            {
                return null;
            }

            editedContract.StartDate = contract.StartDate;
            editedContract.EndDate = contract.EndDate;
            editedContract.Content = contract.Content;

            _context.SaveChanges();
            return editedContract;
        }
    }
}
