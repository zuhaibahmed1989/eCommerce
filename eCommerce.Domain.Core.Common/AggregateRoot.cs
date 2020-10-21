using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Core.Common
{
    public class AggregateRoot<TKey> : Entity<TKey>
    {
        private List<IDomainEvent> _domainEvents { get; set; }
        private List<IIntegrationEvent> _integrationEvents { get; set; }

        public ICollection<IDomainEvent> DomainEvents => _domainEvents;
        public ICollection<IIntegrationEvent> IntegrationEvents => _integrationEvents;

        protected AggregateRoot()
        {
            _domainEvents = new List<IDomainEvent>();
            _integrationEvents = new List<IIntegrationEvent>();
        }

        public void AddDomainEvent(IDomainEvent @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            _domainEvents.Add(@event);
        }

        public void AddIntegrationEvent(IIntegrationEvent @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            _integrationEvents.Add(@event);
        }
    }
}