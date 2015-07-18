namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternEventInStatement {

        public string FieldType { get; set; }

        public string EventId { get; set; }

        public static ExternEventInStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "eventIn") {
                throw new InvalidVRMLSyntaxException("eventIn expected");
            } 
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ExternEventInStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
