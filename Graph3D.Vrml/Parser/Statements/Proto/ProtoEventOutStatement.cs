using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventOutStatement {

        public required FieldType FieldType { get; init; }

        public required string EventId { get; init; }

        public static ProtoEventOutStatement Parse(ParserContext context) {
            context.ConsumeKeyword("eventOut");
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ProtoEventOutStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
