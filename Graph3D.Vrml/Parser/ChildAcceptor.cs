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

        public void Visit(SFBool field) {
            throw new NotImplementedException();
        }

        public void Visit(SFImage field) {
            throw new NotImplementedException();
        }

        public void Visit(SFFloat field) {
            throw new NotImplementedException();
        }

        public void Visit(MFFloat field) {
            throw new NotImplementedException();
        }

        public void Visit(SFString field) {
            throw new NotImplementedException();
        }

        public void Visit(MFString field) {
            throw new NotImplementedException();
        }

        public void Visit(SFInt32 field) {
            throw new NotImplementedException();
        }

        public void Visit(MFInt32 field) {
            throw new NotImplementedException();
        }

        public void Visit(SFVec2f field) {
            throw new NotImplementedException();
        }

        public void Visit(MFVec2f field) {
            throw new NotImplementedException();
        }

        public void Visit(SFVec3f field) {
            throw new NotImplementedException();
        }

        public void Visit(MFVec3f field) {
            throw new NotImplementedException();
        }

        public void Visit(SFColor field) {
            throw new NotImplementedException();
        }

        public void Visit(MFColor field) {
            throw new NotImplementedException();
        }

        public void Visit(SFNode field) {
            field.Node = _child;
        }

        public void Visit(MFNode field) {
            field.AppendValue(_child);
        }

        public void Visit(SFRotation field) {
            throw new NotImplementedException();
        }

        public void Visit(MFRotation field) {
            throw new NotImplementedException();
        }

        public void Visit(SFTime field) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
