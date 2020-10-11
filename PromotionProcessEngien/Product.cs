using System;
using System.Collections.Generic;
using System.Text;
using PromotionProcessEngien.Interface;

namespace PromotionProcessEngien
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="product"></param>
        /// 
        public Product(string product)
        {
            this.Id = product;
            try
            {
                this.Price = this.Id switch
                {
                    "A" => 50,
                    "B" => 30,
                    "C" => 20,
                    "D" => 15,
                    _ => 0

                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
