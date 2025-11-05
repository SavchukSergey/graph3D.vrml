using System.Collections.Generic;

namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternInterfaceDeclarationsStatement {

        private readonly IList<ExternEventInStatement> _eventIns = [];
        private readonly IList<ExternEventOutStatement> _eventOuts = [];
        private readonly IList<ExternFieldStatement> _fields = [];
        private readonly IList<ExternExposedFieldStatement> _exposedFields = [];

        public IList<ExternEventInStatement> EventsIn { get { return _eventIns; } }

        public IList<ExternEventOutStatement> EventsOut { get { return _eventOuts; } }

        public IList<ExternFieldStatement> Fields { get { return _fields; } }

        public IList<ExternExposedFieldStatement> ExposedFields { get { return _exposedFields; } }

        public static ExternInterfaceDeclarationsStatement Parse(ParserContext context) {
            var res = new ExternInterfaceDeclarationsStatement();

            context.ReadOpenBracket();

            do {
                var token = context.PeekNextToken();
                if (token.Value.Type == VRML97TokenType.CloseBracket) {
                    context.ReadCloseBracket();
                    break;
                }
                if (token.Value.SequenceEqual("eventIn")) {
                    var eventIn = ExternEventInStatement.Parse(context);
                    res.EventsIn.Add(eventIn);
                } else if (token.Value.SequenceEqual("eventOut")) {
                    var eventOut = ExternEventOutStatement.Parse(context);
                    res.EventsOut.Add(eventOut);
                } else if (token.Value.SequenceEqual("field")) {
                    var field = ExternFieldStatement.Parse(context);
                    res.Fields.Add(field);
                } else if (token.Value.SequenceEqual("exposedField")) {
                    var exposedField = ExternExposedFieldStatement.Parse(context);
                    res.ExposedFields.Add(exposedField);
                } else {
                    throw new InvalidVRMLSyntaxException($"Unknown statement {token.Value.Text}", context.Position);
                }
            } while (true);

            return res;
        }
    }
}
