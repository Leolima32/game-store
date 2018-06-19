namespace GameStore.Domain.Exceptions {
    [System.Serializable]
    public class CartItemQuantityCannotBeBelowZeroException : System.Exception
    {
        public CartItemQuantityCannotBeBelowZeroException() { }
        public CartItemQuantityCannotBeBelowZeroException(string message) : base(message) { }
        public CartItemQuantityCannotBeBelowZeroException(string message, System.Exception inner) : base(message, inner) { }
        protected CartItemQuantityCannotBeBelowZeroException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
