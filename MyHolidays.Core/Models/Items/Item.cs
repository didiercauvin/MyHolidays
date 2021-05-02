using System;

namespace MyHolidays.Core.Models.Items
{
    public class Item : Aggregate
    {
        private string _label;
        private bool _recurring;

        protected override void RegisterAppliers()
        {
            RegisterApplier<NewItemCreated>(this.Apply);
            RegisterApplier<ItemRenamed>(this.Apply);
        }

        private Item()
        {

        }

        private Item(Guid id, string label, bool recurring)
        {
            ApplyChange(new NewItemCreated(id, label, recurring));
        }

        private Item(ItemDto itemDto)
        {
            this.Id = itemDto.Id;
            this._label = itemDto.Label;
            this._recurring = itemDto.Recurring;
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
