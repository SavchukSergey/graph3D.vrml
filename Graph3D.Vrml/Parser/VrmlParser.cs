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
            Parse(scene.root.Children);
        }

        public void Parse(MFNode container) {
            var context = new ParserContext(_tokenizer);
            try {
                _fieldParser = new FieldParser(context, ParseNodeStatement);

                context.PushNodeContainer(container);

                ParseStatements(context);

                context.PopNodeContainer();

            } catch (VrmlParseException exc) {
                throw new InvalidVRMLSyntaxException(exc.Message + " at Line: " + context.LineIndex + " Column: " + context.ColumnIndex);
            }
        }

        protected virtual void ParseStatements(ParserContext context) {
            bool validToken;
            do {
                var token = context.PeekNextToken();
                switch (token.Text) {
                    case "DEF":
                    case "USE":
                    case "PROTO":
                    case "EXTERNPROTO":
                    case "ROUTE":
                        validToken = true;
                        ParseStatement(context);
                        break;
                    default:
                        if (token.Type == VRML97TokenType.Word) {
                            ParseStatement(context);
                            validToken = true;
                        } else {
                            validToken = false;
                        }
                        break;
                }
            } while (validToken);
        }

        protected virtual void ParseStatement(ParserContext context) {
            var token = context.PeekNextToken();
            switch (token.Text) {
                case "DEF":
                case "USE":
                    ParseNodeStatement(context);
                    break;
                case "PROTO":
                case "EXTERNPROTO":
                    ParseProtoStatement(context);
                    break;
                case "ROUTE":
                    ParseRouteStatement(context);
                    break;
                default:
                    if (token.Type == VRML97TokenType.Word) {
                        ParseNodeStatement(context);
                    } else {
                        throw new Exception("Unexpected context");
                    }
                    break;
            }
        }

        protected virtual void ParseDefNodeStatement(ParserContext context) {
            context.ReadNextToken();
            context.NodeName = ParseNodeNameId(context);
            ParseNode(context);
        }

        protected virtual void ParseNodeStatement(ParserContext context) {
            var token = context.PeekNextToken();
            switch (token.Text) {
                case "DEF":
                    ParseDefNodeStatement(context);
                    break;
                case "USE":
                    var useStatement = UseStatement.Parse(context);
                    var node = context.FindNode(useStatement.NodeName);
                    context.AcceptChild(node);
                    break;
                default:
                    ParseNode(context);
                    break;
            }
        }

        protected virtual void ParseRootNodeStatement(ParserContext context) {
            var token = context.PeekNextToken();
            switch (token.Text) {
                case "DEF":
                    ParseDefNodeStatement(context);
                    break;
                default:
                    ParseNode(context);
                    break;
            }
        }

        protected virtual void ParseProtoStatement(ParserContext context) {
            var keyword = context.PeekNextToken();
            switch (keyword.Text) {
                case "PROTO":
                    ParseProto(context);
                    break;
                case "EXTERNPROTO":
                    ParseExternProto(context);
                    break;
                default:
                    //todo: context.throw? with line number?
                    throw new InvalidVRMLSyntaxException("PROTO or EXTERNPROTO expected");
            }
        }

        public virtual void ParseProtoStatements(ParserContext context) {
            var validToken = true;
            do {
                var token = context.PeekNextToken();
                switch (token.Text) {
                    case "PROTO":
                    case "EXTERNPROTO":
                        ParseProtoStatement(context);
                        break;
                    default:
                        validToken = false;
                        break;
                }
            } while (validToken);
        }

        protected virtual void ParseProto(ParserContext context) {
            context.ReadKeyword("PROTO");

            var proto = new ProtoNode {
                name = ParseNodeNameId(context)
            };
            context.PushNodeContainer(proto.Children);
            context.PushFieldContainer(proto);
            ParseInterfaceDeclarations(context);
            if (context.ReadNextToken().Type != VRML97TokenType.OpenBrace) {
                throw new InvalidVRMLSyntaxException();
            }
            ParseProtoBody(context);
            if (context.ReadNextToken().Type != VRML97TokenType.CloseBrace) {
                throw new InvalidVRMLSyntaxException();
            }
            context.PopFieldContainer();
            context.PopNodeContainer();
            context.RegisterPtototype(proto);
        }

        protected virtual void ParseProtoBody(ParserContext context) {
            ParseProtoStatements(context);
            ParseRootNodeStatement(context);
            ParseStatements(context);
        }

        private void ParseInterfaceDeclarations(ParserContext context) {
            var statement = ProtoInterfaceDeclarationsStatement.Parse(context, ParseNodeStatement);
            //todo: process interface declarations

            var node = context.FieldContainer as ProtoNode;
            if (node == null) throw new Exception("Unexpected context");

            foreach (var expFld in statement.Fields) {
                var field = expFld.Value;
                node.AddField(expFld.FieldId, field);
            }

            foreach (var expFld in statement.ExposedFields) {
                var field = expFld.Value;
                node.AddExposedField(expFld.FieldId, field);
            }

        }

        private void ParseRestrictedInterfaceDeclaration(ParserContext context) {
            var node = context.FieldContainer as ProtoNode;
            if (node == null) throw new Exception("Unexpected context");
            var accessType = context.ReadNextToken().Text;
            switch (accessType) {
                case "eventIn":
                    var fieldInType = ParseFieldType(context);
                    var eventInId = ParseEventInId(context);
                    //TODO: process interface eventIn declaration.
                    break;
                case "eventOut":
                    var fieldOutType = ParseFieldType(context);
                    var eventOutId = ParseEventOutId(context);
                    //TODO: process interface eventOut declaration.
                    break;
                case "field":
                    var fieldType = ParseFieldType(context);
                    var fieldId = ParseFieldId(context);
                    var field = context.CreateField(fieldType);
                    node.AddField(fieldId, field);
                    field.AcceptVisitor(_fieldParser);
                    //TODO: process interface field declaration.
                    break;
                default:
                    throw new Exception("Unexpected context");
            }
        }

        protected virtual void ParseExternProto(ParserContext context) {
            context.ReadKeyword("EXTERNPROTO");

            var nodeTypeId = ParseNodeTypeId(context);
            ParseExternInterfaceDeclarations(context);
            ParseURLList(context);
            //TODO: Process extern proto.
        }

        protected virtual void ParseExternInterfaceDeclarations(ParserContext context) {
            var statement = ExternInterfaceDeclarationsStatement.Parse(context);
            //TODO: process extern interface declarations.
        }

        protected virtual void ParseRouteStatement(ParserContext context) {
            var statement = RouteStatement.Parse(context);
            //TODO: Process route statement.
        }

        protected virtual void ParseURLList(ParserContext context) {
            MFString urls = new MFString();
            urls.AcceptVisitor(_fieldParser);
            //TODO: Process Urls.
        }

        protected virtual void ParseScriptNode(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "Script") {
                throw new InvalidVRMLSyntaxException("Script expected");
            }
            context.ReadOpenBrace();
            ParseScriptBody(context);
            context.ReadCloseBrace();
        }

        protected virtual void ParseScriptBody(ParserContext context) {
            var validToken = true;
            do {
                var token = context.PeekNextToken();
                if (token.Type == VRML97TokenType.Word) {
                    ParseScriptBodyElement(context);
                } else {
                    validToken = false;
                }
            } while (validToken);
            //TODO: Process script body
        }

        protected virtual void ParseNode(ParserContext context) {
            var token = context.PeekNextToken();
            if (token.Type == VRML97TokenType.EOF) return;
            switch (token.Text) {
                case "Script":
                    ParseScriptNode(context);
                    break;
                default:
                    var nodeTypeId = ParseNodeTypeId(context);
                    var node = context.CreateNode(nodeTypeId, context.NodeName);
                    context.NodeName = null;
                    context.PushFieldContainer(node);
                    if (context.ReadNextToken().Type != VRML97TokenType.OpenBrace) {
                        throw new InvalidVRMLSyntaxException("Open brace expected");
                    }
                    ParseNodeBody(context);
                    if (context.ReadNextToken().Type != VRML97TokenType.CloseBrace) {
                        throw new InvalidVRMLSyntaxException();
                    }
                    context.PopFieldContainer();
                    context.AcceptChild(node);
                    break;
            }
        }

        protected virtual void ParseNodeBody(ParserContext context) {
            var validToken = true;
            do {
                var token = context.PeekNextToken();
                if (token.Type == VRML97TokenType.Word) {
                    ParseNodeBodyElement(context);
                } else {
                    validToken = false;
                }
            } while (validToken);
        }


        protected virtual void ParseScriptBodyElement(ParserContext context) {
            var token = context.PeekNextToken();
            VRML97Token tokenIs = null;
            string fieldType;
            switch (token.Text) {
                case "eventIn":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = ParseFieldType(context);
                        string eventInId1 = ParseEventInId(context);
                        tokenIs = context.ReadNextToken();
                        string eventInId2 = ParseEventInId(context);
                        //TODO: process scipt eventIn element
                    } else {
                        ParseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                case "eventOut":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = ParseFieldType(context);
                        string eventOutId1 = ParseEventOutId(context);
                        tokenIs = context.ReadNextToken();
                        string eventOutId2 = ParseEventOutId(context);
                        //TODO: process scipt eventOut element
                    } else {
                        ParseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                case "field":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = ParseFieldType(context);
                        string fieldId1 = ParseFieldId(context);
                        tokenIs = context.ReadNextToken();
                        string fieldId2 = ParseFieldId(context);
                        //TODO: process scipt field element
                    } else {
                        ParseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                default:
                    if (token.Type == VRML97TokenType.Word) {
                        ParseNodeBodyElement(context);
                    } else {
                        throw new Exception("Unexpected context");
                    }
                    break;
            }
        }

        protected virtual void ParseNodeBodyElement(ParserContext context) {
            var node = context.FieldContainer;
            if (node == null) {
                throw new Exception("Invalid context");
            }
            var token = context.PeekNextToken();
            switch (token.Text) {
                case "ROUTE":
                    ParseRouteStatement(context);
                    break;
                case "PROTO":
                    ParseProto(context);
                    break;
            }
            string fieldId = ParseFieldId(context);
            token = context.PeekNextToken();
            //TODO: get field type and parse depending on it.
            switch (token.Text) {
                case "IS":
                    token = context.ReadNextToken();
                    string interfaceFieldId = ParseFieldId(context);
                    //TODO: Process inteface field linking
                    break;
                default:
                    var field = node.GetExposedField(fieldId);
                    field.AcceptVisitor(_fieldParser);
                    break;
            }
        }

        private static string ParseNodeNameId(ParserContext context) {
            return context.ParseNodeNameId();
        }

        private string ParseNodeTypeId(ParserContext context) {
            return ParseId(context);
        }

        private string ParseFieldId(ParserContext context) {
            return context.ParseFieldId();
        }

        protected virtual string ParseEventInId(ParserContext context) {
            return context.ParseEventInId();
        }

        private static string ParseEventOutId(ParserContext context) {
            return context.ParseEventOutId();
        }

        private static string ParseId(ParserContext context) {
            return context.ReadNextToken().Text;
        }

        private string ParseFieldType(ParserContext context) {
            return context.ParseFieldType();
        }

    }
}
