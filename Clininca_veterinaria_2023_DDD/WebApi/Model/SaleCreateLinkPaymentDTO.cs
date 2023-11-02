namespace WebApi.Model
{
    public class SaleCreateLinkPaymentDTO
    { 
        public string BillingType { get; set; }
        public string ChargeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public int DueDateLimitDays { get; set; }
        public string SubscriptionCycle { get; set; }
        public int MaxInstallmentCount { get; set; }
        public bool NotificationEnabled { get; set; }

        public CallbackData Callback { get; set; }

        public class CallbackData
        {
            public string SuccessUrl { get; set; }
            public bool AutoRedirect { get; set; }
        }
    }
}
