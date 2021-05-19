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
                new ProductReview(){ProductId=1, UserId=1, Review="Good", Rating=20, IsLike=true},
                new ProductReview(){ProductId=3, UserId=1, Review="Good", Rating=1, IsLike=false},
                new ProductReview(){ProductId=4, UserId=1, Review="Good", Rating=17, IsLike=true},
                new ProductReview(){ProductId=1, UserId=1, Review="Average", Rating=17, IsLike=true},
                new ProductReview(){ProductId=9, UserId=1, Review="Bad", Rating=2, IsLike=false}
            };
            //IterateOverProductList(list);
            //RetriveTop3RecordsFromList(list);
            RetriveredsBasedOnRatingAndProductId(list);
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
    }
}
