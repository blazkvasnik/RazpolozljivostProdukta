using System;
using System.IO;
using log4net;
using log4net.Config;


namespace ProductAvailabilityApp
{
    public class Product
    {
       //Product ima 3 podatke
       //Online date
       //Offline date
       //Approval status

       //Glede na te podatke dobi avaliblitly TRUE or FALSE

       // javen date time ? -> ima lahko vrednost ali NULL
        public DateTime? OnlineDate { get; set; }
        public DateTime? OfflineDate { get; set; }
        public string ApprovalStatus { get; set; }

        public Product(DateTime? onlineDate, DateTime? offlineDate, string approvalStatus)
        {
            OnlineDate = onlineDate;
            OfflineDate = offlineDate;
            ApprovalStatus = approvalStatus;
        }

        public bool IsApproved()
        {
            //if onlineDate != exist || onlineDate <= currentDate == TRUE
            //if (offlineDate != exist) || (offlineDate = exist && offlineDate >= currentDate) == TRUE

            //else FALSE
            bool isApproved = false;
            if (ApprovalStatus == "approved")
            {
                DateTime currentDate = DateTime.Today;
                if(!OnlineDate.HasValue || OnlineDate <= currentDate)
                {
                    if(!OfflineDate.HasValue || OfflineDate.HasValue && OfflineDate >= currentDate)
                    {
                        isApproved = true;
                    }
                }
            }

            return isApproved;
        }

    }
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Product product1 = new Product(new DateTime(2023, 7, 20), new DateTime(2023, 8, 10), "approved");
            Product product2 = new Product(null, new DateTime(2023, 8, 5), "approved");
            Product product3 = new Product(new DateTime(2023, 8, 1), new DateTime(2023, 8, 2), "approved");
            Product product4 = new Product(null, null, "approved");

            Console.WriteLine("Product 1: " + product1.IsApproved());
            Console.WriteLine("Product 2: " + product2.IsApproved());
            Console.WriteLine("Product 3: " + product3.IsApproved());
            Console.WriteLine("Product 4: " + product4.IsApproved());

            //Testni zapis logganja v datoteko.
            log.Info($"Product 1 : {product1.IsApproved()}");

            Console.ReadKey();
        }

    }
    
}
