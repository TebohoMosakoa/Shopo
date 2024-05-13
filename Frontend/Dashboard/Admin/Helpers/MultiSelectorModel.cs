namespace Admin.Helpers
{
    public class MultiSelectorModel
    {
        public MultiSelectorModel(string key, string value) 
        {
            Key = key;
            Value = value;
        }
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
