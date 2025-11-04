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

        private readonly Queue<VRML97Token> _queue = new Queue<VRML97Token>();

        public void ReadKeyword(string keyword) {
            var token = RequireNextToken();
            if (token.Type != VRML97TokenType.Word || token.Text != keyword) {
                throw new InvalidVRMLSyntaxException(keyword + " expected");
            }
        }

        public void ReadOpenBracket() {
            RequireNextToken(VRML97TokenType.OpenBracket);
        }

        public void ReadCloseBracket() {
            RequireNextToken(VRML97TokenType.CloseBracket);
        }


        public void ReadOpenBrace() {
            RequireNextToken(VRML97TokenType.OpenBrace);
        }

        public void ReadCloseBrace() {
            RequireNextToken(VRML97TokenType.CloseBrace);
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

        public string ParseFieldType() {
            return RequireNextToken().Text;
            //TODO: validate fieldtype
        }

        public string ParseFieldId() {
            return ParseId();
        }


        protected string ParseId() {
            return RequireNextToken().Text;
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
            return token == null ? throw new InvalidVRMLSyntaxException() : token.Value;
        }

        public void RequireNextToken(VRML97TokenType type) {
            var token = RequireNextToken();
            if (token.Type != type) {
                throw new InvalidVRMLSyntaxException($"{type} expected");
            }
        }

        public void RequireNextToken(string value) {
            if (RequireNextToken().Text != value) {
                throw new InvalidVRMLSyntaxException($"{value} is expected");
            }
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


        public int LineIndex {
            get { return _tokenizer.LineIndex; }
        }

        public int ColumnIndex {
            get { return _tokenizer.ColumnIndex; }
        }

        public float ReadFloat() {
            var value = RequireNextToken().Text;
            return float.Parse(value, CultureInfo.InvariantCulture);
        }

        public double ReadDouble() {
            var value = RequireNextToken().Text;
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public virtual int ReadInt32() {
            var value = RequireNextToken().Text;
            return int.Parse(value);
        }

        public virtual string ReadString() {
            return RequireNextToken().Text;
        }

        public uint ReadHexaDecimal() {
            var text = RequireNextToken().Text;
            if (text.StartsWith("0x")) {
                return uint.Parse(text.Substring(2), NumberStyles.HexNumber);
            } else {
                return uint.Parse(text);
            }
        }

        public string NodeName { get; set; }

        private readonly Stack<BaseNode> fieldContainers = new Stack<BaseNode>();
        public BaseNode FieldContainer {
            [DebuggerStepThrough]
            get {
                if (fieldContainers.Count > 0) return fieldContainers.Peek();
                return null;
            }
        }

        [DebuggerStepThrough]
        public void PushFieldContainer(BaseNode fieldContainer) {
            fieldContainers.Push(fieldContainer);
        }

        [DebuggerStepThrough]
        public void PopFieldContainer() {
            fieldContainers.Pop();
        }

        private readonly Stack<Field> nodeContainers = new Stack<Field>();
        public Field NodeContainer {
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

        private readonly Dictionary<string, BaseNode> namedNodes = new Dictionary<string, BaseNode>();

        public BaseNode CreateNode(string nodeTypeId, string nodeNameId) {
            var node = _nodeFactory.CreateNode(nodeTypeId, nodeNameId);
            if (!string.IsNullOrEmpty(node.Name)) {
                namedNodes[node.Name] = node;
            }
            return node;
        }

        public Field CreateField(string fieldType) {
            return Field.CreateField(fieldType);
        }


        //todo: name lookup from bottom to top
        public BaseNode FindNode(string nodeNameId) {
            if (namedNodes.ContainsKey(nodeNameId)) {
                return namedNodes[nodeNameId];
            } else {
                return null;
            }
        }

        public void AcceptChild(BaseNode node) {
            _childAcceptor.child = node;
            NodeContainer.AcceptVisitor(_childAcceptor);
        }

        public void RegisterPtototype(ProtoNode proto) {
            _nodeFactory.AddPrototype(proto);
        }

    }
}
