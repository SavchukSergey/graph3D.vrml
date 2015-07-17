using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class ParserContext {

        private readonly Vrml97Tokenizer tokenizer;
        private readonly NodeFactory nodeFactory;
        private readonly FieldFactory fieldFactory;
        private readonly ChildAcceptor childAcceptor;

        [DebuggerStepThrough]
        public ParserContext(Vrml97Tokenizer tokenizer) {
            this.tokenizer = tokenizer;
            nodeFactory = new NodeFactory();
            fieldFactory = new FieldFactory();
            childAcceptor = new ChildAcceptor();
        }

        private readonly Queue<VRML97Token> queue = new Queue<VRML97Token>();
        [DebuggerStepThrough]
        public VRML97Token ReadNextToken() {
            VRML97Token token = null;
            if (queue.Count > 0) {
                token = queue.Dequeue();
            } else {
                token = tokenizer.ReadNextToken();
            }
            return token;
        }

        [DebuggerStepThrough]
        public virtual VRML97Token PeekNextToken() {
            if (queue.Count == 0) {
                queue.Enqueue(tokenizer.ReadNextToken());
            }
            return queue.Peek();
        }

        [DebuggerStepThrough]
        public VRML97Token PeekNextToken(int index) {
            while (queue.Count < (index + 1)) {
                queue.Enqueue(tokenizer.ReadNextToken());
            }
            foreach (var token in queue) {
                if (index == 0) return token;
                index--;
            }
            return null;
        }


        public int LineIndex {
            get { return tokenizer.LineIndex; }
        }

        public int ColumnIndex {
            get { return tokenizer.ColumnIndex; }
        }

        public float ReadFloat() {
            string value = ReadNextToken().Text;
            return float.Parse(value, CultureInfo.InvariantCulture);
        }

        public double ReadDouble() {
            string value = ReadNextToken().Text;
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public virtual int ReadInt32() {
            string value = ReadNextToken().Text;
            return int.Parse(value);
        }

        public virtual string ReadString() {
            return ReadNextToken().Text;
        }

        public uint ReadHexaDecimal() {
            string text = ReadNextToken().Text;
            if (text.StartsWith("0x")) {
                return uint.Parse(text.Substring(2), NumberStyles.HexNumber);
            } else {
                return uint.Parse(text);
            }
        }

        private string nodeName;
        public string NodeName {
            [DebuggerStepThrough]
            get { return nodeName; }
            [DebuggerStepThrough]
            set { nodeName = value; }
        }

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
            var node = nodeFactory.CreateNode(nodeTypeId, nodeNameId);
            if (!string.IsNullOrEmpty(node.name)) {
                namedNodes[node.name] = node;
            }
            return node;
        }

        public Field CreateField(string fieldType) {
            return fieldFactory.CreateField(fieldType);
        }


        public BaseNode FindNode(string nodeNameId) {
            if (namedNodes.ContainsKey(nodeNameId)) {
                return namedNodes[nodeNameId];
            } else {
                return null;
            }
        }

        public void AcceptChild(BaseNode node) {
            childAcceptor.child = node;
            NodeContainer.acceptVisitor(childAcceptor);
        }

        public void RegisterPtototype(CustomNode proto) {
            nodeFactory.AddPrototype(proto);
        }

    }
}
