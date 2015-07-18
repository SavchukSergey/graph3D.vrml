using System;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml.Parser {
    public class ChildAcceptor : IFieldVisitor {

        private BaseNode _child;
        public BaseNode child {
            get { return _child; }
            set { _child = value; }
        }
        
        #region IFieldVisitor Members

        public void visit(SFBool field) {
            throw new NotImplementedException();
        }

        public void visit(SFImage field) {
            throw new NotImplementedException();
        }

        public void visit(SFFloat field) {
            throw new NotImplementedException();
        }

        public void visit(MFFloat field) {
            throw new NotImplementedException();
        }

        public void visit(SFString field) {
            throw new NotImplementedException();
        }

        public void visit(MFString field) {
            throw new NotImplementedException();
        }

        public void visit(SFInt32 field) {
            throw new NotImplementedException();
        }

        public void visit(MFInt32 field) {
            throw new NotImplementedException();
        }

        public void visit(SFVec2f field) {
            throw new NotImplementedException();
        }

        public void visit(MFVec2f field) {
            throw new NotImplementedException();
        }

        public void visit(SFVec3f field) {
            throw new NotImplementedException();
        }

        public void visit(MFVec3f field) {
            throw new NotImplementedException();
        }

        public void visit(SFColor field) {
            throw new NotImplementedException();
        }

        public void visit(MFColor field) {
            throw new NotImplementedException();
        }

        public void visit(SFNode field) {
            field.node = _child;
        }

        public void visit(MFNode field) {
            field.AppendValue(_child);
        }

        public void visit(SFRotation field) {
            throw new NotImplementedException();
        }

        public void visit(MFRotation field) {
            throw new NotImplementedException();
        }

        public void visit(SFTime field) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
