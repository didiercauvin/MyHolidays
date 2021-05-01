using System;

namespace MyHolidays.Core.Models.Items
{
    public class Item : Aggregate
    {
        private string _label;
        private bool _recurring;

        private Item(Guid id, string label, bool recurring)
        {
            ApplyChange(new NewItemCreated(id, label, recurring));
        }

        public static Item CreateItem(Guid id, string label, bool recurring)
        {
            return new Item(id, label, recurring);
        }

        public void Rename(string newLabel)
        {
            ApplyChange(new ItemRenamed(Id, newLabel));
        }

        public void MarkAsRecurring()
        {
            ApplyChange(new ItemMarkedAsRecurring(Id));
        }

        protected override void When(IDomainEvent @event)
        {
            switch (@event)
            {
                case NewItemCreated e:
                    Apply(e);
                    break;
                case ItemRenamed e:
                    Apply(e);
                    break;
                case ItemMarkedAsRecurring e:
                    Apply(e);
                    break;
            }
        }

        private void Apply(NewItemCreated @event)
        {
            Id = @event.Id;
            _label = @event.Label;
            _recurring = @event.Recurring;
        }

        private void Apply(ItemRenamed @event)
        {
            _label = @event.NewLabel;
        }

        private void Apply(ItemMarkedAsRecurring @event)
        {
            _recurring = true;
        }
    }
}
