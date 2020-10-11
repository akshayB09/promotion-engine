using System;
using System.Collections.Generic;
using PromotionProcessEngien;
using Xunit;

namespace PromotionProcessEngienTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Order placeorder = new Order();
            Order order1 = new Order()
            {
                products = new List<Product>() { new Product("A"), new Product("B"),
            new Product("C")}
            };
            var orderList = placeorder.PlaceOrders(new Order[] { order1 });
            Assert.Equal(100,
                            placeorder.GetFinalPrice(orderList)); ;
        }

        [Fact]
        public void Test2()
        {
            Order placeorder = new Order();
            Order order1 = new Order()
            {
                products = new List<Product>() { new Product("A"),new Product("A"),new Product("A"),new Product("A"),new Product("A") ,new Product("B"),
                new Product("B"),new Product("B"),new Product("B"),new Product("B"),new Product("C")}
            };
            var orderList = placeorder.PlaceOrders(new Order[] { order1 });
            Assert.Equal(370,
                            placeorder.GetFinalPrice(orderList)); ;
        }

        [Fact]
        public void Test3()
        {
            Order placeorder = new Order();
            Order order1 = new Order()
            {
                products = new List<Product>() { new Product("A"),new Product("A"),new Product("A"), new Product("B"),new Product("B"),new Product("B"),new Product("B"),new Product("B"),
            new Product("C"),new Product("D")}
            };
            var orderList = placeorder.PlaceOrders(new Order[] { order1 });
            Assert.Equal(280,
                            placeorder.GetFinalPrice(orderList)); ;
        }
    }
}
