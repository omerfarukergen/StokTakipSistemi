using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;

namespace StokTakipSistemi.BLL
{
    public class ProductManager
    {
        private ProductRepository _productRepo = new ProductRepository();

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public string AddProduct(Product product)
        {
            // İŞ KURALI: Ürün adı boş olamaz
            if (string.IsNullOrEmpty(product.ProductName))
                return "Ürün adı boş olamaz!";

            // İŞ KURALI: Stok 0'dan küçük olamaz
            if (product.StockQuantity < 0)
                return "Stok miktarı negatif olamaz!";

            _productRepo.Add(product);
            return "Başarıyla eklendi.";
        }
        public void DeleteProduct(int id)
        {
            _productRepo.Delete(id);
        }

        public void UpdateProduct(Product product)
        {
            // İŞ KURALI: Fiyat 0'dan küçük olamaz
            if (product.Price > 0)
            {
                _productRepo.Update(product);
            }
        }
    }

}