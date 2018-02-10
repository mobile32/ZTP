using System.Runtime.InteropServices.ComTypes;
using Blog.Bus;

namespace Blog.Command.Events.Post
{
    public abstract class PropertyChangedEvent<T> : IEvent
    {
        public int Id { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        protected PropertyChangedEvent(int id, T oldValue, T newValue)
        {
            Id = id;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class PostCategoryIdChanged : PropertyChangedEvent<int>
    {
        public PostCategoryIdChanged(int id, int oldValue, int newValue) : base(id,oldValue,newValue) {}
    }

    public class PostTitleChanged : PropertyChangedEvent<string>
    {
        public PostTitleChanged(int id, string oldValue, string newValue) : base(id, oldValue, newValue) { }
    }

    public class PostDescriptionChanged : PropertyChangedEvent<string>
    {
        public PostDescriptionChanged(int id, string oldValue, string newValue) : base(id, oldValue, newValue) { }
    }

    public class PostContentChanged : PropertyChangedEvent<string>
    {
        public PostContentChanged(int id, string oldValue, string newValue) : base(id, oldValue, newValue) { }
    }
}
