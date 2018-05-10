using Microsoft.Azure.Mobile.Server;

namespace AltoLapizService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}