using OloLabs.Promotions.SDK.Requests;
using OloLabs.Promotions.SDK.Requests.Models;
using OloLabs.Promotions.SDK.Requests.Models.Basket;
using OloLabs.Promotions.SDK.Requests.Models.Basket.Discounts;
using OloLabs.Promotions.SDK.Requests.Models.Basket.Items.POS;
using OloLabs.Promotions.SDK.Requests.Models.Payments;

namespace OloLabs.Promotions.SDK.Tests.Requests;

[TestFixture]
public class ValidatePromotionsRequestTests
{
    [Test]
    public void NonRequiredFieldsAreNullable()
    {
        _ = new ValidatePromotionsRequest
        {
            OrderId = null,
            AccountId = null,
            Handoff = null,
            Currency = null,
            Placed = null,
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