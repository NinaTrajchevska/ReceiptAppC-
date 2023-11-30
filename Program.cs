using ReceiptApp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var receiptService = new ReceiptService();
        var data = await receiptService.GetReceiptData();

        if (data != null)
        {
            var receiptProcessor = new ReceiptProcess();
            receiptProcessor.ProcessReceiptData(data);
        }
        else
        {
            Console.WriteLine("Failed to fetch data.");
        }
    }
}
