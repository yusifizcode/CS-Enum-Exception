using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Store
    {
        Product[] _products = new Product[0];
        public Product[] Products { get=>_products; }
        public void AddProduct(Product product)
        {
            Array.Resize(ref _products, _products.Length+1);
            _products[_products.Length-1] = product;
        }
        public Product[] RemoveProductByNo(int no)
        {
            Product[] products = new Product[0];
            for (int i = 0; i < _products.Length; i++)
            {
                if (no!=_products[i].No)
                {
                    Array.Resize(ref products, products.Length+1);
                    products[products.Length-1] = _products[i];
                }
            }
            _products = products;
            return _products;
        }
        public Product[] FilterProductsByType(ProductType type)
        {
            Product[] filteredProducts = new Product[0];
            for (int i = 0; i < _products.Length; i++)
            {
                if (type==_products[i].Type)
                {
                    Array.Resize(ref filteredProducts, filteredProducts.Length + 1);
                    filteredProducts[filteredProducts.Length-1] = _products[i];
                }
            }
            return filteredProducts;
        }
        public Product[] FilterProductByName(string name)
        {
            Product[] filteredProducts = new Product[0];
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].Name.Contains(name))
                {
                    Array.Resize(ref filteredProducts, filteredProducts.Length + 1);
                    filteredProducts[filteredProducts.Length - 1] = _products[i];
                }
            }
            return filteredProducts;
        }
        public void Show()
        {
            foreach (var item in Products)
            {
                Console.WriteLine($"Mehsulun adi: {item.Name} | Mehsulun nomresi: {item.No} | Mehsulun qiymeti: {item.Price} | Mehsulun tipi: {item.Type}");
            }
        }

    }
}
