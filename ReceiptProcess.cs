using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    public class ReceiptProcess
    {
        public void ProcessReceiptData(List<Product> data)
        {
            var domesticProducts = new List<string>();
            var importedProducts = new List<string>();

            foreach (var product in data)
            {
                var groupName = product.Domestic ? "Domestic" : "Imported";
                var name = product.Name.Length > 10 ? product.Name.Substring(0, 10) + "..." : product.Name;
                var price = $"Price: ${product.Price:F2}";
                var weight = product.Weight.HasValue ? $"Weight: {product.Weight}g" : "Weight: N/A";
                var description = product.Description.Length > 10 ? product.Description.Substring(0, 10) + "..." : product.Description;

                var formattedProduct = $"{new string('.', groupName == "Domestic" ? 2 : 3)} {name}\n{new string('.', groupName == "Domestic" ? 3 : 4)} {price}\n {description}\n{new string('.', groupName == "Domestic" ? 3 : 4)} {weight}\n";

                if (groupName == "Domestic")
                {
                    domesticProducts.Add(formattedProduct);
                }
                else
                {
                    importedProducts.Add(formattedProduct);
                }
            }

            domesticProducts.Sort();
            importedProducts.Sort();

            Console.WriteLine("Domestic");
            Console.WriteLine(string.Join("", domesticProducts));
            Console.WriteLine("Imported");
            Console.WriteLine(string.Join("", importedProducts));

            var domesticCost = data
                .Where(p => p.Domestic)
                .Sum(p => p.Price)
                .ToString("F2");

            var importedCost = data
                .Where(p => !p.Domestic)
                .Sum(p => p.Price)
                .ToString("F2");

            var domesticCount = data.Count(p => p.Domestic);
            var importedCount = data.Count(p => !p.Domestic);

            Console.WriteLine($"Domestic cost: ${domesticCost}");
            Console.WriteLine($"Imported cost: ${importedCost}");
            Console.WriteLine($"Domestic count: {domesticCount}");
            Console.WriteLine($"Imported count: {importedCount}");
        }
    }


}


