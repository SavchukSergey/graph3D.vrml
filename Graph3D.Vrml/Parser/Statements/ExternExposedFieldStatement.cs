namespace Graph3D.Vrml.Parser.Statements {
    public class ExternExposedFieldStatement {

        public string FieldType { get; set; }
        
        public string FieldId { get; set; }

        public static ExternExposedFieldStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "exposedField") {
                throw new InvalidVRMLSyntaxException("exposedField expected");
            }

            var fieldType = context.ParseFieldType();
            var fieldId = context.ParseFieldId();

            return new ExternExposedFieldStatement {
                FieldType = fieldType,
                FieldId = fieldId,
            };
        }
    }
}
