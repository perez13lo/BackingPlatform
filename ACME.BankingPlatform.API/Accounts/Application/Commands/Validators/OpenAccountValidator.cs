using ACME.BankingPlatform.API.Accounts.Domain.Repositories;
using ACME.BankingPlatform.API.Shared.Constantes;
using ACME.BankingPlatform.API.Shared.Domain.Model.ValueObjects;

namespace ACME.BankingPlatform.API.Accounts.Application.Commands.Validators;

public class OpenAccountValidator(IAccountRepository accountRepository) {
    public async Task<Notification> Validate(OpenAccount command)
    {
        var notification = new Notification();

        var number = command.Number.Trim();
        if (string.IsNullOrEmpty(number)) notification.AddError(ValidationMessages.Accounts.AccountNumberRequired);

        var overdraftLimit = command.OverdraftLimit;
        if (overdraftLimit is < 0 or > 2500) notification.AddError(ValidationMessages.Accounts.AccountOverdraft);
        
        var clientId = command.ClientId;
        if (clientId <= 0) notification.AddError(ValidationMessages.Accounts.ClientRequired);

        if (notification.HasErrors) return notification;
        
        var client = await accountRepository.FindByNumberAsync(number);
        if (client != null)
            notification.AddError(ValidationMessages.Accounts.NumberTaken);

        return notification;
    }
}
