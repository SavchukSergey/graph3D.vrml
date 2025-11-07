using System;
using System.Collections.Generic;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoInterfaceDeclarationsStatement {

        private readonly IList<ProtoEventInStatement> _eventIns = [];
        private readonly IList<ProtoEventOutStatement> _eventOuts = [];
        private readonly IList<ProtoFieldStatement> _fields = [];
        private readonly IList<ProtoExposedFieldStatement> _exposedFields = [];

        public IList<ProtoEventInStatement> EventsIn { get { return _eventIns; } }

        public IList<ProtoEventOutStatement> EventsOut { get { return _eventOuts; } }

        public IList<ProtoFieldStatement> Fields { get { return _fields; } }

        public IList<ProtoExposedFieldStatement> ExposedFields { get { return _exposedFields; } }

        //todo: remove second argument
        public static ProtoInterfaceDeclarationsStatement Parse(ParserContext context, Action<ParserContext> nodeStatementParser) {
            var res = new ProtoInterfaceDeclarationsStatement();

            context.ConsumeOpenBracket();

            do {
                if (context.TryPeekCloseBracket()) {
                    context.ConsumeCloseBracket();
                    break;
                }
                if (context.TryPeekKeyword("eventIn")) {
                    var eventIn = ProtoEventInStatement.Parse(context);
                    res.EventsIn.Add(eventIn);
                } else if (context.TryPeekKeyword("eventOut")) {
                    var eventOut = ProtoEventOutStatement.Parse(context);
                    res.EventsOut.Add(eventOut);
                } else if (context.TryPeekKeyword("field")) {
                    var field = ProtoFieldStatement.Parse(context, nodeStatementParser);
                    res.Fields.Add(field);
                } else if (context.TryPeekKeyword("exposedField")) {
                    var exposedField = ProtoExposedFieldStatement.Parse(context, nodeStatementParser);
                    res.ExposedFields.Add(exposedField);
                } else {
                    throw new InvalidVRMLSyntaxException($"Unknown statement", context.Position);
                }
            } while (true);

            return res;
        }
    }
}
