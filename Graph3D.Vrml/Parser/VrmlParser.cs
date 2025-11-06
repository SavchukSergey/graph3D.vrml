using System;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Parser.Statements.Proto;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    //TODO: Question. VRML97 has a proto. The proto has DEF and USE declarations. We have two instances of this proto. Whether changes to first "DEF" node should affect "USE" of second instance?
    //TODO: Rethrow InvalidFieldExcpetion in VrmlParseException
    public class VrmlParser {

        private readonly Vrml97Tokenizer _tokenizer;
        private FieldParser _fieldParser;

        public VrmlParser(Vrml97Tokenizer tokenizer) {
            _tokenizer = tokenizer;
        }

        public void Parse(VrmlScene scene) {
            Parse(scene.Root.Children);
        }

        public void Parse(MFNode container) {
            var context = new ParserContext(_tokenizer);
            try {
                _fieldParser = new FieldParser(context, ParseNodeStatement);

                context.PushNodeContainer(container);

                ParseStatements(context);

                context.PopNodeContainer();

            } catch (VrmlParseException exc) {
                throw new InvalidVRMLSyntaxException(exc.Message, exc.Position);
            }
        }

        protected virtual void ParseStatements(ParserContext context) {
            bool validToken;
            do {
                var token = context.PeekNextToken();
                if (token == null) {
                    return;
                }
                if (
                    token.Value.SequenceEqual("DEF") ||
                    token.Value.SequenceEqual("USE") ||
                    token.Value.SequenceEqual("PROTO") ||
                    token.Value.SequenceEqual("EXTERNPROTO") ||
                    token.Value.SequenceEqual("ROUTE")
                ) {
                    validToken = true;
                    ParseStatement(context);
                } else {
                    if (token.Value.Type == VRML97TokenType.Word) {
                        ParseStatement(context);
                        validToken = true;
                    } else {
                        validToken = false;
                    }
                }
            } while (validToken);
        }

        protected virtual void ParseStatement(ParserContext context) {
            var token = context.PeekNextToken();
            if (token.Value.SequenceEqual("DEF") || token.Value.SequenceEqual("USE")) {
                ParseNodeStatement(context);
            } else if (token.Value.SequenceEqual("PROTO") || token.Value.SequenceEqual("EXTERNPROTO")) {
                ParseProtoStatement(context);
            } else if (token.Value.SequenceEqual("ROUTE")) {
                ParseRouteStatement(context); //todo:
            } else {
                if (token.Value.Type == VRML97TokenType.Word) {
                    ParseNodeStatement(context);
                } else {
                    throw new Exception("Unexpected context");
                }
            }
        }

        protected virtual void ParseDefNodeStatement(ParserContext context) {
            context.ReadNextToken();
            context.NodeName = ParseNodeNameId(context);
            ParseNode(context);
        }

        protected virtual void ParseNodeStatement(ParserContext context) {
            var token = context.PeekNextToken();
            if (token.Value.SequenceEqual("DEF")) {
                ParseDefNodeStatement(context);
            } else if (token.Value.SequenceEqual("USE")) {
                var useStatement = UseStatement.Parse(context);
                var node = context.FindNode(useStatement.NodeName);
                context.AcceptChild(node);
            } else {
                ParseNode(context);
            }
        }

        protected virtual void ParseRootNodeStatement(ParserContext context) {
            var token = context.PeekNextToken();
            if (token.Value.SequenceEqual("DEF")) {
                ParseDefNodeStatement(context);
            } else {
                ParseNode(context);
            }
        }

        protected virtual void ParseProtoStatement(ParserContext context) {
            var keyword = context.PeekNextToken();
            if (context.TryPeekKeyword("PROTO")) {
                ParseProto(context);
            } else if (keyword.Value.SequenceEqual("EXTERNPROTO")) {
                ParseExternProto(context);
            } else {
                throw new InvalidVRMLSyntaxException("PROTO or EXTERNPROTO expected", context.Position);
            }
        }

        public virtual void ParseProtoStatements(ParserContext context) {
            var validToken = true;
            do {
                var token = context.PeekNextToken();
                if (token.Value.SequenceEqual("PROTO") || token.Value.SequenceEqual("EXTERNPROTO")) {
                    ParseProtoStatement(context);
                } else {
                    validToken = false;
                }
            } while (validToken);
        }

        protected ProtoNode ParseProto(ParserContext context) {
            context.ConsumeKeyword("PROTO");

            var proto = new ProtoNode {
                Name = ParseNodeNameId(context)
            };
            context.PushNodeContainer(proto.Children);
            ParseInterfaceDeclarations(context, proto);

            context.ConsumeToken(VRML97TokenType.OpenBrace);
            ParseProtoBody(context);
            context.ConsumeToken(VRML97TokenType.CloseBrace);
            context.PopNodeContainer();
            context.RegisterPrototype(proto);

            return proto;
        }

        protected virtual void ParseProtoBody(ParserContext context) {
            ParseProtoStatements(context);
            ParseRootNodeStatement(context);
            ParseStatements(context);
        }

        private void ParseInterfaceDeclarations(ParserContext context, ProtoNode node) {
            var statement = ProtoInterfaceDeclarationsStatement.Parse(context, ParseNodeStatement);
            //todo: process interface declarations

            foreach (var expFld in statement.Fields) {
                var field = expFld.Value;
                node.AddField(expFld.FieldId, field);
            }

            foreach (var expFld in statement.ExposedFields) {
                var field = expFld.Value;
                node.AddExposedField(expFld.FieldId, field);
            }

        }

        private void ParseRestrictedInterfaceDeclaration(ParserContext context, BaseNode container) {
            if (context.TryConsumeKeyword("eventIn")) {
                var fieldInType = ParseFieldType(context);
                var eventInId = ParseEventInId(context);
                //TODO: process interface eventIn declaration.
            } else if (context.TryConsumeKeyword("eventOut")) {
                var fieldOutType = ParseFieldType(context);
                var eventOutId = ParseEventOutId(context);
                //TODO: process interface eventOut declaration.
            } else if (context.TryConsumeKeyword("field")) {
                var fieldType = ParseFieldType(context);
                var fieldId = ParseFieldId(context);
                var field = Field.CreateField(fieldType);
                container.AddField(fieldId, field);
                field.AcceptVisitor(_fieldParser);
                //TODO: process interface field declaration.
            } else {
                throw new InvalidVRMLSyntaxException("Unexpected context", context.Position);
            }
        }

        protected void ParseExternProto(ParserContext context) {
            context.ReadKeyword("EXTERNPROTO");

            var nodeTypeId = ParseNodeTypeId(context);
            ParseExternInterfaceDeclarations(context);
            ParseURLList(context);
            //TODO: Process extern proto.
        }

        protected void ParseExternInterfaceDeclarations(ParserContext context) {
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            //TODO: process extern interface declarations.
        }

        protected static RouteStatement ParseRouteStatement(ParserContext context) {
            return RouteStatement.Parse(context);
        }

        protected void ParseURLList(ParserContext context) {
            var urls = new MFString();
            urls.AcceptVisitor(_fieldParser);
            //TODO: Process Urls.
        }

        protected ScriptNode ParseScriptNode(ParserContext context) {
            var scriptNode = new ScriptNode(); //todo: factory
            context.ConsumeKeyword("Script");
            context.ConsumeOpenBrace();
            ParseScriptBody(context, scriptNode);
            context.ConsumeCloseBrace();
            return scriptNode;
        }

        protected void ParseScriptBody(ParserContext context, BaseNode container) {
            var validToken = true;
            do {
                var token = context.PeekNextToken();
                if (token.Value.Type == VRML97TokenType.Word) {
                    ParseScriptBodyElement(context, container);
                } else {
                    validToken = false;
                }
            } while (validToken);
            //TODO: Process script body
        }

        protected void ParseNode(ParserContext context) {
            if (context.IsEOF) return;
            if (context.TryPeekKeyword("Script")) {
                ParseScriptNode(context); //todo: append it to somewhere
            } else {
                var nodeTypeId = ParseNodeTypeId(context);
                var node = context.CreateNode(nodeTypeId, context.NodeName);
                context.NodeName = null;
                context.ConsumeOpenBrace();
                ParseNodeBody(context, node);
                context.ConsumeCloseBrace();
                context.AcceptChild(node);
            }
        }

        protected virtual void ParseNodeBody(ParserContext context, BaseNode container) {
            do {
                context.SkipWhitespace();
                if (context.TryPeekCloseBrace()) {
                    break;
                }
                ParseNodeBodyElement(context, container);
            } while (true);
        }

        protected virtual void ParseScriptBodyElement(ParserContext context, BaseNode container) {
            var token = context.PeekNextToken();
            VRML97Token? tokenIs = null;
            FieldType fieldType;
            if (token.Value.SequenceEqual("eventIn")) {
                tokenIs = context.PeekNextToken(3);
                if (tokenIs.Value.Text == "IS") {
                    token = context.ReadNextToken();
                    fieldType = ParseFieldType(context);
                    string eventInId1 = ParseEventInId(context);
                    tokenIs = context.ReadNextToken();
                    string eventInId2 = ParseEventInId(context);
                    //TODO: process scipt eventIn element
                } else {
                    ParseRestrictedInterfaceDeclaration(context, container);
                }
            } else if (token.Value.SequenceEqual("eventOut")) {
                tokenIs = context.PeekNextToken(3);
                if (tokenIs.Value.SequenceEqual("IS")) {
                    token = context.ReadNextToken();
                    fieldType = ParseFieldType(context);
                    string eventOutId1 = ParseEventOutId(context);
                    tokenIs = context.ReadNextToken();
                    string eventOutId2 = ParseEventOutId(context);
                    //TODO: process scipt eventOut element
                } else {
                    ParseRestrictedInterfaceDeclaration(context, container);
                }
            } else if (token.Value.SequenceEqual("field")) {
                tokenIs = context.PeekNextToken(3);
                if (tokenIs.Value.Text == "IS") {
                    token = context.ReadNextToken();
                    fieldType = ParseFieldType(context);
                    string fieldId1 = ParseFieldId(context);
                    tokenIs = context.ReadNextToken();
                    string fieldId2 = ParseFieldId(context);
                    //TODO: process scipt field element
                } else {
                    ParseRestrictedInterfaceDeclaration(context, container);
                }
            } else {
                if (token.Value.Type == VRML97TokenType.Word) {
                    ParseNodeBodyElement(context, container);
                } else {
                    throw new Exception("Unexpected context");
                }
            }
        }

        protected virtual void ParseNodeBodyElement(ParserContext context, BaseNode container) {
            var token = context.PeekNextToken();
            if (context.TryPeekKeyword("ROUTE")) {
                container.Routes.Add(ParseRouteStatement(context));
            } else if (token.Value.SequenceEqual("PROTO")) {
                ParseProto(context);
            }
            string fieldId = ParseFieldId(context);
            token = context.PeekNextToken();
            //TODO: get field type and parse depending on it.
            if (token.Value.SequenceEqual("IS")) {
                token = context.ReadNextToken();
                string interfaceFieldId = ParseFieldId(context);
                //TODO: Process inteface field linking
            } else {
                var field = container.GetExposedField<Field>(fieldId);
                field.AcceptVisitor(_fieldParser);

            }
        }

        private static string ParseNodeNameId(ParserContext context) {
            return context.ParseNodeNameId();
        }

        private static string ParseNodeTypeId(ParserContext context) {
            return ParseId(context);
        }

        private static string ParseFieldId(ParserContext context) {
            return context.ParseFieldId();
        }

        protected virtual string ParseEventInId(ParserContext context) {
            return context.ParseEventInId();
        }

        private static string ParseEventOutId(ParserContext context) {
            return context.ParseEventOutId();
        }

        private static string ParseId(ParserContext context) {
            return context.RequireNextToken().Text;
        }

        private static FieldType ParseFieldType(ParserContext context) {
            return context.ParseFieldType();
        }

    }
}
