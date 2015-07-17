using System;

namespace Graph3D.Vrml.Fields {
    public abstract class Field : ICloneable {

        protected Field()
            : this(FieldAccessType.ExposedField) {
        }

        protected Field(FieldAccessType accessType) {
            this.accessType = accessType;
        }

        public abstract FieldType getType();

        private readonly FieldAccessType accessType;
        public FieldAccessType getAccessType() {
            return accessType;
        }

        public abstract void acceptVisitor(IFieldVisitor visitor);

        public abstract Field clone();

        #region ICloneable Members

        object ICloneable.Clone() {
            return this.clone();
        }

        #endregion
    }
}
