namespace OloLabs.Promotions.SDK.Responses.Models.Errors
{
    public static class ErrorCode
    {
        /// <summary>
        /// An applied promotion has expired.
        /// </summary>
        public static string ExpiredPromotion = "EXPIRED_PROMOTION";
        /// <summary>
        /// A promotion being voided was not found or is invalid.
        /// </summary>
        public static string InvalidPromotion = "INVALID_PROMOTION";
        /// <summary>
        /// The basket does not contain the required item for an applied promotion.
        /// </summary>
        public static string MissingItem = "MISSING_ITEM";
        /// <summary>
        /// The basket total does not meet the threshold for an applied promotion.
        /// </summary>
        public static string InvalidTotal = "INVALID_TOTAL";
        /// <summary>
        /// The basket does not have the required handoff for an applied promotion.
        /// </summary>
        public static string InvalidHandoff = "INVALID_HANDOFF";
        /// <summary>
        /// The loyalty account ID didn't match an existing loyalty account.
        /// </summary>
        public static string InvalidAccount = "INVALID_ACCOUNT";
        /// <summary>
        /// Reason not listed.
        /// </summary>
        public static string Other = "OTHER";
    }
}