namespace DSA.DataStructures
{
    public class PairedNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public PairedNode<TKey, TValue>? Next {get; set;}
        


        

        public PairedNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}