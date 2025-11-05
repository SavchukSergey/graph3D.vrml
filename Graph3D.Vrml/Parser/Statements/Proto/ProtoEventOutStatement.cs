using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventOutStatement {

        public FieldType FieldType { get; set; }

        public string EventId { get; set; }

        public static ProtoEventOutStatement Parse(ParserContext context) {
            context.ReadKeyword("eventOut");
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ProtoEventOutStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
