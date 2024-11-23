using ACME.BankingPlatform.API.Shared.Constantes;
using ACME.BankingPlatform.API.Shared.Domain.Model.ValueObjects;

namespace ACME.BankingPlatform.API.Transactions.Application.Commands.Validators;

public class StartDepositValidator {
    
    public Notification Validate(StartDeposit command)
    {
        var notification = new Notification();

        var transactionId = command.TransactionId;
        if (transactionId <= 0) notification.AddError(ValidationMessages.Transactions.TransactionsMustZero);

        var accountId = command.AccountId;
        if (accountId <= 0) notification.AddError(ValidationMessages.Transactions.AccountMustZero);

        var amount = command.Amount;
        if (amount <= 0) notification.AddError(ValidationMessages.Transactions.AmountMustaZero);

        return notification;
    }
}
