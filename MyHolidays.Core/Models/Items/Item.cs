using System;

namespace MyHolidays.Core.Models.Items
{
    public class Item : Aggregate
    {
        public string Label { get; private set; }
        public bool Recurring { get; private set; }

        protected override void RegisterAppliers()
        {
            RegisterApplier<NewItemCreated>(this.Apply);
            RegisterApplier<ItemRenamed>(this.Apply);
        }

        private Item(Guid id, string label, bool recurring)
        {
            ApplyChange(new NewItemCreated(id, label, recurring));
        }

        private Item(ItemDto itemDto)
        {
            this.Id = itemDto.Id;
            this.Label = itemDto.Label;
            this.Recurring = itemDto.Recurring;
        }

        public static Item CreateItem(Guid id, string label, bool recurring)
        {
            return new Item(id, label, recurring);
        }

        public void Rename(string newLabel)
        {
            ApplyChange(new ItemRenamed(Id, newLabel));
        }

        public static Item FromEvent(ItemDto itemDto)
        {
            return new Item(itemDto);
        }

        public void MarkAsRecurring()
        {
            ApplyChange(new ItemMarkedAsRecurring(Id));
        }

        private void Apply(NewItemCreated @event)
        {
            Id = @event.Id;
            Label = @event.Label;
            Recurring = @event.Recurring;
        }

        private void Apply(ItemRenamed @event)
        {
            Label = @event.NewLabel;
        }

        private void Apply(ItemMarkedAsRecurring @event)
        {
            Recurring = true;
        }
    }
}
