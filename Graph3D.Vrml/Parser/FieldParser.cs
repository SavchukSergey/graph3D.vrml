using System;
using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser {
    public class FieldParser : IFieldVisitor {

        private readonly ParserContext _context;

        private readonly Action<ParserContext> _nodeStatementParser;

        public FieldParser(ParserContext context, Action<ParserContext> nodeStatementParser) {
            _context = context;
            _nodeStatementParser = nodeStatementParser;
        }


        public void Visit(SFBool field) {
            var token = _context.RequireNextToken();
            if (token.SequenceEqual("TRUE")) {
                field.Value = true;
            } else if (token.SequenceEqual("FALSE")) {
                field.Value = false;
            }
        }

        public void Visit(SFInt32 field) {
            field.Value = _context.ReadInt32();
        }

        public void Visit(SFFloat field) {
            field.Value = _context.ReadFloat();
        }

        public void Visit(SFVec2f field) {
            field.X = _context.ReadFloat();
            field.Y = _context.ReadFloat();
        }

        public void Visit(SFVec3f field) {
            field.X = _context.ReadFloat();
            field.Y = _context.ReadFloat();
            field.Z = _context.ReadFloat();
        }


        public void Visit(SFRotation field) {
            field.X = _context.ReadFloat();
            field.Y = _context.ReadFloat();
            field.Z = _context.ReadFloat();
            field.Angle = _context.ReadFloat();
        }

        public void Visit(SFString field) {
            field.Value = _context.ReadString();
        }

        public void Visit(SFColor field) {
            field.Red = _context.ReadFloat();
            field.Green = _context.ReadFloat();
            field.Blue = _context.ReadFloat();
        }


        public void Visit(SFNode field) {
            var token = _context.PeekNextToken();
            if (token.Value.SequenceEqual("NULL")) {
                _context.ReadNextToken();
                field.Node = null;
                return;
            }
            _context.PushNodeContainer(field);
            _nodeStatementParser(_context);
            _context.PopNodeContainer();
        }

        public void Visit(MFNode field) {
            field.ClearValues();
            _context.PushNodeContainer(field);
            ParseMField(_nodeStatementParser);
            _context.PopNodeContainer();
        }

        public void Visit(MFVec2f field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFVec2f();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFVec3f field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFVec3f();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFInt32 field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFInt32();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFFloat field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFFloat();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFColor field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFColor();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFString field) {
            field.ClearValues();
            ParseMField(subcontext => {
                var child = new SFString();
                Visit(child);
                field.AppendValue(child);
            });
        }

        public void Visit(MFRotation field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFRotation();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

        protected virtual void ParseMField(Action<ParserContext> itemParser) {
            var next = _context.PeekNextToken();
            if (next.Value.Type == VRML97TokenType.OpenBracket) {
                next = _context.ReadNextToken();
                while (true) {
                    next = _context.PeekNextToken();
                    if (next.Value.Type == VRML97TokenType.CloseBracket) break;
                    itemParser(_context);
                }
                next = _context.ReadNextToken();
            } else {
                itemParser(_context);
            }
        }

        public void Visit(SFImage field) {
            int width = _context.ReadInt32();
            int height = _context.ReadInt32();
            int components = _context.ReadInt32();
            byte[,,] value = new byte[height, width, components];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    uint pixel = _context.ReadHexaDecimal();
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
            field.Value = value;
        }

        public void Visit(SFTime field) {
            field.Value = _context.ReadDouble();
        }

        public void Visit(MFTime field) {
            field.ClearValues();
            ParseMField((subcontext) => {
                var child = new SFTime();
                this.Visit(child);
                field.AppendValue(child);
            });
        }

    }
}
