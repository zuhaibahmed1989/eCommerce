using System;

namespace eCommerce.Domain.Core.Common
{
    public interface IDomainEvent
    {
        Guid CorrelationId { get; }
    }
}