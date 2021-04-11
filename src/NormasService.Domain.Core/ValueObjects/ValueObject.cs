using Flunt.Notifications;
using System.Diagnostics.CodeAnalysis;

namespace NormasService.Domain.Core.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public abstract class ValueObject : Notifiable
    {
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
