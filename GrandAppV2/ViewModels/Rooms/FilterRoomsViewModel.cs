using GrandAppV2.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrandAppV2.ViewModels.Rooms
{
    public class FilterRoomsViewModel
    {
        public string SelectedCode { get; private set; }    // введенный код
        public string SelectedName { get; private set; }    // введенное имя

        public SelectList RoomCategories { get; private set; } // список форм обучения
        public short? Category { get; private set; }   // выбранная форма обучения



        public FilterRoomsViewModel(string code, string name,
            List<RoomCategory> roomCategories, short? category)
        {
            SelectedCode = code;
            SelectedName = name;

            // устанавливаем начальный элемент, который позволит выбрать всех
            roomCategories.Insert(0, new RoomCategory { Category = "", ID = 0 });

            RoomCategories = new SelectList(roomCategories, "ID", "Category", category);
            Category = category;
        }
    }
}
