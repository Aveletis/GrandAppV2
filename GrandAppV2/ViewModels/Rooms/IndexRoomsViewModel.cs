using GrandAppV2.Models.Data;

namespace GrandAppV2.ViewModels.Rooms
{
    public class IndexRoomsViewModel
    {
        /*public IEnumerable<Room> Rooms { get; set; }*/
        public PageViewModel PageViewModel { get; set; }
        public FilterRoomsViewModel FilterRoomsViewModel { get; set; }
        public SortRoomsViewModel SortRoomsViewModel { get; set; }
    }
}
