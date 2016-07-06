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
        private IEnumerable<Product> _prods;

       public ProductController()
        {
            // constructor
            this._prods =  Enumerable.Empty<Product>();
        }

        public ProductController(IEnumerable<Product> product)
        {
            this._prods = product;
        }

        public IEnumerable<int> GetProductByGroupSizeAndGetSumFromEachGroup(int PageSize, String ColumnName)
        {
            // 回傳 example: 3筆一組 取 COST　的總和　會得到 6, 15, 24, 21
            // TODO: 思考如何改成 skip, take, sum 結合 Func.
            List<int> resultCountArray = new List<int>();

            Console.WriteLine("selected Column is : {0}", ColumnName);

            // 用來進行依據 pagesize 分組的 list
            var list = new List<List<Product>>();

            list = this._prods.Select((value, index) => new { Index = index, Value = value })
                  .GroupBy(x => x.Index / PageSize)
                  .Select(g => g.Select(x => x.Value).ToList())
                  .ToList();

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

            IEnumerable<int> enumResultCountArray2 = resultCountArray as IEnumerable<int>;
     
            return enumResultCountArray2;
        }
    }
}