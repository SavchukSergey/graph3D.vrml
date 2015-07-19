namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternEventOutStatement {

        public string FieldType { get; set; }

        public string EventId { get; set; }

        public static ExternEventOutStatement Parse(ParserContext context) {
            context.ReadKeyword("eventOut");
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ExternEventOutStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
