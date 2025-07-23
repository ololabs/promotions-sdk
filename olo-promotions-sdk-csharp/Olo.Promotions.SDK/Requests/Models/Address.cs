namespace Olo.Promotions.SDK.Requests.Models
{
    public class Address
    {
        /// <summary>
        /// The street address.
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// The name of the city.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The zip code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// A three-letter <a href="https://www.iso.org/iso-3166-country-codes.html">ISO 3166-1</a> code representing the country.
        /// </summary>
        public string Country { get; set; }
    }
}