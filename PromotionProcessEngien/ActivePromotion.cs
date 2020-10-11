using System;
using System.Collections.Generic;
using System.Text;
using PromotionProcessEngien.Interface;

namespace PromotionProcessEngien
{
    class ActivePromotion : IActivePromotion
    {
        public Dictionary<string, int> productDetails { get; set; }
        public decimal promoPrice { get; set; }
        public string promoCode { get; set; }

        Dictionary<String, int> productDetailA = new Dictionary<String, int>();
        Dictionary<String, int> productDetailB = new Dictionary<String, int>();
        Dictionary<String, int> productDetailCD = new Dictionary<String, int>();

        private readonly decimal promotionPriceA =130;
        private readonly decimal promotionPriceB = 45;
        private readonly decimal promotionPriceCD = 30;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ActivePromotion()
        {
            productDetailA.Add("A", 3);
            productDetailB.Add("B", 2);
            productDetailCD.Add("CD", 2);
            
        }
        /// <summary>
        /// Returns active promotions list.
        /// </summary>
        /// <returns></returns>
        public List<ActivePromotion> GetActivePromotions()
        {
            List<ActivePromotion> promotions = new List<ActivePromotion>();
            try
            {
                promotions.Add(new ActivePromotion() { promoCode="A", productDetails = productDetailA, promoPrice = promotionPriceA });
                promotions.Add(new ActivePromotion() { promoCode="B",productDetails = productDetailB, promoPrice = promotionPriceB });
                promotions.Add(new ActivePromotion() { promoCode="CD",productDetails = productDetailCD, promoPrice = promotionPriceCD });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return promotions;
        }
    }
}
