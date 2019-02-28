using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHCODE_2019
{
    enum LSActionEnum {
        Add,
        Remove,
        Swap
    }

    class ILSActionChooser
    {
        List<LSActionEnum> Weights;
        Random random;
        public ILSActionChooser() {
            Weights = new List<LSActionEnum>();
            Weights.AddRange(Enumerable.Repeat(LSActionEnum.Add, 0));
            Weights.AddRange(Enumerable.Repeat(LSActionEnum.Remove, 0));
            Weights.AddRange(Enumerable.Repeat(LSActionEnum.Swap, 1));
            random = new Random();

        }
        public ILSAction GetAction() {
            LSActionEnum val= Weights[random.Next(Weights.Count)];
            switch (val)
            {
                case LSActionEnum.Add:
                    throw new NotImplementedException();
                    break;
                case LSActionEnum.Remove:
                    throw new NotImplementedException();
                    break;
                case LSActionEnum.Swap:
                    return new ILSSwapAction();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }


        }
    }
}
