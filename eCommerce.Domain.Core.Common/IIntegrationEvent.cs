using System;

namespace eCommerce.Domain.Core.Common
{
    public interface IIntegrationEvent
    {
        Guid CorrelationId { get; }
    }
}