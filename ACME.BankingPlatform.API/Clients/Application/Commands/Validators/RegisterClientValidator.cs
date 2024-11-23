using ACME.BankingPlatform.API.Shared.Constantes;
using ACME.BankingPlatform.API.Clients.Domain.Repositories;
using ACME.BankingPlatform.API.Shared.Domain.Model.ValueObjects;

namespace ACME.BankingPlatform.API.Clients.Application.Commands.Validators;

public class RegisterClientValidator(IClientRepository clientRepository) {
    
    private const int DniMaxLength = 8;
    
    public async Task<Notification> Validate(RegisterClient command)
    {
        var notification = new Notification();

        var firstName = command.FirstName.Trim();
        if (string.IsNullOrEmpty(firstName)) notification.AddError(ValidationMessages.Clients.FirstNameRequired);

        var lastName = command.LastName.Trim();
        if (string.IsNullOrEmpty(lastName)) notification.AddError(ValidationMessages.Clients.LastNameRequired);
        
        var dni = command.Dni.Trim();
        if (string.IsNullOrEmpty(dni)) notification.AddError(ValidationMessages.Clients.DniRequired);

        if (dni.Length != DniMaxLength) notification.AddError(string.Format(ValidationMessages.Clients.DniLength, DniMaxLength));

        if (notification.HasErrors)
        {
            return notification;
        }
        
        var client = await clientRepository.FindByDniAsync(dni);
        if (client != null)
        {
            notification.AddError(ValidationMessages.Clients.DniTaken);
        }

        return notification;
    }
}
