using System;
using System.Collections.Generic;
using System.Linq;
using PromotionProcessEngien.Interface;

namespace PromotionProcessEngien
{
   public class Order : IOrder
    {
        int totalOfA = 0;
        int totalOfB = 0;
        int totalOfC = 0;
        int totalOfD = 0;
        int promoAcount = 0;
        int promoBcount = 0;
        int promoCDcount = 0;
        decimal promoAprice = 0;
        decimal promoBprice = 0;
        decimal promoCDprice = 0;
        decimal finalAprice = 0;
        decimal finalBprice = 0;
        decimal finalCDprice = 0;
       
        public List<Product> products { get; set; }

        /// <summary>
        /// Get final price after deduction.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public decimal GetFinalPrice(List<Order> orders)
        {
            List<ActivePromotion> activePromotionList = new ActivePromotion().GetActivePromotions();
            promoAcount = activePromotionList.FirstOrDefault(w => w.promoCode == "A").productDetails["A"];
            promoBcount = activePromotionList.FirstOrDefault(w => w.promoCode == "B").productDetails["B"];
            promoCDcount = activePromotionList.FirstOrDefault(w => w.promoCode == "CD").productDetails["CD"];
            promoAprice = activePromotionList.FirstOrDefault(w => w.promoCode == "A").promoPrice;
            promoBprice = activePromotionList.FirstOrDefault(w => w.promoCode == "B").promoPrice;
            promoCDprice= activePromotionList.FirstOrDefault(w => w.promoCode == "CD").promoPrice;

            try
            {
                foreach (var order in orders)
                {
                    order.products.ForEach(f =>
                    {
                        switch (f.Id)
                        {
                            case "A":
                                totalOfA += 1;
                                break;
                            case "B":
                                totalOfB += 1;
                                break;
                            case "C":
                                totalOfC += 1;
                                break;
                            case "D":
                                totalOfD += 1;
                                break;
                        }
                    });
                    var c = order.products.FirstOrDefault(f => f.Id == "D");
                    finalAprice = (totalOfA / promoAcount) * promoAprice + (totalOfA % promoAcount * order.products.FirstOrDefault(f=>f.Id=="A").Price);
                    finalBprice = (totalOfB / promoBcount) * promoBprice + (totalOfB % promoBcount * order.products.FirstOrDefault(f => f.Id == "B").Price);
                    finalCDprice = (totalOfC/ promoCDcount + totalOfD/ promoCDcount) * promoCDprice +((totalOfC) % promoCDcount * order.products.FirstOrDefault(f => f.Id == "C").Price) +
                        ((totalOfD) % 2 * (order.products.FirstOrDefault(f => f.Id == "D")==null?0: order.products.FirstOrDefault(f => f.Id == "D").Price));
                    
                }
                return finalAprice+finalBprice+finalCDprice;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Place porder list.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public List<Order> PlaceOrders(Order[] orders)
        {
            List<Order> orderList = new List<Order>();
            try
            {
                orderList.AddRange(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return orderList;
        }
    }
}
