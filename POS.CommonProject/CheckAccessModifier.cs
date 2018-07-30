using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class MyCustomClass
    {

        public int firstNum_Public = 1;
     //   private int secNum_Private = 2;
        protected int thirdNum_Protected = 3;
        internal int fourthNum_Internal = 4;
        protected internal int fivethNum_Protected_Internal = 5;
      //  int sixthNum = 6;
        protected void method() { }
    }
    public class MyCustomClass1
    {

        public void AccessOtherClassMethod1()
        {

            MyCustomClass myCusClass = new MyCustomClass();
            myCusClass.firstNum_Public = 0;
            myCusClass.fivethNum_Protected_Internal = 0;
            myCusClass.fourthNum_Internal = 0;
        }
    }
    public class MyCustomClass2 : MyCustomClass
    {
        public void AccessOtherClassMethod2()
        {

            firstNum_Public = 0;
            fivethNum_Protected_Internal = 0;
            fourthNum_Internal = 0;
            thirdNum_Protected = 0;

            AccessOtherClassMethod2();
            method();
   


        }
    }
}
