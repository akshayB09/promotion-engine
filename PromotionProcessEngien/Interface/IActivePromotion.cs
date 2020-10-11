using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionProcessEngien.Interface
{
    interface IActivePromotion
    {
        List<ActivePromotion> GetActivePromotions();
    }
}
