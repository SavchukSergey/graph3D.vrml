namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventOutStatement {

        public string FieldType { get; set; }

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
