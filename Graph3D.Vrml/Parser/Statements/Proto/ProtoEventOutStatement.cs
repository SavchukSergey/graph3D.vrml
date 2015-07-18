namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventOutStatement {

        public string FieldType { get; set; }

        public string EventId { get; set; }

        public static ProtoEventOutStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "eventOut") {
                throw new InvalidVRMLSyntaxException("eventOut expected");
            } 
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ProtoEventOutStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
