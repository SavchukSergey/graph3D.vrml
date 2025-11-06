using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class ParserContext {

        private readonly Vrml97Tokenizer _tokenizer;
        private readonly NodeFactory _nodeFactory;
        private readonly ChildAcceptor _childAcceptor;

        [DebuggerStepThrough]
        public ParserContext(Vrml97Tokenizer tokenizer) {
            _tokenizer = tokenizer;
            _nodeFactory = new NodeFactory();
            _childAcceptor = new ChildAcceptor();
        }

        private readonly Queue<VRML97Token> _queue = new();

        public TokenPosition Position => _tokenizer.Position;

        public void ReadKeyword(ReadOnlySpan<char> keyword) {
            var token = RequireNextToken();
            if (token.Type != VRML97TokenType.Word || !token.SequenceEqual(keyword)) {
                throw new InvalidVRMLSyntaxException($"{keyword} is expected", Position);
            }
        }

        public void ReadOpenBracket() {
            ConsumeToken(VRML97TokenType.OpenBracket);
        }

        public void ReadCloseBracket() {
            ConsumeToken(VRML97TokenType.CloseBracket);
        }


        public void ConsumeOpenBrace() {
            ConsumeToken(VRML97TokenType.OpenBrace);
        }

        public bool TryPeekCloseBrace() {
            var token = PeekNextToken();
            return token.HasValue && token.Value.Value.Length == 1 && token.Value.Value.Span[0] == '}';
        }

        public void ConsumeCloseBrace() {
            ConsumeToken(VRML97TokenType.CloseBrace);
        }

        public string ParseEventInId() {
            return ParseId();
        }

        public virtual string ParseEventOutId() {
            return ParseId();
        }

        public string ParseNodeNameId() {
            return ParseId();
        }

        public FieldType ParseFieldType() {
            var token = RequireNextToken();
            var value = token.Value.Span;
            if (value[0] == 'M') {
                if (value.SequenceEqual("MFColor")) {
                    return FieldType.MFColor;
                } else if (value.SequenceEqual("MFFloat")) {
                    return FieldType.MFFloat;
                } else if (value.SequenceEqual("MFInt32")) {
                    return FieldType.MFInt32;
                } else if (value.SequenceEqual("MFNode")) {
                    return FieldType.MFNode;
                } else if (value.SequenceEqual("MFRotation")) {
                    return FieldType.MFRotation;
                } else if (value.SequenceEqual("MFString")) {
                    return FieldType.MFString;
                } else if (value.SequenceEqual("MFTime")) {
                    return FieldType.MFTime;
                } else if (value.SequenceEqual("MFVec2f")) {
                    return FieldType.MFVec2f;
                } else if (value.SequenceEqual("MFVec3f")) {
                    return FieldType.MFVec3f;
                }
            } else if (value[0] == 'S') {
                if (value.SequenceEqual("SFBool")) {
                    return FieldType.SFBool;
                } else if (value.SequenceEqual("SFColor")) {
                    return FieldType.SFColor;
                } else if (value.SequenceEqual("SFFloat")) {
                    return FieldType.SFFloat;
                } else if (value.SequenceEqual("SFInt32")) {
                    return FieldType.SFInt32;
                } else if (value.SequenceEqual("SFNode")) {
                    return FieldType.SFNode;
                } else if (value.SequenceEqual("SFRotation")) {
                    return FieldType.SFRotation;
                } else if (value.SequenceEqual("SFString")) {
                    return FieldType.SFString;
                } else if (value.SequenceEqual("SFTime")) {
                    return FieldType.SFTime;
                } else if (value.SequenceEqual("SFVec2f")) {
                    return FieldType.SFVec2f;
                } else if (value.SequenceEqual("SFVec3f")) {
                    return FieldType.SFVec3f;
                }
            }
            throw new InvalidVRMLSyntaxException($"unknown field type {value}", Position);
        }

        public string ParseFieldId() {
            return ParseId();
        }


        protected string ParseId() {
            return RequireNextToken().Text;
        }

        public bool TryConsumeKeyword(ReadOnlySpan<char> keyword) {
            //todo: optimize
            var token = PeekNextToken();
            if (token.HasValue && token.Value.SequenceEqual(keyword)) {
                RequireNextToken();
                return true;
            }

            return false;
        }

        public void ConsumeKeyword(ReadOnlySpan<char> keyword) {
            if (!TryConsumeKeyword(keyword)) {
                throw new InvalidVRMLSyntaxException($"{keyword} expected", Position);
            }
        }

        public bool IsEOF {
            get {
                var token = PeekNextToken();
                return token?.Type == VRML97TokenType.EOF;
            }
        }

        public bool TryPeekKeyword(ReadOnlySpan<char> keyword) {
            //todo: optimize
            var token = PeekNextToken();
            if (token.HasValue && token.Value.SequenceEqual(keyword)) {
                return true;
            }

            return false;
        }

        [DebuggerStepThrough]
        public VRML97Token? ReadNextToken() {
            VRML97Token? token;
            if (_queue.Count > 0) {
                token = _queue.Dequeue();
            } else {
                token = _tokenizer.ReadNextToken();
            }
            return token;
        }

        public VRML97Token RequireNextToken() {
            var token = ReadNextToken();
            return token == null ? throw new InvalidVRMLSyntaxException("Token expected", Position) : token.Value;
        }

        public void ConsumeToken(VRML97TokenType type) {
            var token = RequireNextToken();
            if (token.Type != type) {
                throw new InvalidVRMLSyntaxException($"{type} expected", Position);
            }
        }

        public void RequireNextToken(string value) {
            var token = RequireNextToken();
            if (!token.SequenceEqual(value)) {
                throw new InvalidVRMLSyntaxException($"{value} is expected", Position);
            }
        }

        public void RequireNextToken(char value) {
            var token = RequireNextToken();
            if (token.Value.Length != 1 || token.Value.Span[0] != value) {
                throw new InvalidVRMLSyntaxException($"{value} is expected", Position);
            }
        }

        public void SkipWhitespace() {
            
        }

        [DebuggerStepThrough]
        public virtual VRML97Token? PeekNextToken() {
            if (_queue.Count == 0) {
                _queue.Enqueue(_tokenizer.ReadNextToken());
            }
            return _queue.Peek();
        }

        [DebuggerStepThrough]
        public VRML97Token? PeekNextToken(int index) {
            while (_queue.Count < (index + 1)) {
                _queue.Enqueue(_tokenizer.ReadNextToken());
            }
            foreach (var token in _queue) {
                if (index == 0) return token;
                index--;
            }
            return null;
        }

        public float ReadFloat() {
            var token = RequireNextToken();
            return float.Parse(token.Value.Span, CultureInfo.InvariantCulture);
        }

        public double ReadDouble() {
            var token = RequireNextToken();
            return double.Parse(token.Value.Span, CultureInfo.InvariantCulture);
        }

        public int ReadInt32() {
            var token = RequireNextToken();
            return int.Parse(token.Value.Span);
        }

        public string ReadString() {
            return RequireNextToken().Text;
        }

        public uint ReadHexaDecimal() {
            var token = RequireNextToken();
            if (token.StartsWith("0x")) {
                return uint.Parse(token.Value.Span[2..], NumberStyles.HexNumber);
            } else {
                return uint.Parse(token.Value.Span);
            }
        }

        public string? NodeName { get; set; }

        private readonly Stack<Field> nodeContainers = new();

        public Field? NodeContainer {
            [DebuggerStepThrough]
            get {
                if (nodeContainers.Count > 0) return nodeContainers.Peek();
                return null;
            }
        }

        [DebuggerStepThrough]
        public void PushNodeContainer(Field nodeContainer) {
            nodeContainers.Push(nodeContainer);
        }

        [DebuggerStepThrough]
        public void PopNodeContainer() {
            nodeContainers.Pop();
        }

        private readonly Dictionary<string, BaseNode> namedNodes = [];

        public BaseNode CreateNode(string nodeTypeId, string? nodeNameId) {
            var node = _nodeFactory.CreateNode(nodeTypeId, nodeNameId, Position);
            if (!string.IsNullOrEmpty(node.Name)) {
                namedNodes[node.Name] = node;
            }
            return node;
        }

        //todo: name lookup from bottom to top
        public BaseNode? FindNode(string nodeNameId) {
            if (namedNodes.TryGetValue(nodeNameId, out BaseNode? value)) {
                return value;
            } else {
                return null;
            }
        }

        public void AcceptChild(BaseNode node) {
            _childAcceptor.child = node;
            NodeContainer?.AcceptVisitor(_childAcceptor);
        }

        public void RegisterPrototype(ProtoNode proto) {
            _nodeFactory.AddPrototype(proto);
        }

    }
}
