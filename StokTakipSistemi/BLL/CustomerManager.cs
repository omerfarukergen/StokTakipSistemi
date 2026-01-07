using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System.Collections.Generic;

namespace StokTakipSistemi.BLL
{
    public class CustomerManager
    {
        private CustomerRepository _repo = new CustomerRepository();

        public List<Customer> GetList() => _repo.GetAll();

        public string Save(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FullName)) return "İsim boş olamaz!";
            _repo.Add(customer);
            return "Müşteri kaydedildi.";
        }

        public void UpdateCustomer(Customer customer)
        {
            _repo.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _repo.Delete(id);
        }
    }
}