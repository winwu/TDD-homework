using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationHomework
{
    public class Product
    {
        // auto-implemented properties
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }

    public class ProductController
    {
        private List<Product> _prods;

        public ProductController()
        {
            // constructor
            this._prods = new List<Product>
            {
                new Product() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
        }

        public List<int> GetProdByPageSizeAndColumnSum(int PageSize, String ColumnName)
        {
            // 回傳 example: 3筆一組 取 COST　的總和　會得到 6, 15, 24, 21
            List<int> resultCountArray = new List<int>();
            Console.WriteLine("selected Column is : {0}", ColumnName);

            // default result for each pagesize group
            //  int groupCount = (int)Math.Ceiling( (decimal) (this._prods.Count / (double)PageSize));
            // Console.WriteLine("groupCount is : {0}", groupCount);

            // 用來進行依據 pagesize 分組的 list
            var list = new List<List<Product>>();
            for (int i = 0; i < this._prods.Count; i += PageSize)
            {
                // stackoverflow: split a list into smaller lists of n size
                list.Add(this._prods.GetRange(i, Math.Min(PageSize, this._prods.Count - i)));
            }

            // stackoverflow: iterate multi dimensional array with nested foreach statement.
            foreach (var group in list)
            {
                // 1. 每組總和的初始值, default 0
                int tmpCounter = 0;
                foreach (var p in group)
                {
                    if (p.GetType().GetProperty(ColumnName) != null)
                    {
                        // 2. 相加指定欄位的總和
                        tmpCounter += Convert.ToInt32(p.GetType().GetProperty(ColumnName).GetValue(p));
                    }
                }
                // 3. 並且將這組的總合放到結果的 lists
                resultCountArray.Add(tmpCounter);
            }

            resultCountArray.ForEach(i => Console.Write("{0},\t", i));

            return resultCountArray;
        }
    }
}