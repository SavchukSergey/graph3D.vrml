using System;

namespace Graph3D.Vrml.Tokenizer {

    [Serializable]
    public class TokenizerException : Exception {
    
        public TokenizerException() { }
    
        public TokenizerException(string message) : base(message) { }
        
        public TokenizerException(string message, Exception inner) : base(message, inner) { }
        
        protected TokenizerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
