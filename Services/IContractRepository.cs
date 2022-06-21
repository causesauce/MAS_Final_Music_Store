using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IContractRepository 
    {
        List<Contract> GetAllContracts();
        Contract GetContractById(int id);
        Contract CreateContract(Contract contract);
        Contract UpdateContract(int id, Contract contract);
        bool RemoveContract(int id);

    }
}
