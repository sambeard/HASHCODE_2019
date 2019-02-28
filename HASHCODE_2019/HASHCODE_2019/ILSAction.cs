using System;
namespace HASHCODE_2019
{
    interface ILSAction
    {
        ActionObject Calculate(LocalSearch localSearch);
        void Execute(LocalSearch localSearch);
    }

    public struct ActionObject {
        public bool FAILED;
        public int Diff;
        public ActionObject(int d) {
            FAILED = false;
            Diff = d;
        }

        public static ActionObject FailedObject() {
            var obj = new ActionObject();
            obj.FAILED = true;
            return obj;
        }

    }
}
