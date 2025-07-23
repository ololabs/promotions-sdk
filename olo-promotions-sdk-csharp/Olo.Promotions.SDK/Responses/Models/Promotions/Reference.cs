using Olo.Promotions.SDK.Responses.Models.Promotions;

namespace Olo.Promotions.SDK.Responses
{
    public class Reference
    {
        /// <summary>
        /// The type of the POS reference.
        /// </summary>
        public ReferenceType Type { get; set; }
        /// <summary>
        /// The value of the POS reference.
        /// </summary>
        public string Code { get; set; }
    }
}