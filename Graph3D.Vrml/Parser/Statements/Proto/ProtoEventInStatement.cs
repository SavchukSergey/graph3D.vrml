namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoEventInStatement {

        public string FieldType { get; set; }

        public string EventId { get; set; }

        public static ProtoEventInStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "eventIn") {
                throw new InvalidVRMLSyntaxException("eventIn expected");
            } 
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ProtoEventInStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
