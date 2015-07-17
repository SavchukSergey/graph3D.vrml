using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser {
    public class FieldFactory {

        public FieldFactory() {
        }

        public Field CreateField(string fieldTypeId) {
            switch (fieldTypeId) {
                case "SFColor":
                    return new SFColor();
                case "SFFloat":
                    return new SFFloat();
                default:
                    throw new InvalidVRMLSyntaxException("Unknown fieldTypeID: '" + fieldTypeId + "'");
            }
        }

    }
}
