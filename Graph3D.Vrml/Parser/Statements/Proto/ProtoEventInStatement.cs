using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventInStatement {

        public required FieldType FieldType { get; init; }

        public required string EventId { get; init; }

        public static ProtoEventInStatement Parse(ParserContext context) {
           context.ReadKeyword("eventIn");
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ProtoEventInStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
