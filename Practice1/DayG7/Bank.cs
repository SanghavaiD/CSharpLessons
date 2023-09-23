using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DaySeven
{
    internal class Bank
    {
        //public enum BankName {ICICI,HDFC,SBI };
        public int Id;
        public string CustomerName;
        public string Address;
    }
    internal class Branch
    {
        public readonly int BankId;
        public readonly string BankName;
        public string BranchName = String.Empty;
        public string BranchAddress = String.Empty;
        public string BranchCity = String.Empty;
        public int BranchZipCode;
        
        public Branch(int bankId, int branchId)
        {
            bankId = bankId;
            branchId = branchId;
        }
        public void AddnewCustomerToBranch(Customer customer)
        {
            // Customer foundCustomer = CustomerList
        }
    }

    
    class Customer
    {
        //public readonly CustomerId;

    }

    
}
