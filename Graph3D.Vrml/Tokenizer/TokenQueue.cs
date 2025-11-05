using System;

namespace Graph3D.Vrml.Tokenizer {
    public class TokenQueue {

        public const int Capacity = 16;

        private readonly VRML97Token[] _tokens = new VRML97Token[Capacity];
        private int _head = 0;
        private int _length = 0;

        public int Count => _length;

        public TokenQueue() {
        }

        public void Enqueue(VRML97Token token) {
            if (_length < Capacity) {
                _tokens[(_head + _length) & 0x0f] = token;
                _length++;
            } else {
                throw new Exception();
            }
        }

        public VRML97Token Dequeue() {
            if (_length > 0) {
                var index = _head;
                _head = (_head + 1) & 0x0f;
                _length--;
                return _tokens[index];
            } else {
                throw new Exception();
            }
        }

    }
}