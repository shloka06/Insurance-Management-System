namespace InsuranceManagementSystem.Agent_Classes
{
    public class Policy
    {
        public string PolicyName
        {
            get; set;
        }
        public string PolicyType
        {
            get; set;
        }
        public int InsuredAmount
        {
            get; set;
        }
        public string PaymentSchedule
        {
            get; set;
        }
        public int PaymentAmount
        {
            get; set;
        }
        public int PaymentDuration
        {
            get; set;
        }
        public int CoverDuration
        {
            get; set;
        }
    }
}