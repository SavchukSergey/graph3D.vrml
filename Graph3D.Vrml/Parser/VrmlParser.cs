using System;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    //TODO: Question. VRML97 has a proto. The proto has DEF and USE declarations. We have two instances of this proto. Whether changes to first "DEF" node should affect "USE" of second instance?
    //TODO: Rethrow InvalidFieldExcpetion in VrmlParseException
    public class VrmlParser {

        private readonly Vrml97Tokenizer tokenizer;
        private FieldParser fieldParser;

        public VrmlParser(Vrml97Tokenizer tokenizer) {
            this.tokenizer = tokenizer;
        }

        public void parse(VRMLScene scene) {
            parse(scene.root.children);
        }

        public void parse(MFNode container) {
            ParserContext context = new ParserContext(tokenizer);
            try {
                fieldParser = new FieldParser(context, (subContext) => parseNodeStatement(subContext));

                context.PushNodeContainer(container);

                parseStatements(context);

                context.PopNodeContainer();
            } catch (VrmlParseException exc) {
                throw new InvalidVRMLSyntaxException(exc.Message + " at Line: " + context.LineIndex + " Column: " + context.ColumnIndex);
            }
        }

        protected virtual void parseStatements(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                string nodeTypeName = token.Text;
                switch (token.Text) {
                    case "DEF":
                    case "USE":
                    case "PROTO":
                    case "EXTERNPROTO":
                    case "ROUTE":
                        validToken = true;
                        parseStatement(context);
                        break;
                    default:
                        if (token.Type == VRML97TokenType.Word) {
                            parseStatement(context);
                            validToken = true;
                        } else {
                            validToken = false;
                        }
                        break;
                }
            } while (validToken);
        }

        protected virtual void parseStatement(ParserContext context) {
            VRML97Token token = context.PeekNextToken();
            switch (token.Text) {
                case "DEF":
                case "USE":
                    parseNodeStatement(context);
                    break;
                case "PROTO":
                case "EXTERNPROTO":
                    parseProtoStatement(context);
                    break;
                case "ROUTE":
                    parseRouteStatement(context);
                    break;
                default:
                    if (token.Type == VRML97TokenType.Word) {
                        parseNodeStatement(context);
                    } else {
                        throw new Exception("Unexpected context");
                    }
                    break;
            }
        }

        protected virtual void parseNodeStatement(ParserContext context) {
            VRML97Token token = context.PeekNextToken();
            string nodeNameId = "";
            switch (token.Text) {
                case "DEF":
                    token = context.ReadNextToken();
                    context.NodeName = parseNodeNameId(context);
                    parseNode(context);
                    break;
                case "USE":
                    token = context.ReadNextToken();
                    nodeNameId = parseNodeNameId(context);
                    var node = context.FindNode(nodeNameId);
                    context.AcceptChild(node);
                    break;
                default:
                    parseNode(context);
                    break;
            }
        }

        protected virtual void parseRootNodeStatement(ParserContext context) {
            VRML97Token token = context.PeekNextToken();
            switch (token.Text) {
                case "DEF":
                    token = context.ReadNextToken();
                    context.NodeName = parseNodeNameId(context);
                    parseNode(context);
                    break;
                default:
                    parseNode(context);
                    break;
            }
        }

        protected virtual void parseProtoStatement(ParserContext context) {
            VRML97Token keyword = context.PeekNextToken();
            switch (keyword.Text) {
                case "PROTO":
                    parseProto(context);
                    break;
                case "EXTERNPROTO":
                    parseExternProto(context);
                    break;
            }
        }

        public virtual void parseProtoStatements(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                switch (token.Text) {
                    case "PROTO":
                    case "EXTERNPROTO":
                        parseProtoStatement(context);
                        validToken = true;
                        break;
                    default:
                        validToken = false;
                        break;
                }
            } while (validToken);
        }

        protected virtual void parseProto(ParserContext context) {
            VRML97Token keyword = context.ReadNextToken();
            CustomNode proto = new CustomNode();
            proto.name = parseNodeNameId(context);
            context.PushNodeContainer(proto.children);
            context.PushFieldContainer(proto);
            if (context.ReadNextToken().Type != VRML97TokenType.OpenBracket) {
                throw new InvalidVRMLSyntaxException();
            }
            parseInterfaceDeclarations(context);
            if (context.ReadNextToken().Type != VRML97TokenType.CloseBracket) {
                throw new InvalidVRMLSyntaxException();
            }
            if (context.ReadNextToken().Type != VRML97TokenType.OpenBrace) {
                throw new InvalidVRMLSyntaxException();
            }
            parseProtoBody(context);
            if (context.ReadNextToken().Type != VRML97TokenType.CloseBrace) {
                throw new InvalidVRMLSyntaxException();
            }
            context.PopFieldContainer();
            context.PopNodeContainer();
            context.RegisterPtototype(proto);
        }

        protected virtual void parseProtoBody(ParserContext context) {
            parseProtoStatements(context);
            parseRootNodeStatement(context);
            parseStatements(context);
        }

        protected virtual void parseInterfaceDeclarations(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                switch (token.Text) {
                    case "exposedField":
                    case "eventIn":
                    case "eventOut":
                    case "field":
                        parseInterfaceDeclaration(context);
                        validToken = true;
                        break;
                    default:
                        validToken = false;
                        break;
                }
            } while (validToken);
        }

        protected virtual void parseRestrictedInterfaceDeclaration(ParserContext context) {
            CustomNode node = context.FieldContainer as CustomNode;
            if (node == null) throw new Exception("Unexpected context");
            string accessType = context.ReadNextToken().Text;
            string fieldType;
            switch (accessType) {
                case "eventIn":
                    fieldType = parseFieldType(context);
                    string eventInId = parseEventInId(context);
                    //TODO: process interface eventIn declaration.
                    break;
                case "eventOut":
                    fieldType = parseFieldType(context);
                    string eventOutId = parseEventOutId(context);
                    //TODO: process interface eventOut declaration.
                    break;
                case "field":
                    fieldType = parseFieldType(context);
                    string fieldId = parseFieldId(context);
                    Field field = context.CreateField(fieldType);
                    node.addField(fieldId, field);
                    field.acceptVisitor(fieldParser);
                    //TODO: process interface field declaration.
                    break;
                default:
                    throw new Exception("Unexpected context");
            }
        }

        protected virtual void parseInterfaceDeclaration(ParserContext context) {
            CustomNode node = context.FieldContainer as CustomNode;
            if (node == null) throw new Exception("Unexpected context");
            VRML97Token keyword = context.PeekNextToken();
            switch (keyword.Text) {
                case "eventIn":
                case "eventOut":
                case "field":
                    parseRestrictedInterfaceDeclaration(context);
                    break;
                case "exposedField":
                    //TODO: process interface field declaration.
                    keyword = context.ReadNextToken();
                    string fieldType = parseFieldType(context);
                    string fieldId = parseFieldId(context);
                    Field field = context.CreateField(fieldType);
                    node.addExposedField(fieldId, field);
                    field.acceptVisitor(fieldParser);
                    break;
            }
        }

        protected virtual void parseExternProto(ParserContext context) {
            VRML97Token keyword = context.ReadNextToken();
            string nodeTypeId = parseNodeTypeId(context);
            if (context.ReadNextToken().Type != VRML97TokenType.OpenBracket) {
                throw new InvalidVRMLSyntaxException();
            }
            parseExternInterfaceDeclarations(context);
            if (context.ReadNextToken().Type != VRML97TokenType.CloseBracket) {
                throw new InvalidVRMLSyntaxException();
            }
            parseURLList(context);
            //TODO: Process extern proto.
        }

        protected virtual void parseExternInterfaceDeclarations(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                switch (token.Text) {
                    case "exposedField":
                    case "eventIn":
                    case "eventOut":
                    case "field":
                        parseExternInterfaceDeclaration(context);
                        validToken = true;
                        break;
                    default:
                        validToken = false;
                        break;
                }
            } while (validToken);
        }

        protected virtual void parseExternInterfaceDeclaration(ParserContext context) {
            string accessType = context.ReadNextToken().Text;
            string fieldType;
            switch (accessType) {
                case "eventIn":
                    fieldType = parseFieldType(context);
                    string eventInId = parseEventInId(context);
                    //TODO: process extern interface eventIn declaration.
                    break;
                case "eventOut":
                    fieldType = parseFieldType(context);
                    string eventOutId = parseEventOutId(context);
                    //TODO: process extern interface eventOut declaration.
                    break;
                case "field":
                    fieldType = parseFieldType(context);
                    string fieldId = parseFieldId(context);
                    //TODO: process extern interface field declaration.
                    break;
                case "exposedField":
                    fieldType = parseFieldType(context);
                    string exposedFieldId = parseFieldId(context);
                    //TODO: process extern interface exposedField declaration.
                    break;
                default:
                    throw new Exception("Unexpected context");
            }
        }

        protected virtual void parseRouteStatement(ParserContext context) {
            VRML97Token keyword = context.ReadNextToken();
            string nodeNameId1 = parseNodeNameId(context);
            if (context.ReadNextToken().Text != ".") {
                throw new InvalidVRMLSyntaxException();
            }
            string eventOut1 = parseEventOutId(context);
            if (context.ReadNextToken().Text != "TO") {
                throw new InvalidVRMLSyntaxException();
            }
            string nodeNameId2 = parseNodeNameId(context);
            if (context.ReadNextToken().Text != ".") {
                throw new InvalidVRMLSyntaxException();
            }
            string eventIn2 = parseEventInId(context);
            //TODO: Process route statement.
        }

        protected virtual void parseURLList(ParserContext context) {
            MFString urls = new MFString();
            urls.acceptVisitor(fieldParser);
            //TODO: Process Urls.
        }

        protected virtual void parseNode(ParserContext context) {
            VRML97Token token = context.PeekNextToken();
            if (token.Type == VRML97TokenType.EOF) return;
            switch (token.Text) {
                case "Script":
                    token = context.ReadNextToken();
                    if (context.ReadNextToken().Type != VRML97TokenType.OpenBrace) {
                        throw new InvalidVRMLSyntaxException();
                    }
                    parseScriptBody(context);
                    if (context.ReadNextToken().Type != VRML97TokenType.CloseBrace) {
                        throw new InvalidVRMLSyntaxException();
                    }
                    break;
                default:
                    string nodeTypeId = parseNodeTypeId(context);
                    var node = context.CreateNode(nodeTypeId, context.NodeName);
                    context.NodeName = null;
                    context.PushFieldContainer(node);
                    if (context.ReadNextToken().Type != VRML97TokenType.OpenBrace) {
                        throw new InvalidVRMLSyntaxException("Open brace expected");
                    }
                    parseNodeBody(context);
                    if (context.ReadNextToken().Type != VRML97TokenType.CloseBrace) {
                        throw new InvalidVRMLSyntaxException();
                    }
                    context.PopFieldContainer();
                    context.AcceptChild(node);
                    break;
            }
        }

        protected virtual void parseNodeBody(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                if (token.Type == VRML97TokenType.Word) {
                    parseNodeBodyElement(context);
                    validToken = true;
                } else {
                    validToken = false;
                }
            } while (validToken);
        }

        protected virtual void parseScriptBody(ParserContext context) {
            bool validToken = false;
            do {
                VRML97Token token = context.PeekNextToken();
                if (token.Type == VRML97TokenType.Word) {
                    parseScriptBodyElement(context);
                    validToken = true;
                } else {
                    validToken = false;
                }
            } while (validToken);
            //TODO: Process script body
        }

        protected virtual void parseScriptBodyElement(ParserContext context) {
            VRML97Token token = context.PeekNextToken();
            VRML97Token tokenIs = null;
            string fieldType;
            switch (token.Text) {
                case "eventIn":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = parseFieldType(context);
                        string eventInId1 = parseEventInId(context);
                        tokenIs = context.ReadNextToken();
                        string eventInId2 = parseEventInId(context);
                        //TODO: process scipt eventIn element
                    } else {
                        parseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                case "eventOut":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = parseFieldType(context);
                        string eventOutId1 = parseEventOutId(context);
                        tokenIs = context.ReadNextToken();
                        string eventOutId2 = parseEventOutId(context);
                        //TODO: process scipt eventOut element
                    } else {
                        parseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                case "field":
                    tokenIs = context.PeekNextToken(3);
                    if (tokenIs.Text == "IS") {
                        token = context.ReadNextToken();
                        fieldType = parseFieldType(context);
                        string fieldId1 = parseFieldId(context);
                        tokenIs = context.ReadNextToken();
                        string fieldId2 = parseFieldId(context);
                        //TODO: process scipt field element
                    } else {
                        parseRestrictedInterfaceDeclaration(context);
                    }
                    break;
                default:
                    if (token.Type == VRML97TokenType.Word) {
                        parseNodeBodyElement(context);
                    } else {
                        throw new Exception("Unexpected context");
                    }
                    break;
            }
        }

        protected virtual void parseNodeBodyElement(ParserContext context) {
            var node = context.FieldContainer as BaseNode;
            if (node == null) {
                throw new Exception("Invalid context");
            }
            var token = context.PeekNextToken();
            switch (token.Text) {
                case "ROUTE":
                    parseRouteStatement(context);
                    break;
                case "PROTO":
                    parseProto(context);
                    break;
            }
            string fieldId = parseFieldId(context);
            token = context.PeekNextToken();
            //TODO: get field type and parse depending on it.
            switch (token.Text) {
                case "IS":
                    token = context.ReadNextToken();
                    string interfaceFieldId = parseFieldId(context);
                    //TODO: Process inteface field linking
                    break;
                default:
                    Field field = node.getExposedField(fieldId);
                    field.acceptVisitor(fieldParser);
                    break;
            }
        }

        protected virtual string parseNodeNameId(ParserContext context) {
            return parseId(context);
        }

        protected virtual string parseNodeTypeId(ParserContext context) {
            return parseId(context);
        }

        protected virtual string parseFieldId(ParserContext context) {
            return parseId(context);
        }

        protected virtual string parseEventInId(ParserContext context) {
            return parseId(context);
        }

        protected virtual string parseEventOutId(ParserContext context) {
            return parseId(context);
        }

        protected virtual string parseId(ParserContext context) {
            return context.ReadNextToken().Text;
        }

        protected virtual string parseFieldType(ParserContext context) {
            return context.ReadNextToken().Text;
            //TODO: validate fieldtype
        }

    }
}
