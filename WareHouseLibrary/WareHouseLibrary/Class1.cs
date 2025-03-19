using System;
using System.Collections.Generic;
using System.Linq;
using WareHouseLibrary;

namespace WarehouseLibrary
{
    public class WarehouseManager
    {
        private readonly СкладыEntities _context;

        public WarehouseManager()
        {
            _context = new СкладыEntities();
        }

        // Метод 1: Подсчет общего количества товара на всех складах (один товар на всех складах)
        public int CalculateTotalQuantityForProduct(int productID)
        {
            return _context.Склады
                .Where(s => s.IDТовара == productID)
                .Select(s => s.Количество ?? 0)
                .DefaultIfEmpty(0)
                .Sum();
        }

        // Метод 2: Подсчет количества товара на конкретном складе
        public int CalculateQuantityForProductInWarehouse(int productID, int warehouseID)
        {
            return _context.Склады
                .Where(s => s.IDТовара == productID && s.IDСклада == warehouseID)
                .Select(s => s.Количество ?? 0)
                .DefaultIfEmpty(0)
                .Sum();
        }

        // Метод 3: Подсчет суммы стоимости товаров на всех складах
        public decimal CalculateTotalValueForProduct(int productID)
        {
            var product = _context.Товары.FirstOrDefault(p => p.IDТовара == productID);
            if (product == null)
                return 0;

            int totalQuantity = CalculateTotalQuantityForProduct(productID);
            return totalQuantity * product.Цена;
        }

        // Метод 4: Подсчет суммы стоимости товаров на конкретном складе
        public decimal CalculateValueForProductInWarehouse(int productID, int warehouseID)
        {
            var product = _context.Товары.FirstOrDefault(p => p.IDТовара == productID);
            if (product == null)
                return 0;

            int quantity = CalculateQuantityForProductInWarehouse(productID, warehouseID);
            return quantity * product.Цена;
        }

        // Метод 5: Подсчет количества товаров по категориям на всех складах
        public Dictionary<string, int> CalculateQuantityByCategory()
        {
            return _context.Склады
                .Join(_context.Товары,
                    stock => stock.IDТовара,
                    product => product.IDТовара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество ?? 0));
        }

        // Метод 6: Подсчет количества товаров по категориям на конкретном складе
        public Dictionary<string, int> CalculateQuantityByCategoryInWarehouse(int warehouseID)
        {
            return _context.Склады
                .Where(s => s.IDСклада == warehouseID)
                .Join(_context.Товары,
                    stock => stock.IDТовара,
                    product => product.IDТовара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество ?? 0));
        }
    }
}