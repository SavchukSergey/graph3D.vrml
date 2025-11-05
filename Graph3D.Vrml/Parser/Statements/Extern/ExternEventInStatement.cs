using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternEventInStatement {

        public FieldType FieldType { get; set; }

        public string EventId { get; set; }

        public static ExternEventInStatement Parse(ParserContext context) {
            context.ReadKeyword("eventIn");
            
            var fieldType = context.ParseFieldType();
            var eventId = context.ParseEventInId();
            return new ExternEventInStatement {
                FieldType = fieldType,
                EventId = eventId
            };
        }
    }
}
