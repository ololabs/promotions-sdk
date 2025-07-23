using Olo.Promotions.SDK.Requests;
using Olo.Promotions.SDK.Requests.Models;
using Olo.Promotions.SDK.Requests.Models.Basket;
using Olo.Promotions.SDK.Requests.Models.Basket.Discounts;
using Olo.Promotions.SDK.Requests.Models.Basket.Items.POS;
using Olo.Promotions.SDK.Requests.Models.Payments;

namespace Olo.Promotions.SDK.Tests.Requests;

[TestFixture]
public class RedeemPromotionsRequestTests
{
    [Test]
    public void NonRequiredFieldsAreNullable()
    {
        _ = new RedeemPromotionsRequest
        {
            AccountId = null,
            Handoff = null,
            Currency = null,
            Wanted = null,
            Tax = null,
            Tip = null,
            Delivery = null,
            CustomFees = null,
            Discount = null,
            Address = new Address
            {
                Street = null,
                City = null,
                Code = null,
                Country = null,
            },
            Payments = new List<Payment>
            {
                new Payment
                {
                    Tender = null,
                    Issuer = null,
                    Suffix = null,
                    Amount = null
                }
            },
            Basket = new Basket
            {
                Rewards = new List<Reward>
                {
                    new Reward
                    {
                        Product = null,
                        Discount = null,
                        Type = null,
                        ImageUrl = null,
                        CustomFields = null
                    }
                },
                Coupons = new List<Coupon>
                {
                    new Coupon
                    {
                        Product = null,
                        Discount = null
                    }
                },
                PosEntries = new List<PosEntry>
                {
                    new PosEntry
                    {
                        PosItem = new PosItem
                        {
                            Categories = null,
                            Modifiers = new List<Modifier>
                            {
                                new Modifier
                                {
                                    Categories = null,
                                    Modifiers = null
                                }
                            }
                        }
                    }
                }
            }
        };

        Assert.Pass();
    }
}