using ACME.BankingPlatform.API.Shared.Constantes;
using ACME.BankingPlatform.API.Shared.Domain.Model.ValueObjects;

namespace ACME.BankingPlatform.API.Transactions.Application.Commands.Validators;

public class StartTransferValidator {
    
    public Notification Validate(StartTransfer command)
    {
        var notification = new Notification();

        var transactionId = command.TransactionId;
        if (transactionId <= 0) notification.AddError(ValidationMessages.Transactions.TransactionsMustZero);

        var fromAccountId = command.FromAccountId;
        if (fromAccountId <= 0) notification.AddError(ValidationMessages.Transactions.fromAccountMustZero);
        
        var toAccountId = command.ToAccountId;
        if (toAccountId <= 0) notification.AddError(ValidationMessages.Transactions.toAccountMustZero);

        var amount = command.Amount;
        if (amount <= 0) notification.AddError(ValidationMessages.Transactions.AmountMustaZero);

        return notification;
    }
}
