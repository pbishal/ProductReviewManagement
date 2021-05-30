using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ProductReviewManagement");
            //CreateDataTable();

            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 5, Review = "Excelent", IsLike = true },
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 5, Review = "Excelent", IsLike = true },
                new ProductReview() { ProductId = 2, UserId = 2, Rating = 4, Review = "Good",     IsLike = false },
                new ProductReview() { ProductId = 4, UserId = 3, Rating = 4, Review = "Good",     IsLike = true },
                new ProductReview() { ProductId = 3, UserId = 3, Rating = 3, Review = "Average",  IsLike = false },
                new ProductReview() { ProductId = 3, UserId = 4, Rating = 5, Review = "Excelent", IsLike = true },
                new ProductReview() { ProductId = 4, UserId = 5, Rating = 3, Review = "Average",  IsLike = true },
                new ProductReview() { ProductId = 5, UserId = 5, Rating = 2, Review = "Bad",      IsLike = true },
                new ProductReview() { ProductId = 5, UserId = 6, Rating = 2, Review = "Bad",      IsLike = true },
                new ProductReview() { ProductId = 6, UserId = 7, Rating = 1, Review = "Very Bad", IsLike = true },
                new ProductReview() { ProductId = 6, UserId = 7, Rating = 3, Review = "Average",  IsLike = true }
            };
            //IterateOverProductList(list);
            //RetriveTop3RecordsFromList(list);
            //RetriveredsBasedOnRatingAndProductId(list);
            //CountingProductId(list);
            //RetriveProductIDAndReview(list);
            //SkipTopFiveRecords(list);
            //RetrieveProductIDAndReviewUsingLambdaSyntax(list);
            ReviewTable.AddDataIntoDataTable();
            Console.ReadLine();
        }
        public static void IterateOverProductList(List<ProductReview> list)
        {
            foreach (ProductReview product in list)
            {
                Console.WriteLine("ProductId:" + product.ProductId + "\t" + "UserId:" + product.UserId + "\t" +
                    "Review:" + product.Review + "\t" + "Rating:" + product.Rating + "\t" + "IsLike" + product.IsLike + "\t");
            }
        }
        public static void CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId");
            table.Columns.Add("ProductName");

            table.Rows.Add("1", "Laptop");
            table.Rows.Add("2", "Mobile");
            table.Rows.Add("3", "Tab");
            DisplayDatableContent(table);
        }
        public static void DisplayDatableContent(DataTable table)
        {
            var result = from product in table.AsEnumerable() select product.Field<string>("ProductName");

            foreach (var res in result)
            {
                Console.WriteLine("Productname:" + res);
            }
        }

        //UC2
        public static void RetriveTop3RecordsFromList(List<ProductReview> list)
        {
            var result = from product in list orderby product.Rating descending select product;
            var topThreeRecords = result.Take(3);
            foreach (ProductReview product in topThreeRecords)
            {
                Console.WriteLine("ProductId:" + product.ProductId + "\t" + "UserId:" + product.UserId + "\t" +
                    "Review:" + product.Review + "\t" + "Rating:" + product.Rating + "\t" + "IsLike" + product.IsLike + "\t");
            }
        }

        //UC3
        /// <summary>
        /// Method to retrive records whose rating is greter than 3
        /// and the product ID is either 1 or 4 or 9
        /// </summary>
        /// <param name="list"></param>
        public static void RetriveredsBasedOnRatingAndProductId(List<ProductReview>list)
        {
            //Method Syntax For LINQ
            var data = list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9));
            foreach(var element in data)
            {
                Console.WriteLine("ProductId" + element.ProductId + "\t" + "Rating" + element.Rating);
                Console.WriteLine("--------------");
            }
        }
        ///UC4
        ///
        ///Counting each id present in the list
        public static void CountingProductId(List<ProductReview>list)
        {
            //method syntax for linq
            var data = list.GroupBy(p => p.ProductId).Select(x => new { productID = x.Key, count = x.Count() });
            foreach(var element in data)
            {
                Console.WriteLine("ProductId" + element.productID + "\t" + "Count" + element.count);
                Console.WriteLine("--------------");
            }
        }
        ///UC5
        ///
        ///Retrieve only productId and
        ///review from the list for all records.
        public static void RetriveProductIDAndReview(List<ProductReview> ProductsReviewList)
        {
            var p = ProductsReviewList.Select(Product => new { ProductID = Product.ProductId, review = Product.Review });
            foreach(var elements in p)
            {
                Console.WriteLine("ProductId" + elements.ProductID + "\t" + "Review" + elements.review);
            }
        }

        /// UC6 Skip top five records from the list and display other records.
        public static void SkipTopFiveRecords(List<ProductReview> list)
        {
            var recordedData = (from products in list
                                select products).Skip(5);
            Console.WriteLine("\n Skiping the Top five records and Display others ");
            foreach (var productReview in recordedData)
            {
                Console.WriteLine("Product Id :" + productReview.ProductId + "\t" + "User Id :" + productReview.UserId + "\t" + "Rating ;" + productReview.Rating + "\t" + "Review :" + productReview.Review + "\t" + "Is Like :" + productReview.IsLike);
            }
        }

        // UC7 Retrieving reviews and productId using the lambda expression syntax

        public static void RetrieveProductIDAndReviewUsingLambdaSyntax(List<ProductReview> list)
        {
            var recordedData = list.Select(reviews => new { ProductId = reviews.ProductId, Review = reviews.Review });
            Console.WriteLine("\n Retrieving Product and Review from list");
            foreach (var productReview in recordedData)
            {
                Console.WriteLine("Product ID : " + productReview.ProductId + "\t" + "Review : " + productReview.Review);
            }
        }
    }
}
