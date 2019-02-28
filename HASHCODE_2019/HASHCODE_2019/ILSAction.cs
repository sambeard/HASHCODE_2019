using System;
namespace HASHCODE_2019
{
    public interface ILSAction
    {

        int Calculate();
        void GetDelta();
        void Execute();
    }

    public struct ActionObject {
        public bool FAILED;
        public int Diff;
        public ActionObject(int d) {
            FAILED = false;
            Diff = d;
        }

        static ActionObject FailedObject() {
            var obj = new ActionObject();
            obj.FAILED = true;
            return obj;
        }

    }
}
