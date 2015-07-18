using System;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class FieldParser : IFieldVisitor {

        private readonly ParserContext context;

        private readonly Action<ParserContext> nodeStatementParser;

        public FieldParser(ParserContext context, Action<ParserContext> nodeStatementParser) {
            this.context = context;
            this.nodeStatementParser = nodeStatementParser;
        }


        public void visit(SFBool field) {
            string value = context.ReadNextToken().Text;
            switch (value) {
                case "TRUE":
                    field.value = true;
                    break;
                case "FALSE":
                    field.value = false;
                    break;
            }

        }

        public void visit(SFInt32 field) {
            field.value = context.ReadInt32();
        }

        public void visit(SFFloat field) {
            field.value = context.ReadFloat();
        }

        public void visit(SFVec2f field) {
            field.x = context.ReadFloat();
            field.y = context.ReadFloat();
        }

        public void visit(SFVec3f field) {
            field.x = context.ReadFloat();
            field.y = context.ReadFloat();
            field.z = context.ReadFloat();
        }


        public void visit(SFRotation field) {
            field.x = context.ReadFloat();
            field.y = context.ReadFloat();
            field.z = context.ReadFloat();
            field.angle = context.ReadFloat();
        }

        public void visit(SFString field) {
            field.value = context.ReadString();
        }

        public void visit(SFColor field) {
            field.red = context.ReadFloat();
            field.green = context.ReadFloat();
            field.blue = context.ReadFloat();
        }


        public void visit(SFNode field) {
            VRML97Token token = context.PeekNextToken();
            switch (token.Text) {
                case "NULL":
                    field.node = null;
                    break;
                default:
                    context.PushNodeContainer(field);
                    nodeStatementParser(context);
                    context.PopNodeContainer();
                    break;
            }
        }

        public void visit(MFNode field) {
            field.clearValues();
            context.PushNodeContainer(field);
            ParseMField(nodeStatementParser);
            context.PopNodeContainer();
        }

        public void visit(MFVec2f field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFVec2f();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFVec3f field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFVec3f();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFInt32 field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFInt32();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFFloat field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFFloat();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFColor field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFColor();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFString field) {
            field.clearValues();
            ParseMField(subcontext => {
                var child = new SFString();
                visit(child);
                field.AppendValue(child);
            });
        }

        public void visit(MFRotation field) {
            field.clearValues();
            ParseMField((subcontext) => {
                var child = new SFRotation();
                this.visit(child);
                field.AppendValue(child);
            });
        }

        protected virtual void ParseMField(Action<ParserContext> itemParser) {
            VRML97Token next = context.PeekNextToken();
            if (next.Type == VRML97TokenType.OpenBracket) {
                next = context.ReadNextToken();
                while (true) {
                    next = context.PeekNextToken();
                    if (next.Type == VRML97TokenType.CloseBracket) break;
                    itemParser(context);
                }
                next = context.ReadNextToken();
            } else {
                itemParser(context);
            }
        }



        public void visit(SFImage field) {
            int width = context.ReadInt32();
            int height = context.ReadInt32();
            int components = context.ReadInt32();
            byte[, ,] value = new byte[height, width, components];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    uint pixel = context.ReadHexaDecimal();
                    switch (components) {
                        case 1:
                            value[height - y - 1, x, 0] = (byte)(pixel & 0xff);
                            break;
                        case 2:
                            value[height - y - 1, x, 3] = (byte)(pixel & 0xff);
                            value[height - y - 1, x, 0] = (byte)((pixel >> 8) & 0xff);
                            break;
                        case 3:
                            value[height - y - 1, x, 2] = (byte)(pixel & 0xff);
                            value[height - y - 1, x, 1] = (byte)((pixel >> 8) & 0xff);
                            value[height - y - 1, x, 0] = (byte)((pixel >> 16) & 0xff);
                            break;
                        case 4:
                            value[height - y - 1, x, 3] = (byte)(pixel & 0xff);
                            value[height - y - 1, x, 2] = (byte)((pixel >> 8) & 0xff);
                            value[height - y - 1, x, 1] = (byte)((pixel >> 16) & 0xff);
                            value[height - y - 1, x, 0] = (byte)((pixel >> 24) & 0xff);
                            break;
                    }
                }
            }
            field.value = value;
        }

        public void visit(SFTime field) {
            field.value = context.ReadDouble();
        }

    }
}
