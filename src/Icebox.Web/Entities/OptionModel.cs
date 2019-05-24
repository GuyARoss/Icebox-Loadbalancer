namespace IceBox.Web.Entities
{
    public class OptionModel<T>
    {
        public string Title { get; set; }
        public T Value { get; set; }
    }
}
