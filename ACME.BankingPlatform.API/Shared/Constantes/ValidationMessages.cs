namespace ACME.BankingPlatform.API.Shared.Constantes
{
    public static class ValidationMessages
    {
        public static class Clients
        {
            public const string FirstNameRequired = "Client firstname is required";
            public const string LastNameRequired = "Client lastname is required";
            public const string DniRequired = "Client dni is required";
            public const string DniLength = "Client dni must be {0} characters";
            public const string DniTaken = "Client dni is taken";
        }

        public static class Accounts
        {
            public const string AmountMustZero = "The amount must be greater than zero";
            public const string AccountNumberRequired = "Account number is required";
            public const string AccountOverdraft = "Account overdraft Limit must be between 0 and 2500";
            public const string ClientRequired = "Account clientId is required";
            public const string NumberTaken = "Account number is taken";
        }

        public static class Transactions
        {
            public const string TransactionsMustZero = "TransactionId must be greater than zero";
            public const string AccountMustZero  = "AccountId must be greater than zero";
            public const string AmountMustaZero = "Amount must be greater than zero";
            public const string fromAccountMustZero = "from AccountId must be greater than zero";
            public const string toAccountMustZero = "to AccountId must be greater than zero";
        }

    }
}
