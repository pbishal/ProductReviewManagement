﻿using System;
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
                new ProductReview(){ProductId=1, UserId=1, Review="Good", Rating=17, IsLike=true},
                new ProductReview(){ProductId=3, UserId=1, Review="Good", Rating=17, IsLike=false},
                new ProductReview(){ProductId=1, UserId=1, Review="Good", Rating=17, IsLike=true},
                new ProductReview(){ProductId=1, UserId=1, Review="Average", Rating=17, IsLike=true},
                new ProductReview(){ProductId=1, UserId=1, Review="Bad", Rating=17, IsLike=false}
            };
            Console.ReadLine();
        }
        public static void IterateOverProductList(List<ProductReview>list)
        {
            foreach(ProductReview product in list)
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

            foreach(var res in result)
            {
                Console.WriteLine("Productname:" + res);
            }
        }
    }
}
