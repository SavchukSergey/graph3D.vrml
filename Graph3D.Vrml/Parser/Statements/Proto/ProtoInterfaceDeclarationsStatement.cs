using System;
using System.Collections.Generic;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoInterfaceDeclarationsStatement {

        private readonly IList<ProtoEventInStatement> _eventIns = new List<ProtoEventInStatement>();
        private readonly IList<ProtoEventOutStatement> _eventOuts = new List<ProtoEventOutStatement>();
        private readonly IList<ProtoFieldStatement> _fields = new List<ProtoFieldStatement>();
        private readonly IList<ProtoExposedFieldStatement> _exposedFields = new List<ProtoExposedFieldStatement>();

        public IList<ProtoEventInStatement> EventsIn { get { return _eventIns; } }

        public IList<ProtoEventOutStatement> EventsOut { get { return _eventOuts; } }

        public IList<ProtoFieldStatement> Fields { get { return _fields; } }

        public IList<ProtoExposedFieldStatement> ExposedFields { get { return _exposedFields; } }

        //todo: remove second argument
        public static ProtoInterfaceDeclarationsStatement Parse(ParserContext context, Action<ParserContext> nodeStatementParser) {
            var res = new ProtoInterfaceDeclarationsStatement();

            context.ReadOpenBracket();

            do {
                var token = context.PeekNextToken();
                if (token.Value.Type == VRML97TokenType.CloseBracket) {
                    context.ReadCloseBracket();
                    break;
                }
                switch (token.Value.Text) {
                    case "eventIn":
                        var eventIn = ProtoEventInStatement.Parse(context);
                        res.EventsIn.Add(eventIn);
                        break;
                    case "eventOut":
                        var eventOut = ProtoEventOutStatement.Parse(context);
                        res.EventsOut.Add(eventOut);
                        break;
                    case "field":
                        var field = ProtoFieldStatement.Parse(context, nodeStatementParser);
                        res.Fields.Add(field);
                        break;
                    case "exposedField":
                        var exposedField = ProtoExposedFieldStatement.Parse(context, nodeStatementParser);
                        res.ExposedFields.Add(exposedField);
                        break;
                    default:
                        throw new InvalidVRMLSyntaxException();
                }
            } while (true);

            return res;
        }
    }
}
